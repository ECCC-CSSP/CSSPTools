using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ManageServices;
using CSSPSQLiteServices.Models;

namespace CSSPSQLiteServices
{
    public interface ICSSPSQLiteService
    {
        string Error { get; set; }

        Task<bool> CreateSQLiteCSSPDBManage();
        Task<bool> CreateSQLiteCSSPDBLocal();

        Task<bool> CSSPDBManageIsEmpty();
        Task<bool> CSSPDBLocalIsEmpty();
    }

    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string Error { get; set; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBManageContext dbManage { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPSQLiteService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBLocalContext dbLocal, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
            if (dbLocal == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbLocal") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CreateGzFileService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.dbLocal = dbLocal;
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateSQLiteCSSPDBManage()
        {
            if (!await DoCreateSQLiteCSSPDBManage()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBLocal()
        {
            if (!await DoCreateSQLiteCSSPDBLocal()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBManageIsEmpty()
        {
            if (!await DoCSSPDBManageIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBLocalIsEmpty()
        {
            if (!await DoCSSPDBLocalIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
