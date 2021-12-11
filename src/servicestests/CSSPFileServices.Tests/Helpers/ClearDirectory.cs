namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    private void ClearDirectory(string dirPath)
    {
        DirectoryInfo di = new DirectoryInfo(dirPath);
        Assert.True(di.Exists);

        try
        {
            di.Delete(true);
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        try
        {
            di.Create();
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        Assert.Empty(di.GetFiles());
    }
}

