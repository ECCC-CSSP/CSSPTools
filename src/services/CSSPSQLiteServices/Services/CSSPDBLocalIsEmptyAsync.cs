namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    public async Task<bool> CSSPDBLocalIsEmptyAsync()
    {
        List<string> ExistingTableList = new List<string>();

        if (!await FillExistingTableListAsync(ExistingTableList)) return await Task.FromResult(false);

        using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
        {
            foreach (string tableName in ExistingTableList)
            {
                command.CommandText = $"SELECT * FROM { tableName }";
                dbLocal.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        return await Task.FromResult(false);
                    }
                }
                dbLocal.Database.CloseConnection();
            }
        }

        return await Task.FromResult(true);
    }
}

