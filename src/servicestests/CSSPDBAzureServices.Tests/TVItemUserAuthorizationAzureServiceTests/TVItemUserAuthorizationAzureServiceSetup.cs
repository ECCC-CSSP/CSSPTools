namespace CSSPDBAzureServices.Tests;

[Collection("Sequential")]
public partial class TVItemUserAuthorizationAzureServiceTest : CSSPDBAzureBaseServiceTest
{
    public TVItemUserAuthorizationAzureServiceTest() : base()
    {

    }

    private async Task<bool> TVItemUserAuthorizationAzureServiceSetup(string culture)
    {
        await CSSPDBAzureBaseServiceSetup(culture);

        List<TVItemUserAuthorization> tvItemUserAuthorizationToDeleteList = (from c in dbTempAzureTest.TVItemUserAuthorizations
                                                                             where c.ContactTVItemID == 1
                                                                             select c).ToList();

        try
        {
            dbTempAzureTest.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationToDeleteList);
            dbTempAzureTest.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all tvItemUserAuthorizationList from db. Ex: { ex.Message }");
        }

        return await Task.FromResult(true);
    }
}

