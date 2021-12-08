namespace CSSPDBAzureServices;

public partial class ContactAzureService : ControllerBase, IContactAzureService
{
    public async Task<ActionResult<Contact>> LoginAzureAsync(LoginModel loginModel)
    {
        if (string.IsNullOrWhiteSpace(loginModel.LoginEmail))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail"));
        }

        if (!string.IsNullOrWhiteSpace(loginModel.LoginEmail) && (loginModel.LoginEmail.Length < 5 || loginModel.LoginEmail.Length > 100))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "5", "100"));
        }

        if (string.IsNullOrWhiteSpace(loginModel.Password))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "Password"));
        }

        if (!string.IsNullOrWhiteSpace(loginModel.Password) && (loginModel.Password.Length < 5 || loginModel.Password.Length > 50))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Password", "5", "50"));
        }

        if (errRes.ErrList.Count > 0)
        {
            return await Task.FromResult(BadRequest(errRes));
        }

        try
        {
            Contact contact = (from c in dbAzure.Contacts
                               where c.LoginEmail == loginModel.LoginEmail
                               select c).FirstOrDefault();

            if (contact == null)
            {
                errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                return await Task.FromResult(BadRequest(errRes));
            }

            if (loginModel.Password == CSSPScrambleService.Descramble(contact.PasswordHash))
            {

                byte[] key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("APISecret"));

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim(ClaimTypes.Name, contact.LoginEmail)
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                contact.Token = tokenHandler.WriteToken(token);

                return await Task.FromResult(Ok(contact));
            }
        }
        catch (Exception ex)
        {
            errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.Error_, ex.Message));
            return await Task.FromResult(BadRequest(errRes));
        }

        errRes.ErrList.Add(String.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
        return await Task.FromResult(BadRequest(errRes));
    }
}

