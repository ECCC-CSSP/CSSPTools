namespace CSSPSQLiteServices.Tests;

public partial class CSSPSQLiteServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CSSPDBManageIsEmpty_Good_Test(string culture)
    {
        Assert.True(await CSSPSQLiteServiceSetup(culture));

        bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
        Assert.True(retBool);

        CommandLog commandLog = new CommandLog()
        {
            AppName = "AppName",
            CommandLogID = 1,
            CommandName = "CommandName",
            DateTimeUTC = DateTime.Now,
            Error = "The Error",
            Log = "The Log"
        };

        try
        {
            dbManage.CommandLogs.Add(commandLog);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        retBool = await CSSPSQLiteService.CSSPDBManageIsEmptyAsync();
        Assert.False(retBool);

        List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                           select c).ToList();

        try
        {
            dbManage.CommandLogs.RemoveRange(commandLogList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        retBool = await CSSPSQLiteService.CSSPDBManageIsEmptyAsync();
        Assert.True(retBool);
    }
}

