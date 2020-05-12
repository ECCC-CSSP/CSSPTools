using AngularInterfacesGeneratedServices.Resources;
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

namespace AngularInterfacesGeneratedServices.Services
{
    public class AngularInterfacesGeneratedService : IAngularInterfacesGeneratedService
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
        public AngularInterfacesGeneratedService(IConfiguration configuration,
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
                    actionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.CouldNotCreateDirectory_, diOutputGen.FullName) }");
                    return false;
                }
            }

            FileInfo fiCSSPEnumsDLL = new FileInfo(configuration.GetValue<string>("CSSPEnums"));
            FileInfo fiCSSPModelsDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));


            actionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPEnumsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();
            if (generateCodeBaseService.FillDLLTypeInfoList(fiCSSPEnumsDLL, DLLTypeInfoCSSPEnumsList))
            {
                actionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            actionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPEnumsDLL.FullName }] ...");


            actionCommandDBService.ExecutionStatusText.AppendLine($"Reading [{ fiCSSPModelsDLL.FullName }] ...");
            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (generateCodeBaseService.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                actionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.CouldNotReadFile_, diOutputGen.FullName) }");
                return false;
            }
            actionCommandDBService.ExecutionStatusText.AppendLine($"Loaded [{ fiCSSPModelsDLL.FullName }] ...");

            CreateValidationResultTypeFile();

            List<string> removeClass = new List<string>()
            {
                "CSSPAfterAttribute", "CSSPAllowNullAttribute", "CSSPBiggerAttribute", "CSSPDBContext", "CSSPDescriptionENAttribute",
                "CSSPDescriptionFRAttribute", "CSSPDisplayENAttribute", "CSSPDisplayFRAttribute", "CSSPEnumTypeAttribute",
                "CSSPEnumTypeTextAttribute", "CSSPExistAttribute", "CSSPFillAttribute", "CSSPModelsRes", "Query"
            };
            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                //if (!(dllTypeInfoModels.Name == "Address" || dllTypeInfoModels.Name == "LastUpdate" || dllTypeInfoModels.Name == "CSSPError"))
                //{
                //    continue;
                //}

                if (!removeClass.Contains(dllTypeInfoModels.Name))
                {
                    CreateTypeFile(dllTypeInfoModels, DLLTypeInfoCSSPModelsList);
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
            actionCommandDBService.Action = configuration.GetValue<string>("Action");
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "AngularInterfacesGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OutputDir", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\interfaces\\generated\\" },
                new AppSettingParameter() { Parameter = "ValidateResultFileName", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\interfaces\\generated\\validationresult.interface.ts" },
                new AppSettingParameter() { Parameter = "InterfaceFileName", ExpectedValue = "C:\\CSSPCode\\CSSPWebToolsAng\\src\\app\\interfaces\\generated\\{TypeName}.interface.ts" },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        private void CreateValidationResultTypeFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPWebToolsAngCodeWriter.proj by clicking on the [AngularEnumsGenerate.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");
            sb.AppendLine($@"export interface ValidationResult {{");
            sb.AppendLine($@"    MemberNames: string[];");
            sb.AppendLine($@"    ErrorMessage: string;");
            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("ValidateResultFileName"));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                actionCommandDBService.ExecutionStatusText.AppendLine($"Created [{ fiOutputGen }]");
            }
        }
        private void CreateTypeFile(DLLTypeInfo dllTypeInfoModels, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList)
        {
            StringBuilder sb = new StringBuilder();
            List<string> fileNameUsedList = new List<string>();
            List<string> removeTypeList = new List<string>()
            {
                "Int32", "Int16", "Int64", "Single", "Float", "Double", "String", "DateTime", "Boolean"
            };
            bool IsExtra = false; ;
            string LastLetter = "";
            string BaseClass = "";
            string ParentClass = "";
            List<string> PropToSkip = new List<string>();

            if (dllTypeInfoModels.Name == "AppTaskParameter")
            {
                int seilfj = 34;
            }

            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPWebToolsAngCodeWriter.proj by clicking on the [AngularInterfacesGenerate.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */");
            sb.AppendLine(@"");

            if (dllTypeInfoModels.Name == "CSSPError")
            {
                sb.AppendLine($"import {{ ValidationResult }} from './validationresult.interface';");
            }
            else if (dllTypeInfoModels.Name == "LastUpdate")
            {
                sb.AppendLine($"import {{ CSSPError }} from './cssperror.interface';");
            }
            else
            {
                if (!dllTypeInfoModels.HasNotMappedAttribute)
                {
                    sb.AppendLine($"import {{ LastUpdate }} from './lastupdate.interface';");
                }
                else
                {
                    if (dllTypeInfoModels.Name.Length > 5)
                    {
                        IsExtra = dllTypeInfoModels.Name.Substring(dllTypeInfoModels.Name.Length - 6).StartsWith("Extra");

                        if (!IsExtra)
                        {
                            sb.AppendLine($"import {{ CSSPError }} from './cssperror.interface';");
                        }
                    }
                    else
                    {
                        sb.AppendLine($"import {{ CSSPError }} from './cssperror.interface';");
                    }
                }
            }

            if (dllTypeInfoModels.Name.Length > 6)
            {
                IsExtra = dllTypeInfoModels.Name.Substring(dllTypeInfoModels.Name.Length - 6).StartsWith("Extra");
                if (IsExtra)
                {
                    LastLetter = dllTypeInfoModels.Name.Substring(dllTypeInfoModels.Name.Length - 1);
                    BaseClass = dllTypeInfoModels.Name.Substring(0, dllTypeInfoModels.Name.Length - 6);
                    switch (LastLetter)
                    {
                        case "A":
                            {
                                ParentClass = BaseClass;
                                fileNameUsedList.Add(ParentClass.ToLower());
                                sb.AppendLine($"import {{ { ParentClass } }} from './{ ParentClass.ToLower() }.interface';");
                            }
                            break;
                        case "B":
                            {
                                ParentClass = BaseClass + "ExtraA";
                                fileNameUsedList.Add(ParentClass.ToLower());
                                sb.AppendLine($"import {{ { ParentClass } }} from './{ ParentClass.ToLower() }.interface';");
                            }
                            break;
                        case "C":
                            {
                                ParentClass = BaseClass + "ExtraB";
                                fileNameUsedList.Add(ParentClass.ToLower());
                                sb.AppendLine($"import {{ { ParentClass } }} from './{ ParentClass.ToLower() }.interface';");
                            }
                            break;
                        case "D":
                            {
                                ParentClass = BaseClass + "ExtraC";
                                fileNameUsedList.Add(ParentClass.ToLower());
                                sb.AppendLine($"import {{ { ParentClass } }} from './{ ParentClass.ToLower() }.interface';");
                            }
                            break;
                        case "E":
                            {
                                ParentClass = BaseClass + "ExtraD";
                                fileNameUsedList.Add(ParentClass.ToLower());
                                sb.AppendLine($"import {{ { ParentClass } }} from './{ ParentClass.ToLower() }.interface';");
                            }
                            break;
                        case "F":
                            {
                                ParentClass = BaseClass + "ExtraE";
                                fileNameUsedList.Add(ParentClass.ToLower());
                                sb.AppendLine($"import {{ { ParentClass } }} from './{ ParentClass.ToLower() }.interface';");
                            }
                            break;
                        default:
                            break;
                    }

                    foreach (DLLTypeInfo dllTypeInfoModels2 in DLLTypeInfoCSSPModelsList)
                    {
                        if (dllTypeInfoModels2.Name == ParentClass)
                        {
                            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels2.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
                            {
                                PropToSkip.Add(dllPropertyInfo.CSSPProp.PropName);
                            }
                        }
                    }
                }
                sb.AppendLine(@"");
            }

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
            {
                string fileName = dllPropertyInfo.CSSPProp.PropType.ToLower();
                if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
                {
                    fileName = fileName.Replace("enum", ".enum");
                    if (!fileNameUsedList.Contains(fileName))
                    {
                        fileNameUsedList.Add(fileName);
                        if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }
                        sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from '../../enums/generated/{ fileName }';");
                    }
                }

                if (!fileNameUsedList.Contains(fileName))
                {
                    if (!(dllPropertyInfo.CSSPProp.PropName == "ValidationResults" || dllPropertyInfo.CSSPProp.PropName == "HasErrors"))
                    {
                        if (!removeTypeList.Contains(dllPropertyInfo.CSSPProp.PropType))
                        {
                            fileNameUsedList.Add(fileName);
                            if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                            {
                                continue;
                            }
                            if (dllPropertyInfo.CSSPProp.IsList)
                            {
                                sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from './{ fileName }.interface';");
                            }
                            else
                            {
                                sb.AppendLine($"import {{ { dllPropertyInfo.CSSPProp.PropType } }} from './{ fileName }.interface';");
                            }
                        }
                    }
                }
            }
            sb.AppendLine(@"");

            string MappedText = "";
            if (dllTypeInfoModels.HasNotMappedAttribute)
            {
                if (IsExtra)
                {
                    MappedText = $" extends { ParentClass }";
                }
                else
                {
                    MappedText = " extends CSSPError";
                }
            }
            else
            {
                if (dllTypeInfoModels.Type.Name == "LastUpdate")
                {
                    MappedText = " extends CSSPError";
                }
                else if (dllTypeInfoModels.Type.Name == "CSSPError")
                {
                    MappedText = "";
                }
                else
                {
                    if (IsExtra)
                    {
                        MappedText = $" extends { ParentClass }";
                    }
                    else
                    {
                        MappedText = " extends LastUpdate";
                    }
                }
            }
            sb.AppendLine($@"export interface { dllTypeInfoModels.Name }{ MappedText } {{");

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList.OrderBy(c => c.CSSPProp.PropName))
            {
                if (PropToSkip.Contains(dllPropertyInfo.CSSPProp.PropName))
                {
                    continue;
                }

                if (dllTypeInfoModels.Name != "CSSPError")
                {
                    if (dllPropertyInfo.CSSPProp.PropName == "HasErrors" || dllPropertyInfo.CSSPProp.PropName == "ValidationResults")
                    {
                        continue;
                    }
                }

                string IsNull = "";
                if (dllPropertyInfo.CSSPProp.IsNullable)
                {
                    IsNull = "?";
                }

                string typeText = "";
                switch (dllPropertyInfo.CSSPProp.PropType)
                {
                    case "Int32":
                    case "Int16":
                    case "Int64":
                    case "Single":
                    case "Float":
                    case "Double":
                        {
                            typeText = "number";
                        }
                        break;
                    case "String":
                        {
                            typeText = "string";
                            IsNull = "";
                        }
                        break;
                    case "DateTime":
                        {
                            typeText = "Date";
                        }
                        break;
                    case "Boolean":
                        {
                            typeText = "boolean";
                        }
                        break;
                    default:
                        {
                            if (dllPropertyInfo.CSSPProp.PropName == "ValidationResults")
                            {
                                typeText = "ValidationResult";
                            }
                            else
                            {
                                typeText = dllPropertyInfo.CSSPProp.PropType;
                            }
                        }
                        break;
                }
                if (dllPropertyInfo.CSSPProp.IsList)
                {
                    sb.AppendLine($@"    { dllPropertyInfo.CSSPProp.PropName }{ IsNull }: { typeText }[];");
                }
                else
                {
                    sb.AppendLine($@"    { dllPropertyInfo.CSSPProp.PropName }{ IsNull }: { typeText };");
                }
            }

            sb.AppendLine(@"}");

            FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("InterfaceFileName").Replace("{TypeName}",  dllTypeInfoModels.Name.ToLower()));
            using (StreamWriter sw2 = fiOutputGen.CreateText())
            {
                sw2.Write(sb.ToString());
                actionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(AppRes.Created_, fiOutputGen.FullName) }");
            }
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