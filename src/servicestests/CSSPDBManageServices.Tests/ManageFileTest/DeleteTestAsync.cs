namespace ManageServices.Tests;

public partial class ManageFileServicesTests
{
    private async Task<ManageFile> DeleteTestAsync(ManageFile manageFile)
    {
        var actionDelete = await ManageFileService.DeleteAsync(manageFile.ManageFileID);
        Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
        ManageFile manageFileDelete = (ManageFile)((OkObjectResult)actionDelete.Result).Value;
        Assert.NotNull(manageFileDelete);
        Assert.Equal(manageFileDelete.ManageFileID, manageFileDelete.ManageFileID);

        ManageFile manageFileDeleteDB = (from c in dbManage.ManageFiles
                                         where c.ManageFileID == manageFileDelete.ManageFileID
                                         select c).FirstOrDefault();

        Assert.Null(manageFileDeleteDB);

        return manageFileDelete;
    }
}

