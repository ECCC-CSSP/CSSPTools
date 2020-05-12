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
using WebAPIClassNameControllerTestGeneratedServices.Resources;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public class WebAPIClassNameControllerTestGeneratedService : IWebAPIClassNameControllerTestGeneratedService
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
        public WebAPIClassNameControllerTestGeneratedService(IConfiguration configuration,
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

            FileInfo fiDLL = new FileInfo(configuration.GetValue<string>("CSSPModels"));

            var importAssembly = Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
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

                //if (type.Name != "Address")
                //{
                //    continue;
                //}

                foreach (CustomAttributeData customAttributeData in type.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        ClassNotMapped = true;
                        break;
                    }
                }

                if (!ClassNotMapped)
                {
                    sb.AppendLine(@"using CSSPEnums;");
                    sb.AppendLine(@"using CSSPModels;");
                    sb.AppendLine(@"using CSSPServices;");
                    sb.AppendLine(@"using CSSPWebAPI.Controllers;");
                    sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
                    sb.AppendLine(@"using System.Collections.Generic;");
                    sb.AppendLine(@"using System.Linq;");
                    sb.AppendLine(@"using System.Web.Http;");
                    sb.AppendLine(@"using System.Web.Http.Results;");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"namespace CSSPWebAPI.Tests.Controllers");
                    sb.AppendLine(@"{");
                    sb.AppendLine(@"    [TestClass]");
                    sb.AppendLine($@"    public partial class { TypeName }ControllerTest : BaseControllerTest");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { TypeName }ControllerTest() : base()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");

                    GenerateControllersGetClassList(TypeName, TypeNameLower, sb);

                    GenerateControllersGetClassWithID(TypeName, TypeNameLower, sb);

                    GenerateControllersPostClass(TypeName, TypeNameLower, sb);

                    GenerateControllersPutClass(TypeName, TypeNameLower, sb);

                    GenerateControllersDeleteClass(TypeName, TypeNameLower, sb);

                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"}");

                    FileInfo fiOutputGen = new FileInfo(configuration.GetValue<string>("TypeNameFile").Replace("{TypeName}", TypeName));
                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }

                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(AppRes.Created_, fiOutputGen.FullName) }");
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "WebAPIClassNameControllerTestGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "TypeNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPWebAPI\\CSSPWebAPI.Tests\\Controllers\\Generated\\{TypeName}ControllerTestGenerated.cs" },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        private void GenerateControllersGetClassList(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller GetList Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Get{ TypeName }List_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }First = new { TypeName }();");
            sb.AppendLine(@"                    int count = -1;");
            sb.AppendLine(@"                    Query query = new Query();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }es select c).FirstOrDefault();");
                sb.AppendLine($@"                        count = (from c in db.{ TypeName }es select c).Count();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }s select c).FirstOrDefault();");
                sb.AppendLine($@"                        count = (from c in db.{ TypeName }s select c).Count();");
            }
            sb.AppendLine(@"                        count = (query.Take > count ? count : query.Take);");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }List();");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<List<{ TypeName }>> ret = jsonRet as OkNegotiatedContentResult<List<{ TypeName }>>;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }First.{ TypeName }ID, ret.Content[0].{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    List<{ TypeName }> { TypeNameLower }List = new List<{ TypeName }>();");
            sb.AppendLine(@"                    count = -1;");
            sb.AppendLine(@"                    query = new Query();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }List = (from c in db.{ TypeName }es select c).OrderBy(c => c.{ TypeName }ID).Skip(0).Take(2).ToList();");
                sb.AppendLine($@"                        count = (from c in db.{ TypeName }es select c).Count();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }List = (from c in db.{ TypeName }s select c).OrderBy(c => c.{ TypeName }ID).Skip(0).Take(2).ToList();");
                sb.AppendLine($@"                        count = (from c in db.{ TypeName }s select c).Count();");
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    if (count > 0)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        query.Skip = 0;");
            sb.AppendLine(@"                        query.Take = 5;");
            sb.AppendLine(@"                        count = (query.Take > count ? query.Take : count);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        // ok with { TypeName } info");
            sb.AppendLine($@"                        jsonRet = { TypeNameLower }Controller.Get{ TypeName }List(query.Language.ToString(), query.Skip, query.Take);");
            sb.AppendLine(@"                        Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        ret = jsonRet as OkNegotiatedContentResult<List<{ TypeName }>>;");
            sb.AppendLine($@"                        Assert.AreEqual({ TypeNameLower }List[0].{ TypeName }ID, ret.Content[0].{ TypeName }ID);");
            sb.AppendLine(@"                        Assert.AreEqual((count > query.Take ? query.Take : count), ret.Content.Count);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                       if (count > 1)");
            sb.AppendLine(@"                       {");
            sb.AppendLine(@"                           query.Skip = 1;");
            sb.AppendLine(@"                           query.Take = 5;");
            sb.AppendLine(@"                           count = (query.Take > count ? query.Take : count);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                           // ok with { TypeName } info");
            sb.AppendLine($@"                           IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Get{ TypeName }List(query.Language.ToString(), query.Skip, query.Take);");
            sb.AppendLine(@"                           Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                           OkNegotiatedContentResult<List<{ TypeName }>> ret2 = jsonRet2 as OkNegotiatedContentResult<List<{ TypeName }>>;");
            sb.AppendLine($@"                           Assert.AreEqual({ TypeNameLower }List[1].{ TypeName }ID, ret2.Content[0].{ TypeName }ID);");
            sb.AppendLine(@"                           Assert.AreEqual((count > query.Take ? query.Take : count), ret2.Content.Count);");
            sb.AppendLine(@"                       }");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller GetList Command");
            sb.AppendLine(@"");
        }
        private void GenerateControllersGetClassWithID(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller GetWithID Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Get{ TypeName }WithID_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }First = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query(), db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }First.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }First.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    // Not Found");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Get{ TypeName }WithID(0);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;");
            sb.AppendLine(@"                    Assert.IsNotNull(notFoundRequest);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller GetWithID Command");
            sb.AppendLine(@"");
        }
        private void GenerateControllersPostClass(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller Post Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Post_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Last = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Query query = new Query();");
            sb.AppendLine(@"                        query.Language = LanguageRequest;");
            sb.AppendLine(@"                        query.Asc = """";");
            sb.AppendLine(@"                        query.Desc = """";");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }Last.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }Last.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Post to return CSSPError because { TypeName }ID exist");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Post({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNotNull(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Post to return newly added { TypeName }");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            if (TypeName == "MWQMLookupMPN")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes01 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes1 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes10 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.MPN_100ml = 6;");
            }
            if (TypeName == "SamplingPlan")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.SamplingPlanName = { TypeNameLower }Ret.SamplingPlanName.Replace("".txt"", ""_a.txt"");");
            }
            if (TypeName == "TVItem")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.TVLevel = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.TVType = TVTypeEnum.Contact;");
            }
            sb.AppendLine($@"                    { TypeNameLower }Controller.Request = new System.Net.Http.HttpRequestMessage();");
            sb.AppendLine($@"                    { TypeNameLower }Controller.Request.RequestUri = new System.Uri(""http://localhost:5000/api/{ TypeNameLower }"");");
            sb.AppendLine($@"                    IHttpActionResult jsonRet3 = { TypeNameLower }Controller.Post({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    CreatedNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret3 = jsonRet3 as CreatedNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret3);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    IHttpActionResult jsonRet4 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet4);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret4 = jsonRet4 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret4);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest4);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Post Command");
            sb.AppendLine(@"");
        }
        private void GenerateControllersPutClass(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller Put Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Put_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Last = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Query query = new Query();");
            sb.AppendLine(@"                        query.Language = LanguageRequest;");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "TVItem")
            {
                if (TypeName == "Address")
                {
                    sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }es select c).LastOrDefault();");
                }
                else
                {
                    sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }s select c).LastOrDefault();");
                }
            }
            else
            {
                if (TypeName == "Address")
                {
                    sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }es select c).FirstOrDefault();");
                }
                else
                {
                    sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }s select c).FirstOrDefault();");
                }
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }Last.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }Last.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Put to return success");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Put({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Put to return CSSPError because { TypeName }ID of 0 does not exist");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            sb.AppendLine($@"                    IHttpActionResult jsonRet3 = { TypeNameLower }Controller.Put({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret3 = jsonRet3 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret3);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNotNull(badRequest3);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Put Command");
            sb.AppendLine(@"");
        }
        private void GenerateControllersDeleteClass(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller Delete Command");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Delete_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Last = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Query query = new Query();");
            sb.AppendLine(@"                        query.Language = LanguageRequest;");
            sb.AppendLine(@"                        query.Asc = """";");
            sb.AppendLine(@"                        query.Desc = """";");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }Last = (from c in db.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IHttpActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }Last.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.AreEqual({ TypeNameLower }Last.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Post to return newly added { TypeName }");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            if (TypeName == "MWQMLookupMPN")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes01 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes1 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.Tubes10 = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.MPN_100ml = 6;");
            }
            if (TypeName == "SamplingPlan")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.SamplingPlanName = { TypeNameLower }Ret.SamplingPlanName.Replace("".txt"", ""_a.txt"");");
            }
            if (TypeName == "TVItem")
            {
                sb.AppendLine($@"                    { TypeNameLower }Ret.TVLevel = 1;");
                sb.AppendLine($@"                    { TypeNameLower }Ret.TVType = TVTypeEnum.Contact;");
            }
            sb.AppendLine($@"                    { TypeNameLower }Controller.Request = new System.Net.Http.HttpRequestMessage();");
            sb.AppendLine($@"                    { TypeNameLower }Controller.Request.RequestUri = new System.Uri(""http://localhost:5000/api/{ TypeNameLower }"");");
            sb.AppendLine($@"                    IHttpActionResult jsonRet3 = { TypeNameLower }Controller.Post({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    CreatedNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret3 = jsonRet3 as CreatedNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret3);");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = { TypeNameLower }Ret3.Content;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Delete to return success");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Delete to return CSSPError because { TypeName }ID of 0 does not exist");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            sb.AppendLine($@"                    IHttpActionResult jsonRet4 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsNotNull(jsonRet4);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret4 = jsonRet4 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret4);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest4 = jsonRet4 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNotNull(badRequest4);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Delete Command");
            sb.AppendLine(@"");
        }
        #endregion Functions private
    }
}