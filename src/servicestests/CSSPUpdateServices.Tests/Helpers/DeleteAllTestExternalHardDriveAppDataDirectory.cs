namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestExternalHardDriveAppDataDirectory()
    {
        Assert.True(Configuration["ExternalHardDriveBackkupAppDataPath"].Contains("_Test"), "LocalAppDataPath config parameter must contain '_Test");

        DirectoryInfo diExistTest = new DirectoryInfo(Configuration["ExternalHardDriveBackkupAppDataPath"].Replace("_Test", ""));

        if (diExistTest.Exists)
        {
            DirectoryInfo di = new DirectoryInfo(Configuration["ExternalHardDriveBackkupAppDataPath"]);
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

            di = new DirectoryInfo(Configuration["ExternalHardDriveBackkupAppDataPath"]);
            Assert.False(di.Exists);
        }
    }
}

