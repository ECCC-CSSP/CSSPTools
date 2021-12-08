namespace CSSPServerLoggedInServices;

public partial class CSSPServerLoggedInService : ICSSPServerLoggedInService
{
    public async Task<bool> SetLoggedInContactInfoAsync(string LoginEmail)
    {
        LoggedInContactInfo.LoggedInContact = (from c in dbAzure.Contacts
                                               where c.LoginEmail == LoginEmail
                                               select c).FirstOrDefault();

        if (LoggedInContactInfo.LoggedInContact == null)
        {
            LoggedInContactInfo.TVTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
            LoggedInContactInfo.TVItemUserAuthorizationList = new List<TVItemUserAuthorization>();
        }
        else
        {
            LoggedInContactInfo.TVTypeUserAuthorizationList = (from c in dbAzure.TVTypeUserAuthorizations
                                                               where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                               select c).ToList();

            LoggedInContactInfo.TVItemUserAuthorizationList = (from c in dbAzure.TVItemUserAuthorizations
                                                               where c.ContactTVItemID == LoggedInContactInfo.LoggedInContact.ContactTVItemID
                                                               select c).ToList();
        }

        return await Task.FromResult(true);
    }
}

