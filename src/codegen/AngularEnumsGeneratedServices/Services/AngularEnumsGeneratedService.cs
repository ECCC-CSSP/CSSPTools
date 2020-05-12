using AngularEnumsGeneratedServices.Resources;
using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
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
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularEnumsGeneratedServices.Services
{
    public class AngularEnumsGeneratedService : IAngularEnumsGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public AngularEnumsGeneratedService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
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
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
                Console.WriteLine("");
                Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
                return false;
            }

            if (!await Generate())
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
                Console.WriteLine("");
                Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
                return false;
            }

            await ConsoleWriteEnd();

            return true;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Generate()
        {
           ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();
            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await ConsoleWriteError("actionCommand == null");
                return false;
            }

            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Starting ...");
            actionCommandDBService.PercentCompleted = 10;
            await actionCommandDBService.Update();

            DirectoryInfo diOutputGen = new DirectoryInfo(configuration.GetValue<string>("OutputDir"));
            if (!diOutputGen.Exists)
            {
                try
                {
                    diOutputGen.Create();
                }
                catch (Exception)
                {
                    actionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.CouldNotCreateDirectory_, diOutputGen.FullName ) }");
                    return false;
                }
            }

            FileInfo fiCSSPEnumsDLL = new FileInfo(configuration.GetValue<string>("CSSPEnums"));

            actionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (generateCodeBaseService.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                actionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            actionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");

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
                        actionCommandDBService.ExecutionStatusText.AppendLine($"Created [{ dllTypeInfoEnums.Name.ToLower().Replace("enum", ".enum") }.ts]");
                    }
                }

            }

            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ AppRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            return true;
        }
        private async Task ConsoleWriteEnd()
        {
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ AppRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
            }

            Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
        }
        private async Task ConsoleWriteError(string errMessage)
        {
            actionCommandDBService.ErrorText.AppendLine(errMessage);
            actionCommandDBService.PercentCompleted = 0;
            await actionCommandDBService.Update();
            Console.WriteLine(actionCommandDBService.ErrorText.ToString());
            Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
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
            actionCommandDBService.Command = configuration.GetValue<string>("Command");
            await actionCommandDBService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));
            await validateAppSettingsService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));

            try
            {
                await actionCommandDBService.GetOrCreate();
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
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OutputDir", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\enums\\generated\\" },
                new AppSettingParameter() { Parameter = "EnumNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\enums\\generated\\{EnumName}.ts" },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
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