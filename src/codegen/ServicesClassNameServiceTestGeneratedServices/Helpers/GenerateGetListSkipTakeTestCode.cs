using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateGetListSkipTakeTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_Test()");
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
            sb.AppendLine($@"                        { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, """", """", """", extra);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                        List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                        { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            if (!await GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true)) return await Task.FromResult(false);
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
