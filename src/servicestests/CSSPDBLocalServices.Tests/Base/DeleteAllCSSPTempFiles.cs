namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    private void DeleteAllCSSPTempFiles()
    {
        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPTempFilesPath"]);
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
