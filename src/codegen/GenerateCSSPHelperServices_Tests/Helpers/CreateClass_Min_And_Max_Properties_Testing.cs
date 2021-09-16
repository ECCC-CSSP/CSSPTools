using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_Min_And_Max_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
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
                case "Single":
                case "Double":
                    {
                        //string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            //  propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            //propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.Min == null && csspProp.Max == null)
                        {
                            // nothing to do
                        }
                        else if (csspProp.Min != null && csspProp.Max != null)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { csspProp.Min - 1 }{ numbExt };");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min }"", ""{ csspProp.Max }""))).Any());");

                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { csspProp.Max + 1 }{ numbExt };");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min }"", ""{ csspProp.Max }""))).Any());");
                        }
                        else if (csspProp.Min != null)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { csspProp.Min - 1 }{ numbExt };");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min }""))).Any());");
                        }
                        else if (csspProp.Max != null)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { csspProp.Max + 1 }{ numbExt };");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max }""))).Any());");
                        }
                        else
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"                { TypeName } = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                        }
                    }
                    break;
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
                case "String":
                    {
                        if (csspProp.Min == null && csspProp.Max == null)
                        {
                            // nothing to do
                        }
                        else if (csspProp.Min != null && csspProp.Max != null)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { csspProp.Max + 1 });");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min }"", ""{ csspProp.Max }""))).Any());");

                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { csspProp.Max + 1 });");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min }"", ""{ csspProp.Max }""))).Any());");
                        }
                        else if (csspProp.Min != null)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            if (csspProp.Min - 1 > 0)
                            {
                                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { csspProp.Min - 1 });");
                                sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                                sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                                sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min }""))).Any());");
                            }
                        }
                        else if (csspProp.Max > 0)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { csspProp.Max + 1 });");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max }""))).Any());");
                        }
                        else
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"                { TypeName } = CreateValidationNotRequiredLengths_ConditionShouldNotHappenIn_Int,");
                        }
                    }
                    break;
                default:
                    {
                    }
                    break;
            }

            return await Task.FromResult(true);
        }
    }
}
