namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    private async Task<bool> FillListTableToCreateAsync(List<string> ListTableToCreate, List<string> ListTableToDelete)
    {
        foreach (string DeleteTable in ListTableToDelete)
        {
            ListTableToCreate.Add(DeleteTable);
        }

        ListTableToCreate.Reverse();

        return await Task.FromResult(true);
    }
}

