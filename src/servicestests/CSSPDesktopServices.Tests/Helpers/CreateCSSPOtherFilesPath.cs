namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private void CreateCSSPOtherFilesPath()
    {
        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPOtherFilesPath"]);
        if (!di.Exists)
        {
            try
            {
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

    }
}

