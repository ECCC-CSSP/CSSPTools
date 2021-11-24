namespace ManageServices.Tests;

public partial class ManageFileServicesTests
{
    private async Task<ManageFile> FillManageFileAsync()
    {
        return await Task.FromResult(new ManageFile()
        {
            ManageFileID = 0,
            AzureFileName = "TestingFileName",
            AzureETag = "ThisIsETag",
            AzureStorage = "StorageName",
            AzureCreationTimeUTC = DateTime.UtcNow,
            LoadedOnce = true,
        });
    }
}

