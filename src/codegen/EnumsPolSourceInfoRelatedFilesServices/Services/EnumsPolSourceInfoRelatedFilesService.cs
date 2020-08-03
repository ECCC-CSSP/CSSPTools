using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CSSPCultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public interface IEnumsPolSourceInfoRelatedFilesService
    {
        Task<bool> Run(string[] args);
    }
    public partial class EnumsPolSourceInfoRelatedFilesService : ConfigService, IEnumsPolSourceInfoRelatedFilesService
    {
        #region Variables
        #endregion Variables

        #region Properties
        IPolSourceGroupingExcelFileReadService PolSourceGroupingExcelFileReadService { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsPolSourceInfoRelatedFilesService(IConfiguration Configuration,
            ICSSPCultureService CSSPCultureService,
            IActionCommandDBService ActionCommandDBService,
            IValidateAppSettingsService ValidateAppSettingsService,
            IGenerateCodeBaseService GenerateCodeBaseService,
            IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService) : base(Configuration)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.ActionCommandDBService = ActionCommandDBService;
            this.ValidateAppSettingsService = ValidateAppSettingsService;
            this.GenerateCodeBaseService = GenerateCodeBaseService;
            PolSourceGroupingExcelFileReadService = polSourceGroupingExcelFileReadService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            if (!await FillActionAndCommand()) return await Task.FromResult(false);

            await ActionCommandDBService.ConsoleWriteStart();

            if (!await FillAppSettingsParameters()) return await Task.FromResult(false);

            if (!await CheckAppSettingsParameters()) return await Task.FromResult(false);

            if (!await SetCultureWithArgs(args)) return await Task.FromResult(false);

            if (!await Generate())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await ActionCommandDBService.ConsoleWriteEnd();

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> FillAppSettingsParameters()
        {
            ValidateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Action", ExpectedValue = "run" },
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsPolSourceInfoRelatedFiles" },
                new AppSettingParameter() { Parameter = "CSSPCulture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "C:\\CSSPDesktop\\cssplocaldatabases\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "ExcelFileName", ExpectedValue = "C:\\CSSPTools\\src\\assets\\PolSourceGrouping.xlsm", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "FillPolSourceObsInfoChildServiceGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\Generated\\FillPolSourceObsInfoChildServiceGenerated.cs" },
                new AppSettingParameter() { Parameter = "EnumsPolSourceInfoGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsPolSourceInfoGenerated.cs" },
                new AppSettingParameter() { Parameter = "PolSourceObsInfoEnumGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\PolSourceObsInfoEnumGenerated.cs" },
                new AppSettingParameter() { Parameter = "EnumsPolSourceObsInfoEnumTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\tests\\Generated\\EnumsPolSourceObsInfoEnumTestGenerated.cs" },
                new AppSettingParameter() { Parameter = "CSSPCulturePolSourcesRes_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPCultureServices\\Resources\\CSSPCSSPCulturePolSourcesRes.resx" },
                new AppSettingParameter() { Parameter = "CSSPCulturePolSourcesResFR_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPCultureServices\\Resources\\CSSPCSSPCulturePolSourcesRes.fr.resx" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}