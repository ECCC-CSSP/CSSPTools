namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestJsonFiles()
    {
        Assert.True(Configuration["CSSPJSONPath"].Contains("Test"), "CSSPJSONPath config parameter must contain 'Test");

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPath"]);
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
