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
using WebAPIClassNameControllerGeneratedServices.Resources;

namespace WebAPIClassNameControllerGeneratedServices.Services
{
    public class WebAPIClassNameControllerGeneratedService : IWebAPIClassNameControllerGeneratedService
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
        public WebAPIClassNameControllerGeneratedService(IConfiguration configuration,
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
                    sb.AppendLine(@"using System;");
                    sb.AppendLine(@"using System.Collections.Generic;");
                    sb.AppendLine(@"using System.Linq;");
                    sb.AppendLine(@"using System.Web.Http;");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"namespace CSSPWebAPI.Controllers");
                    sb.AppendLine(@"{");
                    sb.AppendLine($@"    [RoutePrefix(""api/{ TypeNameLower }"")]");
                    sb.AppendLine($@"    public partial class { TypeName }Controller : BaseController");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        #region Variables");
                    sb.AppendLine(@"        #endregion Variables");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Properties");
                    sb.AppendLine(@"        #endregion Properties");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Constructors");
                    sb.AppendLine($@"        public { TypeName }Controller() : base()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"        }");
                    sb.AppendLine($@"        public { TypeName }Controller(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"        #endregion Constructors");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Functions public");

                    sb.AppendLine($@"        // GET api/{ TypeNameLower }");
                    sb.AppendLine(@"        [Route("""")]");
                    sb.AppendLine($@"        public IHttpActionResult Get{ TypeName }List([FromUri]string lang = ""en"", [FromUri]int skip = 0, [FromUri]int take = 200,");
                    sb.AppendLine($@"            [FromUri]string asc = """", [FromUri]string desc = """", [FromUri]string where = """", [FromUri]string extra = """")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    string QueryStr = @"new Query() { Lang = lang }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    foreach (string extra in new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        Type currentType = null;
                        foreach (Type TempType in types)
                        {
                            if (TempType.Name == $"{ TypeName }{ extra }")
                            {
                                currentType = TempType;
                            }
                        }

                        if (currentType == null)
                        {
                            continue;
                        }

                        string elseText = extra == "ExtraA" ? "" : "else ";
                        sb.AppendLine($@"                { elseText }if (extra == ""{ extra.Replace("Extra", "") }"") // QueryString contains [extra={ extra.Replace("Extra", "") }]");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                   { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }{ extra }), lang, skip, take, asc, desc, where, extra);");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                    if ({ TypeNameLower }Service.Query.HasErrors)");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine($@"                        return Ok(new List<{ TypeName }{ extra }>()");
                        sb.AppendLine(@"                        {");
                        sb.AppendLine($@"                            new { TypeName }{ extra }()");
                        sb.AppendLine(@"                            {");
                        sb.AppendLine($@"                                HasErrors = { TypeNameLower }Service.Query.HasErrors,");
                        sb.AppendLine($@"                                ValidationResults = { TypeNameLower }Service.Query.ValidationResults,");
                        sb.AppendLine(@"                            },");
                        sb.AppendLine(@"                        }.ToList());");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine(@"                    else");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine($@"                        return Ok({ TypeNameLower }Service.Get{ TypeName }{ extra }List().ToList());");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine(@"                }");
                    }
                    sb.AppendLine(@"                else // QueryString has no parameter [extra] or extra is empty");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                   { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), lang, skip, take, asc, desc, where, extra);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                    if ({ TypeNameLower }Service.Query.HasErrors)");
                    sb.AppendLine(@"                    {");
                    sb.AppendLine($@"                        return Ok(new List<{ TypeName }>()");
                    sb.AppendLine(@"                        {");
                    sb.AppendLine($@"                            new { TypeName }()");
                    sb.AppendLine(@"                            {");
                    sb.AppendLine($@"                                HasErrors = { TypeNameLower }Service.Query.HasErrors,");
                    sb.AppendLine($@"                                ValidationResults = { TypeNameLower }Service.Query.ValidationResults,");
                    sb.AppendLine(@"                            },");
                    sb.AppendLine(@"                        }.ToList());");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                    else");
                    sb.AppendLine(@"                    {");
                    sb.AppendLine($@"                        return Ok({ TypeNameLower }Service.Get{ TypeName }List().ToList());");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");


                    sb.AppendLine($@"        // GET api/{ TypeNameLower }/1");
                    sb.AppendLine($@"        [Route(""{{{ TypeName }ID:int}}"")]");
                    sb.AppendLine($@"        public IHttpActionResult Get{ TypeName }WithID([FromUri]int { TypeName }ID, [FromUri]string lang = ""en"", [FromUri]string extra = """")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    QueryStr = @"new Query() { Language = (lang == ""fr"" ? LanguageEnum.fr : LanguageEnum.en) }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), lang, 0, 1, """", """", extra);");
                    sb.AppendLine(@"");
                    foreach (string extra in new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        Type currentType = null;
                        foreach (Type TempType in types)
                        {
                            if (TempType.Name == $"{ TypeName }{ extra }")
                            {
                                currentType = TempType;
                            }
                        }

                        if (currentType == null)
                        {
                            continue;
                        }

                        string elseText = extra == "ExtraA" ? "" : "else ";
                        sb.AppendLine($@"                { elseText }if ({ TypeNameLower }Service.Query.Extra == ""{ extra.Replace("Extra", "") }"")");
                        sb.AppendLine(@"                {");
                        sb.AppendLine($@"                    { TypeName }{ extra } { TypeNameLower }{ extra } = new { TypeName }{ extra }();");
                        sb.AppendLine($@"                    { TypeNameLower }{ extra } = { TypeNameLower }Service.Get{ TypeName }{ extra }With{ TypeName }ID({ TypeName }ID);");
                        sb.AppendLine(@"");
                        sb.AppendLine($@"                    if ({ TypeNameLower }{ extra } == null)");
                        sb.AppendLine(@"                    {");
                        sb.AppendLine($@"                        return NotFound();");
                        sb.AppendLine(@"                    }");
                        sb.AppendLine($@"");
                        sb.AppendLine($@"                    return Ok({ TypeNameLower }{ extra });");
                        sb.AppendLine(@"                }");
                    }
                    sb.AppendLine(@"                else");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeName } { TypeNameLower } = new { TypeName }();");
                    sb.AppendLine($@"                    { TypeNameLower } = { TypeNameLower }Service.Get{ TypeName }With{ TypeName }ID({ TypeName }ID);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                    if ({ TypeNameLower } == null)");
                    sb.AppendLine(@"                    {");
                    sb.AppendLine($@"                        return NotFound();");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine($@"");
                    sb.AppendLine($@"                    return Ok({ TypeNameLower });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        // POST api/{ TypeNameLower }");
                    sb.AppendLine(@"        [Route("""")]");
                    sb.AppendLine($@"        public IHttpActionResult Post([FromBody]{ TypeName } { TypeNameLower }, [FromUri]string lang = ""en"")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    QueryStr = @"new Query() { Language = (lang == ""fr"" ? LanguageEnum.fr : LanguageEnum.en) }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"                if (!{ TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn))");
                    }
                    else
                    {
                        sb.AppendLine($@"                if (!{ TypeNameLower }Service.Add({ TypeNameLower }))");
                    }
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    return BadRequest(String.Join(""|||"", { TypeNameLower }.ValidationResults));");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"                else");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.ValidationResults = null;");
                    sb.AppendLine($@"                    return Created<{ TypeName }>(new Uri(Request.RequestUri, { TypeNameLower }.{ TypeName }ID.ToString()), { TypeNameLower });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        // PUT api/{ TypeNameLower }");
                    sb.AppendLine(@"        [Route("""")]");
                    sb.AppendLine($@"        public IHttpActionResult Put([FromBody]{ TypeName } { TypeNameLower }, [FromUri]string lang = ""en"")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    QueryStr = @"new Query() { Language = (lang == ""fr"" ? LanguageEnum.fr : LanguageEnum.en) }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"                if (!{ TypeNameLower }Service.Update({ TypeNameLower }))");
                    }
                    else
                    {
                        sb.AppendLine($@"                if (!{ TypeNameLower }Service.Update({ TypeNameLower }))");
                    }
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    return BadRequest(String.Join(""|||"", { TypeNameLower }.ValidationResults));");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"                else");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.ValidationResults = null;");
                    sb.AppendLine($@"                    return Ok({ TypeNameLower });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        // DELETE api/{ TypeNameLower }");
                    sb.AppendLine(@"        [Route("""")]");
                    sb.AppendLine($@"        public IHttpActionResult Delete([FromBody]{ TypeName } { TypeNameLower }, [FromUri]string lang = ""en"")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    QueryStr = @"new Query() { Language = (lang == ""fr"" ? LanguageEnum.fr : LanguageEnum.en) }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"                if (!{ TypeNameLower }Service.Delete({ TypeNameLower }))");
                    }
                    else
                    {
                        sb.AppendLine($@"                if (!{ TypeNameLower }Service.Delete({ TypeNameLower }))");
                    }
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    return BadRequest(String.Join(""|||"", { TypeNameLower }.ValidationResults));");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"                else");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    { TypeNameLower }.ValidationResults = null;");
                    sb.AppendLine($@"                    return Ok({ TypeNameLower });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                    sb.AppendLine(@"        #endregion Functions public");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        #region Functions private");
                    sb.AppendLine(@"        #endregion Functions private");
                    sb.AppendLine(@"    }");
                    sb.AppendLine(@"}");

                    FileInfo fiOutputGen = null;
                    fiOutputGen = new FileInfo(configuration.GetValue<string>("TypeNameFile").Replace("{TypeName}", TypeName));

                    using (StreamWriter sw2 = fiOutputGen.CreateText())
                    {
                        sw2.Write(sb.ToString());
                    }

                    generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.Created_, fiOutputGen.FullName) }");
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "WebAPIClassNameControllerGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "TypeNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPWebAPI\\CSSPWebAPI\\Controllers\\src\\{TypeName}ControllerGenerated.cs" },
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