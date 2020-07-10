using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        IConfiguration Configuration { get; }
        #endregion Properties

        #region Constructors
        public CSSPSQLiteService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CreateSQLiteCSSPDBLocal()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal.Replace("{AppDataPath}", appDataPath));

            string CSSPFilesManagementDB = Configuration.GetValue<string>("CSSPFilesManagementDB");
            FileInfo fiCSSPFilesManagementDB = new FileInfo(CSSPFilesManagementDB.Replace("{AppDataPath}", appDataPath));

            string CSSPLoginDB = Configuration.GetValue<string>("CSSPLoginDB");
            FileInfo fiCSSPLoginDB = new FileInfo(CSSPLoginDB.Replace("{AppDataPath}", appDataPath));

            if (!await CheckAndCreateMissingDirectoriesAndFiles(new List<FileInfo>() { fiCSSPDBLocal, fiCSSPFilesManagementDB, fiCSSPLoginDB })) return await Task.FromResult(false);

            if (!await CreateCSSPDBLocal(fiCSSPDBLocal)) return await Task.FromResult(false);

            if (!await CreateCSSPFilesManagementDB(fiCSSPFilesManagementDB)) return await Task.FromResult(false);

            if (!await CreateCSSPLoginDB(fiCSSPLoginDB)) return await Task.FromResult(false);

            return true;
        }
        #endregion Functions public
    }
}
