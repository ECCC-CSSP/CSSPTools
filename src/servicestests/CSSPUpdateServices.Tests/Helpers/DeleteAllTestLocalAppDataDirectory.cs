namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestLocalAppDataDirectory()
    {
        Assert.True(Configuration["LocalAppDataPath"].Contains("_Test"), "LocalAppDataPath config parameter must contain '_Test");

        DirectoryInfo di = new DirectoryInfo(Configuration["LocalAppDataPath"]);
        if (di.Exists)
        {
            try
            {
                di.Delete(true);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        di = new DirectoryInfo(Configuration["LocalAppDataPath"]);
        Assert.False(di.Exists);
    }
}

