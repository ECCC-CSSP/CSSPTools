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
        private void GenerateCRUDTestCode(string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        #region Tests Generated CRUD");
            sb.AppendLine(@"        [Fact]");
            sb.AppendLine($@"        public void { TypeName }_CRUD_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext())");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    int count = 0;");
            sb.AppendLine(@"                    if (count == 1)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeName } { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine(@"");

            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // CRUD testing");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"                    // -------------------------------");
            sb.AppendLine(@"");

            CreateClass_CRUD_Testing(TypeName, TypeNameLower, sb);
            sb.AppendLine(@"");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            sb.AppendLine(@"        #endregion Tests Generated CRUD");
            sb.AppendLine(@"");
        }
    }
}
