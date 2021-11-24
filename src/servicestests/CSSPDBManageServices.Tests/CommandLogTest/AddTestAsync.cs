namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    private async Task<CommandLog> AddTestAsync(CommandLog commandLog)
    {
        var actionAdd = await CommandLogService.AddAsync(commandLog);
        Assert.Equal(200, ((ObjectResult)actionAdd.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAdd.Result).Value);
        CommandLog commandLogAdd = (CommandLog)((OkObjectResult)actionAdd.Result).Value;
        Assert.NotNull(commandLogAdd);
        Assert.Equal(1, commandLogAdd.CommandLogID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < commandLogAdd.DateTimeUTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > commandLogAdd.DateTimeUTC);

        CommandLog commandLogAddDB = (from c in dbManage.CommandLogs
                                      where c.CommandLogID == commandLogAdd.CommandLogID
                                      select c).FirstOrDefault();

        Assert.Equal(JsonSerializer.Serialize(commandLogAdd), JsonSerializer.Serialize(commandLogAddDB));

        return commandLogAdd;
    }
}

