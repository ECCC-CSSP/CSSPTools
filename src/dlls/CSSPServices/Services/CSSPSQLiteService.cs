using CSSPEnums;
using CSSPModels;
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
using CSSPServices;

namespace CSSPServices
{
    public interface ICSSPSQLiteService
    {
        string Error { get; set; }

        Task<bool> CheckForLoginInfoInCSSPDBLogin();
        Task<bool> CreateSQLiteCSSPDBLocal();
        Task<bool> CreateSQLiteCSSPDBFilesManagement();
        Task<bool> CreateSQLiteCSSPDBLogin();
        Task<bool> CSSPDBLocalIsEmpty();
        Task<bool> CSSPDBLoginIsEmpty();
        Task<bool> CSSPDBFilesManagementIsEmpty();
    }

    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string Error { get; set; }
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBInMemoryContext dbIM { get; }
        private CSSPDBLoginContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPSQLiteService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, 
            IEnums enums, CSSPDBContext db = null, CSSPDBLocalContext dbLocal = null, CSSPDBInMemoryContext dbIM = null, 
            CSSPDBLoginContext dbLogin = null, CSSPDBFilesManagementContext dbFM = null)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
            this.dbLocal = dbLocal;
            this.dbIM = dbIM;
            this.dbLogin = dbLogin;
            this.dbFM = dbFM;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckForLoginInfoInCSSPDBLogin()
        {
            if (!await DoCheckForLoginInfoInCSSPDBLogin()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBLocal()
        {
            if (!await DoCreateSQLiteCSSPDBLocal()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBFilesManagement()
        {
            if (!await DoCreateSQLiteCSSPDBFileManagement()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBLogin()
        {
            if (!await DoCreateSQLiteCSSPDBLogin()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBFilesManagementIsEmpty()
        {
            if (!await DoCSSPDBFilesManagementIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBLoginIsEmpty()
        {
            if (!await DoCSSPDBLoginIsEmpty()) return await Task.FromResult(false);

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
