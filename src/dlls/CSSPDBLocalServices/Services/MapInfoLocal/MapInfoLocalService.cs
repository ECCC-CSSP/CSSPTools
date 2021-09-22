/*
 * Manually edited
 *
 */

using CreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial interface IMapInfoLocalService
    {
        Task<ActionResult<bool>> AddOrModifyMapInfoLocal(PostMapInfoModel postMapInfoModel);
    }
    public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private ICreateGzFileService CreateGzFileService { get; }
        private List<ToRecreate> ToRecreateList { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,
           ICSSPLogService CSSPLogService, CSSPDBLocalContext dbLocal, IReadGzFileService ReadGzFileService, ICreateGzFileService CreateGzFileService)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (LoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "LoggedInService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
            if (ReadGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "ReadGzFileService") }");
            if (CreateGzFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CreateGzFileService") }");

            if (string.IsNullOrEmpty(Configuration["APISecret"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "APISecret", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDesktopPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDesktopPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDatabasesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDatabasesPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPDBLocalService") }");
            if (string.IsNullOrEmpty(Configuration["ComputerName"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "ComputerName", "CSSPDBLocalService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.LoggedInService = LoggedInService;
            this.CSSPLogService = CSSPLogService;
            this.dbLocal = dbLocal;
            this.ReadGzFileService = ReadGzFileService;
            this.CreateGzFileService = CreateGzFileService;

            ToRecreateList = new List<ToRecreate>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<bool>> AddOrModifyMapInfoLocal(PostMapInfoModel postMapInfoModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostMapInfoModel postMapInfoModel)";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (!await ValidateAddOrModifyMapInfoLocal(postMapInfoModel))
            {
                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }

            if (!await DoAddOrModifyMapInfoLocal(postMapInfoModel))
            {
                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(true));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
