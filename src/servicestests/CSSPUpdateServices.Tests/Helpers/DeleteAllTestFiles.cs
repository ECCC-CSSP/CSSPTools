namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestFiles()
    {
        Assert.True(Configuration["CSSPFilesPath"].Contains("Test"), "CSSPFilesPath config parameter must contain 'Test");

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPFilesPath"]);
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
