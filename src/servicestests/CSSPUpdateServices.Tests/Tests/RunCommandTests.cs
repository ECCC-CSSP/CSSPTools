namespace UpdateServices.Tests;

public partial class UpdateServiceTests
{
    [Theory(Skip = "Temporary disabled because we should not remove old stats from the current database")]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_ClearOldUnnecessaryStats_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "ClearOldUnnecessaryStats"
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.True(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Good_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            DateTime.Now.Year.ToString(),
            DateTime.Now.Month.ToString(),
            DateTime.Now.Day.ToString(),
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.True(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.True(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_CommandDoesNotExist_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "CommandDoesNotExist"
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_CommandDoesNotExistWithDate_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "CommandDoesNotExist",
            DateTime.Now.Year.ToString(),
            DateTime.Now.Month.ToString(),
            DateTime.Now.Day.ToString(),
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Date_Year_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            (DateTime.Now.Year + 5).ToString(),
            DateTime.Now.Month.ToString(),
            DateTime.Now.Day.ToString(),
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Date_Month_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            DateTime.Now.Year.ToString(),
            (DateTime.Now.Month + 13).ToString(),
            DateTime.Now.Day.ToString(),
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Date_Year_Not_Equal_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            (DateTime.Now.Year - 1).ToString(),
            "12",
            "32",
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Date_Month_Not_Equal_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            (DateTime.Now.Year - 1).ToString(),
            "1",
            "32",
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Date_Day_Not_Equal_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            (DateTime.Now.Year - 1).ToString(),
            "2",
            "30",
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task RunCommand_UpdateChangedTVItemStats_Date_Day_Bigger_Than_Now_Error_Test(string culture)
    {
        Assert.True(await CSSPUpdateServiceSetup(culture));

        CSSPLogService.CSSPAppName = "AppNameTest";
        CSSPLogService.CSSPCommandName = "CommandNameTest";

        List<string> argsList = new List<string>()
        {
            "UpdateChangedTVItemStats",
            DateTime.Now.AddDays(1).Year.ToString(),
            DateTime.Now.AddDays(1).Year.ToString(),
            DateTime.Now.AddDays(1).Year.ToString(),
        };

        if (Environment.MachineName.ToLower() == "wmon01dtchlebl2")
        {
            Assert.False(await CSSPUpdateService.RunCommandAsync(argsList.ToArray()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbError.ToString()));
            Assert.False(string.IsNullOrWhiteSpace(CSSPLogService.sbLog.ToString()));
        }

        await CSSPLogService.Save();

        Assert.Equal(1, (from c in dbManage.CommandLogs select c).Count());
    }
}

