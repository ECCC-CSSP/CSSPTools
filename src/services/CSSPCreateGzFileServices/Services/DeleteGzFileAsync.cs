using Azure;

namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    public async Task<ActionResult<bool>> DeleteGzFileAsync(WebTypeEnum webType, int TVItemID)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

          string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

        try
        {
            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJSONPath"]);
            ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
            ShareFileClient shareFileClient = directory.GetFileClient(FileName);

            Response<bool> response = shareFileClient.DeleteIfExists();

            if (response.Value)
            {
                CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletedAzureFile_, FileName) }");
            }
            else
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotFindFileNotDeletedAzureFile_, FileName) }");
            }
        }
        catch (Exception ex)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotDeleteFile_Error_, FileName, ex.Message) }");
        }

        if (CSSPLogService.ErrRes.ErrList.Count > 0)
        {
            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);
        return await Task.FromResult(Ok(true));
    }
}

