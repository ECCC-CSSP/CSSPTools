using GenerateCodeBaseServices.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateValidation_Email(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.dataType == DataType.EmailAddress)
            {
                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }))");
                sb.AppendLine(@"            {");
                sb.AppendLine(@"                Regex regex = new Regex(@""^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$"");");
                sb.AppendLine($@"                if (!regex.IsMatch({ TypeNameLower }.{ prop.Name }))");
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsNotAValidEmail, ""{ prop.Name }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }

            return await Task.FromResult(true);
        }
    }
}
