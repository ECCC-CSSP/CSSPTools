using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClassNameServiceGeneratedServices.Services
{
    public partial class ServicesClassNameServiceGeneratedService : IServicesClassNameServiceGeneratedService
    {
        private async Task<bool> CreateClassServiceFunctionsPublicGenerateCRUD(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "Address", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            sb.AppendLine(@"        #region Functions public Generated CRUD");

            if (TypeName == "Contact")
            {
                sb.AppendLine($@"        public bool Add({ TypeName } { TypeNameLower }, AddContactTypeEnum addContactType)");
            }
            else
            {
                sb.AppendLine($@"        public bool Add({ TypeName } { TypeNameLower })");
            }
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create, addContactType);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");

            sb.AppendLine($@"        public bool Delete({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Delete);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");

            sb.AppendLine($@"        public bool Update({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            { TypeNameLower }.ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine($@"            if ({ TypeNameLower }.ValidationResults.Count() > 0) return false;");
            sb.AppendLine(@"");
            sb.AppendLine($@"            db.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if (!TryToSave({ TypeNameLower })) return false;");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return true;");
            sb.AppendLine(@"        }");
            sb.AppendLine(@"        #endregion Functions public Generated CRUD");
            sb.AppendLine(@"");

            return await Task.FromResult(true);
        }
    }
}
