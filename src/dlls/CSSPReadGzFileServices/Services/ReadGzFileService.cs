/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPLogServices;
using CSSPReadGzFileServices.Models;
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
        Task<bool> FillConfigModel(CSSPReadGzFileServiceConfigModel config);
        Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0);
        Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0);
        WebAppLoaded webAppLoaded { get; set; }
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
        private IManageFileService ManageFileService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private CSSPReadGzFileServiceConfigModel config { get; set; }

        //private string AzureStore { get; set; }
        //private string AzureStoreCSSPJSONPath { get; set; }
        //private string CSSPJSONPath { get; set; }
        //private string CSSPJSONPathLocal { get; set; }
        //private string CSSPAzureUrl { get; set; }
        //private string CSSPFilesPath { get; set; }
        #endregion Properties

        #region Constructors
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IEnums enums, IFileService FileService, ICSSPLogService CSSPLogService, IManageFileService ManageFileService, CSSPDBManageContext dbManage)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.FileService = FileService;
            this.CSSPLogService = CSSPLogService;
            this.ManageFileService = ManageFileService;
            this.dbManage = dbManage;

            //AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            //AzureStore = LoggedInService.Descramble(Configuration.GetValue<string>("AzureStore"));
            //CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            //CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            //CSSPAzureUrl = Configuration.GetValue<string>("CSSPAzureUrl");
            //CSSPFilesPath = Configuration.GetValue<string>("CSSPFilesPath");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
