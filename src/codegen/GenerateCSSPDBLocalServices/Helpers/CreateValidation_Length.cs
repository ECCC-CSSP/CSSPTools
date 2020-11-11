using GenerateCodeBaseServices.Models;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateValidation_Length(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (!csspProp.IsKey)
            {
                switch (csspProp.PropType)
                {
                    case "Boolean":
                        {
                            // nothing
                        }
                        break;
                    case "DateTime":
                    case "DateTimeOffset":
                        {
                            // nothing
                        }
                        break;
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "Single":
                    case "Double":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                if (!csspProp.HasCSSPExistAttribute)
                                {
                                    sb.AppendLine($@"            //{ prop.Name } has no Range Attribute");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (csspProp.IsNullable)
                                    {
                                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                        sb.AppendLine(@"                {");
                                        sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                        sb.AppendLine(@"                }");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                        sb.AppendLine(@"            {");
                                        sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                        sb.AppendLine(@"            }");
                                        sb.AppendLine(@"");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() })");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } < { csspProp.Min.ToString() })");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }

                            }
                            else if (csspProp.Max != null)
                            {
                                if (csspProp.IsNullable)
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } != null)");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                if ({ TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                    sb.AppendLine(@"                {");
                                    sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                    sb.AppendLine(@"                }");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if ({ TypeNameLower }.{ csspProp.PropName } > { csspProp.Max.ToString() })");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else
                            {
                                sb.AppendLine($@"                { prop.Name } = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    case "String":
                        {
                            if (csspProp.Min == null && csspProp.Max == null)
                            {
                                sb.AppendLine($@"            //{ prop.Name } has no StringLength Attribute");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && ({ TypeNameLower }.{ csspProp.PropName }.Length < { csspProp.Min.ToString() } || { TypeNameLower }.{ csspProp.PropName }.Length > { csspProp.Max.ToString() }))");
                                    sb.AppendLine(@"            {");
                                    sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                    sb.AppendLine(@"            }");
                                    sb.AppendLine(@"");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && { TypeNameLower }.{ csspProp.PropName }.Length < { csspProp.Min.ToString() })");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }.{ prop.Name }) && { TypeNameLower }.{ csspProp.PropName }.Length > { csspProp.Max.ToString() })");
                                sb.AppendLine(@"            {");
                                sb.AppendLine($@"                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                                sb.AppendLine(@"            }");
                                sb.AppendLine(@"");
                            }
                            else
                            {
                                sb.AppendLine($@"            // { prop.Name } has no validation");
                                sb.AppendLine(@"");
                            }
                        }
                        break;
                    default:
                        {
                            if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                            {
                                // nothing yet
                            }
                            else
                            {
                                if (!csspProp.HasCSSPEnumTypeAttribute)
                                {
                                    sb.AppendLine($@"                //CSSPError: Type not implemented [{ csspProp.PropName }] of type [{ csspProp.PropType }]");
                                }
                            }
                        }
                        break;
                }
            }

            return await Task.FromResult(true);
        }
    }
}
