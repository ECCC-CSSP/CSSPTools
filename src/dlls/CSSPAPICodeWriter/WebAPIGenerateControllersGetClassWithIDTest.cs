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
        private void GenerateControllersGetClassWithID(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller GetWithID Command");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Get{ TypeName }WithID_Test()");
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
            sb.AppendLine($@"                    IActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }First.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsType<OkObjectResult>(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult ret = jsonRet as OkObjectResult;");
            sb.AppendLine($@"                    Assert.Equal(200, ret.StatusCode);");
            sb.AppendLine($@"                    Assert.Equal({ TypeNameLower }First.{ TypeName }ID, (({ TypeName })ret.Value).{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestResult badRequest = jsonRet as BadRequestResult;");
            sb.AppendLine(@"                    Assert.Null(badRequest);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    // Not Found");
            sb.AppendLine($@"                    IActionResult jsonRet2 = { TypeNameLower }Controller.Get{ TypeName }WithID(0);");
            sb.AppendLine(@"                    Assert.IsType<NotFoundResult>(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    NotFoundResult notFoundRequest = jsonRet2 as NotFoundResult;");
            sb.AppendLine(@"                    Assert.Equal(404, notFoundRequest.StatusCode);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult { TypeNameLower }Ret2 = jsonRet2 as OkObjectResult;");
            sb.AppendLine($@"                    Assert.Null({ TypeNameLower }Ret2);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller GetWithID Command");
            sb.AppendLine(@"");
        }
    }
}
