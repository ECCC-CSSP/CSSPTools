namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    private void DeleteAllCSSPOtherFiles()
    {
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
