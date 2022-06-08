namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<ManageFile>> ModifyAsync(ManageFile manageFile)
    {
        if (manageFile == null)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "manageFile"));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        if (manageFile.ManageFileID == 0)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "ManageFileID"));
        }

        // doing AzureStorage
        if (string.IsNullOrWhiteSpace(manageFile.AzureStorage))
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage"));
        }
        else
        {
            if (manageFile.AzureStorage.Length > 100)
            {
                ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100"));
            }
        }

        // doing AzureFileName
        if (string.IsNullOrWhiteSpace(manageFile.AzureFileName))
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName"));
        }
        else
        {
            if (manageFile.AzureFileName.Length > 200)
            {
                ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200"));
            }
        }

        // doing AzureETag
        if (string.IsNullOrWhiteSpace(manageFile.AzureETag))
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag"));
        }
        else
        {
            if (manageFile.AzureETag.Length > 100)
            {
                ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100"));
            }
        }

        if (manageFile.AzureCreationTimeUTC.Year < 1980)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980"));
        }

        ManageFile manageFileExist = (from c in DbManage.ManageFiles
                                      where c.AzureFileName == manageFile.AzureFileName
                                      && c.AzureStorage == manageFile.AzureStorage
                                      && c.ManageFileID != manageFile.ManageFileID
                                      select c).FirstOrDefault();

        if (manageFileExist != null)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExistsWithDifferent_, "ManageFile", "ManageFileID"));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        ManageFile manageFileModify = new ManageFile();

        manageFileModify = (from c in DbManage.ManageFiles
                            where c.ManageFileID == manageFile.ManageFileID
                            select c).FirstOrDefault();

        if (manageFileModify == null)
        {
            ErrResult.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "ManageFileID", manageFile.ManageFileID.ToString()));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        manageFileModify.AzureCreationTimeUTC = manageFile.AzureCreationTimeUTC;
        manageFileModify.AzureETag = manageFile.AzureETag;
        manageFileModify.AzureFileName = manageFile.AzureFileName;
        manageFileModify.AzureStorage = manageFile.AzureStorage;
        manageFileModify.LoadedOnce = true;

        try
        {
            DbManage.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            ErrResult.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
        }

        if (ErrResult.ErrList.Count > 0) return await Task.FromResult(BadRequest(ErrResult));

        return await Task.FromResult(Ok(manageFileModify));
    }
}

