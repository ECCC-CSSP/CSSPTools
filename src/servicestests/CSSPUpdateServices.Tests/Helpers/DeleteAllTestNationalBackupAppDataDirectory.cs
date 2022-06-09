namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestNationalBackupAppDataDirectory()
    {
        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.True(Configuration["NationalBackupAppDataPath"].Contains("_Test"), "NationalBackupAppDataPath config parameter must contain '_Test");

            DirectoryInfo di = new DirectoryInfo(Configuration["NationalBackupAppDataPath"]);
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

            di = new DirectoryInfo(Configuration["NationalBackupAppDataPath"]);
            Assert.False(di.Exists);
        }
    }
}

