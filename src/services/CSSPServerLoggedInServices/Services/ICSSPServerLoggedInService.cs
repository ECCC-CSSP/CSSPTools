
namespace CSSPServerLoggedInServices;

public interface ICSSPServerLoggedInService
{
    LoggedInContactInfo LoggedInContactInfo { get; set; }
    Task<bool> SetLoggedInContactInfoAsync(string LoginEmail);
}
