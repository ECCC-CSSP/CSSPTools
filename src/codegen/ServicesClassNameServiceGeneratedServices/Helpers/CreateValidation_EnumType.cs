using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateValidation_EnumType(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.HasCSSPEnumTypeAttribute)
            {
                if (csspProp.IsNullable)
                {
                    sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name } != null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == null || !string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"                {");
                    //sb.AppendLine($@"                    { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine($@"            retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"            {");
                    //sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
