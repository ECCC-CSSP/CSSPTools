namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private async Task DeleteOtherFileToTestOtherFile()
    {

        foreach (string fileName in await CSSPDesktopService.GetCSSPOtherFileListAsync())
        {
            try
            {
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        foreach (string fileName in await CSSPDesktopService.GetCSSPOtherFileListAsync())
        {
            FileInfo fi = new FileInfo(fileName);

            Assert.False(fi.Exists);
        }
    }
}

