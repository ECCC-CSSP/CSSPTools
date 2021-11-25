namespace CSSPSQLiteServices.Tests;

public partial class CSSPSQLiteServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateSQLiteCSSPDBLocal_Good_Test(string culture)
    {
        Assert.True(await CSSPSQLiteServiceSetup(culture));

        FileInfo fi = new FileInfo(Configuration["CSSPDBLocal"]);
        if (fi.Exists)
        {
            try
            {
                fi.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync();
        Assert.True(retBool);

        fi = new FileInfo(Configuration["CSSPDBLocal"]);
        Assert.True(fi.Exists);
    }
}

