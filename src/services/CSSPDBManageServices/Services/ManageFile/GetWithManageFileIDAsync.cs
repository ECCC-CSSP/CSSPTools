namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<ManageFile>> GetWithManageFileIDAsync(int ManageFileID)
    {
        ManageFile manageFile = (from c in DbManage.ManageFiles.AsNoTracking()
                                 where c.ManageFileID == ManageFileID
                                 select c).FirstOrDefault();

        //if (manageFile == null)
        //{
        //    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", ManageFileID.ToString()));
        //    return await Task.FromResult(BadRequest(errRes));
        //}

        return await Task.FromResult(Ok(manageFile));
    }
}

