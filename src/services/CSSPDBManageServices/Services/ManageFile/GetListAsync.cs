namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<List<ManageFile>>> GetListAsync(int skip = 0, int take = 100)
    {
        List<ManageFile> manageFileList = (from c in DbManage.ManageFiles.AsNoTracking()
                                           orderby c.ManageFileID
                                           select c).Skip(skip).Take(take).ToList();

        return await Task.FromResult(Ok(manageFileList));
    }
}

