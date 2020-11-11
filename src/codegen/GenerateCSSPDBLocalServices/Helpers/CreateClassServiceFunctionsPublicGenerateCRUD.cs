﻿using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateClassServiceFunctionsPublicGenerateCRUD(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            List<string> TypeNameWithPlurial_es = new List<string>() { "LocalAddress", };

            string Plurial = "s";
            if (TypeNameWithPlurial_es.Contains(TypeName))
            {
                Plurial = "es";
            }

            // Doing Delete
            if (TypeName == "AspNetUser")
            {
                //sb.AppendLine($@"        public async Task<ActionResult<bool>> Delete(string Id)");
            }
            else
            {
                sb.AppendLine($@"        public async Task<ActionResult<bool>> Delete(int { TypeName }ID)");
            }
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(Unauthorized());");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            { TypeName } { TypeNameLower } = (from c in db.{ TypeName }{ Plurial }");
            if (TypeName == "AspNetUser")
            {
                //sb.AppendLine($@"                    where c.Id == Id");
            }
            else
            {
                sb.AppendLine($@"                    where c.{ TypeName.Replace("Local", "") }ID == { TypeName }ID");
            }
            sb.AppendLine($@"                    select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine($@"            if ({ TypeNameLower } == null)");
            sb.AppendLine(@"            {");
            if (TypeName == "AspNetUser")
            {
                //sb.AppendLine($@"                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""Id"", Id)));");
            }
            else
            {
                sb.AppendLine($@"                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeName }ID.ToString())));");
            }
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                db.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine($@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine($@"            catch (Exception ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            return await Task.FromResult(Ok(true));");

            sb.AppendLine(@"        }");

            // Doing Post
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Post({ TypeName } { TypeNameLower }, AddContactTypeEnum addContactType)");
            }
            else
            {
                sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Post({ TypeName } { TypeNameLower })");
            }
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(Unauthorized());");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create, addContactType);");
            }
            else
            {
                sb.AppendLine($@"            ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Create);");
            }
            sb.AppendLine($@"            if (ValidationResults.Count() > 0)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                return await Task.FromResult(BadRequest(ValidationResults));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                db.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine($@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine($@"            catch (Exception ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }));");

            sb.AppendLine(@"        }");

            // doing Put
            sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Put({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if (LocalService.LoggedInContactInfo.LoggedInContact == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(Unauthorized());");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            if (TypeName == "Contact")
            {
                sb.AppendLine($@"            ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);");
            }
            else
            {
                sb.AppendLine($@"            ValidationResults = Validate(new ValidationContext({ TypeNameLower }), ActionDBTypeEnum.Update);");
            }
            sb.AppendLine($@"            if (ValidationResults.Count() > 0)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                return await Task.FromResult(BadRequest(ValidationResults));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                db.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine($@"                db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine($@"            catch (Exception ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }));");

            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
