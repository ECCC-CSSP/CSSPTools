using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateAllGzFiles
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; set; }
        private IConfiguration Configuration { get; set; }
        private ServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEnums enums { get; set; }
        private IContactService ContactService { get; set; }
        private IGzFileService GzFileService { get; set; }
        private string AzureCSSPStorageConnectionString { get; set; }
        private string AzureCSSPStorageCustomerProvidedKey { get; set; }
        private string AzureCSSPStorageCSSPFiles { get; set; }
        private string AzureCSSPStorageCSSPJSON { get; set; }
        private string LocalJSONPath { get; set; }
        private string LocalFilesPath { get; set; }
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
            //if (!await ReadGzFile()) return await Task.FromResult(false);

            if (! await Setup()) return await Task.FromResult(false);
            
            if (!await CreateAllGzFiles()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
