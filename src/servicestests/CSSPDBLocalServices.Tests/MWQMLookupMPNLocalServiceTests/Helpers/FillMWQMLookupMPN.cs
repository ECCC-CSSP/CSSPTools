namespace CSSPDBLocalServices.Tests;

public partial class MWQMLookupMPNLocalServiceTest
{
    private MWQMLookupMPN FillMWQMLookupMPN()
    {
        return new MWQMLookupMPN()
        {
            MWQMLookupMPNID = 0,
            DBCommand = DBCommandEnum.Created,
            Tubes10 = 1,
            Tubes1 = 4,
            Tubes01 = 4,
            MPN_100ml = 2313,
            LastUpdateDate_UTC = DateTime.UtcNow,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };
    }
}

