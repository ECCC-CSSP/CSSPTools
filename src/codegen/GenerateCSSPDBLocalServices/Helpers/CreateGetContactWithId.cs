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
            sb.AppendLine(@"        private async Task<ActionResult<LocalContact>> GetLocalContactWithId(string Id)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            LocalContact localContact = (from c in dbLocal.LocalContacts.AsNoTracking()");
            sb.AppendLine(@"                               where c.Id == Id");
            sb.AppendLine(@"                               select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (localContact == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(NotFound());");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(Ok(localContact));");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
