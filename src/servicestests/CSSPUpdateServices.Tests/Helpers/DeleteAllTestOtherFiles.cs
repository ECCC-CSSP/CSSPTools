namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestOtherFiles()
    {
        Assert.True(Configuration["CSSPOtherFilesPath"].Contains("Test"), "CSSPOtherFilesPath config parameter must contain 'Test");

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPOtherFilesPath"]);
        Assert.True(di.Exists);

        foreach (FileInfo fi in di.GetFiles())
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

        Assert.Empty(di.GetFiles());
    }
}
