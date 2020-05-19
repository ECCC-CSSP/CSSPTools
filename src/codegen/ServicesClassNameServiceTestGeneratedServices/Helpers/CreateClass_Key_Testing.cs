using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> CreateClass_Key_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"                    { TypeNameLower } = null;");
            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 0;");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, ""{ csspProp.PropName }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    { TypeNameLower } = null;");
            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = 10000000;");
            sb.AppendLine($@"                    { TypeNameLower }Service.Update({ TypeNameLower });");
            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ csspProp.PropName }"", { TypeNameLower }.{ csspProp.PropName }.ToString()), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
