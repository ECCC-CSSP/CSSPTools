namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestJsonFilesLocal()
    {
        Assert.True(Configuration["CSSPJSONPathLocal"].Contains("Test"), "CSSPJSONPathLocal config parameter must contain 'Test");

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);
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
