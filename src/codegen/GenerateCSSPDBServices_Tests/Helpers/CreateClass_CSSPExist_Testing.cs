using CSSPDBModels;
using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_CSSPExist_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
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
                    {
                        if (csspProp.IsKey)
                        {
                            break;
                        }

                        if (csspProp.HasCSSPExistAttribute)
                        {
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = 0;");
                            if (TypeName == "Contact")
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                            }
                            else
                            {
                                sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                            }
                            sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                            sb.AppendLine(@"");

                            if (csspProp.ExistTypeName == "TVItem")
                            {
                                int TVItemIDNotGoodType = 0;
                                TVItem tvItem = null;
                                tvItem = (from c in db.TVItems
                                          where !csspProp.AllowableTVTypeList.Contains(c.TVType)
                                          select c).FirstOrDefault();

                                if (tvItem != null)
                                {
                                    TVItemIDNotGoodType = tvItem.TVItemID;
                                }

                                sb.AppendLine($@"            { TypeNameLower } = null;");
                                sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { TVItemIDNotGoodType };");
                                if (TypeName == "Contact")
                                {
                                    sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower }, AddContactTypeEnum.LoggedIn);");
                                }
                                else
                                {
                                    sb.AppendLine($@"            action{ TypeName } = await { TypeName }DBService.Post({ TypeNameLower });");
                                }
                                sb.AppendLine($@"            Assert.IsType<BadRequestObjectResult>(action{ TypeName }.Result);");
                                sb.AppendLine(@"");
                            }
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
