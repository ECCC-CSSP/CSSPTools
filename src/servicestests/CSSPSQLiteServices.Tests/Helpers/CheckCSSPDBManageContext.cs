namespace CSSPSQLiteServices.Tests;

public partial class CSSPSQLiteServiceTests
{
    private void CheckCSSPDBManageContext()
    {
        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBManage"] }");
        });

    }
}

