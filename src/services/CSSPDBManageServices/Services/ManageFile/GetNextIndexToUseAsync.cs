namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<int>> GetNextIndexToUseAsync()
    {
        int? LastIndex = (from c in DbManage.ManageFiles
                          orderby c.ManageFileID descending
                          select c.ManageFileID).FirstOrDefault() + 1;

        return await Task.FromResult(Ok(LastIndex));
    }
}

