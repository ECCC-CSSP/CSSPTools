using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateValidation_Bigger(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.OtherField))
            {
                sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.OtherField } > { TypeNameLower }.{ csspProp.PropName })");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, ""{ csspProp.PropName }"", ""{ TypeName }{ csspProp.OtherField }""), new[] {{ ""{ csspProp.PropName }"" }});");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }

            return await Task.FromResult(true);
        }
    }
}
