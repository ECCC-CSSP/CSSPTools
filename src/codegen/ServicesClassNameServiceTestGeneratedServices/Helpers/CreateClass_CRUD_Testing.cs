﻿using CSSPEnums;
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
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> CreateClass_CRUD_Testing(string TypeName, string TypeNameLower, StringBuilder sb)
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

            return await Task.FromResult(true);
        }
    }
}
