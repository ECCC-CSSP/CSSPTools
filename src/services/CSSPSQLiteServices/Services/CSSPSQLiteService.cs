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
using CSSPHelperModels;

namespace CSSPSQLiteServices
{
    public interface ICSSPSQLiteService
    {
        ErrRes errRes { get; set; }
        Task<bool> CreateSQLiteCSSPDBManageAsync();
        Task<bool> CreateSQLiteCSSPDBLocalAsync();
        Task<bool> CSSPDBManageIsEmptyAsync();
        Task<bool> CSSPDBLocalIsEmptyAsync();
    }

    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ErrRes errRes { get; set; }
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
    }
}
