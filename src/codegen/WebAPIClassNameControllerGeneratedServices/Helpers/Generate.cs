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
using WebAPIClassNameControllerGeneratedServices.Resources;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;

namespace WebAPIClassNameControllerGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerGeneratedService : IWebAPIClassNameControllerGeneratedService
    {
        private async Task<bool> Generate()
        {
            ActionResult<ActionCommand> actionActionCommand = await actionCommandDBService.GetOrCreate();

            if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
            {
                await actionCommandDBService.ConsoleWriteError("actionCommand == null");
                return await Task.FromResult(false);
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

                    actionCommandDBService.ExecutionStatusText.AppendLine($"{ string.Format(WebAPIClassNameControllerGeneratedServicesRes.Created_, fiOutputGen.FullName) }");
                }
            }
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine($"{ WebAPIClassNameControllerGeneratedServicesRes.Done } ...");
            actionCommandDBService.ExecutionStatusText.AppendLine("");
            actionCommandDBService.ExecutionStatusText.AppendLine("Generate Finished ...");
            actionCommandDBService.PercentCompleted = 100;
            await actionCommandDBService.Update();

            return await Task.FromResult(true);
        }
    }
}
