using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using ModelsModelClassNameTestServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCSSPModelsResServices.Services
{
    public class ModelsModelClassNameTestService : IModelsModelClassNameTestService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public ModelsModelClassNameTestService(IConfiguration configuration,
            IGenerateCodeStatusDBService generateCodeStatusDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.generateCodeBaseService = generateCodeBaseService;
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

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                StringBuilder sb = new StringBuilder();

                if (generateCodeBaseService.SkipType(type))
                {
                    continue;
                }

                //if (type.Name == "AppTaskParameter")
                //{
                //    continue;
                //}

                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using Xunit;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPModels.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine($@"    public partial class { type.Name }Test");
                sb.AppendLine(@"    {");
                sb.AppendLine($@"        // most of the tests are auto generated and are located under { type.Name }TestGenerated.cs");
                sb.AppendLine(@"        // use this section to add other manual test");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Tests");
                sb.AppendLine(@"        [Fact]");
                sb.AppendLine($@"        public void { type.Name }_Example_Manual_Test()");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            int i = 5;");
                sb.AppendLine(@"            Assert.Equal(5, i);");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Tests");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("TypeNameTest").Replace("{TypeName}", type.Name));
                if (!fiOutputGen.Exists)
                {
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }
                    generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.CreatedNew_, fiOutputGen.FullName) }");
                }
                else
                {
                    generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.AlreadyCreated_, fiOutputGen.FullName) }");
                }
            }

            generateCodeStatusDBService.Status.AppendLine("");
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ModelsModelClassNameTest" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "TypeNameTest", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\tests\\{TypeName}Test.cs" },
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