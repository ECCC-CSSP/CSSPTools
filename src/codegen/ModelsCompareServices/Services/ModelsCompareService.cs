using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using ModelsCompareServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCompareServices.Services
{
    public class ModelsCompareService : IModelsCompareService
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
        public ModelsCompareService(IConfiguration configuration,
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

            List<string> UseQuestionMarkList = new List<string>() { "bool", "int", "long", "DateTime", "double", "float", "byte[]", "Type" };

            List<string> PropertiesToSkipList = new List<string>() { "ValidationResults", "HasErrors", "LastUpdateDate_UTC", "LastUpdateContactTVItemID" };
            #region Variables and loading DLL properties
            FileInfo fiCSSPModelsDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

            List<DLLTypeInfo> DLLTypeInfoCSSPEnumsList = new List<DLLTypeInfo>();

            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (generateCodeBaseService.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotReadFile_, fiCSSPModelsDLL.FullName) }");
                return false;
            }
            #endregion Variables and loading DLL properties

            DLLTypeInfo dllTypeInfoLastUpdate = new DLLTypeInfo();
            DLLTypeInfo dllTypeInfoCSSPError = new DLLTypeInfo();

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                if (dllTypeInfoModels.Name == "LastUpdate")
                {
                    dllTypeInfoLastUpdate = dllTypeInfoModels;
                }

                if (dllTypeInfoModels.Name == "CSSPError")
                {
                    dllTypeInfoCSSPError = dllTypeInfoModels;
                }
            }

            foreach (DLLTypeInfo dllTypeInfoModels in DLLTypeInfoCSSPModelsList)
            {
                StringBuilder sb = new StringBuilder();
                //bool PleaseStop = false;
                bool NotMappedClass = false;

                if (generateCodeBaseService.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (dllTypeInfoModels.Type.Name != "Address")
                //{
                //    continue;
                //}

                #region Show type file in richTextBoxStatus
                FileInfo fiCodeFile = new FileInfo(configuration.GetValue<string>("CodeFile").Replace("{TypeName}", dllTypeInfoModels.Type.Name));

                if (!fiCodeFile.Exists)
                {
                    NotMappedClass = true;
                    fiCodeFile = new FileInfo(configuration.GetValue<string>("CodeFileNotMapped").Replace("{TypeName}", dllTypeInfoModels.Type.Name));
                    if (!fiCodeFile.Exists)
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindFile_, dllTypeInfoModels.Type.Name) }");
                        return false;
                    }
                }

                StreamReader sr = fiCodeFile.OpenText();
                string OriginalCodeFile = sr.ReadToEnd();
                sr.Close();

                //Application.DoEvents();
                #endregion Show type file in richTextBoxStatus


                #region Top part
                sb.AppendLine(@"/*");
                sb.AppendLine(@" * Manually edited");
                sb.AppendLine(@" * ");
                sb.AppendLine(@" */");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations.Schema;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPModels");
                sb.AppendLine(@"{");
                #endregion Top part

                #region doing type
                if (NotMappedClass)
                {
                    sb.AppendLine(@"    [NotMapped]");
                    sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name } : CSSPError");
                }
                else
                {
                    if (dllTypeInfoModels.Type.Name == "AspNetUser")
                    {
                        sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name } : CSSPError");
                    }
                    else
                    {
                        sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name } : LastUpdate");
                    }
                }
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Properties in DB");
                if (!NotMappedClass)
                {
                    foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                    {
                        if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute || PropertiesToSkipList.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }
                        
                        if (!WriteAttributes(dllTypeInfoModels, dllPropertyInfo, sb))
                        {
                            return false;
                        }
                        string PropTypeText = GetTypeText(dllPropertyInfo.CSSPProp.PropType);
                        if (string.IsNullOrWhiteSpace(PropTypeText))
                        {
                            generateCodeStatusDBService.Error.AppendLine($"{ dllPropertyInfo.CSSPProp.PropType } { AppRes.IsNotImplemented }");
                            return false;
                        }

                        if (dllTypeInfoModels.Type.Name == "Contact" && (dllPropertyInfo.PropertyInfo.Name == "PasswordHash" || dllPropertyInfo.PropertyInfo.Name == "PasswordSalt"))
                        {
                            sb.AppendLine($@"        public byte[] { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }
                        else
                        {
                            string PropText = (dllPropertyInfo.CSSPProp.IsList ? PropTypeText.Replace(PropTypeText, $"List<{ PropTypeText }>") : (dllPropertyInfo.CSSPProp.IsIQueryable ? PropTypeText.Replace(PropTypeText, $"IQueryable<{ PropTypeText }>") : PropTypeText));
                            string IsNullable = (dllPropertyInfo.CSSPProp.IsNullable ? (UseQuestionMarkList.Contains(PropTypeText) || PropTypeText.EndsWith("Enum") ? "?" : "") : "");
                            sb.AppendLine($@"        public { PropText }{ IsNullable } { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }

                    }
                }
                sb.AppendLine(@"        #endregion Properties in DB");
                sb.AppendLine(@"");
                if (NotMappedClass)
                {
                    sb.AppendLine(@"        #region Properties not in DB");

                    foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfoModels.PropertyInfoList)
                    {
                        if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute || PropertiesToSkipList.Contains(dllPropertyInfo.CSSPProp.PropName))
                        {
                            continue;
                        }

                        if (!WriteAttributes(dllTypeInfoModels, dllPropertyInfo, sb))
                        {
                            return false;
                        }
                        string PropTypeText = GetTypeText(dllPropertyInfo.CSSPProp.PropType);
                        if (string.IsNullOrWhiteSpace(PropTypeText))
                        {
                            generateCodeStatusDBService.Error.AppendLine($"{ dllPropertyInfo.CSSPProp.PropType } { AppRes.IsNotImplemented }");
                            return false;
                        }

                        if (dllTypeInfoModels.Type.Name == "Contact" && (dllPropertyInfo.PropertyInfo.Name == "PasswordHash" || dllPropertyInfo.PropertyInfo.Name == "PasswordSalt"))
                        {
                            sb.AppendLine($@"        public byte[] { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }
                        else
                        {
                            string PropText = (dllPropertyInfo.CSSPProp.IsList ? PropTypeText.Replace(PropTypeText, $"List<{ PropTypeText }>") : (dllPropertyInfo.CSSPProp.IsIQueryable ? PropTypeText.Replace(PropTypeText, $"IQueryable<{ PropTypeText }>") : PropTypeText));
                            string IsNullable = (dllPropertyInfo.CSSPProp.IsNullable ? (UseQuestionMarkList.Contains(PropTypeText) || PropTypeText.EndsWith("Enum") ? "?" : "") : "");
                            sb.AppendLine($@"        public { PropText }{ IsNullable } { dllPropertyInfo.CSSPProp.PropName } {{ get; set; }}");
                        }
                    }
                    sb.AppendLine(@"        #endregion Properties not in DB");
                    sb.AppendLine(@"");
                }
                sb.AppendLine(@"        #region Constructors");
                if (dllTypeInfoModels.Type.Name == "AspNetUser")
                {
                    sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }()");
                }
                else
                {
                    sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }() : base()");
                }
                sb.AppendLine(@"        {");
                if (dllTypeInfoModels.Type.Name == "VPFull")
                {
                    sb.AppendLine(@"            VPAmbientList = new List<VPAmbient>();");
                    sb.AppendLine(@"            VPResultList = new List<VPResult>();");
                }
                if (dllTypeInfoModels.Type.Name == "TVLocation")
                {
                    sb.AppendLine(@"            MapObjList = new List<MapObj>();");
                }
                if (dllTypeInfoModels.Type.Name == "TVItemInfrastructureTypeTVItemLink")
                {
                    sb.AppendLine(@"            TVItemLinkList = new List<TVItemLink>();");
                }
                if (dllTypeInfoModels.Type.Name == "TVItemSubsectorAndMWQMSite")
                {
                    sb.AppendLine(@"            TVItemMWQMSiteList = new List<TVItem>();");
                }
                if (dllTypeInfoModels.Type.Name == "SearchTagAndTerms")
                {
                    sb.AppendLine(@"            SearchTermList = new List<string>();");
                }
                if (dllTypeInfoModels.Type.Name == "OtherFilesToUpload")
                {
                    sb.AppendLine(@"            TVFileList = new List<TVFile>();");
                }
                if (dllTypeInfoModels.Type.Name == "Node")
                {
                    sb.AppendLine(@"            ElementList = new List<Element>();");
                    sb.AppendLine(@"            ConnectNodeList = new List<Node>();");
                }
                if (dllTypeInfoModels.Type.Name == "MapObj")
                {
                    sb.AppendLine(@"            CoordList = new List<Coord>();");
                }
                if (dllTypeInfoModels.Type.Name == "LabSheetA1Sheet")
                {
                    sb.AppendLine(@"            LabSheetA1MeasurementList = new List<LabSheetA1Measurement>();");
                }
                if (dllTypeInfoModels.Type.Name == "Element")
                {
                    sb.AppendLine(@"            NodeList = new List<Node>();");
                }
                if (dllTypeInfoModels.Type.Name == "DataPathOfTide")
                {
                    sb.AppendLine(@"            Text = """";");
                    sb.AppendLine(@"            WebTideDataSet = null;");
                }
                if (dllTypeInfoModels.Type.Name == "CSSPWQInputParam")
                {
                    sb.AppendLine(@"            sidList = new List<string>();");
                    sb.AppendLine(@"            MWQMSiteList = new List<string>();");
                    sb.AppendLine(@"            MWQMSiteTVItemIDList = new List<int>();");
                    sb.AppendLine(@"            DailyDuplicateMWQMSiteList = new List<string>();");
                    sb.AppendLine(@"            DailyDuplicateMWQMSiteTVItemIDList = new List<int>();");
                    sb.AppendLine(@"            InfrastructureList = new List<string>();");
                    sb.AppendLine(@"            InfrastructureTVItemIDList = new List<int>();");
                }
                if (dllTypeInfoModels.Type.Name == "ContourPolygon")
                {
                    sb.AppendLine(@"            ContourNodeList = new List<Node>();");
                }
                if (dllTypeInfoModels.Type.Name == "Query")
                {
                    sb.AppendLine(@"            Language = LanguageEnum.en;");
                    sb.AppendLine(@"            Lang = ""en"";");
                    sb.AppendLine(@"            Skip = 0;");
                    sb.AppendLine(@"            Take = 200;");
                    sb.AppendLine(@"            Asc = """";");
                    sb.AppendLine(@"            Desc = """";");
                    sb.AppendLine(@"            Where = """";");
                    sb.AppendLine(@"            AscList = new List<string>();");
                    sb.AppendLine(@"            DescList = new List<string>();");
                    sb.AppendLine(@"            WhereInfoList = new List<WhereInfo>();");
                }

                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");

                sb.AppendLine(@"    }");

                List<PropertyInfo> BaseTypePropInfoList = dllTypeInfoModels.Type.GetProperties().ToList();
                if (!NotMappedClass)
                {
                    foreach (DLLTypeInfo dllTypeInfoModelsX in DLLTypeInfoCSSPModelsList)
                    {
                        if (dllTypeInfoModelsX.Type.Name == $"{ dllTypeInfoModels.Type.Name }")
                        {
                        }
                        BaseTypePropInfoList = dllTypeInfoModelsX.Type.GetProperties().ToList();
                    }
                }
                #endregion doing type

                sb.AppendLine(@"}");

                #region Comparing existing document with created document
                #endregion Comparing existing document with created document

                generateCodeStatusDBService.Status.AppendLine($"{ dllTypeInfoModels.Type.Name } { AppRes.ComparedOK } ...");
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ModelsCompare" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CodeFile", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\src\\{TypeName}.cs" },
                new AppSettingParameter() { Parameter = "CodeFileNotMapped", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\src\\_{TypeName}.cs" },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        private bool WriteAttributes(DLLTypeInfo dllTypeInfoModels, DLLPropertyInfo dllPropertyInfo, StringBuilder sb)
        {
            if (dllPropertyInfo.CSSPProp.IsKey)
            {
                sb.AppendLine(@"        [Key]");
            }
            if (dllPropertyInfo.CSSPProp.HasNotMappedAttribute)
            {
                sb.AppendLine(@"        [NotMapped]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPExistAttribute)
            {
                string AllowableTVTypeListText = "";
                foreach (CSSPEnums.TVTypeEnum tvType in dllPropertyInfo.CSSPProp.AllowableTVTypeList)
                {
                    AllowableTVTypeListText += $"{ ((int)tvType).ToString() },";
                }

                if (!string.IsNullOrWhiteSpace(AllowableTVTypeListText))
                {
                    AllowableTVTypeListText = AllowableTVTypeListText.Substring(0, AllowableTVTypeListText.Length - 1);
                }
                string AllowableTVTypeListEmptyOrNot = (!string.IsNullOrWhiteSpace(AllowableTVTypeListText) ? $@", AllowableTVTypeList = ""{ AllowableTVTypeListText }""" : "");
                sb.AppendLine($@"        [CSSPExist(ExistTypeName = ""{ dllPropertyInfo.CSSPProp.ExistTypeName }"", ExistPlurial = ""{ dllPropertyInfo.CSSPProp.ExistPlurial }"", ExistFieldID = ""{ dllPropertyInfo.CSSPProp.ExistFieldID }""{ AllowableTVTypeListEmptyOrNot })]");
            }
            if (dllPropertyInfo.CSSPProp.HasStringLengthAttribute)
            {
                string MinText = (dllPropertyInfo.CSSPProp.Min != null ? $", MinimumLength = { dllPropertyInfo.CSSPProp.Min.ToString() }" : "");
                sb.AppendLine($@"        [StringLength({ dllPropertyInfo.CSSPProp.Max }{ MinText })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute)
            {
                sb.AppendLine(@"        [CSSPEnumType]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPAfterAttribute)
            {
                sb.AppendLine($@"        [CSSPAfter(Year = { dllPropertyInfo.CSSPProp.Year })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPBiggerAttribute)
            {
                sb.AppendLine($@"        [CSSPBigger(OtherField = ""{ dllPropertyInfo.CSSPProp.OtherField }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPFillAttribute)
            {
                string FillNeedLanguage = (dllPropertyInfo.CSSPProp.FillNeedLanguage ? "true" : "false");
                string FillIsList = (dllPropertyInfo.CSSPProp.FillIsList ? "true" : "false");
                sb.AppendLine($@"        [CSSPFill(FillTypeName = ""{ dllPropertyInfo.CSSPProp.FillTypeName }"", FillPlurial = ""{ dllPropertyInfo.CSSPProp.FillPlurial }"", FillFieldID = ""{ dllPropertyInfo.CSSPProp.FillFieldID }"", FillEqualField = ""{ dllPropertyInfo.CSSPProp.FillEqualField }"", FillReturnField = ""{ dllPropertyInfo.CSSPProp.FillReturnField }"", FillNeedLanguage = { FillNeedLanguage }, FillIsList = { FillIsList })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeTextAttribute)
            {
                sb.AppendLine($@"        [CSSPEnumTypeText(EnumTypeName = ""{ dllPropertyInfo.CSSPProp.EnumTypeName }"", EnumType = ""{ dllPropertyInfo.CSSPProp.EnumType }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasDataTypeAttribute)
            {
                sb.AppendLine(@"        [DataType(DataType.EmailAddress)]");
            }
            if (dllPropertyInfo.CSSPProp.HasCompareAttribute)
            {
                sb.AppendLine($@"        [Compare(""{ dllPropertyInfo.CSSPProp.Compare }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasRangeAttribute)
            {
                string MinText = "";
                string MaxText = "";
                if (dllPropertyInfo.CSSPProp.Min != null)
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MinText = ((int)dllPropertyInfo.CSSPProp.Min).ToString("F0");
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MinText = $"{ ((float)dllPropertyInfo.CSSPProp.Min).ToString("F1") }f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MinText = $"{ ((double)dllPropertyInfo.CSSPProp.Min).ToString("F1") }D";
                    }
                }
                else
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MinText = "-1";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MinText = "-1.0f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MinText = "-1.0D";
                    }
                }
                if (dllPropertyInfo.CSSPProp.Max != null)
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MaxText = ((int)dllPropertyInfo.CSSPProp.Max).ToString("F0");
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MaxText = $"{ ((float)dllPropertyInfo.CSSPProp.Max).ToString("F1") }f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MaxText = $"{ ((double)dllPropertyInfo.CSSPProp.Max).ToString("F1") }D";
                    }
                }
                else
                {
                    if (dllPropertyInfo.CSSPProp.PropType == "Int16" || dllPropertyInfo.CSSPProp.PropType == "Int32" || dllPropertyInfo.CSSPProp.PropType == "Int64")
                    {
                        MaxText = "-1";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Single")
                    {
                        MaxText = "-1.0f";
                    }
                    else if (dllPropertyInfo.CSSPProp.PropType == "Double")
                    {
                        MaxText = "-1.0D";
                    }
                }
                sb.AppendLine($@"        [Range({ MinText }, { MaxText })]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPEnumTypeAttribute && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType == "String" && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType == "TVItemLanguage" && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType.EndsWith("Web") && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllPropertyInfo.CSSPProp.PropType.EndsWith("Report") && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllTypeInfoModels.HasNotMappedAttribute && dllPropertyInfo.CSSPProp.IsNullable)
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            else if (dllTypeInfoModels.Type.Name == "Contact" && (dllPropertyInfo.PropertyInfo.Name == "PasswordHash" || dllPropertyInfo.PropertyInfo.Name == "PasswordSalt"))
            {
                sb.AppendLine(@"        [CSSPAllowNull]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayENAttribute)
            {
                sb.AppendLine($@"        [CSSPDisplayEN(DisplayEN = ""{ dllPropertyInfo.CSSPProp.DisplayEN }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDisplayFRAttribute)
            {
                sb.AppendLine($@"        [CSSPDisplayFR(DisplayFR = ""{ dllPropertyInfo.CSSPProp.DisplayFR }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionENAttribute)
            {
                sb.AppendLine($@"        [CSSPDescriptionEN(DescriptionEN = @""{ dllPropertyInfo.CSSPProp.DescriptionEN.Replace("\"", "\"\"") }"")]");
            }
            if (dllPropertyInfo.CSSPProp.HasCSSPDescriptionFRAttribute)
            {
                sb.AppendLine($@"        [CSSPDescriptionFR(DescriptionFR = @""{ dllPropertyInfo.CSSPProp.DescriptionFR.Replace("\"", "\"\"") }"")]");
            }

            return true;
        }
        private string GetTypeText(string propTypeName)
        {
            switch (propTypeName)
            {
                case "Type":
                    return "Type";
                case "Boolean":
                    return "bool";
                case "Byte[]":
                    return "byte[]";
                case "DateTime":
                    return "DateTime";
                case "Double":
                    return "double";
                case "Single":
                    return "float";
                case "Int16":
                    return "int";
                case "Int32":
                    return "int";
                case "Int64":
                    return "long";
                case "String":
                    return "string";
                default:
                    return propTypeName;
            }
        }
        #endregion Functions private
    }
}