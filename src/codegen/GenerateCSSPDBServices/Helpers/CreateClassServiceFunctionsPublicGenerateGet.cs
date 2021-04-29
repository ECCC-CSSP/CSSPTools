using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateClassServiceFunctionsPublicGenerateGet(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPDBModelsList, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "Address", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfo.PropertyInfoList)
            {
                if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (dllPropertyInfo.PropertyInfo.Name == "ValidationResultList")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBase.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, dllTypeInfo.Type))
                {
                    //Console.WriteLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                    return await Task.FromResult(false);
                }
                if (csspProp.IsKey)
                {
                    DLLTypeInfo currentDLLTypeInfo = null;
                    foreach (DLLTypeInfo dllTypeInfo2 in DLLTypeInfoCSSPDBModelsList)
                    {
                        if (dllTypeInfo2.Name == TypeName)
                        {
                            currentDLLTypeInfo = dllTypeInfo2;
                        }
                    }

                    if (currentDLLTypeInfo == null)
                    {
                        continue;
                    }

                    //if (TypeName == "AspNetUser")
                    //{
                    //    sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Get{ TypeName }WithId(string Id)");
                    //}
                    //else
                    //{
                        sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Get{ TypeName }With{ TypeName }ID(int { TypeName }ID)");
                    //}
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");

                    sb.AppendLine($@"            { TypeName } { TypeNameLower } = (from c in db.{ TypeName }{ Plurial }.AsNoTracking()");

                    //if (currentDLLTypeInfo.Name == "AspNetUser")
                    //{
                    //    sb.AppendLine(@"                    where c.Id == Id");
                    //}
                    //else
                    //{
                        sb.AppendLine($@"                    where c.{ TypeName }ID == { TypeName }ID");
                    //}
                    sb.AppendLine(@"                    select c).FirstOrDefault();");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            if ({ TypeNameLower } == null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(NotFound(""""));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }));");

                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        public async Task<ActionResult<List<{ TypeName }>>> Get{ TypeName }List(int skip = 0, int take = 100)");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");

                    //if (TypeName == "AspNetUser")
                    //{
                    //    sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in db.{ TypeName }{ Plurial }.AsNoTracking() orderby c.Email select c).Skip(skip).Take(take).ToList();");
                    //}
                    //else
                    //{
                        sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in db.{ TypeName }{ Plurial }.AsNoTracking() orderby c.{ TypeName }ID select c).Skip(skip).Take(take).ToList();");
                    //}
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }List));");

                    sb.AppendLine(@"        }");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
