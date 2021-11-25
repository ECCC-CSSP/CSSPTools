namespace CSSPDesktopServices.Tests;

public partial class CSSPDesktopServiceTests
{
    private async Task CheckCSSPDBManage()
    {
        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
        if (!fiCSSPDBManage.Exists)
        {
            DirectoryInfo di = new DirectoryInfo(fiCSSPDBManage.DirectoryName);
            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
        }

        if (!fiCSSPDBManage.Exists)
        {
            await CSSPSQLiteService.CreateSQLiteCSSPDBManageAsync();
        }

    }
}

