using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateClassServiceFunctionsPublicGenerateGet(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            foreach (DLLPropertyInfo dllPropertyInfo in dllTypeInfo.PropertyInfoList)
            {
                if (dllPropertyInfo.PropertyInfo.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (dllPropertyInfo.PropertyInfo.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBaseService.FillCSSPProp(dllPropertyInfo.PropertyInfo, csspProp, dllTypeInfo.Type))
                {
                    //ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                    return await Task.FromResult(false);
                }
                if (csspProp.IsKey)
                {
                    DLLTypeInfo currentDLLTypeInfo = null;
                    foreach (DLLTypeInfo dllTypeInfo2 in DLLTypeInfoCSSPModelsList)
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

                    if (currentDLLTypeInfo.Name == "AspNetUser")
                    {
                        sb.AppendLine($@"        public async Task<ActionResult<{ currentDLLTypeInfo.Name }>> Get{ currentDLLTypeInfo.Name }With{ TypeName }ID(string Id,");
                    }
                    else
                    {
                        sb.AppendLine($@"        public async Task<ActionResult<{ currentDLLTypeInfo.Name }>> Get{ currentDLLTypeInfo.Name }With{ currentDLLTypeInfo.Name }ID(int { currentDLLTypeInfo.Name }ID)");
                    }
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(Unauthorized());");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");

                    if (currentDLLTypeInfo.Name == "AspNetUser")
                    {
                        sb.AppendLine($@"            { currentDLLTypeInfo.Name } { currentDLLTypeInfo.Name.ToLower() } = (from c in db.{ TypeName }s.AsNoTracking()");
                        sb.AppendLine(@"                    where c.Id == Id");
                        sb.AppendLine(@"                    select c).FirstOrDefault();");
                    }
                    else
                    {
                        if (currentDLLTypeInfo.Name.StartsWith("Address"))
                        {
                            sb.AppendLine($@"            { currentDLLTypeInfo.Name } { currentDLLTypeInfo.Name.ToLower() } = (from c in db.{ TypeName }es.AsNoTracking()");
                        }
                        else
                        {
                            sb.AppendLine($@"            { currentDLLTypeInfo.Name } { currentDLLTypeInfo.Name.ToLower() } = (from c in db.{ TypeName }s.AsNoTracking()");
                        }
                        sb.AppendLine($@"                    where c.{ TypeName }ID == { TypeName }ID");
                        sb.AppendLine(@"                    select c).FirstOrDefault();");
                    }
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            if ({ currentDLLTypeInfo.Name.ToLower() } == null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine($@"               return await Task.FromResult(NotFound());");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            return await Task.FromResult(Ok({ currentDLLTypeInfo.Name.ToLower() }));");

                    sb.AppendLine(@"        }");

                    sb.AppendLine($@"        public async Task<ActionResult<List<{ currentDLLTypeInfo.Name }>>> Get{ currentDLLTypeInfo.Name }List()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(Unauthorized());");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    if (currentDLLTypeInfo.Name.StartsWith("Address"))
                    {
                        sb.AppendLine($@"            List<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name.ToLower() }List = (from c in db.{ currentDLLTypeInfo.Name }es.AsNoTracking() select c).Take(100).ToList();");
                    }
                    else
                    {
                        sb.AppendLine($@"            List<{ currentDLLTypeInfo.Name }> { currentDLLTypeInfo.Name.ToLower() }List = (from c in db.{ currentDLLTypeInfo.Name }s.AsNoTracking() select c).Take(100).ToList();");
                    }
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            return await Task.FromResult(Ok({ currentDLLTypeInfo.Name.ToLower() }List));");
                    sb.AppendLine(@"        }");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
