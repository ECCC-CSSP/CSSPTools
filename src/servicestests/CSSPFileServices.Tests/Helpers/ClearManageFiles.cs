namespace CSSPFileServices.Tests;

public partial class FileServiceTests
{
    private void ClearManageFiles()
    {
        List<ManageFile> manageFileToDeleteList = (from c in dbManage.ManageFiles
                                                   select c).ToList();

        try
        {
            dbManage.ManageFiles.RemoveRange(manageFileToDeleteList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all ManageFiles. Ex: { ex.Message }");
        }
    }
}

