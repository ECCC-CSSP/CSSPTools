using CSSPModels;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public interface ICSSPSQLiteService
    {
        string Error { get; set; }
        Task<bool> CreateSQLiteCSSPLocalDatabase();
        Task<bool> CreateSQLiteCSSPFileManagementDatabase();
        Task<bool> CreateSQLiteCSSPLoginDatabase();
        Task<bool> DBContainsInfo(FileInfo fi);
    }

    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string Error { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPSQLiteService(CSSPDBLocalContext dbLocal)
        {
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateSQLiteCSSPLocalDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiCSSPDBLocal = new FileInfo(appDataPath + "\\cssp\\cssplocaldatabases\\CSSPDBLocal.db");

            if (! await DBContainsInfo(fiCSSPDBLocal))
            {
                Error = $"Database [{ fiCSSPDBLocal.FullName }] contains info. You will need to send it to the server before creating or recreating the DB.";
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBLocal })) return await Task.FromResult(false);

            if (!await CreateCSSPDBLocal(fiCSSPDBLocal)) return await Task.FromResult(false);

            return true;
        }
        public async Task<bool> CreateSQLiteCSSPFileManagementDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiCSSPFilesManagementDB = new FileInfo(appDataPath + "\\cssp\\cssplocaldatabases\\CSSPFilesManagementDB.db");


            if (!await DBContainsInfo(fiCSSPFilesManagementDB))
            {
                Error = $"Database [{ fiCSSPFilesManagementDB.FullName }] contains info. You will need to send it to the server before creating or recreating the DB.";
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPFilesManagementDB })) return await Task.FromResult(false);

            if (!await CreateCSSPFilesManagementDB(fiCSSPFilesManagementDB)) return await Task.FromResult(false);

            return true;
        }
        public async Task<bool> CreateSQLiteCSSPLoginDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiCSSPLoginDB = new FileInfo(appDataPath + "\\cssp\\cssplocaldatabases\\CSSPLoginDB.db");

            if (!await DBContainsInfo(fiCSSPLoginDB))
            {
                Error = $"Database [{ fiCSSPLoginDB.FullName }] contains info. You will need to send it to the server before creating or recreating the DB.";
                return await Task.FromResult(false);
            }

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPLoginDB })) return await Task.FromResult(false);

            if (!await CreateCSSPLoginDB(fiCSSPLoginDB)) return await Task.FromResult(false);

            return true;
        }
        public async Task<bool> DBContainsInfo(FileInfo fi)
        {
            if (!await DoDBContainsInfo(fi)) return await Task.FromResult(false);

            return true;
        }
        #endregion Functions public
    }
}
