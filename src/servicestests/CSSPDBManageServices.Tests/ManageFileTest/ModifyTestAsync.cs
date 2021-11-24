namespace ManageServices.Tests;

public partial class ManageFileServicesTests
{
    private async Task<ManageFile> ModifyTestAsync(ManageFile manageFile)
    {
        var actionCommandLogModify = await ManageFileService.ModifyAsync(manageFile);
        Assert.Equal(200, ((ObjectResult)actionCommandLogModify.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionCommandLogModify.Result).Value);
        ManageFile manageFileModify = (ManageFile)((OkObjectResult)actionCommandLogModify.Result).Value;
        Assert.NotNull(manageFileModify);
        Assert.Equal(1, manageFileModify.ManageFileID);

        ManageFile manageFileModifyDB = (from c in dbManage.ManageFiles
                                         where c.ManageFileID == manageFileModify.ManageFileID
                                         select c).FirstOrDefault();

        Assert.Equal(JsonSerializer.Serialize(manageFileModify), JsonSerializer.Serialize(manageFileModifyDB));

        return manageFileModify;
    }
}

