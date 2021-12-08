namespace CSSPLocalLoggedInServices;

public interface ICSSPLocalLoggedInService
{
    LoggedInContactInfo LoggedInContactInfo { get; set; }
    Task<bool> SetLocalLoggedInContactInfoAsync();
}
