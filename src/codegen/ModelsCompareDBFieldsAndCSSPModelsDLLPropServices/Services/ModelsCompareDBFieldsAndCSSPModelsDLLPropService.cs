using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Resources;
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

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public class ModelsCompareDBFieldsAndCSSPModelsDLLPropService : IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private string CSSPDBConnectionString { get; set; }
        private List<TableFieldEnumException> TableFieldEnumExceptionList { get; set; }
        private List<TableFieldEmail> TableFieldEmailList { get; set; }
        private List<TableFieldIDException> TableFieldIDExceptionList { get; set; }
        #endregion Properties

        #region Constructors
        public ModelsCompareDBFieldsAndCSSPModelsDLLPropService(IConfiguration configuration,
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

            CSSPDBConnectionString = configuration.GetValue<string>("CSSPDBConnectionString");

            if (CSSPDBConnectionString == null)
            {
                await ConsoleWriteError("CSSPDBConnectionString == null");
                return false;
            }

            generateCodeStatusDBService.Status.AppendLine("Generate Starting ...");
            await generateCodeStatusDBService.Update(10);

            FillPublicList();

            List<Table> tableCSSPWebList = new List<Table>();
            List<TypeProp> typePropList = new List<TypeProp>();

            // loading what currently exist in the DB
            if (!LoadDBInfo(tableCSSPWebList, CSSPDBConnectionString))
            {
                return false;
            }

            // Loading what exist in the compiled CSSPModels.dll
            if (!LoadCSSPModelsDLLInfo(typePropList))
            {
                return false;
            }

            // Compare DB and Compiled CSSPModels.DLL
            if (!CompareDBAndCSSPModelsDLL(tableCSSPWebList, typePropList))
            {
                return false;
            }

            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine("Generate Finished ...");
            await generateCodeStatusDBService.Update(100);

            return true;
        }
        private bool CompareDBAndCSSPModelsDLL(List<Table> tableList, List<TypeProp> typePropList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Comparing DB Fields name that does not exist in the CSSPModels.DLL");
            sb.AppendLine("");
            foreach (Table table in tableList.OrderBy(c => c.TableName))
            {
                if (table.TableName.StartsWith("AspNet") || table.TableName.StartsWith("sys"))
                {
                    continue;
                }

                TypeProp typePropExist = (from c in typePropList
                                          let t = c.type.Name + c.Plurial
                                          where t == table.TableName
                                          select c).FirstOrDefault();

                if (typePropExist == null)
                {
                    sb.AppendLine($"{ table.TableName } ---------------- object does not exist for table");
                    sb.AppendLine("\r\n");
                }
                foreach (Col col in table.colList)
                {
                    TypeProp typeProp = (from c in typePropList
                                         where (c.type.Name + c.Plurial) == table.TableName
                                         select c).FirstOrDefault();

                    if (typeProp != null)
                    {
                        // ---------------------------------------
                        // Check if field name exist
                        // ---------------------------------------
                        CSSPProp csspProp = (from c in typeProp.csspPropList
                                             where c.PropName == col.FieldName
                                             select c).FirstOrDefault();

                        if (csspProp == null)
                        {
                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- does not exist");
                            continue;
                        }

                        if (csspProp.IsNullable != col.AllowNull)
                        {
                            string NullOrNot = (col.AllowNull ? "Nullable" : "Not Nullable");
                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should be { NullOrNot }");
                            continue;
                        }

                        // ---------------------------------------
                        // Check if field types correspond and proper Attributes
                        // ---------------------------------------
                        switch (col.DataType)
                        {
                            case "bit":
                                {
                                    if (csspProp.PropType != "Boolean")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Boolean]");
                                    }
                                }
                                break;
                            case "bigint":
                                {
                                    if (csspProp.PropType != "Int64")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Int64]");
                                    }

                                    if (csspProp.HasCSSPExistAttribute)
                                    {
                                        if (csspProp.HasRangeAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should NOT have a Range Attribute");
                                        }
                                    }
                                    else
                                    {
                                        if (!csspProp.HasRangeAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a Range Attribute");
                                        }
                                    }
                                }
                                break;
                            case "int":
                                {
                                    if (csspProp.PropType != "Int32")
                                    {
                                        if ($"{ col.FieldName }Enum" != csspProp.PropType)
                                        {
                                            TableFieldEnumException tableFieldEnumException = TableFieldEnumExceptionList.Where(c => c.TableName == table.TableName && c.FieldName == col.FieldName).FirstOrDefault();
                                            if (tableFieldEnumException == null)
                                            {
                                                sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Int32]");
                                                sb.AppendLine("\r\n");
                                                sb.AppendLine("You might need to add this enumeration type within the FillPublicList() within the ModelsGenerateCodeHelper.cs\r\n");
                                                sb.AppendLine("Suggestion line to add:\r\n");
                                                sb.AppendLine($@"new TableFieldEnumException() {{ TableName = ""{ table.TableName }"", FieldName = ""{ col.FieldName }"", EnumText = ""{ csspProp.PropType }"" }},\r\n");
                                            }
                                            else
                                            {
                                                if (tableFieldEnumException.EnumText != csspProp.PropType)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Int32]");
                                                }

                                                if (!csspProp.HasCSSPEnumTypeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPEnumType Attribute");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (!csspProp.HasCSSPEnumTypeAttribute)
                                            {
                                                sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPEnumType Attribute");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!csspProp.IsKey)
                                        {
                                            if (csspProp.HasCSSPExistAttribute)
                                            {
                                                if (csspProp.HasRangeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should NOT have a Range Attribute");
                                                }
                                            }
                                            else
                                            {
                                                if (!csspProp.HasRangeAttribute)
                                                {
                                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a Range Attribute");
                                                }
                                            }

                                            if (csspProp.PropName.EndsWith("ID"))
                                            {
                                                TableFieldIDException tableFieldIDException = TableFieldIDExceptionList.Where(c => c.TableName == table.TableName && c.FieldName == col.FieldName).FirstOrDefault();
                                                if (tableFieldIDException == null)
                                                {
                                                    if (!csspProp.HasCSSPExistAttribute)
                                                    {
                                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPExist Attribute");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            case "datetime":
                                {
                                    if (csspProp.PropType != "DateTime")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [DateTime]");
                                    }

                                    if (!csspProp.HasCSSPAfterAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPAfter Attribute");
                                    }

                                    if (csspProp.PropName.ToUpper().StartsWith("END"))
                                    {
                                        if (!csspProp.HasCSSPBiggerAttribute)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a CSSPBigger Attribute");
                                        }
                                    }
                                }
                                break;
                            case "text":
                                {
                                    if (csspProp.PropType != "String")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [String]");
                                    }
                                }
                                break;
                            case "nchar":
                            case "nvarchar":
                                {
                                    if (csspProp.PropType != "String")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [String]");
                                    }

                                    if (!csspProp.HasStringLengthAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a StringLength Attribute");
                                    }

                                    TableFieldEmail tableFieldEmail = TableFieldEmailList.Where(c => c.TableName == table.TableName && c.FieldName == col.FieldName).FirstOrDefault();
                                    if (tableFieldEmail != null)
                                    {
                                        if (csspProp.dataType != DataType.EmailAddress)
                                        {
                                            sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a DataType Attribute set to email");
                                        }
                                    }
                                }
                                break;
                            case "float":
                                {
                                    if (csspProp.PropType != "Double")
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- wrong type It is [{ csspProp.PropType }] should be [Double]");
                                    }

                                    if (!csspProp.HasRangeAttribute)
                                    {
                                        sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- should have a Range Attribute");
                                    }
                                }
                                break;
                            case "varbinary":
                                {
                                    // don't know what to check yet
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine($"{ table.TableName }\t{ col.FieldName }\t---------------- not implemented [{ col.DataType }]");
                                }
                                break;
                        }

                    }
                }
            }

            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Comparing CSSPModels.DLL properties that does not exist in DB");
            sb.AppendLine("");
            foreach (TypeProp typeProp in typePropList.OrderBy(c => c.type.Name))
            {
                if (typeProp.type.CustomAttributes.Where(c => c.AttributeType.FullName.Contains("NotMappedAttribute")).Any())
                {
                    continue;
                }

                foreach (CSSPProp csspProp in typeProp.csspPropList)
                {
                    if (csspProp.IsVirtual)
                    {
                        continue;
                    }

                    if (csspProp.PropName == "ValidationResults")
                    {
                        continue;
                    }

                    if (csspProp.HasNotMappedAttribute)
                    {
                        continue;
                    }

                    if (generateCodeBaseService.SkipType(typeProp.type))
                    {
                        continue;
                    }

                    string tableName = $"{ typeProp.type.Name }{ typeProp.Plurial }";
                    Table table = (from c in tableList
                                   where c.TableName == tableName
                                   select c).FirstOrDefault();

                    if (table == null)
                    {
                        sb.AppendLine($"{ typeProp.type.Name }\t{ csspProp.PropName }\t---------------- does not exist");
                        continue;
                    }

                    Col col = (from c in table.colList
                               where c.FieldName == csspProp.PropName
                               select c).FirstOrDefault();

                    if (col == null)
                    {
                        sb.AppendLine($"{ typeProp.type.Name }\t{ csspProp.PropName }\t---------------- does not exist");
                    }
                }
            }

            generateCodeStatusDBService.Status.AppendLine(sb.ToString());
            //StatusPermanentEvent(new StatusEventArgs(sb.ToString()));

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
        private void FillPublicList()
        {
            TableFieldEnumExceptionList = new List<TableFieldEnumException>()
            {
                new TableFieldEnumException() { TableName = "MWQMAnalysisReportParameters", FieldName = "Command", EnumText = "AnalysisReportExportCommandEnum" },
                new TableFieldEnumException() { TableName = "MWQMRunLanguages", FieldName = "TranslationStatusRunComment", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMRunLanguages", FieldName = "TranslationStatusRunWeatherComment", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "RunSampleType", EnumText = "SampleTypeEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "SeaStateAtStart_BeaufortScale", EnumText = "BeaufortScaleEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "SeaStateAtEnd_BeaufortScale", EnumText = "BeaufortScaleEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "Tide_Start", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "MWQMRuns", FieldName = "Tide_End", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "MWQMSubsectorLanguages", FieldName = "TranslationStatusSubsectorDesc", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMSubsectorLanguages", FieldName = "TranslationStatusLogBook", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "MWQMSamples", FieldName = "SampleType_old", EnumText = "SampleTypeEnum" },
                new TableFieldEnumException() { TableName = "PolSourceSites", FieldName = "InactiveReason", EnumText = "PolSourceInactiveReasonEnum" },
                new TableFieldEnumException() { TableName = "ReportTypeLanguages", FieldName = "TranslationStatusName", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportTypeLanguages", FieldName = "TranslationStatusDescription", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportTypeLanguages", FieldName = "TranslationStatusStartOfFileName", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportSectionLanguages", FieldName = "TranslationStatusReportSectionName", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "ReportSectionLanguages", FieldName = "TranslationStatusReportSectionText", EnumText = "TranslationStatusEnum" },
                new TableFieldEnumException() { TableName = "SamplingPlans", FieldName = "AnalyzeMethodDefault", EnumText = "AnalyzeMethodEnum" },
                new TableFieldEnumException() { TableName = "SamplingPlans", FieldName = "SampleMatrixDefault", EnumText = "SampleMatrixEnum" },
                new TableFieldEnumException() { TableName = "SamplingPlans", FieldName = "LaboratoryDefault", EnumText = "LaboratoryEnum" },
                new TableFieldEnumException() { TableName = "TideDataValues", FieldName = "TideStart", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "TideDataValues", FieldName = "TideEnd", EnumText = "TideTextEnum" },
                new TableFieldEnumException() { TableName = "TVFiles", FieldName = "TemplateTVType", EnumText = "TVTypeEnum" },
                new TableFieldEnumException() { TableName = "TVItemLinks", FieldName = "FromTVType", EnumText = "TVTypeEnum" },
                new TableFieldEnumException() { TableName = "TVItemLinks", FieldName = "ToTVType", EnumText = "TVTypeEnum" },
                new TableFieldEnumException() { TableName = "VPScenarios", FieldName = "VPScenarioStatus", EnumText = "ScenarioStatusEnum" },
            };

            TableFieldEmailList = new List<TableFieldEmail>()
            {
                new TableFieldEmail() { TableName = "ContactLogins", FieldName = "LoginEmail" },
                new TableFieldEmail() { TableName = "Contacts", FieldName = "LoginEmail" },
                new TableFieldEmail() { TableName = "EmailDistributionListContacts", FieldName = "Email" },
                new TableFieldEmail() { TableName = "Emails", FieldName = "EmailAddress" },
            };

            TableFieldIDExceptionList = new List<TableFieldIDException>()
            {
                new TableFieldIDException() { TableName = "ClimateSites", FieldName = "ECDBID" },
                new TableFieldIDException() { TableName = "ClimateSites", FieldName = "WMOID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "PrismID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "TPID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "LSID" },
                new TableFieldIDException() { TableName = "Infrastructures", FieldName = "SiteID" },
                new TableFieldIDException() { TableName = "LabSheets", FieldName = "OtherServerLabSheetID" },
                new TableFieldIDException() { TableName = "Logs", FieldName = "ID" },
                new TableFieldIDException() { TableName = "PolSourceSites", FieldName = "SiteID" },
            };
        }
        private bool LoadDBInfo(List<Table> tableList, string ConnectionString)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    DataTable tblList = cnn.GetSchema("Tables");
                    DataTable clmList = cnn.GetSchema("Columns");

                    foreach (DataRow tbl in tblList.Rows)
                    {
                        Table table = new Table();
                        table.TableName = tbl.ItemArray[2].ToString();
                        tableList.Add(table);

                        foreach (DataRow dr in clmList.Rows)
                        {
                            if (dr[2].ToString() == table.TableName)
                            {
                                Col col = new Col();
                                col.FieldName = dr[3].ToString();
                                col.AllowNull = (dr[6].ToString() == "NO" ? false : true);
                                col.DataType = dr[7].ToString();
                                col.StringLength = (string.IsNullOrWhiteSpace(dr[8].ToString()) ? 0 : int.Parse(dr[8].ToString()));

                                table.colList.Add(col);
                            }
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                generateCodeStatusDBService.Error.AppendLine(ex.Message);
                return false;
            }

            return true;
        }
        private bool LoadCSSPModelsDLLInfo(List<TypeProp> typePropList)
        {

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

            try
            {
                var importAssembly = Assembly.LoadFile(fiDLL.FullName);
                Type[] types = importAssembly.GetTypes();

                foreach (Type type in types)
                {
                    TypeProp typeProp = new TypeProp();
                    typeProp.type = type;
                    typeProp.Plurial = "s";
                    if (type.Name == "Address")
                    {
                        typeProp.Plurial = "es";
                    }

                    //if (type.Name == "AddressWeb")
                    //{
                    //    int seflij = 34;
                    //}
                    if (generateCodeBaseService.SkipType(type))
                    {
                        continue;
                    }

                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        if (propertyInfo.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (propertyInfo.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!generateCodeBaseService.FillCSSPProp(propertyInfo, csspProp, type))
                        {
                            generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            return false;
                        }

                        typeProp.csspPropList.Add(csspProp);
                    }


                    typePropList.Add(typeProp);
                }
            }
            catch (Exception ex)
            {
                generateCodeStatusDBService.Error.AppendLine(ex.Message);
                return false;
            }

            return true;
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
                new AppSettingParameter() { Parameter = "CSSPDBConnectionString", ExpectedValue = "Server=.\\sqlexpress;Database=CSSPDB;Trusted_Connection=True;MultipleActiveResultSets=true" },
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