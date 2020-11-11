using GenerateCodeBaseServices.Models;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
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
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { (csspProp.Min - 1).ToString() }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.First);");
                            }
                            else
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                            }
                            if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            }
                            else
                            {
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            }
                            sb.AppendLine($@"            //Assert.AreEqual(count, { TypeNameLower }Service.Get{ TypeName }List().Count());");
                        }
                        if (csspProp.Max != null)
                        {
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { csspProp.Max + 1 }{ numbExt };");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.First);");
                            }
                            else
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            }
                            else
                            {
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            }
                            sb.AppendLine($@"            //Assert.AreEqual(count, { TypeNameLower }DBService.Get{ TypeName }List().Count());");
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
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            if (csspProp.Min - 1 > 0)
                            {
                                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { (csspProp.Min - 1).ToString() });");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.First);");
                                }
                                else
                                {
                                    sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                                }
                                if (csspProp.Max != null)
                                {
                                    sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                                }
                                else
                                {
                                    sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                                }
                                sb.AppendLine($@"            //Assert.AreEqual(count, { TypeNameLower }DBService.Get{ TypeName }List().Count());");
                            }
                        }
                        if (csspProp.Max > 0)
                        {
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");

                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = GetRandomString("""", { csspProp.Max + 1 });");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.First);");
                            }
                            else
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                            }
                            if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            }
                            else
                            {
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            }
                            sb.AppendLine($@"            //Assert.AreEqual(count, { TypeNameLower }DBService.Get{ TypeName }List().Count());");
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
