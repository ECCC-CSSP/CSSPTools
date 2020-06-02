using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateValidation_AfterYear(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.Year != null)
            {
                if (csspProp.IsNullable == true)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null && ((DateTime){ TypeNameLower }.{ csspProp.PropName }).Year < { csspProp.Year })");
                    sb.AppendLine(@"            {");
                    //sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
