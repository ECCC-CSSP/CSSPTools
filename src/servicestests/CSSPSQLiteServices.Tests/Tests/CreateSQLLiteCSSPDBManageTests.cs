namespace CSSPSQLiteServices.Tests;

public partial class CSSPSQLiteServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CreateSQLiteCSSPDBManage_Good_Test(string culture)
    {
        Assert.True(await CSSPSQLiteServiceSetup(culture));

        FileInfo fi = new FileInfo(Configuration["CSSPDBManage"]);
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

        bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
        Assert.True(retBool);

        fi = new FileInfo(Configuration["CSSPDBManage"]);
        Assert.True(fi.Exists);
    }
}

