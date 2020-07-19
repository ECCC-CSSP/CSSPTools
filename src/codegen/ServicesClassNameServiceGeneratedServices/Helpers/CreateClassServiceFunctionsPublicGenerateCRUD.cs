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

            // Doing Delete
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"        public async Task<ActionResult<bool>> Delete(string Id)");
            }
            else
            {
                sb.AppendLine($@"        public async Task<ActionResult<bool>> Delete(int { TypeName }ID)");
            }
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(Unauthorized());");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"                { TypeName } { TypeNameLower } = (from c in dbIM.{ TypeName }{ Plurial }");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                                   where c.Id == Id");
            }
            else
            {
                sb.AppendLine($@"                                   where c.{ TypeName }ID == { TypeName }ID");
            }
            sb.AppendLine(@"                                   select c).FirstOrDefault();");
            sb.AppendLine(@"            ");
            sb.AppendLine($@"                if ({ TypeNameLower } == null)");
            sb.AppendLine(@"                {");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""Id"", Id)));");
            }
            else
            {
                sb.AppendLine($@"                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeName }ID.ToString())));");
            }
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            ");
            sb.AppendLine(@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    dbIM.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine(@"                    dbIM.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            ");
            sb.AppendLine(@"                return await Task.FromResult(Ok(true));");
            sb.AppendLine(@"            }");

            sb.AppendLine(@"            else if (LoggedInService.DBLocation == DBLocationEnum.Local)");

            sb.AppendLine(@"            {");
            sb.AppendLine($@"                { TypeName } { TypeNameLower } = (from c in dbLocal.{ TypeName }{ Plurial }");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                                   where c.Id == Id");
            }
            else
            {
                sb.AppendLine($@"                                   where c.{ TypeName }ID == { TypeName }ID");
            }
            sb.AppendLine(@"                                   select c).FirstOrDefault();");
            sb.AppendLine(@"                ");
            sb.AppendLine($@"                if ({ TypeNameLower } == null)");
            sb.AppendLine(@"                {");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""Id"", Id)));");
            }
            else
            {
                sb.AppendLine($@"                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeName }ID.ToString())));");
            }
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");    
            sb.AppendLine($@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   dbLocal.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine($@"                   dbLocal.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine($@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");    
            sb.AppendLine($@"                return await Task.FromResult(Ok(true));");
            
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");

            sb.AppendLine($@"                { TypeName } { TypeNameLower } = (from c in db.{ TypeName }{ Plurial }");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                                   where c.Id == Id");
            }
            else
            {
                sb.AppendLine($@"                                   where c.{ TypeName }ID == { TypeName }ID");
            }
            sb.AppendLine(@"                                   select c).FirstOrDefault();");
            sb.AppendLine(@"                ");
            sb.AppendLine($@"                if ({ TypeNameLower } == null)");
            sb.AppendLine(@"                {");
            if (TypeName == "AspNetUser")
            {
                sb.AppendLine($@"                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""Id"", Id)));");
            }
            else
            {
                sb.AppendLine($@"                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, ""{ TypeName }"", ""{ TypeName }ID"", { TypeName }ID.ToString())));");
            }
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   db.{ TypeName }{ Plurial }.Remove({ TypeNameLower });");
            sb.AppendLine($@"                   db.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine($@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                return await Task.FromResult(Ok(true));");

            sb.AppendLine(@"            }");
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
            sb.AppendLine(@"            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)");
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
            sb.AppendLine($@"               return await Task.FromResult(BadRequest(ValidationResults));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    dbIM.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine(@"                    dbIM.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                return await Task.FromResult(Ok({ TypeNameLower }));");
            sb.AppendLine(@"            }");

            sb.AppendLine(@"            else if (LoggedInService.DBLocation == DBLocationEnum.Local)");
            sb.AppendLine(@"            {");

            sb.AppendLine($@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   dbLocal.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine($@"                   dbLocal.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine($@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");    
            sb.AppendLine($@"                return await Task.FromResult(Ok({ TypeNameLower }));");

            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");

            sb.AppendLine($@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   db.{ TypeName }{ Plurial }.Add({ TypeNameLower });");
            sb.AppendLine($@"                   db.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine($@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                   return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                return await Task.FromResult(Ok({ TypeNameLower }));");

            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            // doing Put
            sb.AppendLine($@"        public async Task<ActionResult<{ TypeName }>> Put({ TypeName } { TypeNameLower })");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)");
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
            sb.AppendLine($@"               return await Task.FromResult(BadRequest(ValidationResults));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                try");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    dbIM.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine(@"                    dbIM.SaveChanges();");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                catch (DbUpdateException ex)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine($@"                return await Task.FromResult(Ok({ TypeNameLower }));");
            sb.AppendLine(@"            }");

            sb.AppendLine(@"            else if (LoggedInService.DBLocation == DBLocationEnum.Local)");
            sb.AppendLine(@"            {");

            sb.AppendLine($@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"               dbLocal.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine($@"               dbLocal.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine($@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }));");

            sb.AppendLine(@"            }");
            sb.AppendLine(@"            else");
            sb.AppendLine(@"            {");

            sb.AppendLine($@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"               db.{ TypeName }{ Plurial }.Update({ TypeNameLower });");
            sb.AppendLine($@"               db.SaveChanges();");
            sb.AppendLine(@"            }");
            sb.AppendLine($@"            catch (DbUpdateException ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine($@"               return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? "" Inner: "" + ex.InnerException.Message : """")));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine($@"            return await Task.FromResult(Ok({ TypeNameLower }));");

            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
