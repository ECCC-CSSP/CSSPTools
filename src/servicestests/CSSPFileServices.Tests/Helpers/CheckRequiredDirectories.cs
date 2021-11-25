namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    private void CheckRequiredDirectories()
    {
        List<string> FileList = new List<string>()
        {
            Configuration["CSSPDBLocal"],
            Configuration["CSSPDBManage"],
            Configuration["CSSPFilesPath"],
            Configuration["CSSPJSONPath"],
            Configuration["CSSPOtherFilesPath"],
            Configuration["CSSPTempFilesPath"],
        };

        // create all directories
        foreach (string FileName in FileList)
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

        foreach (string FileName in FileList)
        {
            FileInfo fi = new FileInfo(FileName);
            DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);
            Assert.True(di.Exists);

        }
    }
}

