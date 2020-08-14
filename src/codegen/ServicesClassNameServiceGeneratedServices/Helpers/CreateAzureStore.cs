﻿using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateAzureStore(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        public async Task<ActionResult<string>> AzureStore()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string sto = Configuration.GetValue<string>(""AzureCSSPStorageConnectionString"");");
            sb.AppendLine(@"            if (string.IsNullOrWhiteSpace(sto))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, ""Configuration"", ""AzureCSSPStorageConnectionString"")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(Ok(sto));");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}