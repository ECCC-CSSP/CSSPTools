using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateAzureStore(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        public async Task<ActionResult<string>> AzureStore()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string sto = Configuration.GetValue<string>(""AzureStoreConnectionString"");");
            sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(sto))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, ""Configuration"", ""AzureStoreConnectionString"")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(Ok(sto));");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
