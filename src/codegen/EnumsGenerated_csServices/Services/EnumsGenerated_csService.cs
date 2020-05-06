﻿using EnumsGenerated_csServices.Resources;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumsGenerated_csServices.Services
{
    public class EnumsGenerated_csService : IEnumsGenerated_csService
    {
        #region Variables
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Variables

        #region Constructors
        public EnumsGenerated_csService(IConfiguration configuration,
            IGenerateCodeStatusDBService generateCodeStatusDBService,
            IValidateAppSettingsService validateAppSettingsService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.validateAppSettingsService = validateAppSettingsService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            SetCulture(args);

            ConsoleWriteStart();

            if (!await Setup()) return false;

            if (!await Generate()) return false;

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

            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPEnums"));
            FileInfo fiInterface = new FileInfo(configuration.GetValue<string>("IEnumsGenerated"));
            FileInfo fi = new FileInfo(configuration.GetValue<string>("EnumsGenerated"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();

            StringBuilder sbAllowableTypesText = new StringBuilder();
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    sbAllowableTypesText.Append($"[{ type.Name }] (CSSPEnums.{ type.Name }.html), ");
                }
            }

            StringBuilder sbAllowablePolSourceObsInfoTypeEnumText = new StringBuilder();
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    if (type.Name == "PolSourceObsInfoTypeEnum")
                    {
                        foreach (FieldInfo fieldInfo in type.GetFields())
                        {
                            if (fieldInfo.FieldType.GetTypeInfo().BaseType == typeof(System.Enum))
                            {
                                sbAllowablePolSourceObsInfoTypeEnumText.Append($"{fieldInfo.Name},");
                            }
                        }
                    }
                }
            }

            // creating Generated\IEnumsGenerated.cs
            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [EnumsGenerated.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */ ");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    partial interface IEnums");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        void SetResourcesCulture(CultureInfo culture);");
            sb.AppendLine(@"        string EnumTypeListOK(Type type, List<int?> intList);");
            sb.AppendLine(@"        string EnumTypeOK(Type type, int? ID);");
            sb.AppendLine(@"        List<EnumIDAndText> GetEnumTextOrderedList(Type type);");
            sb.AppendLine(@"        string GetResValueForTypeAndID(Type type, int? ID, PolSourceObsInfoTypeEnum? polSourceObsInfoTypeEnum = null);");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"");
            sb.AppendLine(@"}");

            using (StreamWriter sw = fiInterface.CreateText())
            {
                sw.Write(sb.ToString());
            }

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Created } [{ fiInterface.FullName }] ...");
            await generateCodeStatusDBService.Update(50);

            sb = new StringBuilder();


            // creating Generated\EnumsGenerated.cs
            sb.AppendLine(@"/*");
            sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [EnumsGenerated.cs] button");
            sb.AppendLine(@" *");
            sb.AppendLine(@" * Do not edit this file.");
            sb.AppendLine(@" *");
            sb.AppendLine(@" */ ");
            sb.AppendLine(@"using CSSPEnums.Resources;");
            sb.AppendLine(@"using CSSPEnums.Resources.Generated;");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Threading;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class Enums");
            sb.AppendLine(@"    {");

            sb.AppendLine(@"        #region Enum Functions public");

            #region Doing Function public SetResourcesCulture
            sb.AppendLine(@"/// <summary>");
            sb.AppendLine(@"/// > [!NOTE]");
            sb.AppendLine(@"/// > <para>**Allowable Culture** : en-CA, fr-CA</para>");
            sb.AppendLine(@"/// </summary>");
            sb.AppendLine(@"/// <param name=""culture"">One of the allowable culture (en-CA, fr-CA)</param>");
            sb.AppendLine(@"/// <returns>empty</returns>");
            sb.AppendLine(@"public void SetResourcesCulture(CultureInfo culture)");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    CSSPEnumsRes.Culture = culture;");
            sb.AppendLine(@"    PolSourceInfoEnumGeneratedRes.Culture = culture;");
            sb.AppendLine(@"}");
            #endregion Doing Function public SetResourcesCulture

            #region Doing Function public EnumTypeOK
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// > [!NOTE]");
            sb.AppendLine($@"        /// > <para>**Allowable types** : { sbAllowableTypesText.Remove(sbAllowableTypesText.Length - 2, 2).ToString() }</para>");
            sb.AppendLine(@"        /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""type"">One of the allowable types (Enum)</param>");
            sb.AppendLine(@"        /// <param name=""intList"">List of nullable IDs representing the enumeration values (int?)</param>");
            sb.AppendLine(@"        /// <returns>Returns empty string if OK... otherwise will return the CSSPError message</returns>");
            sb.AppendLine(@"        public string EnumTypeListOK(Type type, List<int?> intList)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string retStr = """";");
            sb.AppendLine(@"");
            sb.AppendLine(@"            foreach (int? ID in intList)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                retStr = EnumTypeOK(type, ID);");
            sb.AppendLine(@"                if (!string.IsNullOrWhiteSpace(retStr))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    break;");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(retStr))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return string.Format(CSSPEnumsRes._IsRequired, type.Name);");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// > [!NOTE]");
            sb.AppendLine($@"        /// > <para>**Allowable types** : { sbAllowableTypesText.Remove(sbAllowableTypesText.Length - 2, 2).ToString() }</para>");
            sb.AppendLine(@"        /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""type"">One of the allowable types (Enum)</param>");
            sb.AppendLine(@"        /// <param name=""intList"">List of nullable IDs representing the enumeration values (int?)</param>");
            sb.AppendLine(@"        /// <returns>Returns empty string if OK... otherwise will return the CSSPError message</returns>");
            sb.AppendLine(@"        public string EnumTypeOK(Type type, int? ID)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (ID == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            foreach (int i in Enum.GetValues(type))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                if (i == ID)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return string.Format(CSSPEnumsRes._IsRequired, type.Name);");
            sb.AppendLine(@"        }");
            #endregion Doing Function public EnumTypeOK

            #region Doing Function public GetEnumTextOrderedList
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// > [!NOTE]");
            sb.AppendLine($@"        /// > <para>**Allowable types** : { sbAllowableTypesText.Remove(sbAllowableTypesText.Length - 2, 2).ToString() }</para>");
            sb.AppendLine(@"        /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""type"">One of the allowable types (Enum)</param>");
            sb.AppendLine(@"        /// <returns>Returns list of EnumIDAndText ordered by the Enum text for one of the allowable languages [LanguageEnum.en, LanguageEnum.fr]</returns>");
            sb.AppendLine(@"        public List<EnumIDAndText> GetEnumTextOrderedList(Type type)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            List<EnumIDAndText> enumTextOrderedList = new List<EnumIDAndText>();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            foreach (int i in Enum.GetValues(type))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                enumTextOrderedList.Add(new EnumIDAndText() { EnumID = i, EnumText = GetResValueForTypeAndID(type, i) });");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            enumTextOrderedList = (from c in enumTextOrderedList");
            sb.AppendLine(@"                                   orderby c.EnumText");
            sb.AppendLine(@"                                   select c).ToList();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return enumTextOrderedList;");
            sb.AppendLine(@"        }");
            #endregion Doing Function public GetEnumTextOrderedList

            #region Doing Function public GetResValueForTypeID
            sb.AppendLine(@"        /// <summary>");
            sb.AppendLine(@"        /// > [!NOTE]");
            sb.AppendLine($@"        /// > <para>**Allowable types** : { sbAllowableTypesText.Remove(sbAllowableTypesText.Length - 2, 2).ToString() }</para>");
            sb.AppendLine(@"        /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
            sb.AppendLine($@"        /// > <para>**Allowable <c>[PolSourceObsInfoTypeEnum] (CSSPEnums.PolSourceObsInfoTypeEnum.html)</c>:** { sbAllowablePolSourceObsInfoTypeEnumText.ToString() }</para>");
            sb.AppendLine(@"        /// > <para>**Return to [CSSPEnums](CSSPEnums.html)**</para>");
            sb.AppendLine(@"        /// </summary>");
            sb.AppendLine(@"        /// <param name=""type"">One of the allowable types (Enum)</param>");
            sb.AppendLine(@"        /// <param name=""ID"">ID representing the enumeration values (int?)</param>");
            sb.AppendLine(@"        /// <param name=""polSourceObsInfoTypeEnum"">Null or one of the allowable PolSourceObsInfoTypeEnum</param>");
            sb.AppendLine(@"        /// <returns>Will return the Enum text for one of the allowable languages [LanguageEnum.en, LanguageEnum.fr]</returns>");
            sb.AppendLine(@"        public string GetResValueForTypeAndID(Type type, int? ID, PolSourceObsInfoTypeEnum? polSourceObsInfoTypeEnum = null)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string enumName = type.Name;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            switch (enumName)");
            sb.AppendLine(@"            {");
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                    {
                        sb.AppendLine(@"                case ""PolSourceObsInfoEnum"":");
                        sb.AppendLine(@"                {");
                        sb.AppendLine(@"                    switch (polSourceObsInfoTypeEnum)");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine(@"                        case PolSourceObsInfoTypeEnum.Description:");
                        sb.AppendLine(@"                            return GetEnumText_PolSourceObsInfoDescEnum((ID == null ? null : (PolSourceObsInfoEnum?)ID));");
                        sb.AppendLine(@"                        case PolSourceObsInfoTypeEnum.Report:");
                        sb.AppendLine(@"                            return GetEnumText_PolSourceObsInfoReportEnum((ID == null ? null : (PolSourceObsInfoEnum?)ID));");
                        sb.AppendLine(@"                        case PolSourceObsInfoTypeEnum.Text:");
                        sb.AppendLine(@"                            return GetEnumText_PolSourceObsInfoTextEnum((ID == null ? null : (PolSourceObsInfoEnum?)ID));");
                        sb.AppendLine(@"                        case PolSourceObsInfoTypeEnum.Initial:");
                        sb.AppendLine(@"                            return GetEnumText_PolSourceObsInfoInitEnum((ID == null ? null : (PolSourceObsInfoEnum?)ID));");
                        sb.AppendLine(@"                        default:");
                        sb.AppendLine(@"                            return GetEnumText_PolSourceObsInfoEnum((ID == null ? null : (PolSourceObsInfoEnum?)ID));");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine(@"                }");
                    }
                    else
                    {
                        sb.AppendLine($@"                case ""{ enumName }"":");
                        sb.AppendLine($@"                    return GetEnumText_{ enumName }((ID == null ? null : ({ enumName }?)ID));");
                    }
                }
            }
            sb.AppendLine(@"                default:");
            sb.AppendLine(@"                    return """";");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            #endregion Doing Function public GetResValueForTypeAndID
            sb.AppendLine(@"        #endregion Enum Function public");
            sb.AppendLine(@"");

            #region Doing Functions private
            sb.AppendLine(@"        #region Functions private");
            foreach (Type type in types)
            {
                if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine($@"        private string GetEnumText_{ enumName }({ enumName }? { enumName.Substring(0, 1).ToLower() }{ enumName.Substring(1, enumName.Length - 5) })");
                    sb.AppendLine(@"        {");
                    sb.AppendLine($@"            if ({ enumName.Substring(0, 1).ToLower() }{ enumName.Substring(1, enumName.Length - 5) } == null)");
                    sb.AppendLine(@"                return CSSPEnumsRes.Empty;");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            switch ({ enumName.Substring(0, 1).ToLower() }{ enumName.Substring(1, enumName.Length - 5) })");
                    sb.AppendLine(@"            {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.GetTypeInfo().BaseType == typeof(System.Enum))
                        {
                            string fName = fieldInfo.Name;
                            sb.AppendLine($@"                case { enumName }.{ fName }:");
                            if (fName == "CSSPError")
                            {
                                sb.AppendLine(@"                    return CSSPEnumsRes.Empty;");
                            }
                            else
                            {
                                sb.AppendLine($@"                    return CSSPEnumsRes.{ enumName }{ fName };");
                            }
                        }
                    }
                    sb.AppendLine(@"                default:");
                    sb.AppendLine(@"                    return CSSPEnumsRes.Empty;");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Functions private");
            #endregion Doing Functions private

            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");

            using (StreamWriter sw = fi.CreateText())
            {
                sw.Write(sb.ToString());
            }

            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Created } [{ fi.FullName }] ...");
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsGenerated_cs" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "IEnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\IEnumsGenerated.cs", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "EnumsGenerated", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsGenerated.cs", IsFile = true, CheckExist = true },
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