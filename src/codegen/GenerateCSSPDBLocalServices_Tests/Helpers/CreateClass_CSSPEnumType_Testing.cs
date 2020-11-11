using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
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
                    string InsertVar = "var";
                    if (csspProp.PropName != "LocalDBCommand")
                    {
                        InsertVar = "";
                    }
                    sb.AppendLine($@"            { TypeNameLower } = null;");
                    sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                    sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = ({ csspProp.PropType })1000000;");
                    if (TypeName == "Contact")
                    { 
                        sb.AppendLine($@"            { InsertVar } action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                    }
                    else
                    {
                        sb.AppendLine($@"            { InsertVar } action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                    }
                    sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
