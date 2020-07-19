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
            await WebService.GetWebRoot();

            return await Task.FromResult(true);
        }
    }
}
