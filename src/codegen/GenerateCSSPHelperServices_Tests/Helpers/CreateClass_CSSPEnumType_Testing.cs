using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
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
                    sb.AppendLine("");
                    sb.AppendLine($@"            { TypeNameLower } = null;");
                    sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                    sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = ({ csspProp.PropType })1000000;");
                    sb.AppendLine($@"            validationResults = { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                    sb.AppendLine($@"            ValidationResultList = validationResults.ToList();");
                    sb.AppendLine($@"            Assert.True(ValidationResultList.Count() > 0);");
                    sb.AppendLine($@"            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, ""{ csspProp.PropName }""))).Any());");
                    sb.AppendLine(@"");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
