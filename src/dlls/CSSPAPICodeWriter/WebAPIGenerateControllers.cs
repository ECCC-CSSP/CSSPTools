﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
//using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using CSSPModelsGenerateCodeHelper;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;
using System.IO;

namespace CSSPWebAPIGenerateCodeHelper
{
    public partial class WebAPICodeWriter
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // constructor was done in the WebAPIGenerateCodeHelper.cs file
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        /// <summary>
        /// Generates:
        ///     for WithDoc == true
        ///     C:\CSSPTools\src\web\CSSPWebAPI\Controllers\GeneratedWithDoc\[ModelClassName]ControllerGenerated.cs file
        /// 
        ///     for WithDoc == true
        ///     C:\CSSPTools\src\web\CSSPWebAPI\Controllers\Generated\[ModelClassName]ControllerGenerated.cs file
        ///
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        /// </summary>
        public void ModelControllerGenerated(bool WithDoc)
        {
            StatusTempEvent(new StatusEventArgs(""));
            ClearPermanentEvent(new StatusEventArgs(""));

            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll");

            if (!fiDLL.Exists)
            {
                CSSPErrorEvent(new CSSPErrorEventArgs($"{ fiDLL.FullName } does not exist"));
                return;
            }

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

                StatusTempEvent(new StatusEventArgs(TypeName));
                //Application.DoEvents();

                if (modelsGenerateCodeHelper.SkipType(type))
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
                    sb.AppendLine(@"using Microsoft.AspNetCore.Mvc;");
                    sb.AppendLine(@"using System;");
                    sb.AppendLine(@"using System.Collections.Generic;");
                    sb.AppendLine(@"using System.Linq;");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"namespace CSSPWebAPI.Controllers");
                    sb.AppendLine(@"{");
                    sb.AppendLine($@"    [Route(""api/{ TypeNameLower }"")]");
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
                    sb.AppendLine($@"        public IActionResult Get{ TypeName }List([FromQuery]string lang = ""en"", [FromQuery]int skip = 0, [FromQuery]int take = 200,");
                    sb.AppendLine($@"            [FromQuery]string asc = """", [FromQuery]string desc = """", [FromQuery]string where = """")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    string QueryStr = @"new Query() { Lang = lang }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), lang, skip, take, asc, desc, where);");
                    sb.AppendLine(@"");              
                    sb.AppendLine($@"                 if ({ TypeNameLower }Service.Query.HasErrors)");
                    sb.AppendLine(@"                 {");
                    sb.AppendLine($@"                     return Ok(new List<{ TypeName }>()");
                    sb.AppendLine(@"                     {");
                    sb.AppendLine($@"                         new { TypeName }()");
                    sb.AppendLine(@"                         {");
                    sb.AppendLine($@"                             HasErrors = { TypeNameLower }Service.Query.HasErrors,");
                    sb.AppendLine($@"                             ValidationResults = { TypeNameLower }Service.Query.ValidationResults,");
                    sb.AppendLine(@"                         },");
                    sb.AppendLine(@"                     }.ToList());");
                    sb.AppendLine(@"                 }");
                    sb.AppendLine(@"                 else");
                    sb.AppendLine(@"                 {");
                    sb.AppendLine($@"                     return Ok({ TypeNameLower }Service.Get{ TypeName }List().ToList());");
                    sb.AppendLine(@"                 }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");


                    sb.AppendLine($@"        // GET api/{ TypeNameLower }/1");
                    sb.AppendLine($@"        [Route(""{{{ TypeName }ID:int}}"")]");
                    sb.AppendLine($@"        public IActionResult Get{ TypeName }WithID([FromQuery]int { TypeName }ID, [FromQuery]string lang = ""en"")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
                    sb.AppendLine(@"            {");
                    QueryStr = @"new Query() { Language = (lang == ""fr"" ? LanguageEnum.fr : LanguageEnum.en) }";
                    sb.AppendLine($@"                { TypeName }Service { TypeNameLower }Service = new { TypeName }Service({ QueryStr }, db, ContactID);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), lang, 0, 1, """", """");");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                { TypeName } { TypeNameLower } = new { TypeName }();");
                    sb.AppendLine($@"                { TypeNameLower } = { TypeNameLower }Service.Get{ TypeName }With{ TypeName }ID({ TypeName }ID);");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                if ({ TypeNameLower } == null)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine($@"                    return NotFound();");
                    sb.AppendLine(@"                }");
                    sb.AppendLine($@"");
                    sb.AppendLine($@"                return Ok({ TypeNameLower });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        // POST api/{ TypeNameLower }");
                    sb.AppendLine(@"        [Route("""")]");
                    sb.AppendLine($@"        public IActionResult Post([FromBody]{ TypeName } { TypeNameLower }, [FromQuery]string lang = ""en"")");
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
                    sb.AppendLine($@"                    return Created(Url.ToString(), { TypeNameLower });");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        // PUT api/{ TypeNameLower }");
                    sb.AppendLine(@"        [Route("""")]");
                    sb.AppendLine($@"        public IActionResult Put([FromBody]{ TypeName } { TypeNameLower }, [FromQuery]string lang = ""en"")");
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
                    sb.AppendLine($@"        public IActionResult Delete([FromBody]{ TypeName } { TypeNameLower }, [FromQuery]string lang = ""en"")");
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
                    if (WithDoc)
                    {
                        fiOutputGen = new FileInfo($@"C:\CSSPTools\src\web\CSSPWebAPI\Controllers\srcWithDoc\{ TypeName }ControllerGenerated.cs");
                        using (StreamWriter sw2 = fiOutputGen.CreateText())
                        {
                            sw2.Write(sb.ToString());
                        }
                    }
                    else
                    {
                        fiOutputGen = new FileInfo($@"C:\CSSPTools\src\web\CSSPWebAPI\Controllers\src\{ TypeName }ControllerGenerated.cs");
                        using (StreamWriter sw2 = fiOutputGen.CreateText())
                        {
                            sw2.Write(sb.ToString());
                        }
                    }

                    StatusPermanentEvent(new StatusEventArgs($"Created [{ fiOutputGen.FullName }] ..."));
                }
            }

            StatusTempEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
            StatusPermanentEvent(new StatusEventArgs("Done ..."));
            StatusPermanentEvent(new StatusEventArgs(""));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
