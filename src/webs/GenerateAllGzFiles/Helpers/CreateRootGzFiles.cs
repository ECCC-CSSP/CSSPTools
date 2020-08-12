/*
 * Manually edited
 * 
 */
using System.Threading.Tasks;

namespace GenerateAllGzFiles
{
    public partial class Startup
    {
        private async Task<bool> CreateRootGzFile()
        {
            await CSSPWebService.CreateWebRootGzFile();

            return await Task.FromResult(true);
        }
    }
}
