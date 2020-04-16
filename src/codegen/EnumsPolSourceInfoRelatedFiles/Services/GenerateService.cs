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
        private readonly IConfigurationRoot _configuration;
        private readonly IStatusAndResultsService _statusAndResultsService;
        private readonly IPolSourceGroupingExcelFileRead _polSourceGroupingExcelFileRead;
        #endregion Variables

        #region Properties
        private StringBuilder sbError { get; set; }
        private StringBuilder sbStatus { get; set; }
        private string command { get; set; }
        private StatusAndResults statusAndResults { get; set; }
        #endregion Properties

        #region Constructors
        public GenerateService(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService, IPolSourceGroupingExcelFileRead polSourceGroupingExcelFileRead)
        {
            _configuration = configuration;
            _statusAndResultsService = statusAndResultsService;
            _polSourceGroupingExcelFileRead = polSourceGroupingExcelFileRead;

            command = _configuration.GetValue<string>("Command");

            sbError = new StringBuilder();
            sbStatus = new StringBuilder();
            statusAndResults = new StatusAndResults();
        }
        #endregion Constructors

        #region Functions public
        public async Task Start()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string dbFileNamePartial = _configuration.GetValue<string>("DBFileName");

            FileInfo fiDB = new FileInfo(dbFileNamePartial.Replace("{AppDataPath}", appDataPath));

            sbStatus.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = await _statusAndResultsService.Get(command);

            if (statusAndResults == null)
            {
                statusAndResults = await _statusAndResultsService.Create(command);
                if (statusAndResults == null)
                {
                    return;
                }

                statusAndResults = await _statusAndResultsService.Get(command);

                if (statusAndResults == null)
                {
                    return;
                }
            }

            sbStatus.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking }");
            //await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            FileInfo fiExcel = new FileInfo(_configuration.GetValue<string>("ExcelFileName"));

            if (! await _polSourceGroupingExcelFileRead.ReadExcelSheet(fiExcel.FullName, false, sbError, sbStatus, command, _statusAndResultsService))
            {
                return;
            }

            if (_polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(AppRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                sbError.AppendLine($"{ ErrorText }");
                await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

                return;
            }

            sbStatus.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking } { AppRes.Done } ...");
            //await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            await Generate_FillPolSourceObsInfoChildService();
            await Generate_EnumsPolSourceInfo();
            await Generate_PolSourceObsInfoEnum();
            await Generate_EnumsPolSourceObsInfoEnumTest();
            await Generate_PolSourceInfoEnumGeneratedRes_resx();
            await Generate_PolSourceInfoEnumGeneratedResFR_resx();

            sbStatus.AppendLine($"{ AppRes.Done } ...");

            await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 100);

            Console.WriteLine(sbError.ToString());
            Console.WriteLine(sbStatus.ToString());

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}