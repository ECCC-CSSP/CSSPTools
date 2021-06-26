/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPScrambleServices;
using CSSPWebModels;
using FileServices;
using LoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public interface IReadGzFileService
    {
        WebAppLoaded webAppLoaded { get; set; }
        Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0);
        Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0);
    }
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public WebAppLoaded webAppLoaded { get; set; } = new WebAppLoaded();

        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IFileService FileService { get; }
        private IScrambleService ScrambleService { get; }
        private IManageFileService ManageFileService { get; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string CSSPAzureUrl { get; set; }
        private string CSSPFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IScrambleService ScrambleService, IEnums enums, IFileService FileService, 
            IManageFileService ManageFileService, CSSPDBManageContext dbManage)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.ScrambleService = ScrambleService;
            this.enums = enums;
            this.FileService = FileService;
            this.ManageFileService = ManageFileService;
            this.dbManage = dbManage;

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            return await DoReadJSON<T>(webType, TVItemID);
        }
        public async Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            var actionRes = await ReadJSON<T>(webType, TVItemID);
            return (T)((OkObjectResult)actionRes.Result).Value;
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
