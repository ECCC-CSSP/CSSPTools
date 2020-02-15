using System;
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
        private void GenerateControllersPutClass(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller Put Command");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Put_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (LanguageEnum LanguageRequest in AllowableLanguages)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                foreach (int ContactID in new List<int>() { AdminContactID })  //, TestEmailValidatedContactID, TestEmailNotValidatedContactID })");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Controller { TypeNameLower }Controller = new { TypeName }Controller(DatabaseTypeEnum.SqlServerTestDB);");
            sb.AppendLine($@"                    Assert.NotNull({ TypeNameLower }Controller);");
            sb.AppendLine($@"                    Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, { TypeNameLower }Controller.DatabaseType);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }First = new { TypeName }();");
            sb.AppendLine(@"                    using (CSSPDBContext db = new CSSPDBContext(DatabaseType))");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Query query = new Query();");
            sb.AppendLine(@"                        query.Language = LanguageRequest;");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(query, db, ContactID);");
            if (TypeName == "TVItem")
            {
                sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }s select c).Skip(2).FirstOrDefault();");
            }
            else
            {
                if (TypeName == "Address")
                {
                    sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }es select c).FirstOrDefault();");
                }
                else
                {
                    sb.AppendLine($@"                        { TypeNameLower }First = (from c in db.{ TypeName }s select c).FirstOrDefault();");
                }
            }
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // ok with { TypeName } info");
            sb.AppendLine($@"                    IActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }First.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsType<OkObjectResult>(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult Ret = jsonRet as OkObjectResult;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = ({ TypeName })Ret.Value;");
            sb.AppendLine($@"                    Assert.Equal({ TypeNameLower }First.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestResult badRequest = jsonRet as BadRequestResult;");
            sb.AppendLine(@"                    Assert.Null(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Put to return success");
            sb.AppendLine($@"                    IActionResult jsonRet2 = { TypeNameLower }Controller.Put({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsType<OkObjectResult>(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult { TypeNameLower }Ret2 = jsonRet2 as OkObjectResult;");
            sb.AppendLine($@"                    Assert.NotNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;");
            sb.AppendLine(@"                    Assert.Null(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Put to return CSSPError because { TypeName }ID of 0 does not exist");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            sb.AppendLine($@"                    IActionResult jsonRet3 = { TypeNameLower }Controller.Put({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsType<BadRequestObjectResult>(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult { TypeNameLower }Ret3 = jsonRet3 as OkObjectResult;");
            sb.AppendLine($@"                    Assert.Null({ TypeNameLower }Ret3);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestObjectResult badRequest3 = jsonRet3 as BadRequestObjectResult;");
            sb.AppendLine(@"                    Assert.NotNull(badRequest3);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Put Command");
            sb.AppendLine(@"");
        }
    }
}
