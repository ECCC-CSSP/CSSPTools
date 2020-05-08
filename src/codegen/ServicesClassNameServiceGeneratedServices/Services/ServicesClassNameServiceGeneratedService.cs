using CSSPEnums;
using CSSPModels;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicesClassNameServiceGeneratedServices.Resources;
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

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private CSSPDBContext dbCSSPDB { get; set; }
        private TestDBContext dbTestDB { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesClassNameServiceGeneratedService(IConfiguration configuration,
            IGenerateCodeStatusDBService generateCodeStatusDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService,
            CSSPDBContext dbCSSPDB,
            TestDBContext dbTestDB)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.generateCodeBaseService = generateCodeBaseService;
            this.dbCSSPDB = dbCSSPDB;
            this.dbTestDB = dbTestDB;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            SetCulture(args);

            ConsoleWriteStart();

            if (!await Setup()) return false;

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

            string CSSPDBConnectionString = configuration.GetValue<string>("CSSPDBConnectionString");
            string TestDBConnectionString = configuration.GetValue<string>("TestDBConnectionString");

            #region Variables and loading DLL properties
            FileInfo fiCSSPModelsDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

            List<DLLTypeInfo> DLLTypeInfoCSSPModelsList = new List<DLLTypeInfo>();
            if (generateCodeBaseService.FillDLLTypeInfoList(fiCSSPModelsDLL, DLLTypeInfoCSSPModelsList))
            {
                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotFindFile_, fiCSSPModelsDLL.FullName) }");
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
                bool NotMappedClass = false;
                StringBuilder sb = new StringBuilder();

                string TypeNameLower = "";

                if (dllTypeInfoModels.Type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 4).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(4) }";
                }
                else if (dllTypeInfoModels.Type.Name.StartsWith("TV") || dllTypeInfoModels.Type.Name.StartsWith("VP"))
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 2).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(2) }";
                }
                else
                {
                    TypeNameLower = $"{ dllTypeInfoModels.Type.Name.Substring(0, 1).ToLower() }{ dllTypeInfoModels.Type.Name.Substring(1) }";
                }

                if (generateCodeBaseService.SkipType(dllTypeInfoModels.Type))
                {
                    continue;
                }

                //if (type.Name != "Address")
                //{
                //    continue;
                //}

                if (dllTypeInfoModels.HasNotMappedAttribute)
                {
                    NotMappedClass = true;
                }
                else
                {
                    NotMappedClass = false;
                }

                #region Top
                sb.AppendLine(@"/*");
                sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Text;");
                sb.AppendLine(@"using System.Text.RegularExpressions;");
                sb.AppendLine(@"using System.Threading;");
                sb.AppendLine(@"using System.Threading.Tasks;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices");
                sb.AppendLine(@"{");
                #endregion Top

                sb.AppendLine($@"    public partial class { dllTypeInfoModels.Type.Name }Service : BaseService");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine($@"        public { dllTypeInfoModels.Type.Name }Service(Query query, CSSPDBContext db, int ContactID)");
                sb.AppendLine(@"            : base(query, db, ContactID)");
                sb.AppendLine(@"        {");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Validation");
                if (dllTypeInfoModels.Type.Name == "Contact")
                {
                    sb.AppendLine(@"        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactTypeEnum addContactType)");
                }
                else
                {
                    sb.AppendLine(@"        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)");
                }
                sb.AppendLine(@"        {");
                sb.AppendLine(@"            string retStr = """";");
                sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                sb.AppendLine($@"            { dllTypeInfoModels.Type.Name } { TypeNameLower } = validationContext.ObjectInstance as { dllTypeInfoModels.Type.Name };");
                sb.AppendLine($@"            { TypeNameLower }.HasErrors = false;");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in dllTypeInfoModels.Type.GetProperties())
                {
                    if (prop.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, dllTypeInfoModels.Type))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                        return false;
                    }

                    if (!NotMappedClass)
                    {
                        if (!CreateValidation_Key(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    }

                    if (!CreateValidation_NotNullable(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateValidation_Length(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateValidation_Email(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateValidation_AfterYear(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateValidation_Bigger(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateValidation_Exist(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateValidation_EnumType(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                }

                sb.AppendLine(@"            retStr = """"; // added to stop compiling CSSPError");
                sb.AppendLine(@"            if (retStr != """") // will never be true");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                sb.AppendLine(@"                yield return new ValidationResult(""AAA"", new[] { ""AAA"" });");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
                sb.AppendLine(@"        }");

                sb.AppendLine(@"        #endregion Validation");
                sb.AppendLine(@"");

                if (!NotMappedClass)
                {
                    if (!CreateClassServiceFunctionsPublicGenerateGet(dllTypeInfoModels, DLLTypeInfoCSSPModelsList, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateClassServiceFunctionsPublicGenerateCRUD(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                    if (!CreateClassServiceFunctionsPrivateRegionFillClass_x(dllTypeInfoModels, DLLTypeInfoCSSPModelsList, dllTypeInfoModels.Type.Name, TypeNameLower)) return false;
                    if (!CreateClassServiceFunctionsPrivateRegionTrySave(dllTypeInfoModels, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return false;
                }

                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = null;
                fiOutputGen = new FileInfo(configuration.GetValue<string>("ClassNameFile").Replace("{TypeName}", dllTypeInfoModels.Type.Name));

                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.Created_, fiOutputGen.FullName) }");

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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ServicesRepopulateTestDB" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPServices", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\bin\\Debug\\netcoreapp3.1\\CSSPServices.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPDBConnectionString", ExpectedValue = "Data Source=.\\sqlexpress;Initial Catalog=CSSPDB;Integrated Security=True" },
                new AppSettingParameter() { Parameter = "TestDBConnectionString", ExpectedValue = "Data Source=.\\sqlexpress;Initial Catalog=TestDB;Integrated Security=True" },
                new AppSettingParameter() { Parameter = "ClassNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPServices\\CSSPServices\\src\\{TypeName}ServiceGenerated.cs" },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        private bool CreateValidation_Key(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any())
            {
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)");
                sb.AppendLine(@"            {");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == """")");
                }
                else
                {
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == 0)");
                }
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                if (!(from c in db.{ TypeName }s select c).Where(c => c.Id == { TypeNameLower }.Id).Any())");
                }
                else
                {
                    if (TypeName == "Address")
                    {
                        sb.AppendLine($@"                if (!(from c in db.{ TypeName }es select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                    else
                    {
                        sb.AppendLine($@"                if (!(from c in db.{ TypeName }s select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                }
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }Id"", ({ TypeNameLower }.Id == null ? """" : { TypeNameLower }.Id.ToString())), new[] {{ ""{ csspProp.PropName }"" }});");
                }
                else
                {
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeNameLower }.{ TypeName }ID.ToString()), new[] {{ ""{ csspProp.PropName }"" }});");
                }
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                if (TypeName == "TVItem")
                {
                    sb.AppendLine(@"            if (tvItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    if (TypeName == "Address")
                    {
                        sb.AppendLine($@"                if ((from c in db.{ TypeName }es select c).Count() > 0)");
                    }
                    else
                    {
                        sb.AppendLine($@"                if ((from c in db.{ TypeName }s select c).Count() > 0)");
                    }
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine(@"                    yield return new ValidationResult(CSSPServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ""TVItemTVItemID"" });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

            }

            return true;
        }
        private bool CreateValidation_NotNullable(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsNullable)
                switch (prop.PropertyType.Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            //sb.AppendLine($@"            //{ prop.Name } ({ prop.PropertyType.Name }) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D");
                            //sb.AppendLine(@"");
                        }
                        break;
                    case "Boolean":
                        {
                            if (csspProp.PropName == "HasErrors")
                            {
                                // nothing yet
                            }
                            else
                            {
                                //sb.AppendLine($@"            //{ prop.Name } (bool) is required but no testing needed ");
                                //sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name }.Year == 1)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name }.Year < { csspProp.Year })");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ prop.Name }"", ""{ csspProp.Year }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        break;
                    case "String":
                        {
                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine($@"            if (string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }))");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (!csspProp.HasCSSPEnumTypeAttribute)
                            {
                                sb.AppendLine($@"                //CSSPError: Type not implemented [{ prop.Name }] of type [{ prop.PropertyType.Name }]");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                }

            return true;
        }
        private bool CreateValidation_Length(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsKey)
            {
                switch (csspProp.PropType)
                {
                    case "Boolean":
                        {
                            // nothing
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            // nothing
                        }
                        break;
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                if (!csspProp.HasCSSPExistAttribute)
                                {
                                    sb.AppendLine($@"            //{ prop.Name } has no Range Attribute");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (csspProp.IsNullable)
                                    {
                                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                        sb.AppendLine(@"                {");
                                        sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                        sb.AppendLine(@"                }");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                        sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() })");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() })");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }

                            }
                            else if (csspProp.Max != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else
                            {
                                sb.AppendLine($@"                { prop.Name } = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "String":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                sb.AppendLine($@"            //{ prop.Name } has no StringLength Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && ({ TypeNameLower }.{ csspProp.PropName }.Length < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName }.Length > { csspProp.Max.ToString() }))");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && { TypeNameLower }.{ csspProp.PropName }.Length < { csspProp.Min.ToString() })");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && { TypeNameLower }.{ csspProp.PropName }.Length > { csspProp.Max.ToString() })");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine($@"            // { prop.Name } has no validation");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                if (!csspProp.HasCSSPEnumTypeAttribute)
                                {
                                    sb.AppendLine($@"                //CSSPError: Type not implemented [{ csspProp.PropName }] of type [{ csspProp.PropType }]");
                                }
                            }
                        }
                        break;
                }
            }

            return true;
        }
        private bool CreateValidation_Email(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.dataType == DataType.EmailAddress)
            {
                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }))");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                Regex regex = new Regex(@""^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$"");");
                sb.AppendLine($@"                if (!regex.IsMatch({ TypeNameLower }.{ prop.Name }))");
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }

            return true;
        }
        private bool CreateValidation_AfterYear(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.Year != null)
            {
                if (csspProp.IsNullable == true)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null && ((DateTime){ TypeNameLower }.{ csspProp.PropName }).Year < { csspProp.Year })");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }

            return true;
        }
        private bool CreateValidation_Bigger(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.OtherField))
            {
                sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.OtherField } > { TypeNameLower }.{ csspProp.PropName })");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, ""{ csspProp.PropName }"", ""{ TypeName }{ csspProp.OtherField }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }

            return true;
        }
        private bool CreateValidation_Exist(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.ExistTypeName) && !string.IsNullOrWhiteSpace(csspProp.ExistPlurial) && !string.IsNullOrWhiteSpace(csspProp.ExistFieldID))
            {
                if (TypeName == "TVItem" && (csspProp.PropName == "ParentID" || csspProp.PropName == "LastUpdateContactTVItemID"))
                {
                    sb.AppendLine(@"            if (tvItem.TVType != TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial } where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"                }");
                    if (csspProp.ExistTypeName == "TVItem")
                    {
                        sb.AppendLine(@"                else");
                        sb.AppendLine(@"                {");
                        sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                        sb.AppendLine(@"                    {");
                        foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                        {
                            sb.AppendLine($@"                        TVTypeEnum.{ tvType.ToString() },");
                        }
                        sb.AppendLine(@"                    };");
                        sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine($@"                        { TypeNameLower }.HasErrors = true;");
                        sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ ""{ csspProp.PropName }"" }});");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine(@"                }");
                    }
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    if (csspProp.IsNullable)
                    {
                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial } where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ ""{ csspProp.PropName }"" }});");
                        sb.AppendLine(@"                }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"                else");
                            sb.AppendLine(@"                {");
                            sb.AppendLine(@"                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                    {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                        TVTypeEnum.{ tvType.ToString() },");
                            }
                            sb.AppendLine(@"                    };");
                            sb.AppendLine($@"                    if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                    {");
                            sb.AppendLine($@"                        { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                    }");
                            sb.AppendLine(@"                }");
                        }
                        sb.AppendLine(@"            }");
                        sb.AppendLine(@"");
                    }
                    else
                    {
                        sb.AppendLine($@"            { csspProp.ExistTypeName } { csspProp.ExistTypeName }{ csspProp.PropName } = (from c in db.{ csspProp.ExistTypeName }{ csspProp.ExistPlurial } where c.{ csspProp.ExistFieldID } == { TypeNameLower }.{ csspProp.PropName } select c).FirstOrDefault();");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"            if ({ csspProp.ExistTypeName }{ csspProp.PropName } == null)");
                        sb.AppendLine(@"            {");
                        sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                        if (TypeName == "Contact" && csspProp.PropName == "Id")
                        {
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", ({ TypeNameLower }.{ csspProp.PropName } == null ? """" : { TypeNameLower }.{ csspProp.PropName }.ToString())), new[] {{ ""{ csspProp.PropName }"" }});");
                        }
                        else
                        {
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), new[] {{ ""{ csspProp.PropName }"" }});");
                        }
                        sb.AppendLine(@"            }");
                        if (csspProp.ExistTypeName == "TVItem")
                        {
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine(@"                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()");
                            sb.AppendLine(@"                {");
                            foreach (TVTypeEnum tvType in csspProp.AllowableTVTypeList)
                            {
                                sb.AppendLine($@"                    TVTypeEnum.{ tvType.ToString() },");
                            }
                            sb.AppendLine(@"                };");
                            sb.AppendLine($@"                if (!AllowableTVTypes.Contains({ csspProp.ExistTypeName }{ csspProp.PropName }.TVType))");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                        }
                        sb.AppendLine(@"");
                    }
                }
            }

            return true;
        }
        private bool CreateValidation_EnumType(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.HasCSSPEnumTypeAttribute)
            {
                if (csspProp.IsNullable)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name } != null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == null || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine($@"            retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }

            return true;
        }
        private bool CreateClassServiceFunctionsPublicGenerateGet(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions public Generated Get");
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfo.PropertyInfoList)
            {
                if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (dllPropertyInfo.PropertyInfo.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!generateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, dllTypeInfo.Type))
                {
                    generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                    return false;
                }
                if (csspProp.IsKey)
                {
                    List<string> ClassNameList = new List<string>() { TypeName, $"{ TypeName }ExtraA", $"{ TypeName }ExtraB", $"{ TypeName }ExtraC", $"{ TypeName }ExtraD", $"{ TypeName }ExtraE" };
                    foreach (string ClassName in ClassNameList)
                    {
                        DLLTypeInfo currentDLLTypeInfo = null;
                        foreach (DLLTypeInfo dllTypeInfo2 in DLLTypeInfoCSSPModelsList)
                        {
                            if (dllTypeInfo2.Name == ClassName)
                            {
                                currentDLLTypeInfo = dllTypeInfo2;
                            }
                        }

                        if (currentDLLTypeInfo == null)
                        {
                            continue;
                        }

                        if (currentDLLTypeInfo.Name == "AspNetUser" || currentDLLTypeInfo.Name == "AspNetUserExtraA" || currentDLLTypeInfo.Name == "AspNetUserExtraB" || currentDLLTypeInfo.Name == "AspNetUserExtraC" || currentDLLTypeInfo.Name == "AspNetUserExtraD" || currentDLLTypeInfo.Name == "AspNetUserExtraE")
                        {
                            sb.AppendLine($@"        public { currentDLLTypeInfo.Name } Get{ currentDLLTypeInfo.Name }With{ TypeName }ID(string Id,");
                        }
                        else
                        {
                            sb.AppendLine($@"        public { currentDLLTypeInfo.Name } Get{ currentDLLTypeInfo.Name }With{ TypeName }ID(int { TypeName }ID)");
                        }
                        sb.AppendLine(@"        {");
                        if (currentDLLTypeInfo.Name == "AspNetUser")
                        {
                            sb.AppendLine($@"            return (from c in db.{ TypeName }s");
                            sb.AppendLine(@"                    where c.Id == Id");
                            sb.AppendLine(@"                    select c).FirstOrDefault();");
                        }
                        else if (currentDLLTypeInfo.Name.EndsWith("ExtraA") || currentDLLTypeInfo.Name.EndsWith("ExtraB") || currentDLLTypeInfo.Name.EndsWith("ExtraC") || currentDLLTypeInfo.Name.EndsWith("ExtraD") || currentDLLTypeInfo.Name.EndsWith("ExtraE"))
                        {
                            sb.AppendLine($@"            return Fill{ currentDLLTypeInfo.Name }().Where(c => c.{ TypeName }ID == { TypeName }ID).FirstOrDefault();");
                        }
                        else
                        {
                            if (currentDLLTypeInfo.Name.StartsWith("Address"))
                            {
                                sb.AppendLine($@"            return (from c in db.{ TypeName }es");
                            }
                            else
                            {
                                sb.AppendLine($@"            return (from c in db.{ TypeName }s");
                            }
                            sb.AppendLine($@"                    where c.{ TypeName }ID == { TypeName }ID");
                            sb.AppendLine(@"                    select c).FirstOrDefault();");
                        }
                        sb.AppendLine(@"");
                        sb.AppendLine(@"        }");

                        sb.AppendLine($@"        public IQueryable<{ currentDLLTypeInfo.Name }> Get{ currentDLLTypeInfo.Name }List()");
                        sb.AppendLine(@"        {");
                        if (currentDLLTypeInfo.Name.EndsWith("ExtraA") || currentDLLTypeInfo.Name.EndsWith("ExtraB") || currentDLLTypeInfo.Name.EndsWith("ExtraC") || currentDLLTypeInfo.Name.EndsWith("ExtraD") || currentDLLTypeInfo.Name.EndsWith("ExtraE"))
                        {
                            sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = Fill{ currentDLLTypeInfo.Name }();");
                        }
                        else
                        {
                            if (currentDLLTypeInfo.Name.StartsWith("Address"))
                            {
                                sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }es select c);");
                            }
                            else
                            {
                                sb.AppendLine($@"            IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }s select c);");
                            }
                        }
                        sb.AppendLine(@"");
                        sb.AppendLine($@"            { currentDLLTypeInfo.Name }Query = EnhanceQueryStatements<{ currentDLLTypeInfo.Name }>({ currentDLLTypeInfo.Name }Query) as IQueryable<{ currentDLLTypeInfo.Name }>;");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"            return { currentDLLTypeInfo.Name }Query;");
                        sb.AppendLine(@"        }");
                    }
                }
            }
            sb.AppendLine(@"        #endregion Functions public Generated Get");
            sb.AppendLine(@"");

            return true;
        }
        private bool CreateClassServiceFunctionsPublicGenerateCRUD(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "Address", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            sb.AppendLine(@"        #region Functions public Generated CRUD");

            if (TypeName == "Contact")
            {
                sb.AppendLine($@"        public bool Add({ TypeName } { TypeNameLower }, AddContactTypeEnum addContactType)");
            }
            else
            {
                sb.AppendLine($@"        public bool Add({ TypeName } { TypeNameLower })");
            }
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create, addContactType);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");

            sb.AppendLine($@"        public bool Delete({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Delete);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");

            sb.AppendLine($@"        public bool Update({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions public Generated CRUD");
            sb.AppendLine(@"");

            return true;
        }
        private bool CreateClassServiceFunctionsPrivateRegionFillClass_x(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList, string TypeName, string TypeNameLower)
        {
            if (TypeName == "AspNetUser")
            {
                return true;
            }

            List<string> ClassNameList = new List<string>() { $"{ TypeName }ExtraA", $"{ TypeName }ExtraB", $"{ TypeName }ExtraC", $"{ TypeName }ExtraD", $"{ TypeName }ExtraE" };
            foreach (string ClassName in ClassNameList)
            {
                StringBuilder sb = new StringBuilder();
                bool ClassContainsEnum = false;
                DLLTypeInfo currentDLLTypeInfo = null;

                foreach (DLLTypeInfo dllTypeInfo2 in DLLTypeInfoCSSPModelsList)
                {
                    if (dllTypeInfo2.Name == ClassName)
                    {
                        currentDLLTypeInfo = dllTypeInfo2;
                    }
                }

                if (currentDLLTypeInfo == null)
                {
                    continue;
                }

                #region Top
                sb.AppendLine(@"/*");
                sb.AppendLine(@" * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore;");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using System.ComponentModel.DataAnnotations;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Text;");
                sb.AppendLine(@"using System.Text.RegularExpressions;");
                sb.AppendLine(@"using System.Threading;");
                sb.AppendLine(@"using System.Threading.Tasks;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices");
                sb.AppendLine(@"{");
                #endregion Top

                sb.AppendLine($@"    public partial class { TypeName }Service");
                sb.AppendLine(@"    {");
                sb.AppendLine($@"        #region Functions private Generated Fill{ currentDLLTypeInfo.Name }");

                sb.AppendLine($@"        private IQueryable<{ currentDLLTypeInfo.Name }> Fill{ currentDLLTypeInfo.Name }()");
                sb.AppendLine(@"        {");

                foreach (DLLPropertyInfo dllPropertyInfo in currentDLLTypeInfo.PropertyInfoList)
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!generateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, currentDLLTypeInfo.Type))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                        return false;
                    }
                    if (csspProp.HasCSSPEnumTypeAttribute)
                    {
                        ClassContainsEnum = true;
                        break;
                    }
                }

                if (ClassContainsEnum)
                {
                    sb.AppendLine(@"            Enums enums = new Enums(LanguageRequest);");
                    sb.AppendLine(@"");
                    List<string> EnumTypeNameAddedList = new List<string>();
                    foreach (DLLPropertyInfo dllPropertyInfo in currentDLLTypeInfo.PropertyInfoList)
                    {
                        if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                        {
                            continue;
                        }

                        if (dllPropertyInfo.PropertyInfo.Name == "ValidationResults")
                        {
                            continue;
                        }

                        CSSPProp csspProp = new CSSPProp();
                        if (!generateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, currentDLLTypeInfo.Type))
                        {
                            generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                            return false;
                        }
                        if (csspProp.HasCSSPEnumTypeTextAttribute)
                        {
                            if (!EnumTypeNameAddedList.Contains(csspProp.EnumTypeName))
                            {
                                sb.AppendLine($@"            List<EnumIDAndText> { csspProp.EnumTypeName }List = enums.GetEnumTextOrderedList(typeof({ csspProp.EnumTypeName }));");
                                EnumTypeNameAddedList.Add(csspProp.EnumTypeName);
                            }
                        }
                    }
                    sb.AppendLine(@"");
                }

                if (TypeName == "Address")
                {
                    sb.AppendLine($@"             IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }es");
                }
                else
                {
                    sb.AppendLine($@"             IQueryable<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name }Query = (from c in db.{ TypeName }s");
                }

                List<string> PropertyConstructedList = new List<string>();

                foreach (DLLPropertyInfo dllPropertyInfo in currentDLLTypeInfo.PropertyInfoList)
                {
                    if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (dllPropertyInfo.PropertyInfo.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!generateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, currentDLLTypeInfo.Type))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                        return false;
                    }
                    if (csspProp.HasCSSPEnumTypeAttribute)
                    {
                        ClassContainsEnum = true;
                    }
                    if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        sb.AppendLine($@"                let { csspProp.PropName } = (from e in { csspProp.EnumTypeName }List");
                        sb.AppendLine($@"                    where e.EnumID == (int?)c.{ csspProp.EnumType }");
                        sb.AppendLine(@"                    select e.EnumText).FirstOrDefault()");
                    }
                    if (csspProp.HasCSSPFillAttribute)
                    {
                        sb.AppendLine($@"                let { csspProp.PropName } = (from cl in db.{ csspProp.FillTypeName }{ csspProp.FillPlurial }");
                        sb.AppendLine($@"                    where cl.{ csspProp.FillFieldID } == c.{ csspProp.FillEqualField }");
                        if (csspProp.FillNeedLanguage)
                        {
                            sb.AppendLine(@"                    && cl.Language == LanguageRequest");
                        }
                        if (!string.IsNullOrWhiteSpace(csspProp.FillReturnField))
                        {
                            sb.AppendLine($@"                    select cl.{ csspProp.FillReturnField }).FirstOrDefault()");
                        }
                        else
                        {
                            if (csspProp.FillIsList)
                            {
                                sb.AppendLine(@"                    select cl)");
                            }
                            else
                            {
                                sb.AppendLine(@"                    select cl).FirstOrDefault()");
                            }
                        }

                        PropertyConstructedList.Add(dllPropertyInfo.PropertyInfo.Name);
                    }
                }
                sb.AppendLine($@"                    select new { currentDLLTypeInfo.Name }");
                sb.AppendLine(@"                    {");
                foreach (DLLPropertyInfo dllPropertyInfo in currentDLLTypeInfo.PropertyInfoList)
                {
                    if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                    {
                        continue;
                    }

                    if (dllPropertyInfo.PropertyInfo.Name == "ValidationResults" || dllPropertyInfo.PropertyInfo.Name == "HasErrors" || dllPropertyInfo.PropertyInfo.Name.EndsWith("Report") || dllPropertyInfo.PropertyInfo.Name.EndsWith("Report"))
                    {
                        continue;
                    }

                    CSSPProp csspProp = new CSSPProp();
                    if (!generateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, currentDLLTypeInfo.Type))
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                        return false;
                    }
                    if (currentDLLTypeInfo.Name == "ContactLogin" && dllPropertyInfo.PropertyInfo.Name == "PasswordHash")
                    {
                        continue;
                    }
                    if (currentDLLTypeInfo.Name == "ContactLogin" && dllPropertyInfo.PropertyInfo.Name == "PasswordSalt")
                    {
                        continue;
                    }

                    if (dllPropertyInfo.PropertyInfo.Name == $"{ currentDLLTypeInfo.Name }Test")
                    {
                        sb.AppendLine($@"                        { csspProp.PropName } = ""Testing Report"",");
                    }
                    else if (PropertyConstructedList.Contains(dllPropertyInfo.PropertyInfo.Name))
                    {
                        sb.AppendLine($@"                        { csspProp.PropName } = { csspProp.PropName },");
                    }
                    else if (csspProp.HasCSSPEnumTypeTextAttribute)
                    {
                        sb.AppendLine($@"                        { csspProp.PropName } = { csspProp.PropName },");
                    }
                    else
                    {
                        sb.AppendLine($@"                        { csspProp.PropName } = c.{ csspProp.PropName },");
                    }
                }
                sb.AppendLine(@"                        HasErrors = false,");
                sb.AppendLine(@"                        ValidationResults = null,");
                sb.AppendLine(@"                    }).AsNoTracking();");
                sb.AppendLine(@"");
                sb.AppendLine($@"            return { currentDLLTypeInfo.Name }Query;");
                sb.AppendLine(@"        }");
                sb.AppendLine($@"        #endregion Functions private Generated Fill{ currentDLLTypeInfo.Name }");
                sb.AppendLine(@"");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                DirectoryInfo di;
                di = new DirectoryInfo($@"C:\CSSPCode\CSSPServices\CSSPServices\src\Extra{ ClassName.Substring(ClassName.Length - 1) }\");

                if (!di.Exists)
                {
                    try
                    {
                        di.Create();
                    }
                    catch (Exception)
                    {
                        generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.CouldNotCreateDirectory_, di.FullName) }");
                        return false;
                    }
                }

                FileInfo fiOutputGen = new FileInfo($@"{ di.FullName }\{ currentDLLTypeInfo.Name }Service.cs");

                using (StreamWriter sw = fiOutputGen.CreateText())
                {
                    sw.Write(sb.ToString());
                }

                generateCodeStatusDBService.Error.AppendLine($"{ string.Format(AppRes.Created_, fiOutputGen.FullName) }");
            }

            return true;
        }
        private bool CreateClassServiceFunctionsPrivateRegionTrySave(DLLTypeInfo dllTypeInfo, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Functions private Generated TryToSave");
            sb.AppendLine($@"        private bool TryToSave({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                { TypeNameLower }.ValidationResults = new List<ValidationResult>() {{ new ValidationResult(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")) }}.AsEnumerable();");
            sb.AppendLine(@"                return false;");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions private Generated TryToSave");
            sb.AppendLine(@"");

            return true;
        }
        #endregion Functions private
    }
}