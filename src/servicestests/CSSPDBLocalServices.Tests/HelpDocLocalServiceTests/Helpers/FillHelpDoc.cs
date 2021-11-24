namespace CSSPDBLocalServices.Tests;

public partial class HelpDocLocalServiceTest
{
    private HelpDoc FillHelpDoc()
    {
        return new HelpDoc()
        {
            HelpDocID = 0,
            DBCommand = DBCommandEnum.Created,
            DocKey = "ThisIsDocKey",
            Language = LanguageEnum.en,
            DocHTMLText = "<html><head><title>The Title</title></head><body><p>Bonjour</p></body></html>",
            LastUpdateDate_UTC = DateTime.UtcNow,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        };
    }
}

