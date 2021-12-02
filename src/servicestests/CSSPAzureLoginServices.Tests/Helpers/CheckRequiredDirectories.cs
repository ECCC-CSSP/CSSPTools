namespace CSSPAzureLoginServices.Tests;

public partial class CSSPAzureLoginServiceTests
{
    private void CheckRequiredDirectories()
    {
        List<string> dirList = new List<string>()
        {
            Configuration["CSSPDBManage"],
        };

        // create all directories
        foreach (string FileName in dirList)
        {
            FileInfo fi = new FileInfo(FileName);
            DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
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

        foreach (string FileName in dirList)
        {
            FileInfo fi = new FileInfo(FileName);
            DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
            Assert.True(di.Exists);

        }
    }
}

