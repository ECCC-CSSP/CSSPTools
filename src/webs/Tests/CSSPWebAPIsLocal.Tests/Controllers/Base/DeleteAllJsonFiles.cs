namespace CSSPWebAPIsLocal.Tests;

public partial class CSSPWebAPIsLocalTests
{
    private void DeleteAllJsonFiles()
    {
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

