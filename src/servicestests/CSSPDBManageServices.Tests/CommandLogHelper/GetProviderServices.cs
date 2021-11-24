namespace ManageServices.Tests;

public partial class CommandLogServicesTests
{
    private async Task GetProviderServices(string culture)
    {
        CSSPCultureService = Provider.GetService<ICSSPCultureService>();
        Assert.NotNull(CSSPCultureService);

        CSSPCultureService.SetCulture(culture);

        CommandLogService = Provider.GetService<ICommandLogService>();
        Assert.NotNull(CommandLogService);

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

        dbLocal = Provider.GetService<CSSPDBLocalContext>();
        Assert.NotNull(dbLocal);
    }
}

