/*
 * Manually edited
 *
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using CSSPLocalLoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;

namespace CSSPDBLocalServices
{

    public partial interface IMapInfoLocalService
    {
        Task<ActionResult<MapInfoModel>> AddMapInfoLocalAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType, List<Coord> coordList);
        Task<ActionResult<MapInfoModel>> AddMapInfoLocalFromAverageAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType);
        Task<ActionResult<MapInfoModel>> DeleteMapInfoLocalAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType);
        //Task<ActionResult<MapInfoLocalModel>> ModifyMapInfoLocal(MapInfoLocalModel mapInfoLocalModel);
        Task<double> CalculateAreaOfPolygonAsync(List<Coord> NodeList);
        Task<double> CalculateDistanceAsync(double lat1, double long1, double lat2, double long2, double EarthRadius);

    }
    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private ICSSPReadGzFileService CSSPReadGzFileService { get; }
        private ICSSPCreateGzFileService CSSPCreateGzFileService { get; }
        private IHelperLocalService HelperLocalService { get; }
        private string AzureStoreHash { get; set; }
        private List<ToRecreate> ToRecreateList { get; set; }
        private double R = 6378137.0;
        private double d2r = Math.PI / 180;
        private double r2d = 180 / Math.PI;

        #endregion Properties

        #region Constructors
        public MapInfoLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService,
           ICSSPLogService CSSPLogService, CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage, ICSSPReadGzFileService CSSPReadGzFileService,
           ICSSPCreateGzFileService CSSPCreateGzFileService, IHelperLocalService HelperLocalService)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");
            if (CSSPReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPReadGzFileService") }");
            if (CSSPCreateGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCreateGzFileService") }");
            if (HelperLocalService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "HelperLocalService") }");

            if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "MapInfoLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "MapInfoLocalService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.CSSPLogService = CSSPLogService;
            this.dbLocal = dbLocal;
            this.CSSPReadGzFileService = CSSPReadGzFileService;
            this.CSSPCreateGzFileService = CSSPCreateGzFileService;
            this.HelperLocalService = HelperLocalService;

            CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();

            if (CSSPLocalLoggedInService.LoggedInContactInfo == null || CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                CSSPLogService.AppendError(CSSPCultureServicesRes.NeedToBeLoggedIn);
                return;
            }

            AzureStoreHash = (from c in dbManage.Contacts
                              where c.ContactID == CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactID
                              select c.AzureStoreHash).FirstOrDefault();

            ToRecreateList = new List<ToRecreate>();

            if (r2d == 0.0D)
            {
                // nothing 
                // this if is just to remove the warning that the r2d is not use
                // it will be use in the future and this if should be removed.
            }
        }
        #endregion Constructors
    }
}
