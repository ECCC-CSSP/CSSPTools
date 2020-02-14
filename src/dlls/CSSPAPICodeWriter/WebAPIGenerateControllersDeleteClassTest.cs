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
        private void GenerateControllersDeleteClass(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated for Class Controller Delete Command");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void { TypeName }_Controller_Delete_Test()");
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
            sb.AppendLine($@"                    IActionResult jsonRet = { TypeNameLower }Controller.Get{ TypeName }WithID({ TypeNameLower }Last.{ TypeName }ID);");
            sb.AppendLine(@"                    Assert.IsType<OkObjectResult>(jsonRet);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult Ret = jsonRet as OkObjectResult;");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower }Ret = ({ TypeName })Ret.Value;");
            sb.AppendLine($@"                    Assert.Equal({ TypeNameLower }Last.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestResult badRequest = jsonRet as BadRequestResult;");
            sb.AppendLine(@"                    Assert.Null(badRequest);");
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
            //sb.AppendLine($@"                    { TypeNameLower }Controller.Request = new System.Net.Http.HttpRequestMessage();");
            //sb.AppendLine($@"                    { TypeNameLower }Controller.Request.RequestUri = new System.Uri(""http://localhost:5000/api/{ TypeNameLower }"");");
            sb.AppendLine($@"                    IActionResult jsonRet3 = { TypeNameLower }Controller.Post({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsType<CreatedResult>(jsonRet3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    CreatedResult ret3 = jsonRet3 as CreatedResult;");
            sb.AppendLine($@"                    Assert.IsType<CreatedResult>(ret3);");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = ({ TypeName })ret3.Value;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestResult badRequest3 = jsonRet3 as BadRequestResult;");
            sb.AppendLine(@"                    Assert.Null(badRequest3);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Delete to return success");
            sb.AppendLine($@"                    IActionResult jsonRet2 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsType<OkObjectResult>(jsonRet2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult ret2 = jsonRet2 as OkObjectResult;");
            sb.AppendLine($@"                    Assert.NotNull(ret2);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestResult badRequest2 = jsonRet2 as BadRequestResult;");
            sb.AppendLine(@"                    Assert.Null(badRequest2);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    // Delete to return CSSPError because { TypeName }ID of 0 does not exist");
            sb.AppendLine($@"                    { TypeNameLower }Ret.{ TypeName }ID = 0;");
            sb.AppendLine($@"                    IActionResult jsonRet4 = { TypeNameLower }Controller.Delete({ TypeNameLower }Ret, LanguageRequest.ToString());");
            sb.AppendLine(@"                    Assert.IsType<BadRequestObjectResult>(jsonRet4);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    OkObjectResult ret4 = jsonRet4 as OkObjectResult;");
            sb.AppendLine($@"                    Assert.Null(ret4);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    BadRequestObjectResult badRequest4 = jsonRet4 as BadRequestObjectResult;");
            sb.AppendLine(@"                    Assert.NotNull(badRequest4);");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Tests Generated for Class Controller Delete Command");
            sb.AppendLine(@"");
        }
    }
}
