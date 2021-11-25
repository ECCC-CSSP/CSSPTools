namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private void CreateCopyOfCSSPDBManage()
    {
        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"].Replace("_test", ""));
        Assert.True(fiCSSPDBManage.Exists);

        FileInfo fiCSSPDBManageTest = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fiCSSPDBManageTest.Exists)
        {
            try
            {
                File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not copy {fiCSSPDBManage.FullName} to {fiCSSPDBManageTest.FullName}. Ex: {ex.Message}");
            }
        }

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */
        Services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManageTest.FullName }");
        });
    }
}

