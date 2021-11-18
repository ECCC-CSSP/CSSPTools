/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using System.Linq;

namespace CSSPReadGzFileServices
{
    public interface ICSSPReadGzFileService
    {
        Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0);
        Task<ActionResult<T>> ReadJSON<T>(WebTypeEnum webType, int TVItemID = 0);
    }
    public partial class CSSPReadGzFileService : ICSSPReadGzFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private IEnums enums { get; }
        private ICSSPFileService FileService { get; }
        private IManageFileService ManageFileService { get; }
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private string AzureStoreHash { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPReadGzFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPLocalLoggedInService CSSPLocalLoggedInService, 
            ICSSPFileService FileService, ICSSPScrambleService CSSPScrambleService, ICSSPLogService CSSPLogService, IManageFileService ManageFileService, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
            if (FileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "FileService") }");
            if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");
            if (CSSPLogService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService") }");
            if (ManageFileService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "ManageFileService") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "ReadGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "ReadGzFileService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.FileService = FileService;
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPLogService = CSSPLogService;
            this.ManageFileService = ManageFileService;
            this.dbManage = dbManage;

            CSSPLocalLoggedInService.SetLocalLoggedInContactInfo();

            if (CSSPLocalLoggedInService.LoggedInContactInfo == null || CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                CSSPLogService.AppendError(CSSPCultureServicesRes.NeedToBeLoggedIn);
                return;
            }

            AzureStoreHash = (from c in dbManage.Contacts
                              where c.ContactID == CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactID
                              select c.AzureStoreHash).FirstOrDefault();
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
