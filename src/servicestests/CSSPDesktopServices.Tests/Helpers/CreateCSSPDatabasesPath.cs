namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private void CreateCSSPDatabasesPath()
    {
        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPDatabasesPath"]);
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

