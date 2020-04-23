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

            statusAndResults = new StatusAndResults();
        }
        #endregion Constructors

        #region Functions public
        public async Task Start()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string dbFileNamePartial = _configuration.GetValue<string>("DBFileName");

            FileInfo fiDB = new FileInfo(dbFileNamePartial.Replace("{AppDataPath}", appDataPath));

            _statusAndResultsService.Status.AppendLine($"{ AppRes.Starting }...");

            statusAndResults = await _statusAndResultsService.Get();

            if (statusAndResults == null)
            {
                statusAndResults = await _statusAndResultsService.Create();
                if (statusAndResults == null)
                {
                    return;
                }

                statusAndResults = await _statusAndResultsService.Get();

                if (statusAndResults == null)
                {
                    return;
                }
            }

            _statusAndResultsService.Status.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking }");
            //await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            FileInfo fiExcel = new FileInfo(_configuration.GetValue<string>("ExcelFileName"));

            if (! await _polSourceGroupingExcelFileRead.ReadExcelSheet(fiExcel.FullName, false, command, _statusAndResultsService))
            {
                return;
            }

            if (_polSourceGroupingExcelFileRead.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(AppRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                _statusAndResultsService.Error.AppendLine($"{ ErrorText }");
                await _statusAndResultsService.Update(0);

                return;
            }

            _statusAndResultsService.Status.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking } { AppRes.Done } ...");
            //await _statusAndResultsService.Update(command, sbError.ToString(), sbStatus.ToString(), 0);

            await Generate_FillPolSourceObsInfoChildService();
            await Generate_EnumsPolSourceInfo();
            await Generate_PolSourceObsInfoEnum();
            await Generate_EnumsPolSourceObsInfoEnumTest();
            await Generate_PolSourceInfoEnumGeneratedRes_resx();
            await Generate_PolSourceInfoEnumGeneratedResFR_resx();

            _statusAndResultsService.Status.AppendLine($"{ AppRes.Done } ...");

            await _statusAndResultsService.Update(100);

            Console.WriteLine(_statusAndResultsService.Error.ToString());
            Console.WriteLine(_statusAndResultsService.Status.ToString());

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}