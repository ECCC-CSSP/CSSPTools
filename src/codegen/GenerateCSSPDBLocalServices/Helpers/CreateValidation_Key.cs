using GenerateCodeBaseServices.Models;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateValidation_Key(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            string plurial = "s";
            if (TypeName == "Address")
            {
                plurial = "es";
            }
            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any())
            {
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)");
                sb.AppendLine(@"            {");
                sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == 0)");
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"");
                sb.AppendLine($@"                if (!(from c in dbLocal.{ TypeName }{ plurial }.AsNoTracking() select c).Where(c => c.{ TypeName.Replace("Local", "") }ID == { TypeNameLower }.{ TypeName.Replace("Local", "") }ID).Any())");
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName.Replace("Local", "") }"", ""{ TypeName.Replace("Local", "") }ID"", { TypeNameLower }.{ TypeName.Replace("Local", "") }ID.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                sb.AppendLine(@"                }");

                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                if (TypeName == "LocalTVItem")
                {
                    sb.AppendLine(@"            if (localTVItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"");

                    sb.AppendLine($@"                if ((from c in dbLocal.{ TypeName }{ plurial } select c).Count() > 0)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    yield return new ValidationResult(CSSPCultureServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ""TVItemTVItemID"" });");
                    sb.AppendLine(@"                }");
                                                    
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

            }

            return await Task.FromResult(true);
        }
    }
}
