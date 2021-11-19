/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks; 
using Microsoft.Extensions.Configuration;
using CSSPHelperModels;

namespace ManageServices
{
    public partial interface IManageFileService
    {
        Task<ActionResult<ManageFile>> AddAsync(ManageFile manageFile);
        Task<ActionResult<ManageFile>> DeleteAsync(int ManageFileID);
        Task<ActionResult<List<ManageFile>>> GetListAsync(int skip = 0, int take = 100);
        Task<ActionResult<int>> GetNextIndexToUseAsync();
        Task<ActionResult<ManageFile>> GetWithAzureStorageAndAzureFileNameAsync(string AzureStorage, string AzureFileName);
        Task<ActionResult<ManageFile>> GetWithManageFileIDAsync(int ManageFileID);
        Task<ActionResult<ManageFile>> ModifyAsync(ManageFile manageFile);
    }
    public partial class ManageFileService : ControllerBase, IManageFileService
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private IConfiguration Configuration { get; }
        //private ICSSPCultureService CSSPCultureService { get; }
        private CSSPDBManageContext dbManage { get; set; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public ManageFileService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService ") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");

            //this.Configuration = Configuration;
            //this.CSSPCultureService = CSSPCultureService;
            this.dbManage = dbManage;
        }
        #endregion Constructors
    }
}
