namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult<bool>> CreateTempPNGAsync(HttpRequest request)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(HttpRequest request)";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        try
        {
            IFormFile file = request.Form.Files[0];

            if (file.Length > 0)
            {
                FileInfo fi = new FileInfo($"{ Configuration["CSSPTempFilesPath"] }{file.FileName}");

                CSSPLogService.AppendLog($"{ CSSPCultureServicesRes.Creating } { fi.FullName }");

                using (FileStream stream = new FileStream(fi.FullName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
            }
            else
            {
                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.File_LengthIs0, file.FileName));
            }
        }
        catch (Exception ex)
        {
            string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerExcecption: " + ex.InnerException.Message);

            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotCreateTemp_FileError_, ErrorText));
        }
    }
}

