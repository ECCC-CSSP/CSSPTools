namespace CSSPReadGzFileServices.Tests;

public partial class CSSPReadGzFileServiceTests
{
    private void CheckRequiredDirectories()
    {
        List<string> FileList = new List<string>()
            {
                Configuration["CSSPDBLocal"],
                Configuration["CSSPDBManage"],
                Configuration["CSSPDatabasesPath"],
                Configuration["CSSPFilesPath"],
                Configuration["CSSPJSONPath"],
                Configuration["CSSPJSONPathLocal"],
                Configuration["CSSPOtherFilesPath"],
                Configuration["CSSPTempFilesPath"],
                Configuration["azure_csspjson_backup_uncompress"],
                Configuration["azure_csspjson_backup"],
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

