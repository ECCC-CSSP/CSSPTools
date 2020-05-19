using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateGetListTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List()");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Test()");
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
            sb.AppendLine($@"                    List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Take(200).ToList();");
            }
            else
            {
                sb.AppendLine($@"                    { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Take(200).ToList();");
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"                    foreach (string extra in new List<string>() { null, ""A"", ""B"", ""C"", ""D"", ""E"" })");
            sb.AppendLine(@"                    {");
            sb.AppendLine($@"                        { TypeNameLower }Service.Query.Extra = extra;");
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            if (!await GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, false)) return await Task.FromResult(false);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List()");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
