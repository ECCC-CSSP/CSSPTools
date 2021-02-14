using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateGetContactWithId(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        private async Task<ActionResult<Contact>> GetContactWithLoginEmail(string LoginEmail)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            Contact contact = (from c in db.Contacts.AsNoTracking()");
            sb.AppendLine(@"                               where c.LoginEmail == LoginEmail");
            sb.AppendLine(@"                               select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (contact == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(NotFound());");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(Ok(contact));");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
