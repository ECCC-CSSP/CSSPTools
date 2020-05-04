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
        #endregion Variables

        #region Properties
        //public IServiceCollection serviceCollection { get; set; }
        public IConfiguration configuration { get; set; }
        public IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        public IValidateAppSettingsService validateAppSettingsService { get; set; }

        public List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        public string DBFileName { get; set; } = "DBFileName";
        //public IServiceProvider provider { get; set; }
        public FileInfo fiDB { get; set; }
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsService(IConfiguration configuration,
            IGenerateCodeStatusDBService generateCodeStatusDBService,
            IValidateAppSettingsService validateAppSettingsService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            //serviceCollection = new ServiceCollection();


            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (configuration.GetValue<string>(DBFileName) == null)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
                return;
            }

            fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }");
                return;
            }

            generateCodeStatusDBService.DBFileFullName = fiDB.FullName;
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            try
            {
                generateCodeStatusDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            await ConsoleWriteStart();

            if (!await Setup()) return false;

            if (!await CompareDLLs()) return false;

            await ConsoleWriteEnd();

            return true;
        }
        public async Task<bool> Setup()
        {
            if (!await SetupConfigure()) return false;

            if (!await SetupGenerateCodeStatusDBService()) return false;

            if (!await SetupValidateAppSettingsService()) return false;

            if (!await SettingProvider()) return false;

            if (!await FillGenerateCodeStatusDB()) return false;

            if (!await DoValidateAppSettings()) return false;

            return true;
        }
        public async Task<bool> CompareDLLs()
        {
            string NewEnumsDLL = "NewEnumsDLL";
            string OldEnumsDLL = "OldEnumsDLL";

            GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();

            generateCodeStatusDBService.Status.AppendLine("CompareDLLs Starting...");
            if (generateCodeStatus == null)
            {
                ConsoleWriteError("generateCodeStatus == null");
                return false;
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
                    await ConsoleWriteError($"{ String.Format(AppRes.Type_NotFound, type.Name) }");
                    return false;
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
                            await ConsoleWriteError($"{ String.Format(AppRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            return false;
                        }
                        else
                        {
                            // nothing
                        }
                    }
                }
            }

            generateCodeStatusDBService.Status.AppendLine("CompareDLLs Finished...");

            return true;
        }


        public async Task ConsoleWriteEnd()
        {
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(100);

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            }

            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        public async Task ConsoleWriteError(string errMessage)
        {
            generateCodeStatusDBService.Error.AppendLine(errMessage);
            await generateCodeStatusDBService.Update(0);
            Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        public async Task ConsoleWriteStart()
        {
            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");
        }
        public async Task<bool> DoValidateAppSettings()
        {
            //validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();
            //if (validateAppSettingsService == null)
            //{
            //    await ConsoleWriteError("validateAppSettingsService == null");
            //    return false;
            //}

            validateAppSettingsService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsCompareWithOldEnums" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "NewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OldEnumsDLL", ExpectedValue = "C:\\CSSP Latest Code Old\\CSSPEnumsDLL\\CSSPEnumsDLL\\bin\\Debug\\CSSPEnumsDLL.dll", IsFile = true, CheckExist = true },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        public async Task<bool> FillGenerateCodeStatusDB()
        {
            //generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            //if (generateCodeStatusDBService == null)
            //{
            //    Console.WriteLine("EnumsCompareWithOldEnumsService generateCodeStatusDBService == null");
            //    return false;
            //}

            generateCodeStatusDBService.DBFileFullName = fiDB.FullName;
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            try
            {
                await generateCodeStatusDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        public async Task<bool> SettingProvider()
        {
            //provider = serviceCollection.BuildServiceProvider();
            //if (provider == null)
            //{
            //    Console.WriteLine("provider == null");
            //    return false;
            //}

            return true;
        }
        public async Task<bool> SetupConfigure()
        {
            //try
            //{
            //    configuration = new ConfigurationBuilder()
            //        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //    serviceCollection.AddSingleton<IConfiguration>(configuration);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}

            return true;
        }
        public async Task<bool> SetupGenerateCodeStatusDBService()
        {
            //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //if (configuration.GetValue<string>(DBFileName) == null)
            //{
            //    Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
            //    return false;
            //}

            //fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            //if (!fiDB.Exists)
            //{
            //    Console.WriteLine($"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }");
            //    return false;
            //}

            //try
            //{
            //    serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            //    {
            //        options.UseSqlite($"DataSource={fiDB.FullName}");
            //    });

            //    serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}

            return true;
        }
        public async Task<bool> SetupValidateAppSettingsService()
        {
            //try
            //{
            //    serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}
            return true;
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
