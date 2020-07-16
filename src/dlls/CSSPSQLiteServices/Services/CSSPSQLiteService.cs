using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public interface ICSSPSQLiteService
    {
        string Error { get; set; }
        Task<bool> CreateSQLiteCSSPLocalDatabase();
        Task<bool> CreateSQLiteCSSPFileManagementDatabase();
        Task<bool> CreateSQLiteCSSPLoginDatabase();
        Task<bool> DBLocalIsEmpty();
        Task<bool> CSSPLoginDBIsEmpty();
        Task<bool> CSSPFilesManagementDBIsEmpty();
    }

    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string Error { get; set; }
        private CSSPDBContext db { get; }
        private CSSPDBLocalContext dbLocal { get; }
        private InMemoryDBContext dbIM { get; }
        private CSSPLoginDBContext dbLogin { get; }
        private CSSPFilesManagementDBContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPSQLiteService(IConfiguration Configuration, ICultureService CultureService, ILoggedInService LoggedInService, 
            IEnums enums, CSSPDBContext db, CSSPDBLocalContext dbLocal, InMemoryDBContext dbIM, 
            CSSPLoginDBContext dbLogin, CSSPFilesManagementDBContext dbFM)
        {
            this.Configuration = Configuration;
            this.CultureService = CultureService;
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
        public async Task<bool> CreateSQLiteCSSPLocalDatabase()
        {
            if (!await DoCreateSQLiteCSSPLocalDatabase()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPFileManagementDatabase()
        {
            if (!await DoCreateSQLiteCSSPFileManagementDatabase()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPLoginDatabase()
        {
            if (!await DoCreateSQLiteCSSPLoginDatabase()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPFilesManagementDBIsEmpty()
        {
            if (!await DoCSSPFilesManagementDBIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPLoginDBIsEmpty()
        {
            if (!await DoCSSPLoginDBIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> DBLocalIsEmpty()
        {
            if (!await DoDBLocalIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
