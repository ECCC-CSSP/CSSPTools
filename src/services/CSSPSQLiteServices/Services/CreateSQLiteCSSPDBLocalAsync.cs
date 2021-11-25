namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    public async Task<bool> CreateSQLiteCSSPDBLocalAsync()
    {
        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);

        if (!await CheckAndCreateMissingDirectoriesAndFilesAsync(new List<FileInfo>() { fiCSSPDBLocal })) return await Task.FromResult(false);

        if (!await CSSPDBLocalIsEmptyAsync())
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBLocal.FullName));
            return await Task.FromResult(false);
        }

        List<string> ListTableToDelete = new List<string>();
        List<string> ListTableToCreate = new List<string>();
        List<string> ExistingTableList = new List<string>();

        if (!await FillExistingTableListAsync(ExistingTableList)) return await Task.FromResult(false);
        if (!await FillListTableToDelete(ListTableToDelete)) return await Task.FromResult(false);
        if (!await DeleteTablesAsync(ListTableToDelete, ExistingTableList)) return await Task.FromResult(false);
        if (!await FillListTableToCreateAsync(ListTableToCreate, ListTableToDelete)) return await Task.FromResult(false);
        if (!await CreateAllTablesAsync(ListTableToCreate, false)) return await Task.FromResult(false);

        return await Task.FromResult(true);
    }
}

