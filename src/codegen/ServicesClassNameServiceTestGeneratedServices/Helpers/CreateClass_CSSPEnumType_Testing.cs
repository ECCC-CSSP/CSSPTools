using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> CreateClass_CSSPEnumType_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
            {
                return await Task.FromResult(true);
            }

            if (csspProp.PropType.EndsWith("Enum"))
            {
                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    sb.AppendLine($@"                    { TypeNameLower } = null;");
                    sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                    sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = ({ csspProp.PropType })1000000;");
                    if (TypeName == "Contact")
                    {
                        sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                    }
                    else
                    {
                        sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                    }
                    sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
