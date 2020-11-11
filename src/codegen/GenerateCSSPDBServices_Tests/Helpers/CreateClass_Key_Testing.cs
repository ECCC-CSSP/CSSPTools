using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_Key_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"            { TypeNameLower } = null;");
            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = """";");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = 0;");
            }
            sb.AppendLine(@"");
            sb.AppendLine($@"            var action{ TypeName } = await { TypeName }DBService.Put({ TypeNameLower });");
            sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeNameLower } = null;");
            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = ""silefjilsefjsliejlsjflisjefl"";");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = 10000000;");
            }
            sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Put({ TypeNameLower });");
            sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
