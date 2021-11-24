namespace ManageServices;

public partial interface IManageFileService
{
    Task<ActionResult<ManageFile>> AddAsync(ManageFile manageFile);
    Task<ActionResult<ManageFile>> DeleteAsync(int ManageFileID);
    Task<ActionResult<List<ManageFile>>> GetListAsync(int skip = 0, int take = 100);
    Task<ActionResult<int>> GetNextIndexToUseAsync();
    Task<ActionResult<ManageFile>> GetWithAzureStorageAndAzureFileNameAsync(string AzureStorage, string AzureFileName);
    Task<ActionResult<ManageFile>> GetWithManageFileIDAsync(int ManageFileID);
    Task<ActionResult<ManageFile>> ModifyAsync(ManageFile manageFile);
}
