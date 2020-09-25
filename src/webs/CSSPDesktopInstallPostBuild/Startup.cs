using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuild
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private string AzureStoreConnectionString { get; set; }
        private string AzureStoreCSSPWebAPIsLocalPath { get; set; }
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run()
        {
            if (!await FillVariables()) return await Task.FromResult(false);
            if (!await HelpDocsCompressAndSendToAzure()) return await Task.FromResult(false);
            if (!await CSSPWebAPIsLocalCompressAndSendToAzure()) return await Task.FromResult(false);
            if (!await CSSPClientCompressAndSendToAzure()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
