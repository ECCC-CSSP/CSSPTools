namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    private async Task<bool> CreateAllTablesAsync(List<string> ListTableToCreate, bool DoSearch)
    {
        foreach (string TableName in ListTableToCreate)
        {
            string tableName = TableName;

            if (!await CreateTableBuilder(tableName, DoSearch)) return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }
}

