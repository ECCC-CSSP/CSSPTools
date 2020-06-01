﻿using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateClassServiceFunctionsPrivateGenerateValidate(DLLTypeInfo dllTypeInfoModels, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            if (dllTypeInfoModels.Type.Name == "Contact")
            {
                sb.AppendLine(@"        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactTypeEnum addContactType)");
            }
            else
            {
                sb.AppendLine(@"        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)");
            }
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            string retStr = """";");
            sb.AppendLine($@"            { dllTypeInfoModels.Type.Name } { TypeNameLower } = validationContext.ObjectInstance as { dllTypeInfoModels.Type.Name };");
            sb.AppendLine($@"            { TypeNameLower }.HasErrors = false;");
            sb.AppendLine(@"");

            foreach (PropertyInfo prop in dllTypeInfoModels.Type.GetProperties())
            {
                if (prop.GetGetMethod().IsVirtual)
                {
                    continue;
                }

                if (prop.Name == "ValidationResults")
                {
                    continue;
                }

                CSSPProp csspProp = new CSSPProp();
                if (!GenerateCodeBaseService.FillCSSPProp(prop, csspProp, dllTypeInfoModels.Type))
                {
                    //ActionCommandDBService.ErrorText.AppendLine($"{ string.Format(AppRes.ErrorWhileCreatingCode_, csspProp.CSSPError) }");
                    return false;
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

            sb.AppendLine(@"            retStr = """"; // added to stop compiling CSSPError");
            sb.AppendLine(@"            if (retStr != """") // will never be true");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                { TypeNameLower }.HasErrors = true;");
            sb.AppendLine(@"                yield return new ValidationResult(""AAA"", new[] { ""AAA"" });");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}