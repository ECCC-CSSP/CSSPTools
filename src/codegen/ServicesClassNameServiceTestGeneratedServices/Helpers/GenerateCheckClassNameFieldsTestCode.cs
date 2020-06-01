using GenerateCodeBaseServices.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGeneratedServices.Services
{
    public partial class ServicesClassNameServiceTestGeneratedService : IServicesClassNameServiceTestGeneratedService
    {
        private async Task<bool> GenerateCheckClassNameFieldsTestCode(Type type, List<Type> types, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine($@"        private void Check{ TypeName }Fields(List<{ TypeName }> { TypeNameLower }List)");
            sb.AppendLine(@"        {");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBaseService.FillCSSPProp(prop, csspProp, type))
                {
                    return await Task.FromResult(false);
                }
                if (csspProp.PropName == "ValidationResults")
                {
                    continue;
                }

                if (TypeName == "ContactLogin" && (csspProp.PropName == "PasswordHash" || csspProp.PropName == "PasswordSalt"))
                {
                    continue;
                }

                if (TypeName == "ResetPassword" && (csspProp.PropName == "Password" || csspProp.PropName == "ConfirmPassword"))
                {
                    continue;
                }

                if (csspProp.IsNullable)
                {
                    if (csspProp.PropType == "String")
                    {
                        sb.AppendLine($@"            if (!string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }))");
                    }
                    else
                    {
                        sb.AppendLine($@"            if ({ TypeNameLower }List[0].{ csspProp.PropName } != null)");
                    }
                    sb.AppendLine(@"            {");
                }
                if (csspProp.PropType == "String")
                {
                    sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsFalse(string.IsNullOrWhiteSpace({ TypeNameLower }List[0].{ csspProp.PropName }));");
                }
                else
                {
                    sb.AppendLine($@"            { (csspProp.IsNullable ? "    " : "") }Assert.IsNotNull({ TypeNameLower }List[0].{ csspProp.PropName });");
                }
                if (csspProp.IsNullable)
                {
                    sb.AppendLine(@"            }");
                }
            }
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
