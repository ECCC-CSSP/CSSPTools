namespace CSSPDBLocalServices.Tests;

public partial class EmailLocalServiceTest
{
    private Email FillEmail()
    {
        return new Email()
        {
            EmailID = 0,
            DBCommand = DBCommandEnum.Created,
            EmailTVItemID = 0,
            EmailType = EmailTypeEnum.Personal,
            EmailAddress = "SomeEmail@ec.gc.ca",
            LastUpdateDate_UTC = DateTime.UtcNow,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };
    }
}

