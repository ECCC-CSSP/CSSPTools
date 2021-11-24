namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<ManageFile>> AddAsync(ManageFile manageFile)
    {
        if (manageFile == null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "manageFile"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        if (manageFile.ManageFileID != 0)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "ManageFileID", "0"));
        }

        // doing AzureStorage
        if (string.IsNullOrWhiteSpace(manageFile.AzureStorage))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AzureStorage"));
        }
        else
        {
            if (manageFile.AzureStorage.Length > 100)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureStorage", "100"));
            }
        }

        // doing AzureFileName
        if (string.IsNullOrWhiteSpace(manageFile.AzureFileName))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AzureFileName"));
        }
        else
        {
            if (manageFile.AzureFileName.Length > 100)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureFileName", "200"));
            }
        }

        // doing AzureETag
        if (string.IsNullOrWhiteSpace(manageFile.AzureETag))
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AzureETag"));
        }
        else
        {
            if (manageFile.AzureETag.Length > 100)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AzureETag", "100"));
            }
        }

        if (manageFile.AzureCreationTimeUTC.Year < 1980)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "AzureCreationTimeUTC", "1980"));
        }

        ManageFile manageFileAlreadyExist = (from c in dbManage.ManageFiles
                                             where c.AzureETag == manageFile.AzureETag
                                             && c.AzureFileName == manageFile.AzureFileName
                                             && c.AzureStorage == manageFile.AzureStorage
                                             select c).FirstOrDefault();

        if (manageFileAlreadyExist != null)
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, "ManageFile"));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        ManageFile manageFileAdd = new ManageFile();

        manageFileAdd = manageFile;
        int? LastIndex = (from c in dbManage.ManageFiles
                          orderby c.ManageFileID descending
                          select c.ManageFileID).FirstOrDefault() + 1;

        manageFile.ManageFileID = (int)LastIndex;
        dbManage.ManageFiles.Add(manageFile);

        try
        {
            dbManage.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
        }

        if (errRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(errRes));

        return await Task.FromResult(Ok(manageFileAdd));
    }
}

