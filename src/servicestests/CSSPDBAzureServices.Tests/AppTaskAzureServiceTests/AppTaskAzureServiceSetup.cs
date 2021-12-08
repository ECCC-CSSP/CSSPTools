namespace CSSPDBAzureServices.Tests;

[Collection("Sequential")]
public partial class AppTaskAzureServiceTest : CSSPDBAzureBaseServiceTest
{
    public AppTaskAzureServiceTest() : base()
    {

    }

    private async Task<bool> AppTaskAzureServiceSetup(string culture)
    {
        await CSSPDBAzureBaseServiceSetup(culture);

        List<AppTask> appTaskToDeleteList = (from c in dbTempAzureTest.AppTasks
                                             where c.AppTaskStatus == AppTaskStatusEnum.Completed
                                             select c).ToList();

        try
        {
            dbTempAzureTest.AppTasks.RemoveRange(appTaskToDeleteList);
            dbTempAzureTest.SaveChanges();
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Could not delete all AppTasks from db. Ex: { ex.Message }");
        }

        return await Task.FromResult(true);
    }
}

