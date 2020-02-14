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
        private void GenerateControllersGetClassList(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller GetList Command");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Get{ TypeName }List_Test()");
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
            sb.AppendLine($@"                    IActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }List();");
            sb.AppendLine(@"                    Assert.IsType<OkObjectResult>(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult ret = jsonRet as OkObjectResult;");
            sb.AppendLine($@"                    Assert.Equal({ TypeNameLower }First.{ TypeName }ID, ((List<{ TypeName }>)ret.Value)[0].{ TypeName }ID);");
            sb.AppendLine($@"                    Assert.Equal((count > query.Take ? query.Take : count), ((List<{ TypeName }>)ret.Value).Count);");
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
            sb.AppendLine(@"                        Assert.IsType<OkObjectResult>(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        ret = jsonRet as OkObjectResult;");
            sb.AppendLine($@"                        Assert.Equal({ TypeNameLower }List[0].{ TypeName }ID, ((List<{ TypeName }>)ret.Value)[0].{ TypeName }ID);");
            sb.AppendLine($@"                        Assert.Equal((count > query.Take ? query.Take : count), ((List<{ TypeName }>)ret.Value).Count);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                       if (count > 1)");
            sb.AppendLine(@"                       {");
            sb.AppendLine(@"                           query.Skip = 1;");
            sb.AppendLine(@"                           query.Take = 5;");
            sb.AppendLine(@"                           count = (query.Take > count ? query.Take : count);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                           // ok with { TypeName } info");
            sb.AppendLine($@"                           IActionResult jsonRet2 = { TypeNameLower }Controller.Get{ TypeName }List(query.Language.ToString(), query.Skip, query.Take);");
            sb.AppendLine(@"                           Assert.NotNull(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                           OkObjectResult ret2 = jsonRet2 as OkObjectResult;");
            sb.AppendLine($@"                           Assert.Equal({ TypeNameLower }List[1].{ TypeName }ID, ((List<{ TypeName }>)ret2.Value)[0].{ TypeName }ID);");
            sb.AppendLine($@"                           Assert.Equal((count > query.Take ? query.Take : count), ((List<{ TypeName }>)ret2.Value).Count);");
            sb.AppendLine(@"                       }");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller GetList Command");
            sb.AppendLine(@"");
        }
    }
}
