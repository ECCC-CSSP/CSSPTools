using CSSPEnums;
using CSSPModels;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServicesClassNameServiceTestGeneratedServices.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
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
        public ServicesClassNameServiceTestGeneratedService(IConfiguration configuration,
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

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            List<Type> types = importAssembly.GetTypes().ToList();
            foreach (Type type in types)
            {
                bool ClassNotMapped = false;
                StringBuilder sb = new StringBuilder();
                string TypeName = type.Name;

                string TypeNameLower = "";

                if (type.Name.StartsWith("MWQM"))
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 4).ToLower() }{ type.Name.Substring(4) }";
                }
                else if (type.Name.StartsWith("TV") || type.Name.StartsWith("VP"))
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 2).ToLower() }{ type.Name.Substring(2) }";
                }
                else
                {
                    TypeNameLower = $"{ type.Name.Substring(0, 1).ToLower() }{ type.Name.Substring(1) }";
                }

                if (generateCodeBaseService.SkipType(type))
                {
                    continue;
                }

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                //if (TypeName != "Address")
                //{
                //    continue;
                //}

                sb.AppendLine(@" /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button");
                sb.AppendLine(@" *");
                sb.AppendLine(@" * Do not edit this file.");
                sb.AppendLine(@" *");
                sb.AppendLine(@" */ ");
                sb.AppendLine(@"");
                sb.AppendLine(@"using System;");
                sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
                sb.AppendLine(@"using System.Linq;");
                sb.AppendLine(@"using System.Collections.Generic;");
                sb.AppendLine(@"using CSSPModels;");
                sb.AppendLine(@"using CSSPServices;");
                sb.AppendLine(@"using Microsoft.EntityFrameworkCore.Metadata;");
                sb.AppendLine(@"using System.Reflection;");
                sb.AppendLine(@"using CSSPEnums;");
                sb.AppendLine(@"using System.Security.Principal;");
                sb.AppendLine(@"using System.Globalization;");
                sb.AppendLine(@"using CSSPServices.Resources;");
                sb.AppendLine(@"using CSSPModels.Resources;");
                sb.AppendLine(@"using CSSPEnums.Resources;");
                sb.AppendLine(@"");
                sb.AppendLine(@"namespace CSSPServices.Tests");
                sb.AppendLine(@"{");
                sb.AppendLine(@"    [TestClass]");
                sb.AppendLine($@"    public partial class { TypeName }ServiceTest : TestHelper");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"        #region Variables");
                sb.AppendLine(@"        #endregion Variables");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Properties");
                sb.AppendLine($@"        //private { TypeName }Service { TypeNameLower }Service {{ get; set; }}");
                sb.AppendLine(@"        #endregion Properties");
                sb.AppendLine(@"");
                sb.AppendLine(@"        #region Constructors");
                sb.AppendLine($@"        public { TypeName }ServiceTest() : base()");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            //{ TypeNameLower }Service = new { TypeName }Service(LanguageRequest, dbTestDB, ContactID);");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Constructors");
                sb.AppendLine(@"");
                if (!ClassNotMapped)
                {
                    GenerateCRUDTestCode(TypeName, TypeNameLower, sb);

                    GeneratePropertiesTestCode(TypeName, TypeNameLower, type, sb);

                    GenerateGetWithIDTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeAscTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTake2AscTestCode(TypeName, TypeNameLower, type, types, sb);

                    GenerateGetListSkipTakeAscWhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeAsc2WhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeDescTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTake2DescTestCode(TypeName, TypeNameLower, type, types, sb);

                    GenerateGetListSkipTakeDescWhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetListSkipTakeDesc2WhereTestCode(TypeName, TypeNameLower, types, sb);

                    GenerateGetList2WhereTestCode(TypeName, TypeNameLower, types, sb);
                }
                sb.AppendLine(@"        #region Functions private");
                if (!ClassNotMapped)
                {
                    sb.AppendLine($@"        private void Check{ TypeName }Fields(List<{ TypeName }> { TypeNameLower }List)");
                    sb.AppendLine(@"        {");
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        CSSPProp csspProp = new CSSPProp();
                        if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                        {
                            return false;
                        }
                        if (csspProp.PropName == "ValidationResults")
                        {
                            continue;
                        }

                        if (TypeName == "ContactLogin" && (csspProp.PropName == "PasswordHash" || csspProp.PropName == "PasswordSalt"))
                        {
                            continue;
                        }

                        if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                        {
                            continue;
                        }

                        if (csspProp.IsNullable)
                        {
                            if (csspProp.PropType == "String")
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }))");
                            }
                            else
                            {
                                sb.AppendLine($@"            if ({ TypeNameLower }List[0].{ csspProp.PropName } != null)");
                            }
                            sb.AppendLine(@"            {");
                        }
                        if (csspProp.PropType == "String")
                        {
                            sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsFalse(string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }));");
                        }
                        else
                        {
                            sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsNotNull({ TypeNameLower }List[0].{ csspProp.PropName });");
                        }
                        if (csspProp.IsNullable)
                        {
                            sb.AppendLine(@"            }");
                        }
                    }
                    sb.AppendLine(@"        }");
                    foreach (string extra in new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        Type currentType = null;
                        foreach (Type typeDetail in types)
                        {
                            if ($"{ type.Name }{ extra }" == typeDetail.Name)
                            {
                                currentType = typeDetail;
                                break;
                            }
                        }

                        if (currentType == null)
                        {
                            continue;
                        }

                        sb.AppendLine($@"        private void Check{ TypeName }{ extra }Fields(List<{ TypeName }{ extra }> { TypeNameLower }{ extra }List)");
                        sb.AppendLine(@"        {");

                        foreach (PropertyInfo prop in currentType.GetProperties())
                        {
                            CSSPProp csspProp = new CSSPProp();
                            if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, currentType))
                            {
                                return false;
                            }
                            if (csspProp.PropName == "ValidationResults")
                            {
                                continue;
                            }

                            if (TypeName == "ContactLogin" && (csspProp.PropName == "PasswordHash" || csspProp.PropName == "PasswordSalt"))
                            {
                                continue;
                            }

                            if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                            {
                                continue;
                            }

                            if (csspProp.IsNullable)
                            {
                                if (csspProp.PropType == "String")
                                {
                                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }{ extra }List[0].{ csspProp.PropName }))");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }{ extra }List[0].{ csspProp.PropName } != null)");
                                }
                                sb.AppendLine(@"            {");
                            }
                            if (csspProp.PropType == "String")
                            {
                                sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsFalse(string.IsNullOrWhiteSpace({ TypeNameLower }{ extra }List[0].{ csspProp.PropName }));");
                            }
                            else
                            {
                                sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsNotNull({ TypeNameLower }{ extra }List[0].{ csspProp.PropName });");
                            }
                            if (csspProp.IsNullable)
                            {
                                sb.AppendLine(@"            }");
                            }
                        }
                        sb.AppendLine(@"        }");

                    }
                }
                sb.AppendLine($@"        private { TypeName } GetFilledRandom{ TypeName }(string OmitPropName)");
                sb.AppendLine(@"        {");
                sb.AppendLine($@"            { TypeName } { TypeNameLower } = new { TypeName }();");
                sb.AppendLine(@"");

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    CSSPProp csspProp = new CSSPProp();
                    if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                    {
                        return false;
                    }

                    if (csspProp.IsKey || prop.GetGetMethod().IsVirtual || prop.Name == "ValidationResults")
                    {
                        continue;
                    }

                    CreateGetFilledRandomClass(prop, csspProp, TypeName, TypeNameLower, sb);
                }

                sb.AppendLine(@"");
                sb.AppendLine($@"            return { TypeNameLower };");
                sb.AppendLine(@"        }");
                sb.AppendLine(@"        #endregion Functions private");
                sb.AppendLine(@"    }");
                sb.AppendLine(@"}");

                FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("ClassNameFile").Replace("{TypeName}", TypeName));
                using (StreamWriter sw2 = fiOutputGen.CreateText())
                {
                    sw2.Write(sb.ToString());
                }

                generateCodeStatusDBService.Status.AppendLine($"Created [{ fiOutputGen.FullName }] ...");
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
                new AppSettingParameter() { Parameter = "ClassNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPServices\\CSSPServices.Tests\\{TypeName}ServiceTestGenerated.cs" },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        private void GenerateCRUDTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated CRUD");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_CRUD_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    int count = 0;");
            sb.AppendLine(@"                    if (count == 1)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");

            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // CRUD testing");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"");

            CreateClass_CRUD_Testing(TypeName, TypeNameLower, sb);
            sb.AppendLine(@"");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated CRUD");
            sb.AppendLine(@"");
        }
        private void CreateClass_CRUD_Testing(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"                    count = { TypeNameLower }Service.Get{ TypeName }List().Count();");
            sb.AppendLine(@"");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    Assert.AreEqual(count, (from c in dbTestDB.{ TypeName }es select c).Count());");
            }
            else
            {
                sb.AppendLine($@"                    Assert.AreEqual(count, (from c in dbTestDB.{ TypeName }s select c).Count());");
            }
            sb.AppendLine(@"");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
            }
            sb.AppendLine($@"                    if ({ TypeNameLower }.HasErrors)");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        Assert.AreEqual("""", { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                    }");
            sb.AppendLine($@"                    Assert.AreEqual(true, { TypeNameLower }Service.Get{ TypeName }List().Where(c => c == { TypeNameLower }).Any());");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    if ({ TypeNameLower }.HasErrors)");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        Assert.AreEqual("""", { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                    }");
            sb.AppendLine($@"                    Assert.AreEqual(count + 1, { TypeNameLower }Service.Get{ TypeName }List().Count());");
            sb.AppendLine($@"                    { TypeNameLower }Service.Delete({ TypeNameLower });");
            sb.AppendLine($@"                    if ({ TypeNameLower }.HasErrors)");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        Assert.AreEqual("""", { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"                    }");
            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
        }
        private void CreateClass_Key_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"                    { TypeNameLower } = null;");
            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 0;");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeNameLower } = null;");
            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 10000000;");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
        }
        private void CreateGetFilledRandomClass(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.IsKey)
                        {
                            //sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { prop.Name };");
                        }
                        else
                        {
                            if (csspProp.PropName == "LastUpdateContactTVItemID")
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 2;");
                            }
                            else if (csspProp.HasCSSPExistAttribute)
                            {
                                switch (csspProp.ExistTypeName)
                                {
                                    case "AppTask":
                                        {
                                            AppTask appTask = dbTestDB.AppTasks.AsNoTracking().FirstOrDefault();
                                            if (appTask == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { appTask.AppTaskID };");
                                            }
                                        }
                                        break;
                                    case "BoxModel":
                                        {
                                            BoxModel boxModel = dbTestDB.BoxModels.AsNoTracking().FirstOrDefault();
                                            if (boxModel == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { boxModel.BoxModelID };");
                                            }
                                        }
                                        break;
                                    case "ClimateSite":
                                        {
                                            ClimateSite climateSite = dbTestDB.ClimateSites.AsNoTracking().FirstOrDefault();
                                            if (climateSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { climateSite.ClimateSiteID };");
                                            }
                                        }
                                        break;
                                    case "Contact":
                                        {
                                            Contact contact = dbTestDB.Contacts.AsNoTracking().FirstOrDefault();
                                            if (contact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { contact.ContactID };");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionList":
                                        {
                                            EmailDistributionList emailDistributionList = dbTestDB.EmailDistributionLists.AsNoTracking().FirstOrDefault();
                                            if (emailDistributionList == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionList.EmailDistributionListID };");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionListContact":
                                        {
                                            EmailDistributionListContact emailDistributionListContact = dbTestDB.EmailDistributionListContacts.AsNoTracking().FirstOrDefault();
                                            if (emailDistributionListContact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionListContact.EmailDistributionListContactID };");
                                            }
                                        }
                                        break;
                                    case "HydrometricSite":
                                        {
                                            HydrometricSite hydrometricSite = dbTestDB.HydrometricSites.AsNoTracking().FirstOrDefault();
                                            if (hydrometricSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { hydrometricSite.HydrometricSiteID };");
                                            }
                                        }
                                        break;
                                    case "Infrastructure":
                                        {
                                            Infrastructure infrastructure = dbTestDB.Infrastructures.AsNoTracking().FirstOrDefault();
                                            if (infrastructure == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { infrastructure.InfrastructureID };");
                                            }
                                        }
                                        break;
                                    case "LabSheet":
                                        {
                                            LabSheet labSheet = dbTestDB.LabSheets.AsNoTracking().FirstOrDefault();
                                            if (labSheet == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheet.LabSheetID };");
                                            }
                                        }
                                        break;
                                    case "LabSheetDetail":
                                        {
                                            LabSheetDetail labSheetDetail = dbTestDB.LabSheetDetails.AsNoTracking().FirstOrDefault();
                                            if (labSheetDetail == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheetDetail.LabSheetDetailID };");
                                            }
                                        }
                                        break;
                                    case "MapInfo":
                                        {
                                            MapInfo mapInfo = dbTestDB.MapInfos.AsNoTracking().FirstOrDefault();
                                            if (mapInfo == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mapInfo.MapInfoID };");
                                            }
                                        }
                                        break;
                                    case "MikeSource":
                                        {
                                            MikeSource mikeSource = dbTestDB.MikeSources.AsNoTracking().FirstOrDefault();
                                            if (mikeSource == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mikeSource.MikeSourceID };");
                                            }
                                        }
                                        break;
                                    case "MWQMAnalysisReportParameter":
                                        {
                                            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = dbTestDB.MWQMAnalysisReportParameters.AsNoTracking().FirstOrDefault();
                                            if (mwqmAnalysisReportParameter == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID };");
                                            }
                                        }
                                        break;
                                    case "MWQMRun":
                                        {
                                            MWQMRun mwqmRun = dbTestDB.MWQMRuns.AsNoTracking().FirstOrDefault();
                                            if (mwqmRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmRun.MWQMRunID };");
                                            }
                                        }
                                        break;
                                    case "MWQMSample":
                                        {
                                            MWQMSample mwqmSample = dbTestDB.MWQMSamples.AsNoTracking().FirstOrDefault();
                                            if (mwqmSample == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSample.MWQMSampleID };");
                                            }
                                        }
                                        break;
                                    case "MWQMSubsector":
                                        {
                                            MWQMSubsector mwqmSubsector = dbTestDB.MWQMSubsectors.AsNoTracking().FirstOrDefault();
                                            if (mwqmSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSubsector.MWQMSubsectorID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceObservation":
                                        {
                                            PolSourceObservation polSourceObservation = dbTestDB.PolSourceObservations.AsNoTracking().FirstOrDefault();
                                            if (polSourceObservation == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceObservation.PolSourceObservationID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceSite":
                                        {
                                            PolSourceSite polSourceSite = dbTestDB.PolSourceSites.AsNoTracking().FirstOrDefault();
                                            if (polSourceSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceSite.PolSourceSiteID };");
                                            }
                                        }
                                        break;
                                    case "RatingCurve":
                                        {
                                            RatingCurve ratingCurve = dbTestDB.RatingCurves.AsNoTracking().FirstOrDefault();
                                            if (ratingCurve == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { ratingCurve.RatingCurveID };");
                                            }
                                        }
                                        break;
                                    case "ReportSection":
                                        {
                                            ReportSection ReportSection = dbTestDB.ReportSections.AsNoTracking().FirstOrDefault();
                                            if (ReportSection == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { ReportSection.ReportSectionID };");
                                            }
                                        }
                                        break;
                                    case "ReportType":
                                        {
                                            ReportType reportType = dbTestDB.ReportTypes.AsNoTracking().FirstOrDefault();
                                            if (reportType == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { reportType.ReportTypeID };");
                                            }
                                        }
                                        break;
                                    case "SamplingPlanSubsector":
                                        {
                                            SamplingPlanSubsector samplingPlanSubsector = dbTestDB.SamplingPlanSubsectors.AsNoTracking().FirstOrDefault();
                                            if (samplingPlanSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlanSubsector.SamplingPlanSubsectorID };");
                                            }
                                        }
                                        break;
                                    case "SamplingPlan":
                                        {
                                            SamplingPlan samplingPlan = dbTestDB.SamplingPlans.AsNoTracking().FirstOrDefault();
                                            if (samplingPlan == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlan.SamplingPlanID };");
                                            }
                                        }
                                        break;
                                    case "Spill":
                                        {
                                            Spill spill = dbTestDB.Spills.AsNoTracking().FirstOrDefault();
                                            if (spill == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { spill.SpillID };");
                                            }
                                        }
                                        break;
                                    case "TVFile":
                                        {
                                            TVFile tvFile = dbTestDB.TVFiles.AsNoTracking().FirstOrDefault();
                                            if (tvFile == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvFile.TVFileID };");
                                            }
                                        }
                                        break;
                                    case "VPScenario":
                                        {
                                            VPScenario vpScenario = dbTestDB.VPScenarios.AsNoTracking().FirstOrDefault();
                                            if (vpScenario == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { vpScenario.VPScenarioID };");
                                            }
                                        }
                                        break;
                                    case "TVItem":
                                        {
                                            if (TypeName == "MikeScenario" && csspProp.PropName == "ParentMikeScenarioID")
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = null;");
                                            }
                                            else
                                            {
                                                if (csspProp.AllowableTVTypeList.Count == 0)
                                                {
                                                    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                }
                                                else
                                                {
                                                    TVItem tvItem = dbTestDB.TVItems.AsNoTracking().Where(c => c.TVType == csspProp.AllowableTVTypeList[0]).FirstOrDefault();
                                                    if (tvItem == null)
                                                    {
                                                        sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvItem.TVItemID };");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                        }
                                        break;
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
                                    if (TypeName == "MWQMLookupMPN" && (prop.Name == "Tubes01" || prop.Name == "Tubes1" || prop.Name == "Tubes10"))
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ 2.ToString() }{ numbExt }, { 5.ToString() }{ numbExt });");
                                    }
                                    else if (TypeName == "MWQMLookupMPN" && prop.Name == "MPN_100ml")
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 14;");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min.ToString() }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min.ToString() }{ numbExt }, { (csspProp.Min + 10).ToString() }{ numbExt });");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ (csspProp.Max - 10).ToString() }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                            }
                            else
                            {
                                sb.AppendLine($@"            // should implement a Range for the property { prop.Name } and type { TypeName }");
                            }
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        switch ($"{ TypeName }_{ csspProp.PropName }")
                        {
                            case "AppTask_EndDateTime_UTC":
                            case "ClimateSite_HourlyEndDate_Local":
                            case "ClimateSite_DailyEndDate_Local":
                            case "ClimateSite_MonthlyEndDate_Local":
                            case "HydrometricSite_EndDate_Local":
                            case "MikeScenario_MikeScenarioEndDateTime_Local":
                            case "MikeSourceStartEnd_EndDateAndTime_Local":
                            case "MWQMRun_EndDateTime_Local":
                            case "MWQMSiteStartEndDate_EndDate":
                            case "MWQMSubsector_IncludeRainEndDate":
                            case "MWQMSubsector_NoRainEndDate":
                            case "MWQMSubsector_OnlyRainEndDate":
                            case "Spill_EndDateTime_Local":
                            case "TVItemLink_EndDateTime_Local":
                                break;
                            case "AppTask_StartDateTime_UTC":
                            case "ClimateSite_HourlyStartDate_Local":
                            case "ClimateSite_DailyStartDate_Local":
                            case "ClimateSite_MonthlyStartDate_Local":
                            case "HydrometricSite_StartDate_Local":
                            case "MikeScenario_MikeScenarioStartDateTime_Local":
                            case "MikeSourceStartEnd_StartDateAndTime_Local":
                            case "MWQMRun_StartDateTime_Local":
                            case "MWQMSiteStartEndDate_StartDate":
                            case "MWQMSubsector_IncludeRainStartDate":
                            case "MWQMSubsector_NoRainStartDate":
                            case "MWQMSubsector_OnlyRainStartDate":
                            case "Spill_StartDateTime_Local":
                            case "TVItemLink_StartDateTime_Local":
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name.Replace("Start", "End") }"") { TypeNameLower }.{ prop.Name.Replace("Start", "End") } = new DateTime(2005, 3, 7);");
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                }
                                break;
                        }
                    }
                    break;
                case "Boolean":
                    {
                        if (csspProp.PropName == "HasErrors")
                        {
                            //sb.AppendLine($@"            //if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = true;");
                        }
                        else
                        {
                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = true;");
                        }
                    }
                    break;
                case "String":
                    {
                        if (csspProp.HasDataTypeAttribute) // will have to do this better ... works because it's only use when email
                        {
                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomEmail();");
                        }
                        else
                        {
                            if (csspProp.Min != null && csspProp.Max > 0)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = MinBiggerMaxLengthPleaseFix;");
                                }
                                else
                                {
                                    double? StrLen = (int)csspProp.Min + 5;
                                    if (StrLen > csspProp.Max)
                                    {
                                        StrLen = csspProp.Max;
                                    }
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                double StrLen = (int)csspProp.Min + 5;
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                            }
                            else if (csspProp.Max > 0)
                            {
                                double? StrLen = 5;
                                if (StrLen > csspProp.Max)
                                {
                                    StrLen = csspProp.Max;
                                }
                                if (TypeName == "Contact" && csspProp.HasCSSPExistAttribute)
                                {
                                    switch (csspProp.ExistTypeName)
                                    {
                                        case "AspNetUser":
                                            {
                                                AspNetUser AspNetUser = dbTestDB.AspNetUsers.AsNoTracking().FirstOrDefault();

                                                if (AspNetUser == null)
                                                {
                                                    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                }
                                                else
                                                {
                                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ""{ AspNetUser.Id }"";");
                                                }
                                            }
                                            break;
                                        default:
                                            {
                                                sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                                }
                            }
                            else
                            {
                                if (csspProp.IsList)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new List<string>() {{ GetRandomString("""", 20), GetRandomString("""", 20) }};");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", 20);");
                                }
                            }
                        }
                    }
                    break;
                case "Byte[]":
                    {
                        if (TypeName == "ContactLogin")
                        {
                            if (csspProp.PropName == "PasswordSalt")
                            {
                                // Don't do anything for this property
                                // everything will be done while at the PasswordHash property
                            }

                            if (csspProp.PropName == "PasswordHash")
                            {
                                sb.AppendLine(@"            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            Register register = new Register();");
                                sb.AppendLine(@"            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            byte[] passwordHash;");
                                sb.AppendLine(@"            byte[] passwordSalt;");
                                sb.AppendLine(@"            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordHash"") contactLogin.PasswordHash = passwordHash;");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordSalt"") contactLogin.PasswordSalt = passwordSalt;");
                            }
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.PropType.Contains("Enum"))
                        {
                            if (csspProp.PropType.Contains("LanguageEnum"))
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = LanguageRequest;");
                            }
                            else
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ({ csspProp.PropType })GetRandomEnumType(typeof({ csspProp.PropType }));");
                            }
                        }
                        else if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                        {
                            // nothing for now
                        }
                        else
                        {
                            sb.AppendLine($@"            //CSSPError: property [{ csspProp.PropName }] and type [{ TypeName }] is  not implemented");
                        }
                    }
                    break;
            }
        }
        private void GenerateGetWithIDTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID)");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }With{ TypeName }ID__{ TypeNameLower }_{ TypeName }ID__Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    { TypeName } { TypeNameLower } = (from c in dbTestDB.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                    { TypeName } { TypeNameLower } = (from c in dbTestDB.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query.Extra = extra;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                        if (string.IsNullOrWhiteSpace(extra))");
            sb.AppendLine(@"                        {");
            sb.AppendLine($@"                            { TypeName } { TypeNameLower }Ret = { TypeNameLower }Service.Get{ TypeName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID);");
            sb.AppendLine($@"                            Check{ TypeName }Fields(new List<{ TypeName }>() {{ { TypeNameLower }Ret }});");
            sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"                        }");
            List<string> ClassNameList = new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" };
            foreach (string ClassName in ClassNameList)
            {
                Type currentType = null;

                foreach (Type TempType in types)
                {
                    if (TempType.Name == $"{ TypeName }{ ClassName }")
                    {
                        currentType = TempType;
                        break;
                    }
                }

                if (currentType == null)
                {
                    continue;
                }

                sb.AppendLine($@"                        else if (extra == ""{ ClassName.Substring(ClassName.Length - 1) }"")");
                sb.AppendLine(@"                        {");
                sb.AppendLine($@"                            { TypeName }{ ClassName } { TypeNameLower }{ ClassName }Ret = { TypeNameLower }Service.Get{ TypeName }{ ClassName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID);");
                sb.AppendLine($@"                            Check{ TypeName }{ ClassName }Fields(new List<{ TypeName }{ ClassName }>() {{ { TypeNameLower }{ ClassName }Ret }});");
                sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }.{ TypeName }ID, { TypeNameLower }{ ClassName }Ret.{ TypeName }ID);");
                sb.AppendLine(@"                        }");
            }
            sb.AppendLine(@"                        else");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            //Assert.AreEqual(true, false);");
            sb.AppendLine(@"                        }"); sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID)");
            sb.AppendLine(@"");
        }
        private void GeneratePropertiesTestCode(string TypeName, string TypeNameLower, Type type, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated Properties");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Properties_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    int count = 0;");
            sb.AppendLine(@"                    if (count == 1)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    count = { TypeNameLower }Service.Get{ TypeName }List().Count();");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");

            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // Properties testing");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"");

            foreach (PropertyInfo prop in type.GetProperties())
            {
                CSSPProp csspProp = new CSSPProp();
                if (!generateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                {
                    return;
                }

                sb.AppendLine(@"");
                sb.AppendLine(@"                    // -----------------------------------");
                if (csspProp.IsKey)
                {
                    sb.AppendLine(@"                    // [Key]");
                }
                if (csspProp.IsNullable)
                {
                    sb.AppendLine(@"                    // Is Nullable");
                }
                else
                {
                    sb.AppendLine(@"                    // Is NOT Nullable");
                }
                if (csspProp.IsVirtual)
                {
                    sb.AppendLine(@"                    // [IsVirtual]");
                }
                if (csspProp.HasCompareAttribute)
                {
                    sb.AppendLine($@"                    // [Compare(OtherField = { csspProp.OtherField })]");
                }
                if (csspProp.HasCSSPAfterAttribute)
                {
                    sb.AppendLine($@"                    // [CSSPAfter(Year = { csspProp.Year })]");
                }
                if (csspProp.HasCSSPAllowNullAttribute)
                {
                    sb.AppendLine(@"                    // [CSSPAllowNull]");
                }
                if (csspProp.HasCSSPBiggerAttribute)
                {
                    sb.AppendLine($@"                    // [CSSPBigger(OtherField = { csspProp.OtherField })]");
                }
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine(@"                    // [CSSPEnumType]");
                }
                if (csspProp.HasCSSPExistAttribute)
                {
                    sb.AppendLine($@"                    // [CSSPExist(ExistTypeName = ""{ csspProp.ExistTypeName }"", ExistPlurial = ""{ csspProp.ExistPlurial }"", ExistFieldID = ""{ csspProp.ExistFieldID }"", AllowableTVtypeList = { String.Join(",", csspProp.AllowableTVTypeList) })]");
                }
                if (csspProp.HasCSSPFillAttribute)
                {
                    string FillNeedLanguage = (csspProp.FillNeedLanguage ? "true" : "false");
                    string FillIsList = (csspProp.FillIsList ? "true" : "false");
                    sb.AppendLine($@"                    // [CSSPFill(FillTypeName = ""{ csspProp.FillTypeName }"", FillPlurial = ""{ csspProp.FillPlurial }"", FillFieldID = ""{ csspProp.FillFieldID }"", FillEqualField = ""{ csspProp.FillEqualField }"", FillReturnField = ""{ csspProp.FillReturnField }"", FillNeedLanguage = { FillNeedLanguage }, FillIsList = { FillIsList })]");
                }
                if (csspProp.HasDataTypeAttribute)
                {
                    sb.AppendLine($@"                    // [DataType(DataType.{ csspProp.dataType.ToString() })]");
                }
                if (csspProp.HasNotMappedAttribute)
                {
                    sb.AppendLine(@"                    // [NotMapped]");
                }
                if (csspProp.HasRangeAttribute)
                {
                    sb.AppendLine($@"                    // [Range({ csspProp.Min }, { (csspProp.Max == null ? "-1" : csspProp.Max.ToString()) })]");
                }
                if (csspProp.HasStringLengthAttribute)
                {
                    string MinText = (csspProp.Min == null ? ")" : $", MinimumLength = { csspProp.Min.ToString() }");
                    sb.AppendLine($@"                    // [StringLength({ csspProp.Max }{ MinText })]");
                }
                sb.AppendLine($@"                    // { TypeNameLower }.{ csspProp.PropName }   ({ csspProp.PropType })");
                sb.AppendLine(@"                    // -----------------------------------");
                sb.AppendLine(@"");

                if (csspProp.IsVirtual || csspProp.PropName == "ValidationResults")
                {
                    sb.AppendLine(@"                    // No testing requied");
                    continue;
                }
                if (csspProp.PropName == "HasErrors")
                {
                    sb.AppendLine(@"                    // No testing requied");
                    continue;
                }
                if (csspProp.IsKey)
                {
                    CreateClass_Key_Testing(csspProp, TypeName, TypeNameLower, sb);
                }

                CreateClass_CSSPExist_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_CSSPEnumType_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_Required_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_CSSPAfter_Testing(csspProp, TypeName, TypeNameLower, sb);
                CreateClass_Min_And_Max_Properties_Testing(csspProp, TypeName, TypeNameLower, sb);
            }

            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated Properties");
            sb.AppendLine(@"");
        }
        private void GenerateGetListTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List()");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    { TypeName } { TypeNameLower } = (from c in dbTestDB.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                    { TypeName } { TypeNameLower } = (from c in dbTestDB.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Take(200).ToList();");
            }
            else
            {
                sb.AppendLine($@"                    { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Take(200).ToList();");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query.Extra = extra;");
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, false);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List()");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, """", """", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeAscTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take Asc");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Asc_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1,  ""{ TypeName }ID"", """", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).OrderBy(c => c.{ TypeName }ID).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).OrderBy(c => c.{ TypeName }ID).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take Asc");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTake2AscTestCode(string TypeName, string TypeNameLower, Type type, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take 2 Asc");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_2Asc_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            string PropName2 = type.GetProperties().Skip(1).Take(1).FirstOrDefault().Name;
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, ""{ TypeName }ID,{ PropName2 }"", """", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).OrderBy(c => c.{ TypeName }ID).ThenBy(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).OrderBy(c => c.{ TypeName }ID).ThenBy(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take 2 Asc");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeAscWhereTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take Asc Where");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Asc_Where_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 0, 1, ""{ TypeName }ID"", """", ""{ TypeName }ID,EQ,4"", """");");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Where(c => c.{ TypeName }ID == 4).OrderBy(c => c.{ TypeName }ID).Skip(0).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Where(c => c.{ TypeName }ID == 4).OrderBy(c => c.{ TypeName }ID).Skip(0).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take Asc Where");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeAsc2WhereTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take Asc 2 Where");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Asc_2Where_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 0, 1, ""{ TypeName }ID"", """", ""{ TypeName }ID,GT,2|{ TypeName }ID,LT,5"", """");");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).Skip(0).Take(1).OrderBy(c => c.{ TypeName }ID).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).Skip(0).Take(1).OrderBy(c => c.{ TypeName }ID).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take Asc 2 Where");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeDescTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take Desc");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Desc_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, """", ""{ TypeName }ID"", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).OrderByDescending(c => c.{ TypeName }ID).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).OrderByDescending(c => c.{ TypeName }ID).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take Desc");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTake2DescTestCode(string TypeName, string TypeNameLower, Type type, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take 2 Desc");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_2Desc_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            string PropName2 = type.GetProperties().Skip(1).Take(1).FirstOrDefault().Name;
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, """", ""{ TypeName }ID,{ PropName2 }"", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).OrderByDescending(c => c.{ TypeName }ID).ThenByDescending(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).OrderByDescending(c => c.{ TypeName }ID).ThenByDescending(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take 2 Desc");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeDescWhereTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take Desc Where");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Desc_Where_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 0, 1, ""{ TypeName }ID"", """", ""{ TypeName }ID,EQ,4"", """");");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Where(c => c.{ TypeName }ID == 4).OrderByDescending(c => c.{ TypeName }ID).Skip(0).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Where(c => c.{ TypeName }ID == 4).OrderByDescending(c => c.{ TypeName }ID).Skip(0).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take Desc Where");
            sb.AppendLine(@"");
        }
        private void GenerateGetListSkipTakeDesc2WhereTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take Desc 2 Where");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Desc_2Where_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 0, 1, """", ""{ TypeName }ID"", ""{ TypeName }ID,GT,2|{ TypeName }ID,LT,5"", """");");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).OrderByDescending(c => c.{ TypeName }ID).Skip(0).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).OrderByDescending(c => c.{ TypeName }ID).Skip(0).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take Desc 2 Where");
            sb.AppendLine(@"");
        }
        private void GenerateGetList2WhereTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() 2 Where");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_2Where_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 0, 10000, """", """", ""{ TypeName }ID,GT,2|{ TypeName }ID,LT,5"", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Where(c => c.{ TypeName }ID > 2 && c.{ TypeName }ID < 5).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() 2 Where");
            sb.AppendLine(@"");
        }
        private void CreateClass_CSSPAfter_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                case "String":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (csspProp.HasCSSPAfterAttribute)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = new DateTime({ ((int)csspProp.Year - 1).ToString() }, 1, 1);");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");

                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            // nothing for now
                        }
                        else
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                sb.AppendLine($@"                    //CSSPError: Type not implemented [{ csspProp.PropName }]");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
            }
        }
        private void CreateClass_CSSPEnumType_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            if (csspProp.PropType.EndsWith("Enum"))
            {
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine($@"                    { TypeNameLower } = null;");
                    sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                    sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = ({ csspProp.PropType })1000000;");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                    }
                    else
                    {
                        sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                    }
                    sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                    sb.AppendLine(@"");
                }
            }
        }
        private void CreateClass_CSSPExist_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                    {
                        if (csspProp.IsKey)
                        {
                            break;
                        }

                        if (csspProp.HasCSSPExistAttribute)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 0;");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ csspProp.ExistTypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            sb.AppendLine(@"");

                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                int TVItemIDNotGoodType = 0;
                                TVItem tvItem = null;
                                tvItem = (from c in dbTestDB.TVItems
                                          where !csspProp.AllowableTVTypeList.Contains(c.TVType)
                                          select c).FirstOrDefault();

                                if (tvItem != null)
                                {
                                    TVItemIDNotGoodType = tvItem.TVItemID;
                                }

                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { TVItemIDNotGoodType };");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                                }
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, ""{ csspProp.PropName }"", ""{ String.Join(",", csspProp.AllowableTVTypeList) }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }
        private void CreateClass_Min_And_Max_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {

                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        //string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            //  propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            //propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.Min != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Min - 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                        if (csspProp.Max != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Max + 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                    }
                    break;
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
                case "String":
                    {
                        if (csspProp.Min != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            if (csspProp.Min - 1 > 0)
                            {
                                sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Min - 1).ToString() });");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                                }
                                if (csspProp.Max != null)
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                            }
                        }
                        if (csspProp.Max > 0)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Max + 1).ToString() });");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }
        private void CreateClass_Required_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return;
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = new DateTime();");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                        }
                    }
                    break;
                case "String":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }(""{ csspProp.PropName }"");");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (TypeName == "Contact" && csspProp.PropName == "Id")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(2, { TypeNameLower }.ValidationResults.Count());");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(1, { TypeNameLower }.ValidationResults.Count());");
                            }
                            sb.AppendLine($@"                    Assert.IsTrue({ TypeNameLower }.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }"")).Any());");
                            sb.AppendLine($@"                    Assert.AreEqual(null, { TypeNameLower }.{ csspProp.PropName });");
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                            sb.AppendLine(@"");
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            // nothing for now
                        }
                        else
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                string EndText = csspProp.PropName.EndsWith("Web") ? "Web" : "Report";

                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ TypeName }{ EndText } = null;");
                                sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }.{ TypeName }{ EndText });");
                                sb.AppendLine(@"");
                                sb.AppendLine($@"                    { TypeNameLower } = null;");
                                sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"                    { TypeNameLower }.{ TypeName }{ EndText } = new { TypeName }{ EndText }();");
                                sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }.{ TypeName }{ EndText });");
                            }
                            else if (csspProp.PropName.EndsWith("Report"))
                            {
                            }
                            else
                            {
                                sb.AppendLine($@"                    //CSSPError: Type not implemented [{ csspProp.PropName }]");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
            }
        }
        private void GetTestForDifferentQueryDetailType(List<Type> types, string CountText, string TypeName, string TypeNameLower, StringBuilder sb, bool AssertDirectQuery)
        {
            sb.AppendLine(@"                        if (string.IsNullOrWhiteSpace(extra))");
            sb.AppendLine(@"                        {");
            sb.AppendLine($@"                            List<{ TypeName }> { TypeNameLower }List = new List<{ TypeName }>();");
            sb.AppendLine($@"                            { TypeNameLower }List = { TypeNameLower }Service.Get{ TypeName }List().ToList();");
            sb.AppendLine($@"                            Check{ TypeName }Fields({ TypeNameLower }List);");
            if (AssertDirectQuery)
            {
                sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }DirectQueryList[0].{ TypeName }ID, { TypeNameLower }List[0].{ TypeName }ID);");
            }
            sb.AppendLine(@"                        }");
            List<string> ClassNameList = new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" };
            foreach (string ClassName in ClassNameList)
            {
                Type currentType = null;

                foreach (Type TempType in types)
                {
                    if (TempType.Name == $"{ TypeName }{ ClassName }")
                    {
                        currentType = TempType;
                        break;
                    }
                }

                if (currentType == null)
                {
                    continue;
                }

                sb.AppendLine($@"                        else if (extra == ""{ ClassName.Substring(ClassName.Length - 1) }"")");
                sb.AppendLine(@"                        {");
                sb.AppendLine($@"                            List<{ TypeName }{ ClassName }> { TypeNameLower }{ ClassName }List = new List<{ TypeName }{ ClassName }>();");
                sb.AppendLine($@"                            { TypeNameLower }{ ClassName }List = { TypeNameLower }Service.Get{ TypeName }{ ClassName }List().ToList();");
                sb.AppendLine($@"                            Check{ TypeName }{ ClassName }Fields({ TypeNameLower }{ ClassName }List);");
                if (AssertDirectQuery)
                {
                    sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }DirectQueryList[0].{ TypeName }ID, { TypeNameLower }{ ClassName }List[0].{ TypeName }ID);");
                }
                sb.AppendLine($@"                            Assert.AreEqual({ CountText }, { TypeNameLower }{ ClassName }List.Count);");
                sb.AppendLine(@"                        }");



            }

            sb.AppendLine(@"                        else");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            //Assert.AreEqual(true, false);");
            sb.AppendLine(@"                        }");
        }
        #endregion Functions private
    }
}