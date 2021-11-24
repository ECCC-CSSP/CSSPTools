namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    private async Task<CommandLog> FillCommandLogAsync()
    {
        return await Task.FromResult(new CommandLog()
        {
            CommandLogID = 0,
            AppName = "Some AppName",
            CommandName = "Some CommandName",
            Log = "Testing Log",
            Error = "Testing Error",
            DateTimeUTC = DateTime.UtcNow,
        });
    }
}

