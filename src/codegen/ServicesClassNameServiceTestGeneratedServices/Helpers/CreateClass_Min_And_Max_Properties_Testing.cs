using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> CreateClass_Min_And_Max_Properties_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
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

                        if (csspProp.Min != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Min - 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                        if (csspProp.Max != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Max + 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxValueIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
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
                        if (csspProp.Min != null)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            if (csspProp.Min - 1 > 0)
                            {
                                sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Min - 1).ToString() });");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                                }
                                if (csspProp.Max != null)
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                else
                                {
                                    sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MinLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                                }
                                sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                            }
                        }
                        if (csspProp.Max > 0)
                        {
                            sb.AppendLine($@"                    { TypeNameLower } = null;");
                            sb.AppendLine($@"                    { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"                    { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Max + 1).ToString() });");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }, AddContactTypeEnum.First));");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(false, { TypeNameLower }Service.Add({ TypeNameLower }));");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, ""{ csspProp.PropName }"", ""{ csspProp.Min.ToString() }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            else
                            {
                                sb.AppendLine($@"                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, ""{ csspProp.PropName }"", ""{ csspProp.Max.ToString() }""), { TypeNameLower }.ValidationResults.FirstOrDefault().ErrorMessage);");
                            }
                            sb.AppendLine($@"                    Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
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
