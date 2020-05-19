using ActionCommandDBServices.Services;
using BaseCodeGenerateServices.Services;
using CSSPModels;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : BaseCodeGenerateService, IServicesClassNameServiceTestGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext dbCSSPDB { get; set; }
        private TestDBContext dbTestDB { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesClassNameServiceTestGeneratedService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService,
            CSSPDBContext dbCSSPDB,
            TestDBContext dbTestDB) : base(configuration)
        {
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ServicesClassNameServiceTestGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\bin\\Debug\\netcoreapp3.1\\CSSPServices.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPDBConnectionString", ExpectedValue = "Data Source=.\\sqlexpress;Initial Catalog=CSSPDB;Integrated Security=True" },
                new AppSettingParameter() { Parameter = "TestDBConnectionString", ExpectedValue = "Data Source=.\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True" },
                new AppSettingParameter() { Parameter = "ClassNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPServices\\CSSPServices.Tests\\{TypeName}ServiceTestGenerated.cs" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}