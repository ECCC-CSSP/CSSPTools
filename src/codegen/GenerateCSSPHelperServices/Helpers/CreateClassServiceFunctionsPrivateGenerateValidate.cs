using GenerateCodeBaseHelper;
using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices
{
    public partial class Startup
    {
        private async Task<bool> CreateClassServiceFunctionsPrivateGenerateValidateNotMapped(DLLTypeInfo dllTypeInfoModels, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            bool EnumExist = false;
            foreach (PropertyInfo prop in dllTypeInfoModels.Type.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, dllTypeInfoModels.Type))
                {
                    return await Task.FromResult(false);
                }

                if (csspProp.HasCSSPEnumTypeAttribute)
                {
                    EnumExist = true;
                    break;
                }
            }

            sb.AppendLine(@"        public bool Validate(ValidationContext validationContext)");
            sb.AppendLine(@"        {");
            if (EnumExist)
            {
                sb.AppendLine(@"            string retStr = """";");
            }
            sb.AppendLine($@"            { TypeName } { TypeNameLower } = validationContext.ObjectInstance as { TypeName };");
            sb.AppendLine(@"");

            foreach (PropertyInfo prop in dllTypeInfoModels.Type.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBase.FillCSSPProp(prop, csspProp, dllTypeInfoModels.Type))
                {
                    return await Task.FromResult(false);
                }

                if (!dllTypeInfoModels.HasNotMappedAttribute)
                {
                    if (!await CreateValidation_Key(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                }

                if (!await CreateValidation_NotNullable(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateValidation_Length(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateValidation_Email(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateValidation_AfterYear(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateValidation_Bigger(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateValidation_Exist(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
                if (!await CreateValidation_EnumType(prop, csspProp, dllTypeInfoModels.Type.Name, TypeNameLower, sb)) return await Task.FromResult(false);
            }

            sb.AppendLine(@"            return errRes.ErrList.Count == 0 ? true : false;");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
