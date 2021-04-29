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
            sb.AppendLine(@"            if (!LoginModelService.Validate(new ValidationContext(loginModel)))");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                return await Task.FromResult(BadRequest(ValidationResultList));");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"");
            sb.AppendLine(@"            try");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                Contact contact = (from c in db.Contacts");
            sb.AppendLine(@"                   where c.LoginEmail == loginModel.LoginEmail");
            sb.AppendLine(@"                   select c).FirstOrDefault();");
            sb.AppendLine(@"");
            sb.AppendLine(@"                if (contact == null)");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"                    return await Task.FromResult(BadRequest(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));");
            sb.AppendLine(@"                }");
            sb.AppendLine(@"                ");
            sb.AppendLine(@"                if (loginModel.Password == ScrambleService.Descramble(contact.PasswordHash))");
            sb.AppendLine(@"                {");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    byte[] key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>(""APISecret""));");
            sb.AppendLine(@"");
            sb.AppendLine(@"                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();");
            sb.AppendLine(@"                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor");
            sb.AppendLine(@"                    {");
            sb.AppendLine(@"                        Subject = new ClaimsIdentity(new Claim[]");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            new Claim(ClaimTypes.Name, contact.LoginEmail)");
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
