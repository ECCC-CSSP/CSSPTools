namespace CSSPSQLiteServices;

public partial class CSSPSQLiteService : ICSSPSQLiteService
{
    public async Task<bool> CreateSQLiteCSSPDBManageAsync()
    {
        FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);

        if (!await CheckAndCreateMissingDirectoriesAndFilesAsync(new List<FileInfo>() { fiCSSPDBManage })) return await Task.FromResult(false);

        if (!await CSSPDBManageIsEmptyAsync())
        {
            errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.Database_ContainsInfo, fiCSSPDBManage.FullName));
            return await Task.FromResult(false);
        }

        List<string> ExistingTableList = new List<string>();

        using (var command = dbManage.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
            dbManage.Database.OpenConnection();
            using (var result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    ExistingTableList.Add(result.GetString(0));
                }
            }

            foreach (string tableName in ExistingTableList)
            {
                command.CommandText = $"DROP TABLE { tableName }";
                command.ExecuteNonQuery();
            }

            dbManage.Database.CloseConnection();
        }

        string CreateTable = "CREATE TABLE ManageFiles (" +
            "ManageFileID INTEGER  NOT NULL UNIQUE, " +
            "AzureStorage TEXT NOT NULL, " +
            "AzureFileName TEXT NOT NULL, " +
            "AzureETag TEXT NOT NULL, " +
            "AzureCreationTimeUTC TEXT NOT NULL, " +
            "LoadedOnce INTEGER)";

        using (var command = dbManage.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = CreateTable;
            dbManage.Database.OpenConnection();
            command.ExecuteNonQuery();
            dbManage.Database.CloseConnection();
        }

        CreateTable = "CREATE TABLE CommandLogs (" +
            "CommandLogID INTEGER  NOT NULL UNIQUE, " +
            "AppName TEXT NOT NULL, " +
            "CommandName TEXT NOT NULL, " +
            "Error TEXT NULL, " +
            "Log TEXT NULL, " +
            "DateTimeUTC TEXT NOT NULL)";

        using (var command = dbManage.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = CreateTable;
            dbManage.Database.OpenConnection();
            command.ExecuteNonQuery();
            dbManage.Database.CloseConnection();
        }

        CreateTable = "CREATE TABLE Contacts (" +
            "ContactID INTEGER  NOT NULL  UNIQUE , " +
            "DBCommand INTEGER  NOT NULL  , " +
            "Id TEXT  NOT NULL  , " +
            "ContactTVItemID INTEGER  NOT NULL  , " +
            "LoginEmail TEXT  NOT NULL COLLATE NOCASE, " +
            "FirstName TEXT  NOT NULL COLLATE NOCASE, " +
            "LastName TEXT  NOT NULL COLLATE NOCASE, " +
            "Initial TEXT COLLATE NOCASE, " +
            "CellNumber TEXT   , " +
            "CellNumberConfirmed INTEGER   , " +
            "WebName TEXT  NOT NULL COLLATE NOCASE, " +
            "ContactTitle INTEGER   , " +
            "IsAdmin INTEGER  NOT NULL  , " +
            "EmailValidated INTEGER  NOT NULL  , " +
            "Disabled INTEGER  NOT NULL  , " +
            "IsNew INTEGER  NOT NULL  , " +
            "SamplingPlanner_ProvincesTVItemID TEXT   , " +
            "PasswordHash TEXT   , " +
            "Token TEXT   , " +
            "HasInternetConnection INTEGER   , " +
            "IsLoggedIn INTEGER   , " +
            "GoogleMapKeyHash TEXT   , " +
            "AzureStoreHash TEXT   , " +
            "AccessFailedCount INTEGER   , " +
            "LastUpdateDate_UTC TEXT  NOT NULL  , " +
            "LastUpdateContactTVItemID INTEGER  NOT NULL  )";

        using (var command = dbManage.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = CreateTable;
            dbManage.Database.OpenConnection();
            command.ExecuteNonQuery();
            dbManage.Database.CloseConnection();
        }

        CreateTable = "CREATE TABLE TVItemUserAuthorizations (" +
            "TVItemUserAuthorizationID INTEGER  NOT NULL  UNIQUE, " +
            "DBCommand INTEGER  NOT NULL  , " +
            "ContactTVItemID INTEGER NOT NULL, " +
            "TVItemID1 INTEGER NOT NULL, " +
            "TVItemID2 INTEGER, " +
            "TVItemID3 INTEGER, " +
            "TVItemID4 INTEGER, " +
            "TVAuth INTEGER NOT NULL, " +
            "LastUpdateDate_UTC TEXT NOT NULL, " +
            "LastUpdateContactTVItemID INTEGER NOT NULL)";

        using (var command = dbManage.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = CreateTable;
            dbManage.Database.OpenConnection();
            command.ExecuteNonQuery();
            dbManage.Database.CloseConnection();
        }

        CreateTable = "CREATE TABLE TVTypeUserAuthorizations (" +
            "TVTypeUserAuthorizationID INTEGER  NOT NULL  UNIQUE, " +
            "DBCommand INTEGER  NOT NULL  , " +
            "ContactTVItemID INTEGER  NOT NULL, " +
            "TVType INTEGER  NOT NULL, " +
            "TVAuth INTEGER  NOT NULL, " +
            "LastUpdateDate_UTC TEXT NOT NULL, " +
            "LastUpdateContactTVItemID INTEGER NOT NULL)";

        using (var command = dbManage.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = CreateTable;
            dbManage.Database.OpenConnection();
            command.ExecuteNonQuery();
            dbManage.Database.CloseConnection();
        }
        return await Task.FromResult(true);
    }
}

