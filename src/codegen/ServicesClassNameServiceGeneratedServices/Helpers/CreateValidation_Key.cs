using GenerateCodeBaseServices.Models;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateValidation_Key(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (prop.CustomAttributes.Where(c => c.AttributeType.Name.StartsWith("KeyAttribute")).Any())
            {
                sb.AppendLine(@"            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)");
                sb.AppendLine(@"            {");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == """")");
                }
                else
                {
                    sb.AppendLine($@"                if ({ TypeNameLower }.{ prop.Name } == 0)");
                }
                sb.AppendLine(@"                {");
                sb.AppendLine($@"                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, ""{ prop.Name }""), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                sb.AppendLine(@"                }");
                sb.AppendLine(@"");
                sb.AppendLine(@"                if (LoggedInService.DBLocation == DBLocationEnum.Local)");
                sb.AppendLine(@"                {");

                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                    if (!(from c in dbLocal.{ TypeName }s select c).Where(c => c.Id == { TypeNameLower }.Id).Any())");
                }
                else
                {
                    if (TypeName == "Address")
                    {
                        sb.AppendLine($@"                    if (!(from c in dbLocal.{ TypeName }es select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                    else
                    {
                        sb.AppendLine($@"                    if (!(from c in dbLocal.{ TypeName }s select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                }
                sb.AppendLine(@"                    {");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }Id"", ({ TypeNameLower }.Id == null ? """" : { TypeNameLower }.Id.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                }
                else
                {
                    sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeNameLower }.{ TypeName }ID.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                }
                sb.AppendLine(@"                    }");

                sb.AppendLine(@"                }");
                sb.AppendLine(@"                else");
                sb.AppendLine(@"                {");

                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                    if (!(from c in db.{ TypeName }s select c).Where(c => c.Id == { TypeNameLower }.Id).Any())");
                }
                else
                {
                    if (TypeName == "Address")
                    {
                        sb.AppendLine($@"                    if (!(from c in db.{ TypeName }es select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                    else
                    {
                        sb.AppendLine($@"                    if (!(from c in db.{ TypeName }s select c).Where(c => c.{ TypeName }ID == { TypeNameLower }.{ TypeName }ID).Any())");
                    }
                }
                sb.AppendLine(@"                    {");
                if (TypeName == "AspNetUser")
                {
                    sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }Id"", ({ TypeNameLower }.Id == null ? """" : { TypeNameLower }.Id.ToString())), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                }
                else
                {
                    sb.AppendLine($@"                        yield return new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeNameLower }.{ TypeName }ID.ToString()), new[] {{ nameof({ TypeNameLower }.{ csspProp.PropName }) }});");
                }
                sb.AppendLine(@"                    }");

                sb.AppendLine(@"                }");
                sb.AppendLine(@"            }");
                sb.AppendLine(@"");

                if (TypeName == "TVItem")
                {
                    sb.AppendLine(@"            if (tvItem.TVType == TVTypeEnum.Root)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                if (LoggedInService.DBLocation == DBLocationEnum.Local)");
                    sb.AppendLine(@"                {");
                                                    
                    if (TypeName == "Address")      
                    {                               
                        sb.AppendLine($@"                    if ((from c in dbLocal.{ TypeName }es select c).Count() > 0)");
                    }                               
                    else                            
                    {                               
                        sb.AppendLine($@"                    if ((from c in dbLocal.{ TypeName }s select c).Count() > 0)");
                    }                               
                    sb.AppendLine(@"                    {");
                    sb.AppendLine(@"                        yield return new ValidationResult(CSSPCultureServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ""TVItemTVItemID"" });");
                    sb.AppendLine(@"                    }");
                                                    
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"                else");
                    sb.AppendLine(@"                {");
                                                    
                    if (TypeName == "Address")      
                    {                               
                        sb.AppendLine($@"                    if ((from c in db.{ TypeName }es select c).Count() > 0)");
                    }                               
                    else                            
                    {                               
                        sb.AppendLine($@"                    if ((from c in db.{ TypeName }s select c).Count() > 0)");
                    }                               
                    sb.AppendLine(@"                    {");
                    sb.AppendLine(@"                        yield return new ValidationResult(CSSPCultureServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ""TVItemTVItemID"" });");
                    sb.AppendLine(@"                    }");
                                                    
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                }

            }

            return await Task.FromResult(true);
        }
    }
}
