namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private void CreateCopyOfCSSPDBLocal()
    {
        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"].Replace("_test", ""));
        Assert.True(fiCSSPDBLocal.Exists);

        FileInfo fiCSSPDBLocalTest = new FileInfo(Configuration["CSSPDBLocal"]);
        if (!fiCSSPDBLocalTest.Exists)
        {
            try
            {
                File.Copy(fiCSSPDBLocal.FullName, fiCSSPDBLocalTest.FullName);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not copy {fiCSSPDBLocal.FullName} to {fiCSSPDBLocalTest.FullName}. Ex: {ex.Message}");
            }
        }

        /* ---------------------------------------------------------------------------------
         * CSSPDBLocalContext
         * ---------------------------------------------------------------------------------      
         */
        Services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBLocalTest.FullName }");
        });
    }
}

