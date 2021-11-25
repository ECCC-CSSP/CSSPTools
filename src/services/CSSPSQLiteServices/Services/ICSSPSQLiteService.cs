namespace CSSPSQLiteServices;

public interface ICSSPSQLiteService
{
    ErrRes errRes { get; set; }
    Task<bool> CreateSQLiteCSSPDBManageAsync();
    Task<bool> CreateSQLiteCSSPDBLocalAsync();
    Task<bool> CSSPDBManageIsEmptyAsync();
    Task<bool> CSSPDBLocalIsEmptyAsync();
}
