using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using CSSPModels;
using CSSPEnums;
using CSSPServices;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter
    {
        private void GenerateGetListTestCode(string TypeName, string TypeNameLower, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List()");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext())");
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
            sb.AppendLine($@"                    Assert.NotNull({ TypeNameLower });");
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
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List()");
            sb.AppendLine(@"");
        }
    }
}
