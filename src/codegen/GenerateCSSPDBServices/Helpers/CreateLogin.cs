using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices
{
    public partial class Startup
    {
        private async Task<bool> CreateLogin(DLLTypeInfo dllTypeInto, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            sb.AppendLine(@"        public async Task<ActionResult<Contact>> Login(LoginModel loginModel)");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            ValidationResults = LoginModelService.Validate(new ValidationContext(loginModel));");
            sb.AppendLine(@"            if (ValidationResults.Count() > 0)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(BadRequest(ValidationResults));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ApplicationUser appUser = await UserManager.FindByNameAsync(loginModel.LoginEmail);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                if (appUser == null)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.__CouldNotBeFound, CSSPCultureServicesRes.Email, loginModel.LoginEmail)));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                bool HasPassword = await UserManager.CheckPasswordAsync(appUser, loginModel.Password);");
            sb.AppendLine(@"                if (!HasPassword)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                if (HasPassword == true)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    var actionContact = await GetContactWithId(appUser.Id);");
            sb.AppendLine(@"                    if (((ObjectResult)actionContact.Result).StatusCode != 200)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    Contact contact = (Contact)((OkObjectResult)actionContact.Result).Value;");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    if (contact == null)");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));");
            sb.AppendLine(@"                    }");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    byte[] key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>(""APISecret""));");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();");
            sb.AppendLine(@"                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Subject = new ClaimsIdentity(new Claim[]");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            new Claim(ClaimTypes.Name, contact.Id.ToString())");
            sb.AppendLine(@"                        }),");
            sb.AppendLine(@"                        Expires = DateTime.UtcNow.AddDays(2),");
            sb.AppendLine(@"                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)");
            sb.AppendLine(@"                    };");
            sb.AppendLine(@"                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);");
            sb.AppendLine(@"                    contact.Token = tokenHandler.WriteToken(token);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    return await Task.FromResult(Ok(contact));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"            catch (Exception ex)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.Error_, ex.Message)));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));");
            sb.AppendLine(@"        }");

            return await Task.FromResult(true);
        }
    }
}
