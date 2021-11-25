namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult<LocalFileInfo>> GetAzureJSONFileInfoAsync(string FileName)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(string FileName) - FileName: { FileName }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        ShareFileClient shareFileClient;
        ShareFileProperties shareFileProperties;
        try
        {
            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
            ShareDirectoryClient shareDirectoryClient = shareClient.GetRootDirectoryClient();
            shareFileClient = shareDirectoryClient.GetFileClient(FileName);
            shareFileProperties = shareFileClient.GetProperties();
        }
        catch (Exception ex)
        {
            string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToGetAzureFileInfoFor_Error_, $"{FileName}", ErrorText));
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(new LocalFileInfo() { FileName = FileName, Length = shareFileProperties.ContentLength }));
    }
}

