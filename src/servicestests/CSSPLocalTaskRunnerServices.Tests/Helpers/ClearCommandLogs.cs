namespace CSSPLocalTaskRunnerServices.Tests;

public partial class CSSPLocalTaskRunnerServiceTest
{
    private void ClearCommandLogs()
    {
        List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                   select c).ToList();

        try
        {
            dbManage.CommandLogs.RemoveRange(commandLogToDeleteList);
            dbManage.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all CommandLogs. Ex: { ex.Message }");
        }
    }
}

