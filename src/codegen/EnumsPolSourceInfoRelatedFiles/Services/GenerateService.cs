using CSSPPolSourceGroupingExcelFileRead.Models;
using CSSPPolSourceGroupingExcelFileRead.Services;
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
    public partial class GenerateService : IGenerateService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        public GenerateService()
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task Start(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService, IPolSourceGroupingExcelFileRead polSourceGroupingExcelFileRead)
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

            sbStatus.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking }");
            await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);

            FileInfo fiExcel = new FileInfo(configuration.GetValue<string>("ExcelFileName"));

            if (! await polSourceGroupingExcelFileRead.ReadExcelSheet(fiExcel.FullName, false, sbError, sbStatus, Command, statusAndResultsService))
            {
                return;
            }

            if (polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(AppRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                sbError.AppendLine($"{ ErrorText }");
                await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);

                return;
            }

            sbStatus.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking } { AppRes.Done } ...");
            await statusAndResultsService.Update(Command, sbError.ToString(), sbStatus.ToString(), 0);

            await Generate_FillPolSourceObsInfoChildService(configuration, statusAndResultsService, polSourceGroupingExcelFileRead);
            await Generate_EnumsPolSourceInfo(configuration, statusAndResultsService, polSourceGroupingExcelFileRead);
            await Generate_PolSourceObsInfoEnum(configuration, statusAndResultsService, polSourceGroupingExcelFileRead);
            await Generate_EnumsPolSourceObsInfoEnumTest(configuration, statusAndResultsService, polSourceGroupingExcelFileRead);
            await Generate_PolSourceInfoEnumGeneratedRes_resx(configuration, statusAndResultsService, polSourceGroupingExcelFileRead);
            await Generate_PolSourceInfoEnumGeneratedResFR_resx(configuration, statusAndResultsService, polSourceGroupingExcelFileRead);

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