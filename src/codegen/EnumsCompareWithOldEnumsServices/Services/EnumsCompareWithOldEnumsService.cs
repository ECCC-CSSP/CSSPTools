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
        private static IServiceCollection _serviceCollection;
        private static IConfiguration _configuration;
        private static IGenerateCodeStatusDBService _generateCodeStatusDBService;
        private static IValidateAppSettingsService _validateAppSettingsService;
        private string DBFullName;
        #endregion Variables

        #region Properties
        private List<string> Args0Allowables { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            _configuration = configuration;
            _generateCodeStatusDBService = generateCodeStatusDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task Run(string[] args)
        {
            _serviceCollection = new ServiceCollection();

            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            // setting culture
            SettingCulture(args);

            // Filling serviceCollection with DI
            ServiceProvider provider = SettingDependencyInjections("DBFileName");
            if (provider == null)
            {
                Console.WriteLine($"provider { AppRes.IsNull }");
                return;
            }

            // getting Generate Code DB status object fom DI and checking if not null
            _generateCodeStatusDBService = provider.GetService<IGenerateCodeStatusDBService>();
            if (_generateCodeStatusDBService == null)
            {
                Console.WriteLine("generateCodeStatusDBService is null");
                return;
            }
            SettingGenerateCodeStatusDBService();

            // getting all other objects fom DI and checking if not null
            _validateAppSettingsService = provider.GetService<IValidateAppSettingsService>();

            if (_validateAppSettingsService == null)
            {
                ServiceIsNull("validateAppSettingsService");
                return;
            }

            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            _generateCodeStatusDBService.Status.AppendLine("");
            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Starting } ...");
            _generateCodeStatusDBService.Status.AppendLine("");
            await _generateCodeStatusDBService.Update(0);

            // checking the appsettings.json parameters
            SettingsValidateAppSettingsService();
            await _validateAppSettingsService.VerifyAppSettings();
            if (ErrorFound()) return;

            await _generateCodeStatusDBService.Update(3);

            // running the compare with old enums service
            await Start();
            if (ErrorFound()) return;

            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            _generateCodeStatusDBService.Status.AppendLine("");
            await _generateCodeStatusDBService.Update(100);

            Console.WriteLine($"{ _generateCodeStatusDBService.Status }");
        }
        #endregion Functions public

        #region Functions private
        private static bool ErrorFound()
        {
            if (!string.IsNullOrWhiteSpace(_generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine($"{ _generateCodeStatusDBService.Error }");
                Console.WriteLine("");
                Console.WriteLine($"{ _generateCodeStatusDBService.Status }");
                Console.WriteLine("");

                _generateCodeStatusDBService.Update(0);
                return true;
            }

            return false;
        }
        private void ServiceIsNull(string serviceIsNull)
        {
            _generateCodeStatusDBService.Error.AppendLine($"{ serviceIsNull } is null");
            ErrorFound();
        }
        private void SettingCulture(string[] args)
        {
            AppRes.Culture = new CultureInfo(_configuration.GetValue<string>("Culture"));

            if (args.Length == 1)
            {
                if (!Args0Allowables.Contains(args[0]))
                {
                    _generateCodeStatusDBService.Error.AppendLine($"\t#0:\t{ string.Format(AppRes.Parameter_ShouldBe_, "0", string.Join(" || ", Args0Allowables)) }");
                    _generateCodeStatusDBService.Error.AppendLine("");
                    return;
                }
                else
                {
                    AppRes.Culture = new CultureInfo(args[0]);
                }
            }
        }
        private ServiceProvider SettingDependencyInjections(string DBFileNameParam)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (_configuration.GetValue<string>(DBFileNameParam) == null)
            {
                Console.WriteLine($"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileNameParam) }");
                Console.WriteLine("");

                return null;
            }

            FileInfo fiDB = new FileInfo(_configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

            DBFullName = fiDB.FullName;

            _serviceCollection.AddSingleton<IConfiguration>(_configuration);
            _serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });
            _serviceCollection.AddSingleton<IGenerateCodeStatusDBService, GenerateCodeStatusDBService>();
            _serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
            
            return _serviceCollection.BuildServiceProvider();
        }
        private void SettingGenerateCodeStatusDBService()
        {
            _generateCodeStatusDBService.DBFileFullName = DBFullName;
            _generateCodeStatusDBService.Command = _configuration.GetValue<string>("Command");
            _generateCodeStatusDBService.SetCulture(AppRes.Culture);
        }
        private void SettingsValidateAppSettingsService()
        {
            _validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsCompareWithOldEnums" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "NewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OldEnumsDLL", ExpectedValue = "C:\\CSSP Latest Code Old\\CSSPEnumsDLL\\CSSPEnumsDLL\\bin\\Debug\\CSSPEnumsDLL.dll", IsFile = true, CheckExist = true },
            };
        }
        private async Task Start()
        {
            string NewEnumsDLL = "NewEnumsDLL";
            string OldEnumsDLL = "OldEnumsDLL";

            GenerateCodeStatus statusAndResults = await _generateCodeStatusDBService.GetOrCreate();

            if (statusAndResults == null)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.CouldNotGetOrCreateObject_InDB_, _generateCodeStatusDBService.Command, _generateCodeStatusDBService.DBFileFullName) }");
            }

            await _generateCodeStatusDBService.Update(0);

            FileInfo fiDLL = new FileInfo(_configuration.GetValue<string>(NewEnumsDLL));
            FileInfo fiOldDLL = new FileInfo(_configuration.GetValue<string>(OldEnumsDLL));

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
                    _generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.Type_NotFound, type.Name) }");
                    await _generateCodeStatusDBService.Update(0);
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
                            _generateCodeStatusDBService.Error.AppendLine($"{ String.Format(AppRes.Type_Enum_NotFound, type.Name, EnumStr) }");
                            await _generateCodeStatusDBService.Update(0);
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
