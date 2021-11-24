namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        await DeleteTestAsync(commandLogAdd);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_CommandLogID_0_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        commandLogAdd.CommandLogID = 0;

        var actionCommandLog = await CommandLogService.DeleteAsync(commandLogAdd.CommandLogID);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "CommandLogID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Delete_CommandLogID_cant_find_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        commandLogAdd.CommandLogID = 10000;

        var actionCommandLog = await CommandLogService.DeleteAsync(commandLogAdd.CommandLogID);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", commandLogAdd.CommandLogID.ToString()), errRes.ErrList[0]);
    }
}

