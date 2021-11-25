namespace CSSPSQLiteServices.Tests;

public partial class CSSPSQLiteServiceTests
{
    private void CheckCSSPDBLocalContext()
    {
        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ Configuration["CSSPDBLocal"] }");
        });
    }
}

