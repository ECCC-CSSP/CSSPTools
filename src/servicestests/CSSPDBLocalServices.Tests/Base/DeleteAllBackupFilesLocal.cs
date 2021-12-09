namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    private void DeleteAllBackupFilesLocal()
    {
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

