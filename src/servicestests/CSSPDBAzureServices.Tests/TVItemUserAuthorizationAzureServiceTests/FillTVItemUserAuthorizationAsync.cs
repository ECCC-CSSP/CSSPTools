namespace CSSPDBAzureServices.Tests;

public partial class TVItemUserAuthorizationAzureServiceTest
{
    private async Task<TVItemUserAuthorization> FillTVItemUserAuthorization()
    {
        return await Task.FromResult(new TVItemUserAuthorization()
        {
            ContactTVItemID = 1, // contact can't be 1 but 1 is use to be able to delete it after the test
            DBCommand = DBCommandEnum.Created,
            LastUpdateContactTVItemID = 2,
            LastUpdateDate_UTC = DateTime.UtcNow,
            TVAuth = TVAuthEnum.Read,
            TVItemID1 = 2,
            TVItemID2 = 2,
            TVItemID3 = 2,
            TVItemID4 = 2,
            TVItemUserAuthorizationID = 0,
        });
    }
}

