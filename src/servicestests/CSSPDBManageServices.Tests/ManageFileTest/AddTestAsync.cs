namespace ManageServices.Tests;

public partial class ManageFileServicesTests
{
    private async Task<ManageFile> AddTestAsync(ManageFile manageFile)
    {
        var actionAdd = await ManageFileService.AddAsync(manageFile);
        Assert.Equal(200, ((ObjectResult)actionAdd.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAdd.Result).Value);
        ManageFile manageFileAdd = (ManageFile)((OkObjectResult)actionAdd.Result).Value;
        Assert.NotNull(manageFileAdd);
        //Assert.Equal(1, manageFileAdd.ManageFileID);

        ManageFile manageFileAddDB = (from c in dbManage.ManageFiles
                                      where c.ManageFileID == manageFileAdd.ManageFileID
                                      select c).FirstOrDefault();

        Assert.Equal(JsonSerializer.Serialize(manageFileAdd), JsonSerializer.Serialize(manageFileAddDB));

        return manageFileAdd;
    }
}

