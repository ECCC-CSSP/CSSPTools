using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_Required_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
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
                case "Double":
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = new DateTime();");
                            sb.AppendLine($@"            validationResults = { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            ValidationResultList = validationResults.ToList();");
                            sb.AppendLine($@"            Assert.True(ValidationResultList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, ""{ csspProp.PropName }""))).Any());");
                        }
                    }
                    break;
                case "String":
                    {
                        if (!csspProp.IsNullable)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }(""{ csspProp.PropName }"");");
                            sb.AppendLine($@"            validationResults = { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            ValidationResultList = validationResults.ToList();");
                            sb.AppendLine($@"            Assert.True(ValidationResultList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True(ValidationResultList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, ""{ csspProp.PropName }""))).Any());");
                            sb.AppendLine(@"");
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
                                string EndText = csspProp.PropName.EndsWith("Web") ? "Web" : "Report";

                                sb.AppendLine("");
                                sb.AppendLine($@"            { TypeNameLower } = null;");
                                sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"            { TypeNameLower }.{ TypeName }{ EndText } = null;");
                                sb.AppendLine($@"            Assert.IsNull({ TypeNameLower }.{ TypeName }{ EndText });");
                                sb.AppendLine(@"");
                                sb.AppendLine($@"            { TypeNameLower } = null;");
                                sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"            { TypeNameLower }.{ TypeName }{ EndText } = new { TypeName }{ EndText }();");
                                sb.AppendLine($@"            Assert.IsNotNull({ TypeNameLower }.{ TypeName }{ EndText });");
                            }
                            else if (csspProp.PropName.EndsWith("Report"))
                            {
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
