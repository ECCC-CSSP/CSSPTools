using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateClassServiceFunctionsPublicGenerateGet(DLLTypeInfo dllTypeInfo, List<DLLTypeInfo> DLLTypeInfoCSSPModelsList, string TypeName, string TypeNameLower, StringBuilder sb, string DBType)
        {
            string db = "";
            if (DBType == "DB")
            {
                db = "db";
            }
            if (DBType == "DBLocal")
            {
                db = "dbLocal";
            }
            if (DBType == "DBLocalIM")
            {
                db = "dbLocalIM";
            }
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

                    if (TypeName == "AspNetUser")
                    {
                        sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Get{ TypeName }WithId(string Id)");
                    }
                    else
                    {
                        sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Get{ TypeName }With{ TypeName }ID(int { TypeName }ID)");
                    }
                    sb.AppendLine(@"        {");
                    if (DBType == "DB")
                    {
                        sb.AppendLine(@"            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)");
                    }
                    if (DBType == "DBLocal")
                    {
                        sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
                    }
                    if (DBType == "DBLocalIM")
                    {
                        sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
                    }
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(Unauthorized(""""));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");

                    if (DBType == "DB")
                    {
                        sb.AppendLine($@"            { TypeName } { TypeNameLower } = (from c in { db }.{ TypeName }{ Plurial }.AsNoTracking()");
                    }
                    if (DBType == "DBLocal")
                    {
                        sb.AppendLine($@"            { TypeName } { TypeNameLower } = (from c in { db }.{ TypeName }{ Plurial }.AsNoTracking()");
                    }
                    if (DBType == "DBLocalIM")
                    {
                        sb.AppendLine($@"            { TypeName } { TypeNameLower } = (from c in { db }.{ TypeName }{ Plurial }.Local");
                    }

                    if (currentDLLTypeInfo.Name == "AspNetUser")
                    {
                        sb.AppendLine(@"                    where c.Id == Id");
                    }
                    else
                    {
                        sb.AppendLine($@"                    where c.{ TypeName }ID == { TypeName }ID");
                    }
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
                    if (DBType == "DB")
                    {
                        sb.AppendLine(@"            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)");
                    }
                    if (DBType == "DBLocal")
                    {
                        sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
                    }
                    if (DBType == "DBLocalIM")
                    {
                        sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
                    }
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                return await Task.FromResult(Unauthorized(""""));");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");

                    if (DBType == "DB")
                    {
                        if (TypeName == "AspNetUser")
                        {
                            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in { db }.{ TypeName }{ Plurial }.AsNoTracking() orderby c.Email select c).Skip(skip).Take(take).ToList();");
                        }
                        else
                        {
                            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in { db }.{ TypeName }{ Plurial }.AsNoTracking() orderby c.{ TypeName }ID select c).Skip(skip).Take(take).ToList();");
                        }
                    }
                    if (DBType == "DBLocal")
                    {
                        if (TypeName == "AspNetUser")
                        {
                            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in { db }.{ TypeName }{ Plurial }.AsNoTracking() orderby c.Email select c).Skip(skip).Take(take).ToList();");
                        }
                        else
                        {
                            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in { db }.{ TypeName }{ Plurial }.AsNoTracking() orderby c.{ TypeName }ID select c).Skip(skip).Take(take).ToList();");
                        }
                    }
                    if (DBType == "DBLocalIM")
                    {
                        if (TypeName == "AspNetUser")
                        {
                            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in { db }.{ TypeName }{ Plurial }.Local orderby c.Email select c).Skip(skip).Take(take).ToList();");
                        }
                        else
                        {
                            sb.AppendLine($@"            List<{ TypeName }> { TypeNameLower }List = (from c in { db }.{ TypeName }{ Plurial }.Local orderby c.{ TypeName }ID select c).Skip(skip).Take(take).ToList();");
                        }
                    }
                    sb.AppendLine(@"");
                    sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }List));");

                    sb.AppendLine(@"        }");
                }
            }

            return await Task.FromResult(true);
        }
    }
}
