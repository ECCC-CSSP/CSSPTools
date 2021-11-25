namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    private async Task<bool> DeleteTablesAsync(List<string> ListTableToDelete, List<string> ExistingTableList)
    {
        foreach (string TableName in ListTableToDelete)
        {
            if (ExistingTableList.Contains(TableName))
            {
                using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"DROP TABLE { TableName }";
                    dbLocal.Database.OpenConnection();
                    command.ExecuteNonQuery();
                    dbLocal.Database.CloseConnection();
                }
            }
        }

        return await Task.FromResult(true);
    }
}

