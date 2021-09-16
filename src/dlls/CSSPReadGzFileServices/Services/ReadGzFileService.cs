/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPLogServices;
using CSSPReadGzFileServices.Models;
using CSSPWebModels;
using CSSPFileServices;
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
        private ICSSPFileService FileService { get; }
        private IManageFileService ManageFileService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private CSSPReadGzFileServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        public ReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IEnums enums, ICSSPFileService FileService, ICSSPLogService CSSPLogService, IManageFileService ManageFileService, CSSPDBManageContext dbManage)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.FileService = FileService;
            this.CSSPLogService = CSSPLogService;
            this.ManageFileService = ManageFileService;
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
