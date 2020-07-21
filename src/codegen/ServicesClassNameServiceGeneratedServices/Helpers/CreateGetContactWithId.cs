using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateGetContactWithId(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<ActionResult<Contact>> GetContactWithId(string Id)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            //if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)");
            sb.AppendLine(@"            //{");
            sb.AppendLine(@"            //    return await Task.FromResult(Unauthorized());");
            sb.AppendLine(@"            //}");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                Contact contact = (from c in dbIM.Contacts.AsNoTracking()");
            sb.AppendLine(@"                                   where c.Id == Id");
            sb.AppendLine(@"                                   select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"                if (contact == null)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(NotFound());");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                return await Task.FromResult(Ok(contact));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else if (LoggedInService.DBLocation == DBLocationEnum.Local)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                Contact contact = (from c in dbLocal.Contacts.AsNoTracking()");
            sb.AppendLine(@"                                   where c.Id == Id");
            sb.AppendLine(@"                                   select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"                if (contact == null)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(NotFound());");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                return await Task.FromResult(Ok(contact));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                Contact contact = (from c in db.Contacts.AsNoTracking()");
            sb.AppendLine(@"                                   where c.Id == Id");
            sb.AppendLine(@"                                   select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"                if (contact == null)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(NotFound());");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                return await Task.FromResult(Ok(contact));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
