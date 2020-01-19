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
            sb.AppendLine(@"                    Assert.NotNull(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> Ret = jsonRet as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = Ret.Content;");
            sb.AppendLine($@"                    Assert.Equal({ TypeNameLower }Last.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest = jsonRet as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Put to return success");
            sb.AppendLine($@"                    IHttpActionResult jsonRet2 = { TypeNameLower }Controller.Put({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.NotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret2 = jsonRet2 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.NotNull({ TypeNameLower }Ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest2 = jsonRet2 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.IsNull(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Put to return CSSPError because { TypeName }ID of 0 does not exist");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            sb.AppendLine($@"                    IHttpActionResult jsonRet3 = { TypeNameLower }Controller.Put({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.NotNull(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkNegotiatedContentResult<{ TypeName }> { TypeNameLower }Ret3 = jsonRet3 as OkNegotiatedContentResult<{ TypeName }>;");
            sb.AppendLine($@"                    Assert.IsNull({ TypeNameLower }Ret3);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestErrorMessageResult badRequest3 = jsonRet3 as BadRequestErrorMessageResult;");
            sb.AppendLine(@"                    Assert.NotNull(badRequest3);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Put Command");
            sb.AppendLine(@"");
        }
    }
}
