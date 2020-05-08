using AngularEnumsGeneratedServices.Resources;
using CSSPEnums;
using CSSPModels;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AngularEnumsGeneratedServices.Services
{
    public class AngularEnumsGeneratedService : IAngularEnumsGeneratedService
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
        public AngularEnumsGeneratedService(IConfiguration configuration,
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

            DirectoryInfo diOutputGen = new DirectoryInfo(configuration.GetValue<string>("OutputDir"));
            if (!diOutputGen.Exists)
            {
                try
                {
                    diOutputGen.Create();
                }
                catch (Exception)
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotCreateDirectory_, diOutputGen.FullName ) }");
                    return false;
                }
            }

            FileInfo fiCSSPEnumsDLL = new FileInfo(configuration.GetValue<string>("CSSPEnums"));

            generateCodeStatusDBService.Status.AppendLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (generateCodeBaseService.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            generateCodeStatusDBService.Status.AppendLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");

            foreach (DLLTypeInfo dllTypeInfoEnums in DLLTypeInfoCSSPEnumsList)
            {
                //if (dllTypeInfoEnums.Name != "AddressTypeEnum")
                //{
                //    continue;
                //}

                StringBuilder sb = new StringBuilder();

                if (dllTypeInfoEnums.IsEnum)
                {
                    sb.AppendLine(@"/*");
                    sb.AppendLine(@" * Auto generated from the CSSPWebToolsAngCodeWriter.proj by clicking on the [AngularEnumsGenerate.cs] button");
                    sb.AppendLine(@" *");
                    sb.AppendLine(@" * Do not edit this file.");
                    sb.AppendLine(@" *");
                    sb.AppendLine(@" */");
                    sb.AppendLine($@"export enum { dllTypeInfoEnums.Name } {{");

                    List<EnumNameAndNumber> enumNameAndNumberList = new List<EnumNameAndNumber>();

                    foreach (DLLFieldInfo dllFieldInfo in dllTypeInfoEnums.FieldInfoList)
                    {
                        if (dllTypeInfoEnums.IsEnum)
                        {

                            string fName = dllFieldInfo.Name;
                            int IntVal = (int)dllFieldInfo.FieldInfo.GetValue(dllFieldInfo.Name);

                            enumNameAndNumberList.Add(new EnumNameAndNumber() { EnumName = fName, EnumNumber = IntVal });
                        }
                    }

                    foreach (EnumNameAndNumber enumNameAndNumber in enumNameAndNumberList.OrderBy(c => c.EnumNumber))
                    {
                        sb.AppendLine($@"    { enumNameAndNumber.EnumName } = { enumNameAndNumber.EnumNumber },");
                    }

                    sb.AppendLine(@"}");
                    sb.AppendLine(@"");

                    FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("EnumNameFile").Replace("{EnumName}", dllTypeInfoEnums.Name.ToLower().Replace("enum", ".enum")));

                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                        generateCodeStatusDBService.Status.AppendLine($"Created [{ dllTypeInfoEnums.Name.ToLower().Replace("enum", ".enum") }.ts]");
                    }
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "AngularEnumsGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OutputDir", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\enums\\generated\\" },
                new AppSettingParameter() { Parameter = "EnumNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\enums\\generated\\{EnumName}.ts" },
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

        #region Sub Classes
        private class EnumNameAndNumber
        {
            public EnumNameAndNumber()
            {
            }

            public string EnumName { get; set; }
            public int EnumNumber { get; set; }
        }
        #endregion Sub Classes
    }
}