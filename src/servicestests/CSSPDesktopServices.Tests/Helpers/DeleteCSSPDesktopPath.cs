namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private void DeleteCSSPDesktopPath()
    {
        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPDesktopPath"]);
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
    }
}

