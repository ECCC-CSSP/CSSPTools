using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices
{
    public partial class Startup
    {
        private async Task<bool> CreateValidation_Bigger(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!string.IsNullOrWhiteSpace(csspProp.OtherField))
            {
                sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.OtherField } > { TypeNameLower }.{ csspProp.PropName })");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._DateIsBiggerThan_, ""{ csspProp.PropName }"", ""{ TypeName }{ csspProp.OtherField }""));");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");
            }

            return await Task.FromResult(true);
        }
    }
}
