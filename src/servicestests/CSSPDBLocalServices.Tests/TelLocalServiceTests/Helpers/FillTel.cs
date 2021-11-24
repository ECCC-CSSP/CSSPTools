namespace CSSPDBLocalServices.Tests;

public partial class TelLocalServiceTest
{
    private Tel FillTel()
    {

        return new Tel()
        {
            TelID = 0,
            DBCommand = DBCommandEnum.Created,
            TelTVItemID = 0,
            TelType = TelTypeEnum.Personal,
            TelNumber = "15061231234",
            LastUpdateDate_UTC = DateTime.UtcNow,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };
    }
}

