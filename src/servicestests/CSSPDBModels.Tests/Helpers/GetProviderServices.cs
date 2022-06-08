namespace CSSPDBModels.Tests;

public partial class ContextTest
{
    private async Task GetProviderServices(string culture)
    {
        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        enums = Provider.GetService<IEnums>();
        Assert.NotNull(enums);

        CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
        Assert.NotNull(CSSPScrambleService);

        CSSPLogService = Provider.GetService<ICSSPLogService>();
        Assert.NotNull(CSSPLogService);

        CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
        Assert.NotNull(CSSPSQLiteService);

        FileInfo fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
        if (!fiCSSPDBLocal.Exists)
        {
            await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync();
        }

        fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"]);
        Assert.True(fiCSSPDBLocal.Exists);

        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fiCSSPDBManage.Exists)
        {
            await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
        }

        fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        Assert.True(fiCSSPDBManage.Exists);

        dbManage = Provider.GetService<CSSPDBManageContext>();
        Assert.NotNull(dbManage);

        CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
        Assert.NotNull(CSSPLocalLoggedInService);
    }
}

