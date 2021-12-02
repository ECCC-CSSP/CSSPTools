namespace CSSPDBLocalServices.Tests;

public partial class MWQMLookupMPNLocalServiceTest
{
    private MWQMLookupMPN FillMWQMLookupMPN()
    {
        return new MWQMLookupMPN()
        {
            MWQMLookupMPNID = 1,
            DBCommand = DBCommandEnum.Created,
            Tubes10 = 0,
            Tubes1 = 0,
            Tubes01 = 0,
            MPN_100ml = 2313,
            LastUpdateDate_UTC = DateTime.UtcNow,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };
    }
}

