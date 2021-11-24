namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        await AddTestAsync(commandLog);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_commandLog_null_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog = null;

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "commandLog"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_CommandLogID_not_equal_0_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.CommandLogID = 1;

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "CommandLogID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppName_empty_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.AppName = "";

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AppName"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_AppName_length_200_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.AppName = "a".PadRight(201);

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_CommandName_empty_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.CommandName = "";

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "CommandName"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_CommandName_length_200_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.CommandName = "a".PadRight(201);

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_Error_length_10000000_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.Error = "a".PadRight(10000001);

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Error", "10000000"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_Log_length_10000000_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.Log = "a".PadRight(10000001);

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Log", "10000000"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Add_DateTimeUTC_year_before_1980_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        commandLog.DateTimeUTC = new DateTime(1979, 1, 1);

        var actionCommandLog = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionCommandLog.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980"), errRes.ErrList[0]);
    }
}

