using EnumsPolSourceInfoRelatedFilesServices.Resources;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public EnumsPolSourceInfoRelatedFilesService(IConfiguration configuration,
            IGenerateCodeStatusDBService generateCodeStatusDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.polSourceGroupingExcelFileReadService = polSourceGroupingExcelFileReadService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            SetCulture(args);

            ConsoleWriteStart();

            if (!await Setup())
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                Console.WriteLine("");
                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                return false;
            }

            if (!await Generate())
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                Console.WriteLine("");
                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                return false;
            }

            await ConsoleWriteEnd();

            return true;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Generate()
        {
            GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();

            if (generateCodeStatus == null)
            {
                await ConsoleWriteError("generateCodeStatus == null");
                return false;
            }

            generateCodeStatusDBService.Status.AppendLine("Generate Starting ...");
            await generateCodeStatusDBService.Update(10);


            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking }");

            FileInfo fiExcel = new FileInfo(configuration.GetValue<string>("ExcelFileName"));

            if (!await polSourceGroupingExcelFileReadService.ReadExcelSheet(fiExcel.FullName, false))
            {
                return false;
            }

            if (polSourceGroupingExcelFileReadService.groupChoiceChildLevelList.Count() == 0)
            {
                string ErrorText = String.Format(AppRes.ERROR_IsEqualTo0, "_groupChoiceChildLevelList");
                generateCodeStatusDBService.Error.AppendLine($"{ ErrorText }");
                await generateCodeStatusDBService.Update(0);

                return false;
            }

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.ReadingExcelDocumentAndChecking } { AppRes.Done } ...");

            await Generate_FillPolSourceObsInfoChildService();
            await Generate_EnumsPolSourceInfo();
            await Generate_PolSourceObsInfoEnum();
            await Generate_EnumsPolSourceObsInfoEnumTest();
            await Generate_PolSourceInfoEnumGeneratedRes_resx();
            await Generate_PolSourceInfoEnumGeneratedResFR_resx();

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine("Generate Finished ...");
            await generateCodeStatusDBService.Update(100);

            return true;
        }
        private async Task ConsoleWriteEnd()
        {
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(100);

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            }

            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private async Task ConsoleWriteError(string errMessage)
        {
            generateCodeStatusDBService.Error.AppendLine(errMessage);
            await generateCodeStatusDBService.Update(0);
            Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private void ConsoleWriteStart()
        {
            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");
        }
        private void SetCulture(string[] args)
        {
            string culture = AllowableCultures[0];

            if (args.Count() > 0)
            {
                if (AllowableCultures.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            AppRes.Culture = new CultureInfo(culture);
        }
        private async Task<bool> Setup()
        {
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));
            validateAppSettingsService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            try
            {
                await generateCodeStatusDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsPolSourceInfoRelatedFiles" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "ExcelFileName", ExpectedValue = "C:\\CSSPTools\\src\\assets\\PolSourceGrouping.xlsm", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "FillPolSourceObsInfoChildServiceGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\Generated\\FillPolSourceObsInfoChildServiceGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "EnumsPolSourceInfoGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsPolSourceInfoGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PolSourceObsInfoEnumGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\PolSourceObsInfoEnumGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "EnumsPolSourceObsInfoEnumTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\tests\\Generated\\EnumsPolSourceObsInfoEnumTestGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PolSourceInfoEnumGeneratedRes_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Resources\\Generated\\PolSourceInfoEnumGeneratedRes.resx", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "PolSourceInfoEnumGeneratedResFR_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Resources\\Generated\\PolSourceInfoEnumGeneratedRes.fr.resx", IsFile = true, CheckExist = true },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}