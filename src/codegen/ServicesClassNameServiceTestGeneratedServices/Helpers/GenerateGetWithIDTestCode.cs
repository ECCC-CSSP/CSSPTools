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
        private async Task<bool> GenerateGetWithIDTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID)");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }With{ TypeName }ID__{ TypeNameLower }_{ TypeName }ID__Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    { TypeName } { TypeNameLower } = (from c in dbTestDB.{ TypeName }es select c).FirstOrDefault();");
            }
            else
            {
                sb.AppendLine($@"                    { TypeName } { TypeNameLower } = (from c in dbTestDB.{ TypeName }s select c).FirstOrDefault();");
            }
            sb.AppendLine($@"                    Assert.IsNotNull({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query.Extra = extra;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                        if (string.IsNullOrWhiteSpace(extra))");
            sb.AppendLine(@"                        {");
            sb.AppendLine($@"                            { TypeName } { TypeNameLower }Ret = { TypeNameLower }Service.Get{ TypeName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID);");
            sb.AppendLine($@"                            Check{ TypeName }Fields(new List<{ TypeName }>() {{ { TypeNameLower }Ret }});");
            sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }.{ TypeName }ID, { TypeNameLower }Ret.{ TypeName }ID);");
            sb.AppendLine(@"                        }");
            List<string> ClassNameList = new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" };
            foreach (string ClassName in ClassNameList)
            {
                Type currentType = null;

                foreach (Type TempType in types)
                {
                    if (TempType.Name == $"{ TypeName }{ ClassName }")
                    {
                        currentType = TempType;
                        break;
                    }
                }

                if (currentType == null)
                {
                    continue;
                }

                sb.AppendLine($@"                        else if (extra == ""{ ClassName.Substring(ClassName.Length - 1) }"")");
                sb.AppendLine(@"                        {");
                sb.AppendLine($@"                            { TypeName }{ ClassName } { TypeNameLower }{ ClassName }Ret = { TypeNameLower }Service.Get{ TypeName }{ ClassName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID);");
                sb.AppendLine($@"                            Check{ TypeName }{ ClassName }Fields(new List<{ TypeName }{ ClassName }>() {{ { TypeNameLower }{ ClassName }Ret }});");
                sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }.{ TypeName }ID, { TypeNameLower }{ ClassName }Ret.{ TypeName }ID);");
                sb.AppendLine(@"                        }");
            }
            sb.AppendLine(@"                        else");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            //Assert.AreEqual(true, false);");
            sb.AppendLine(@"                        }"); sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }With{ TypeName }ID({ TypeNameLower }.{ TypeName }ID)");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
