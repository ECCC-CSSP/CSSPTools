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
using CSSPDBLocalModels;
using CSSPDBPreferenceModels;
using CSSPDBCommandLogModels;
using CSSPDBSearchModels;
using CSSPDBFilesManagementModels;

namespace CSSPSQLiteServices
{
    public interface ICSSPSQLiteService
    {
        string Error { get; set; }

        Task<bool> CreateSQLiteCSSPDBCommandLog();
        Task<bool> CreateSQLiteCSSPDBFilesManagement();
        Task<bool> CreateSQLiteCSSPDBLocal();
        Task<bool> CreateSQLiteCSSPDBPreference();
        Task<bool> CreateSQLiteCSSPDBSearch();

        Task<bool> CSSPDBCommandLogIsEmpty();
        Task<bool> CSSPDBFilesManagementIsEmpty();
        Task<bool> CSSPDBPreferenceIsEmpty();
        Task<bool> CSSPDBLocalIsEmpty();
        Task<bool> CSSPDBSearchIsEmpty();
    }

    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string Error { get; set; }
        private CSSPDBLocalContext dbLocal { get; }
        private CSSPDBSearchContext dbSearch { get; }
        private CSSPDBCommandLogContext dbCommandLog { get; }
        private CSSPDBPreferenceContext dbLogin { get; }
        private CSSPDBFilesManagementContext dbFM { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPSQLiteService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, 
            CSSPDBLocalContext dbLocal, CSSPDBSearchContext dbSearch, CSSPDBCommandLogContext dbCommandLog,
            CSSPDBPreferenceContext dbLogin, CSSPDBFilesManagementContext dbFM)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.dbLocal = dbLocal;
            this.dbSearch = dbSearch;
            this.dbCommandLog = dbCommandLog;
            this.dbLogin = dbLogin;
            this.dbFM = dbFM;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateSQLiteCSSPDBCommandLog()
        {
            if (!await DoCreateSQLiteCSSPDBCommandLog()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBFilesManagement()
        {
            if (!await DoCreateSQLiteCSSPDBFileManagement()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBPreference()
        {
            if (!await DoCreateSQLiteCSSPDBPreference()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBLocal()
        {
            if (!await DoCreateSQLiteCSSPDBLocal()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CreateSQLiteCSSPDBSearch()
        {
            if (!await DoCreateSQLiteCSSPDBSearch()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }

        public async Task<bool> CSSPDBCommandLogIsEmpty()
        {
            if (!await DoCSSPDBCommandLogIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBFilesManagementIsEmpty()
        {
            if (!await DoCSSPDBFilesManagementIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBPreferenceIsEmpty()
        {
            if (!await DoCSSPDBPreferenceIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBLocalIsEmpty()
        {
            if (!await DoCSSPDBLocalIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        public async Task<bool> CSSPDBSearchIsEmpty()
        {
            if (!await DoCSSPDBSearchIsEmpty()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
