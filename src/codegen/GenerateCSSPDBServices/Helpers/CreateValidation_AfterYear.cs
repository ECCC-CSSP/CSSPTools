using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateValidation_AfterYear(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.Year != null)
            {
                if (csspProp.IsNullable == true)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null && ((DateTime){ TypeNameLower }.{ csspProp.PropName }).Year < { csspProp.Year })");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }}));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
