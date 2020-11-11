using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_CSSPAfter_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (csspProp.IsVirtual || csspProp.IsKey || csspProp.PropName == "ValidationResults")
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
                case "String":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (csspProp.HasCSSPAfterAttribute)
                        {
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = new DateTime({ ((int)csspProp.Year - 1).ToString() }, 1, 1);");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                            }
                            sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");

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
