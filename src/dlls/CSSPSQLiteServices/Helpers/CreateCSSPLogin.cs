using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSSPSQLiteServices.Services
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> CreateCSSPLoginDB(FileInfo fiCSSPLoginDB)
        {
            List<string> ListTableToDelete = new List<string>();
            List<string> ExistingTableList = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Data Source={fiCSSPLoginDB.FullName}"))
            {
                db.Open();

                if (!await FillExistingTableList(ExistingTableList, db)) return await Task.FromResult(false);
                ListTableToDelete.Add("CSSPFiles");
                if (!await DeleteTables(ListTableToDelete, ExistingTableList, db)) return await Task.FromResult(false);

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

                SqliteCommand createAspNetUsersTableCmd = new SqliteCommand(CreateAspNetUsersTable, db);

                createAspNetUsersTableCmd.ExecuteReader();

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

                SqliteCommand createContactsTableCmd = new SqliteCommand(CreateContactsTable, db);

                createContactsTableCmd.ExecuteReader();
            }

            return await Task.FromResult(true);
        }
    }
}
