namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<ManageFile>> DeleteAsync(int ManageFileID)
    {
        if (ManageFileID == 0)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ManageFileID"));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        ManageFile manageFile = (from c in DbManage.ManageFiles
                                 where c.ManageFileID == ManageFileID
                                 select c).FirstOrDefault();

        if (manageFile == null)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", ManageFileID.ToString()));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        try
        {
            DbManage.ManageFiles.Remove(manageFile);
            DbManage.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            ErrResult.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        return await Task.FromResult(Ok(manageFile));
    }
}

