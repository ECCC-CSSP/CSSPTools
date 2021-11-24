namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    private async Task<CommandLog> DeleteTestAsync(CommandLog commandLogAdd)
    {
        var actionDelete = await CommandLogService.DeleteAsync(commandLogAdd.CommandLogID);
        Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
        CommandLog commandLogDelete = (CommandLog)((OkObjectResult)actionDelete.Result).Value;
        Assert.NotNull(commandLogDelete);
        Assert.Equal(commandLogAdd.CommandLogID, commandLogDelete.CommandLogID);

        CommandLog commandLogDeleteDB = (from c in dbManage.CommandLogs
                                         where c.CommandLogID == commandLogAdd.CommandLogID
                                         select c).FirstOrDefault();

        Assert.Null(commandLogDeleteDB);

        return commandLogDelete;
    }
}

