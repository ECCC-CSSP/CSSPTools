using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        public async Task<bool> DoUploadAllJsonFilesToAzure()
        {
            if (!await CreateGzFileService.CreateAllGzFiles()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
