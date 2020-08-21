using CSSPModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPDBLogin()
        {
            List<string> ExistingTableList = new List<string>();

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbLogin.Database.OpenConnection();
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
                    dbLogin.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }

            string CreateAspNetUsersTable = "CREATE TABLE AspNetUsers (" +
                "Id TEXT NOT NULL UNIQUE, " +
                "Email TEXT, " +
                "EmailConfirmed INTEGER NOT NULL, " +
                "PasswordHash TEXT, " +
                "SecurityStamp TEXT, " +
                "PhoneNumber TEXT, " +
                "PhoneNumberConfirmed INTEGER NOT NULL, " +
                "TwoFactorEnabled INTEGER NOT NULL, " +
                "LockoutEndDateUtc TEXT, " +
                "LockoutEnabled INTEGER NOT NULL, " +
                "AccessFailedCount INTEGER NOT NULL, " +
                "UserName TEXT NOT NULL, " +
                "NormalizedUserName TEXT, " +
                "NormalizedEmail TEXT, " +
                "ConcurrencyStamp TEXT, " +
                "LockoutEnd TEXT)";

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CreateAspNetUsersTable;
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            string CreateContactsTable = "CREATE TABLE Contacts ( " +
                "ContactID INTEGER NOT NULL UNIQUE, " +
                "Id TEXT NOT NULL, " +
                "ContactTVItemID INTEGER NOT NULL, " +
                "LoginEmail TEXT NOT NULL, " +
                "FirstName TEXT NOT NULL, " +
                "LastName TEXT NOT NULL, " +
                "Initial TEXT, " +
                "WebName TEXT NOT NULL, " +
                "ContactTitle INTEGER, " +
                "IsAdmin INTEGER NOT NULL, " +
                "EmailValidated INTEGER NOT NULL, " +
                "Disabled INTEGER NOT NULL, " +
                "IsNew INTEGER NOT NULL, " +
                "SamplingPlanner_ProvincesTVItemID TEXT, " +
                "Token TEXT, " +
                "LastUpdateDate_UTC TEXT NOT NULL, " +
                "LastUpdateContactTVItemID INTEGER NOT NULL)";

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CreateContactsTable;
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            string TVItemUserAuthorizationsTable = "CREATE TABLE TVItemUserAuthorizations (" +
                "TVItemUserAuthorizationID INTEGER  NOT NULL  UNIQUE, " +
                "ContactTVItemID INTEGER  NOT NULL , " +
                "TVItemID1 INTEGER  NOT NULL , " +
                "TVItemID2 INTEGER  , " +
                "TVItemID3 INTEGER  , " +
                "TVItemID4 INTEGER  , " +
                "TVAuth INTEGER  NOT NULL , " +
                "LastUpdateDate_UTC TEXT  NOT NULL , " +
                "LastUpdateContactTVItemID INTEGER  NOT NULL )";

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = TVItemUserAuthorizationsTable;
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            string TVTypeUserAuthorizationsTable = "CREATE TABLE TVTypeUserAuthorizations (" +
                "TVTypeUserAuthorizationID INTEGER  NOT NULL  UNIQUE, " +
                "ContactTVItemID INTEGER  NOT NULL , " +
                "TVType INTEGER  NOT NULL , " +
                "TVAuth INTEGER  NOT NULL , " +
                "LastUpdateDate_UTC TEXT  NOT NULL , " +
                "LastUpdateContactTVItemID INTEGER  NOT NULL )";

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = TVTypeUserAuthorizationsTable;
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            string CreatePreferencesTable = "CREATE TABLE Preferences ( " +
                    "PreferenceID INTEGER NOT NULL UNIQUE, " +
                    "AzureStore TEXT NOT NULL, " +
                    "LoginEmail TEXT NOT NULL, " +
                    "Password TEXT NOT NULL, + " +
                    "HasInternetConnection INTEGER NOT NULL, " +
                    "LoggedIn INTEGER NOT NULL, " +
                    "Token TEXT NOT NULL)";

            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CreatePreferencesTable;
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();
            }

            return await Task.FromResult(true);
        }
    }
}
