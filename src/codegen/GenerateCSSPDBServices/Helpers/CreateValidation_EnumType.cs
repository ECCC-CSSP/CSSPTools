using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
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
                    sb.AppendLine($@"                    ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }}));");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
                else
                {
                    sb.AppendLine($@"            retStr = enums.EnumTypeOK(typeof({ csspProp.PropType }), (int?){ TypeNameLower }.{ prop.Name });");
                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace(retStr))");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"                ValidationResultList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }}));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
