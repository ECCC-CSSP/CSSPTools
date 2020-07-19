using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateValidation_NotNullable(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsNullable)
                switch (prop.PropertyType.Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            //sb.AppendLine($@"            //{ prop.Name } ({ prop.PropertyType.Name }) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D");
                            //sb.AppendLine(@"");
                        }
                        break;
                    case "Boolean":
                        {
                            if (csspProp.PropName == "HasErrors")
                            {
                                // nothing yet
                            }
                            else
                            {
                                //sb.AppendLine($@"            //{ prop.Name } (bool) is required but no testing needed ");
                                //sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name }.Year == 1)");
                            sb.AppendLine(@"            {");
                            //sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name }.Year < { csspProp.Year })");
                            sb.AppendLine(@"                {");
                            //sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                            sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, ""{ prop.Name }"", ""{ csspProp.Year }""), new[] {{ ""{ csspProp.PropName }"" }});");
                            sb.AppendLine(@"                }");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"");
                        }
                        break;
                    case "String":
                        {
                            if (!csspProp.IsKey)
                            {
                                sb.AppendLine($@"            if (string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }))");
                                sb.AppendLine(@"            {");
                                //sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ ""{ csspProp.PropName }"" }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (!csspProp.HasCSSPEnumTypeAttribute)
                            {
                                sb.AppendLine($@"                //CSSPError: Type not implemented [{ prop.Name }] of type [{ prop.PropertyType.Name }]");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                }

            return await Task.FromResult(true);
        }
    }
}
