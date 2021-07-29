using System.Threading.Tasks;

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        public async Task<bool> UploadAllJsonFilesToAzure()
        {
            if (!await CreateGzFileService.CreateAllGzFiles()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}
