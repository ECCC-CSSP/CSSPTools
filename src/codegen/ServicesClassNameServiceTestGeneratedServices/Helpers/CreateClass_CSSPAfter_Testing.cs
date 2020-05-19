using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
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
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = new DateTime({ ((int)csspProp.Year - 1).ToString() }, 1, 1);");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    { TypeNameLower }Service.Add({ TypeNameLower });");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, ""{ csspProp.PropName }"", ""{ csspProp.Year }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");

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
                                sb.AppendLine($@"                    //CSSPError: Type not implemented [{ csspProp.PropName }]");
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
