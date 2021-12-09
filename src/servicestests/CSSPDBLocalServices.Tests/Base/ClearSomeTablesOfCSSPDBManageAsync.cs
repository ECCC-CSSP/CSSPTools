namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    private async Task<bool> ClearSomeTablesOfCSSPDBManageAsync()
    {
        List<string> TableList = new List<string>()
            {
                "CommandLogs",
                "ManageFiles",
            };


        foreach (string tableName in TableList)
        {
            try
            {
                dbManage.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        return await Task.FromResult(true);
    }
}

