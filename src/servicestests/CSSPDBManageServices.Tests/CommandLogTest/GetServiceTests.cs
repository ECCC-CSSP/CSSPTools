namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetTodayListAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        var actionGet = await CommandLogService.GetTodayListAsync();
        Assert.Equal(200, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionGet.Result).Value);
        List<CommandLog> commandLogList = (List<CommandLog>)((OkObjectResult)actionGet.Result).Value;
        Assert.NotNull(commandLogList);
        Assert.NotEmpty(commandLogList);
        Assert.Single(commandLogList);

        List<CommandLog> commandLogListDB = await (from c in dbManage.CommandLogs
                                                   select c).ToListAsync();

        Assert.NotNull(commandLogListDB);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLastWeekListAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        var actionGet = await CommandLogService.GetLastWeekListAsync();
        Assert.Equal(200, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionGet.Result).Value);
        List<CommandLog> commandLogList = (List<CommandLog>)((OkObjectResult)actionGet.Result).Value;
        Assert.NotNull(commandLogList);
        Assert.NotEmpty(commandLogList);
        Assert.Single(commandLogList);

        List<CommandLog> commandLogListDB = await (from c in dbManage.CommandLogs
                                                   select c).ToListAsync();

        Assert.NotNull(commandLogListDB);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetLastMonthListAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        var actionGet = await CommandLogService.GetLastMonthListAsync();
        Assert.Equal(200, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionGet.Result).Value);
        List<CommandLog> commandLogList = (List<CommandLog>)((OkObjectResult)actionGet.Result).Value;
        Assert.NotNull(commandLogList);
        Assert.NotEmpty(commandLogList);
        Assert.Single(commandLogList);

        List<CommandLog> commandLogListDB = await (from c in dbManage.CommandLogs
                                                   select c).ToListAsync();

        Assert.NotNull(commandLogListDB);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetBetweenDatesListAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        var actionGet = await CommandLogService.GetBetweenDatesListAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(1));
        Assert.Equal(200, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionGet.Result).Value);
        List<CommandLog> commandLogList = (List<CommandLog>)((OkObjectResult)actionGet.Result).Value;
        Assert.NotNull(commandLogList);
        Assert.NotEmpty(commandLogList);
        Assert.Single(commandLogList);

        List<CommandLog> commandLogListDB = await (from c in dbManage.CommandLogs
                                                   select c).ToListAsync();

        Assert.NotNull(commandLogListDB);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetBetweenDatesListAsync_StartDate_Year_lessThan_1980_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        DateTime StartDate = new DateTime(1979, 1, 1);
        DateTime EndDate = new DateTime(2020, 1, 1);

        var actionGet = await CommandLogService.GetBetweenDatesListAsync(StartDate, EndDate);
        Assert.Equal(400, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionGet.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionGet.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate", "1980"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetBetweenDatesListAsync_EndDate_Year_lessThan_1980_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        DateTime StartDate = new DateTime(2020, 1, 1);
        DateTime EndDate = new DateTime(1979, 1, 1);

        var actionGet = await CommandLogService.GetBetweenDatesListAsync(StartDate, EndDate);
        Assert.Equal(400, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionGet.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionGet.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDate", "1980"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetBetweenDatesListAsync_StartDate_biggerThan_EndDate_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        DateTime StartDate = new DateTime(2020, 1, 1);
        DateTime EndDate = new DateTime(2019, 1, 1);

        var actionGet = await CommandLogService.GetBetweenDatesListAsync(StartDate, EndDate);
        Assert.Equal(400, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionGet.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionGet.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDate", "EndDate"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetWithCommandLogIDAsync_Good_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        var actionGet = await CommandLogService.GetWithCommandLogIDAsync(commandLogAdd.CommandLogID);
        Assert.Equal(200, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionGet.Result).Value);
        CommandLog commandLogGet = (CommandLog)((OkObjectResult)actionGet.Result).Value;
        Assert.NotNull(commandLogGet);

        CommandLog commandLogDB = await (from c in dbManage.CommandLogs
                                         select c).FirstOrDefaultAsync();

        Assert.NotNull(commandLogDB);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task GetWithCommandLogIDAsync_CommandLogID_Error_Test(string culture)
    {
        Assert.True(await CommandLogServiceSetup(culture));

        CommandLog commandLog = await FillCommandLogAsync();

        CommandLog commandLogAdd = await AddTestAsync(commandLog);

        commandLogAdd.CommandLogID = 0;

        var actionGet = await CommandLogService.GetWithCommandLogIDAsync(commandLogAdd.CommandLogID);
        Assert.Equal(400, ((ObjectResult)actionGet.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionGet.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionGet.Result).Value;
        Assert.NotNull(errRes);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "CommandLogID"), errRes.ErrList[0]);
    }
}

