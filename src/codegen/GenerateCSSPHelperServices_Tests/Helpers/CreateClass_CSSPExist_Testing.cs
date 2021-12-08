using CSSPDBModels;
using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateClass_CSSPExist_Testing(CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
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
                case "Boolean":
                case "Single":
                    {
                        if (csspProp.IsKey)
                        {
                            break;
                        }

                        if (csspProp.HasCSSPExistAttribute)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($@"            { TypeNameLower } = null;");
                            sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                            sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = 0;");
                            sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                            sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, ""{ csspProp.PropName }""))).Any());");
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

                                sb.AppendLine("");
                                sb.AppendLine($@"            { TypeNameLower } = null;");
                                sb.AppendLine($@"            { TypeNameLower } = GetFilledRandom{ TypeName }("""");");
                                sb.AppendLine($@"            { TypeNameLower }.{ csspProp.PropName } = { TVItemIDNotGoodType };");
                                sb.AppendLine($@"            { TypeName }Service.Validate(new ValidationContext({ TypeNameLower }));");
                                sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Count() > 0);");
                                sb.AppendLine($@"            Assert.True({ TypeName }Service.errRes.ErrList.Where(c => c.Contains(string.Format(CSSPCultureServicesRes._IsRequired, ""{ csspProp.PropName }""))).Any());");
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
