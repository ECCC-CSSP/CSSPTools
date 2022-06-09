namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    private void DeleteAllTestBackupFilesLocal()
    {
        Assert.True(Configuration["azure_csspjson_backup_uncompress"].Contains("test"), "azure_csspjson_backup_uncompress config parameter must contain 'test");
        Assert.True(Configuration["azure_csspjson_backup"].Contains("test"), "azure_csspjson_backup config parameter must contain 'test");

        DirectoryInfo di = new DirectoryInfo(Configuration["azure_csspjson_backup_uncompress"]);
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

        di = new DirectoryInfo(Configuration["azure_csspjson_backup"]);
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

