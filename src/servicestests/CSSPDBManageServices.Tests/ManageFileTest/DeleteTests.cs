namespace ManageServices.Tests;

public partial class ManageFileServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Good_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        ManageFile manageFileDelete = await DeleteTestAsync(manageFileAdd);
        Assert.NotNull(manageFileDelete);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_ManageFileID_not_0_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.ManageFileID = 0;

        var actionCommandLog = await ManageFileService.DeleteAsync(manageFileAdd.ManageFileID);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ManageFileID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_Manage_not_found_Error_Test(string culture)
    {
        Assert.True(await ManageFileServiceSetup(culture));

        ManageFile manageFile = await FillManageFileAsync();

        ManageFile manageFileAdd = await AddTestAsync(manageFile);

        manageFileAdd.ManageFileID = 10000;

        var actionCommandLog = await ManageFileService.DeleteAsync(manageFileAdd.ManageFileID);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", manageFileAdd.ManageFileID.ToString()), errRes.ErrList[0]);
    }
}

