namespace CSSPDBAzureServices.Tests;

[Collection("Sequential")]
public partial class TVTypeUserAuthorizationAzureServiceTest : CSSPDBAzureBaseServiceTest
{
    public TVTypeUserAuthorizationAzureServiceTest() : base()
    {

    }

    private async Task<bool> TVTypeUserAuthorizationAzureServiceSetup(string culture)
    {
        await CSSPDBAzureBaseServiceSetup(culture);

        List<TVTypeUserAuthorization> tvTypeUserAuthorizationToDeleteList = (from c in dbTempAzureTest.TVTypeUserAuthorizations
                                                                             where c.ContactTVItemID == 1
                                                                             select c).ToList();

        try
        {
            dbTempAzureTest.TVTypeUserAuthorizations.RemoveRange(tvTypeUserAuthorizationToDeleteList);
            dbTempAzureTest.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all tvTypeUserAuthorizationList from db. Ex: { ex.Message }");
        }

        return await Task.FromResult(true);
    }
}

