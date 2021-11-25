namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private async Task CreateAndEmptyDirectories()
    {
        foreach (string dir in await CSSPDesktopService.GetDirectoryToCreateListAsync())
        {
            DirectoryInfo di = new DirectoryInfo(dir);
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
            else
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }

            di = new DirectoryInfo(dir);
            Assert.True(di.Exists);
            Assert.Empty(di.GetFiles());
        }
    }
}

