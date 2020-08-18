/*
 * Manually edited
 * 
 */
using System.Threading.Tasks;

namespace GenerateAllGzFiles
{
    public partial class Startup
    {
        private async Task<bool> CreateAllGzFiles()
        {
            await GzFileService.CreateAllGzFiles();

            return await Task.FromResult(true);
        }
    }
}
