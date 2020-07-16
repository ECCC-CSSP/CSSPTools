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
        private async Task<bool> CreateCSSPLoginDB(FileInfo fiCSSPLoginDB)
        {
            using (var command = dbLogin.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"DROP TABLE AspNetUsers";
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();

                command.CommandText = $"DROP TABLE Contacts";
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();

                command.CommandText = $"DROP TABLE Preferences";
                dbLogin.Database.OpenConnection();
                command.ExecuteNonQuery();
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

            string CreatePreferencesTable = "CREATE TABLE Preferences ( " +
                "PreferenceID INTEGER NOT NULL UNIQUE, " +
                "PreferenceText TEXT NOT NULL)";

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
