using EnumsCompareWithOldEnumsServices.Resources;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeCompile.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnumsServices.Services
{
    public class EnumsCompareWithOldEnumsService : IEnumsCompareWithOldEnumsService
    {
        #region Variables
        private static IServiceCollection serviceCollection;
        private static IConfiguration configuration;
        private static IGenerateCodeStatusDBService generateCodeStatusDBService;
        private static IValidateAppSettingsService validateAppSettingsService;
        #endregion Variables

        #region Properties
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private string DBFileName { get; set; } = "DBFileName";
        private ServiceProvider provider { get; set; }
        private FileInfo fiDB { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsService()
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task Setup()
        {
            ConsoleWriteStart();

            serviceCollection = new ServiceCollection();

            SetupConfigure();

            SetupGenerateCodeStatusDB();

            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            SettingProvider();

            FillGenerateCodeStatusDB();

            DoValidateAppSettings();
        }
        public async Task Run(string[] args)
        {
            await CompareDLLs();

            ConsoleWriteEnd();
        }
        #endregion Functions public

        #region Functions private
        private void ConsoleWriteEnd()
        {
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Update(100);

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            }

            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private void ConsoleWriteStart()
        {
            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");
        }
        private void DoValidateAppSettings()
        {
            try
            {
                validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
                if (validateAppSettingsService == null)
                {
                    return;
                }

                validateAppSettingsService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

                validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsCompareWithOldEnums" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "NewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OldEnumsDLL", ExpectedValue = "C:\\CSSP Latest Code Old\\CSSPEnumsDLL\\CSSPEnumsDLL\\bin\\Debug\\CSSPEnumsDLL.dll", IsFile = true, CheckExist = true },
            };

                validateAppSettingsService.VerifyAppSettings();
                if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
                {
                    generateCodeStatusDBService.Update(0);
                    Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                    Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void FillGenerateCodeStatusDB()
        {
            try
            {
                generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
                if (generateCodeStatusDBService == null || true)
                {
                    generateCodeStatusDBService.Error.AppendLine("EnumsCompareWithOldEnumsService generateCodeStatusDBService == null");
                    generateCodeStatusDBService.Update(0);
                    throw new Exception("EnumsCompareWithOldEnumsService generateCodeStatusDBService == null");
                }

                generateCodeStatusDBService.DBFileFullName = fiDB.FullName;
                generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
                generateCodeStatusDBService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                throw ex;
            }
        }
        private void SettingProvider()
        {
            try
            {
                provider = serviceCollection.BuildServiceProvider();
                if (provider == null)
                {
                    generateCodeStatusDBService.Error.AppendLine("provider == null");
                    generateCodeStatusDBService.Update(0);
                    Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                    Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                    throw new Exception("provider == null");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetupConfigure()
        {
            try
            {
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json")
                    .Build();

                serviceCollection.AddSingleton<IConfiguration>(configuration);
            }
            catch (Exception ex)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ ex.Message }");
                generateCodeStatusDBService.Update(0);
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
                Console.WriteLine(generateCodeStatusDBService.Status.ToString());
                throw ex;
            }
        }
        private void SetupGenerateCodeStatusDB()
        {
            try
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (configuration.GetValue<string>(DBFileName) == null)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }

                fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }");
                    generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }

                serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });

                serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task CompareDLLs()
        {
            string NewEnumsDLL = "NewEnumsDLL";
            string OldEnumsDLL = "OldEnumsDLL";

            GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();

            if (generateCodeStatus == null)
            {
                generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotGetOrCreateObject_InDB_, generateCodeStatusDBService.Command, generateCodeStatusDBService.DBFileFullName) }");
            }

            await generateCodeStatusDBService.Update(0);

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>(NewEnumsDLL));
            FileInfo fiOldDLL = new FileInfo(configuration.GetValue<string>(OldEnumsDLL));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> typeList = importAssembly.GetTypes().ToList();

            var importAssemblyOld = Assembly.LoadFile(fiOldDLL.FullName);
            List<Type> typeOldList = importAssemblyOld.GetTypes().ToList();

            foreach (Type type in typeOldList)
            {
                if (type.Name.EndsWith("Service") || type.Name.EndsWith("Res") || type.Name.EndsWith("TextOrdered") || type.Name.StartsWith("<>"))
                {
                    continue;
                }
                Type typeExist = (from c in typeList
                                  where c.Name == type.Name
                                  select c).FirstOrDefault();

                if (typeExist == null)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.Type_NotFound, type.Name) }");
                    await generateCodeStatusDBService.Update(0);
                    return;
                }
                else
                {
                    List<string> EnumNameOldList = Enum.GetNames(type).ToList();
                    List<string> EnumNameList = Enum.GetNames(typeExist).ToList();

                    foreach (string EnumStr in EnumNameOldList)
                    {
                        if (EnumStr == "Error")
                        {
                            continue;
                        }

                        string EnumStrExist = (from c in EnumNameList
                                               where c == EnumStr
                                               select c).FirstOrDefault();

                        if (string.IsNullOrWhiteSpace(EnumStrExist))
                        {
                            generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            await generateCodeStatusDBService.Update(0);
                            return;
                        }
                        else
                        {
                            // nothing
                        }

                    }
                }
            }

            return;
        }
        #endregion Functions private
    }
}
