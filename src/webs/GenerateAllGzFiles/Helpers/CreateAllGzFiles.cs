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
            await CSSPWebService.CreateAllGzFiles();

            return await Task.FromResult(true);
        }
    }
}
