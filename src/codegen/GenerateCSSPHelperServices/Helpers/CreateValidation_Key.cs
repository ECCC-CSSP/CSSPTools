using GenerateCodeBaseServices.Models;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices
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
                sb.AppendLine($@"                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""));");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"");
                sb.AppendLine($@"                if (!(from c in db.{ TypeName }{ plurial }.AsNoTracking() select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    errRes.ErrList.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeNameLower }.{ TypeName }ID.ToString()));");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                if (TypeName == "TVItem")
                {
                    sb.AppendLine(@"            if (tvItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"                if ((from c in db.{ TypeName }{ plurial } select c).Count() > 0)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    errRes.ErrList.Add(CSSPCultureServicesRes.TVItemRootShouldBeTheFirstOneAdded);");
                    sb.AppendLine(@"                }");                                                   
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

            }

            return await Task.FromResult(true);
        }
    }
}
