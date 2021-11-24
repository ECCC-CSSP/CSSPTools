namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    private async Task<CommandLog> ModifyTestAsync(CommandLog commandLog)
    {
        var actionCommandLogModify = await CommandLogService.ModifyAsync(commandLog);
        Assert.Equal(200, ((ObjectResult)actionCommandLogModify.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionCommandLogModify.Result).Value);
        CommandLog commandLogModify = (CommandLog)((OkObjectResult)actionCommandLogModify.Result).Value;
        Assert.NotNull(commandLogModify);
        Assert.Equal(1, commandLogModify.CommandLogID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < commandLogModify.DateTimeUTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > commandLogModify.DateTimeUTC);

        CommandLog commandLogModifyDB = (from c in dbManage.CommandLogs
                                         where c.CommandLogID == commandLogModify.CommandLogID
                                         select c).FirstOrDefault();

        Assert.Equal(JsonSerializer.Serialize(commandLogModify), JsonSerializer.Serialize(commandLogModifyDB));

        return commandLogModify;
    }
}

