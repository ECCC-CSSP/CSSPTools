using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CSSPModels;
using CultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public interface IServicesClassNameServiceGeneratedService
    {
        Task<bool> Run(string[] args);
    }
    public partial class ServicesClassNameServiceGeneratedService : ConfigService, IServicesClassNameServiceGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext dbCSSPDB { get; set; }
        private TestDBContext dbTestDB { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesClassNameServiceGeneratedService(IConfiguration configuration,
            ICultureService cultureService,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService,
            CSSPDBContext dbCSSPDB,
            TestDBContext dbTestDB) : base(configuration)
        {
            CultureService = cultureService;
            ActionCommandDBService = actionCommandDBService;
            ValidateAppSettingsService = validateAppSettingsService;
            GenerateCodeBaseService = generateCodeBaseService;
            this.dbCSSPDB = dbCSSPDB;
            this.dbTestDB = dbTestDB;
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ServicesClassNameServiceGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\cssp\\cssplocaldatabases\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPDB2", ExpectedValue = "Data Source=.\\sqlexpress;Initial Catalog=CSSPDB2;Integrated Security=True" },
                new AppSettingParameter() { Parameter = "TestDB", ExpectedValue = "Data Source=.\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True" },
                new AppSettingParameter() { Parameter = "ClassNameFile", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\Services\\Generated\\{TypeName}ServiceGenerated.cs" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}