using CSSPCultureServices.Resources;
using System;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoUploadAllJsonFilesToAzure()
        {
            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.Starting } DoUploadAllJsonFilesToAzure ...");

            if (!await CheckComputerName()) return await Task.FromResult(false);

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.RunningOn } { Environment.MachineName.ToString().ToLower() }");

            if (!await CreateGzFileService.CreateAllGzFiles())
            {
                ErrorAppend(sbError, $"{ CSSPCultureUpdateRes.ErrorWhileCreateAllGzFiles  }");

                await StoreInCommandLog(sbLog, sbError, "DoUploadAllJsonFilesToAzure");

                return await Task.FromResult(false);
            }

            LogAppend(sbLog, $"{ CSSPCultureUpdateRes.End } DoUploadAllJsonFilesToAzure ...");

            await StoreInCommandLog(sbLog, sbError, "DoUploadAllJsonFilesToAzure");

            return await Task.FromResult(true);
        }
    }
}
