using EnumsPolSourceInfoRelatedFiles.Resources;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFiles.Services
{
    public class GenerateService : IGenerateService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        public GenerateService()
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task Start(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService)
        {
            string Command = configuration.GetValue<string>("Command");

            StringBuilder sbError = new StringBuilder();
            StringBuilder sbStatus = new StringBuilder();
            StatusAndResults statusAndResults = new StatusAndResults();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string dbFileNamePartial = configuration.GetValue<string>("DBFileName");

            FileInfo fiDB = new FileInfo(dbFileNamePartial.Replace("{AppDataPath}", appDataPath));

            sbStatus.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = await statusAndResultsService.Get(Command);

            if (statusAndResults == null)
            {
                statusAndResults = await statusAndResultsService.Create(Command);
                if (statusAndResults == null)
                {
                    return;
                }

                statusAndResults = await statusAndResultsService.Get(Command);

                if (statusAndResults == null)
                {
                    return;
                }
            }

            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPEnums"));
            FileInfo fiInterface = new FileInfo(configuration.GetValue<string>("IEnumsGenerated"));
            FileInfo fi = new FileInfo(configuration.GetValue<string>("EnumsGenerated"));

            ClearPermanentEvent(new StatusEventArgs(""));
            StatusTempEvent(new StatusEventArgs(""));

            polSourceGroupingExcelFileRead = new PolSourceGroupingExcelFileRead();
            polSourceGroupingExcelFileRead.Status += PolSourceGroupingExcelFileRead_Status;
            polSourceGroupingExcelFileRead.CSSPError += PolSourceGroupingExcelFileRead_CSSPError;

            string ExcelFileName = @"C:\CSSPTools\src\assets\PolSourceGrouping.xlsm";

            if (!CheckFileDirectoriesExist(ExcelFileName))
            {
                return;
            }

            StatusPermanentEvent(new StatusEventArgs(ExcelFileName));
            StatusTempEvent(new StatusEventArgs(ExcelFileName));

            if (!polSourceGroupingExcelFileRead.ReadExcelSheet(ExcelFileName, false))
            {
                return;
            }

            StatusPermanentEvent(new StatusEventArgs("Reading Group Choice Child Level List"));
            StatusTempEvent(new StatusEventArgs("Reading Group Choice Child Level List"));

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count() == 0)
            {
                ClearPermanentEvent(new StatusEventArgs("\r\nCSSPError: groupChoiceChildLevelList is equal to 0"));
                return;
            }

            StatusTempEvent(new StatusEventArgs("Reading Excel Document and Checking done..."));
            StatusPermanentEvent(new StatusEventArgs("Reading Excel Document and Checking done..."));

            Generate_FillPolSourceObsInfoChildService();
            Generate_EnumsPolSourceInfo();
            Generate_PolSourceObsInfoEnum();
            Generate_EnumsPolSourceObsInfoEnumTest();
            Generate_PolSourceInfoEnumGeneratedRes_resx();
            Generate_PolSourceInfoEnumGeneratedResFR_resx();

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));

            sbStatus.AppendLine($"{ AppRes.Created } [{ fi.FullName }] ...");
            sbStatus.AppendLine($"{ AppRes.Done } ...");

            await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 100);

            Console.WriteLine(sbError.ToString());
            Console.WriteLine(sbStatus.ToString());

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}