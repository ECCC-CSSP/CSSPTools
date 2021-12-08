namespace CSSPDBAzureServices.Tests;

public partial class TVTypeUserAuthorizationAzureServiceTest
{
    private async Task<TVTypeUserAuthorization> FillTVTypeUserAuthorization()
    {
        return await Task.FromResult(new TVTypeUserAuthorization()
        {
            ContactTVItemID = 1, // contact can't be 1 but 1 is use to be able to delete it after the test
            DBCommand = DBCommandEnum.Created,
            LastUpdateContactTVItemID = 2,
            LastUpdateDate_UTC = DateTime.UtcNow,
            TVAuth = TVAuthEnum.Read,
            TVType = TVTypeEnum.Address,
            TVTypeUserAuthorizationID = 0,
        });
    }
}

