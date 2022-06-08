namespace ManageServices;

public partial class ManageFileService : ControllerBase, IManageFileService
{
    public async Task<ActionResult<ManageFile>> GetWithAzureStorageAndAzureFileNameAsync(string AzureStorage, string AzureFileName)
    {
        ManageFile manageFile = (from c in DbManage.ManageFiles.AsNoTracking()
                                 where c.AzureStorage == AzureStorage
                                 && c.AzureFileName == AzureFileName
                                 select c).FirstOrDefault();

        //if (manageFile == null)
        //{
        //    return await Task.FromResult(Ok(manageFile));
        //    //errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "ManageFile", "AzureStorage,AzureFileName", $"{ AzureStorage }, { AzureFileName }"));
        //    //return await Task.FromResult(BadRequest(errRes));
        //}

        return await Task.FromResult(Ok(manageFile));
    }
}

