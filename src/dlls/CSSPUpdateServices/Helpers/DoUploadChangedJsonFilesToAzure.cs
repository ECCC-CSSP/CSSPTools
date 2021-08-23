using CSSPCultureServices.Resources;
using CSSPEnums;
using System;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoUploadChangedJsonFilesToAzure()
        {
            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.Starting } DoUploadChangedJsonFilesToAzure ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            //if (!await CreateGzFileService.CreateChangedGzFiles())
            //{
            //    CSSPLogService.AppendError($"{ CSSPCultureUpdateRes.ErrorWhileCreateAllGzFiles  }");

            //    await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UploadAllJsonFilesToAzure);

            //    return await Task.FromResult(false);
            //}

            CSSPLogService.AppendLog($"{ CSSPCultureUpdateRes.End } DoUploadChangedJsonFilesToAzure ...");

            await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UploadAllJsonFilesToAzure);

            return await Task.FromResult(true);
        }
    }
}
