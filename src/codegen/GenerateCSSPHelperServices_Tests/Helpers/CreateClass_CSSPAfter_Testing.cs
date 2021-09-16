using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_CSSPAfter_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey)
            {
                return await Task.FromResult(true);
            }

            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Boolean":
                case "Single":
                case "Double":
                case "String":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (csspProp.HasCSSPAfterAttribute)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = new DateTime({ (int)csspProp.Year - 1 }, 1, 1);");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ (int)csspProp.Year }""))).Any());");
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.HasCSSPEnumTypeAttribute)
                        {
                            // nothing for now
                        }
                        else
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                sb.AppendLine($@"            //CSSPError: Type not implemented [{ csspProp.PropName }]");
                                sb.AppendLine(@"");
                            }
                        }
                    }
                    break;
            }

            return await Task.FromResult(true);
        }
    }
}
