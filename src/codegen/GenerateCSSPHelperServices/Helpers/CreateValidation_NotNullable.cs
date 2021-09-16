using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices
{
    public partial class Startup
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
                            //sb.AppendLine($@"            //{ prop.Name } (bool) is required but no testing needed ");
                            //sb.AppendLine(@"");
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            sb.AppendLine($@"            if ({ TypeNameLower }.{ prop.Name }.Year == 1)");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""));");
                            sb.AppendLine(@"            }");
                            sb.AppendLine(@"            else");
                            sb.AppendLine(@"            {");
                            sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name }.Year < { csspProp.Year })");
                            sb.AppendLine(@"                {");
                            sb.AppendLine($@"                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, ""{ prop.Name }"", ""{ csspProp.Year }""));");
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
                                sb.AppendLine($@"                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""));");
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
