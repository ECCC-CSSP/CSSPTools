namespace CSSPSQLiteServices.Tests;

public partial class CSSPSQLiteServiceTests
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task CSSPDBLocalIsEmpty_Good_Test(string culture)
    {
        Assert.True(await CSSPSQLiteServiceSetup(culture));

        bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocalAsync();
        Assert.True(retBool);

        AppTask appTask = new AppTask()
        {
            AppTaskCommand = AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData,
            AppTaskID = 1,
            AppTaskStatus = AppTaskStatusEnum.Running,
            DBCommand = DBCommandEnum.Deleted,
            EndDateTime_UTC = DateTime.UtcNow,
            EstimatedLength_second = 123,
            Language = LanguageEnum.en,
            LastUpdateContactTVItemID = 2,
            LastUpdateDate_UTC = DateTime.UtcNow,
            Parameters = "lasijf",
            PercentCompleted = 23,
            RemainingTime_second = 354,
            StartDateTime_UTC = DateTime.UtcNow.AddDays(-1),
            TVItemID = 2,
            TVItemID2 = 5,
        };

        try
        {
            dbLocal.AppTasks.Add(appTask);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        AppTask appTaskRet = (from c in dbLocal.AppTasks
                              select c).FirstOrDefault();

        Assert.NotNull(appTaskRet);

        retBool = await CSSPSQLiteService.CSSPDBLocalIsEmptyAsync();
        Assert.False(retBool);

        List<AppTask> appTaskList = (from c in dbLocal.AppTasks
                                     select c).ToList();

        try
        {
            dbLocal.AppTasks.RemoveRange(appTaskList);
            dbLocal.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, ex.Message);
        }

        retBool = await CSSPSQLiteService.CSSPDBLocalIsEmptyAsync();
        Assert.True(retBool);
    }
}

