namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void CheckRequiredDirectories()
    {
        List<string> FileList = new List<string>()
        {
            Configuration["CSSPDBLocal"],
            Configuration["CSSPDBManage"],
            Configuration["azure_csspjson_backup"],
            Configuration["azure_csspjson_backup_uncompress"],
            Configuration["CSSPDatabasesPath"],
            Configuration["CSSPJSONPath"],
            Configuration["CSSPJSONPathLocal"],
            Configuration["CSSPFilesPath"],
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

