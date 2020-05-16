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
        private async Task<bool> GenerateGetListSkipTake2DescTestCode(string TypeName, string TypeNameLower, Type type, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take 2 Desc");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_2Desc_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            string PropName2 = type.GetProperties().Skip(1).Take(1).FirstOrDefault().Name;
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, """", ""{ TypeName }ID,{ PropName2 }"", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).OrderByDescending(c => c.{ TypeName }ID).ThenByDescending(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).OrderByDescending(c => c.{ TypeName }ID).ThenByDescending(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            if (!await GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true)) return await Task.FromResult(false);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take 2 Desc");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
