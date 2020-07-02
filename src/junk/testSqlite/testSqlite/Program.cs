using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.CompilerServices;
using testSqlite.Models;

namespace testSqlite
{
    class Program
    {

        static void Main(string[] args)
        {
            string dbName = @"hello.db3";


            Console.WriteLine("Hello World!");
            //InitializeDatabase(dbName);
            //getTableSchema(dbName);
            AddMoreDataInUsers(dbName);
        }

        public static void AddMoreDataInUsers(string dbName)
        {
            using (helloContext db = new helloContext())
            {
                Users users = new Users();
                for (int i = 3; i < 100; i++)
                {
                    users.Id = i;
                    users.Name = $"Pascal_{i}";

                    try
                    {
                        db.Users.Add(users);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

        }
        public void CreateSQLiteCSSPDBTables()
        {
            string a = @"CREATE TABLE TVItems (
            TVItemID INTEGER NOT NULL UNIQUE,
            TVLevel INTEGER NOT NULL,
            TVPath TEXT NOT NULL,
            TVType INTEGER NOT NULL,
            ParentID INTEGER NOT NULL,
            IsActive INTEGER NOT NULL,
            LastUpdateDate_UTC TEXT NOT NULL,
            LastUpdateContactTVItemID INTEGER NOT NULL,
            PRIMARY KEY(TVItemID AUTOINCREMENT))";

        }
        public static void InitializeDatabase(string dbName)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo($@"{appDataPath}\CSSP\testSqlite\{dbName}");

            DirectoryInfo directoryInfo = new DirectoryInfo($@"{fiAppDataPath.Directory}");
            if (!directoryInfo.Exists)
            {
                try
                {
                    directoryInfo.Create();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return;
                }
            }


            if (!fiAppDataPath.Exists)
            {
                try
                {
                    FileStream fs = fiAppDataPath.Create();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return;
                }
            }
            using (SqliteConnection db = new SqliteConnection($"Data Source={fiAppDataPath.FullName}"))
            {
                db.Open();

                string CreateTableUsers = "CREATE TABLE IF NOT EXISTS Users (id int, name nvarchar(50))";

                SqliteCommand createUsersTableCmd = new SqliteCommand(CreateTableUsers, db);

                createUsersTableCmd.ExecuteReader();

                string InsertCharlesSql = "INSERT INTO Users (id, name) VALUES (1, 'Charles')";

                SqliteCommand InsertCharlesCmd = new SqliteCommand(InsertCharlesSql, db);

                InsertCharlesCmd.ExecuteReader();


                string CreateTableUsers2 = "CREATE TABLE IF NOT EXISTS Users2 (id int, name nvarchar(50))";

                SqliteCommand createUsers2TableCmd = new SqliteCommand(CreateTableUsers2, db);

                createUsers2TableCmd.ExecuteReader();

                string InsertNathalieSql = "INSERT INTO Users2 (id, name) VALUES (1, 'Nathalie')";

                SqliteCommand InsertNathalieCmd = new SqliteCommand(InsertNathalieSql, db);

                InsertNathalieCmd.ExecuteReader();
            }
        }

        static void getTableSchema(string dbName)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fi = new FileInfo($@"{appDataPath}\CSSP\testSqlite\{dbName}");

            if (fi.Exists)
            {
                using (var connection = new SqliteConnection($@"Data Source={fi.FullName}"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @" SELECT * FROM sqlite_master";

                    using (var reader = command.ExecuteReader())
                    {
                        ReadOnlyCollection<DbColumn> dbColumns = reader.GetColumnSchema();
                        foreach (DbColumn dbColumn in dbColumns)
                        {
                            string tn = reader.GetDataTypeName((int)dbColumn.ColumnOrdinal);

                            Console.WriteLine($"{dbColumn.ColumnName}\t{tn}");
                        }

                        Console.WriteLine("----------------------------");
                        while (reader.Read())
                        {
                            for (int i = 0; i < dbColumns.Count; i++)
                            {
                                Console.WriteLine($"\t{reader.GetValue(i).ToString()}");
                            }
                        }
                    }

                    Console.WriteLine("\r\n\r\n");
                    command.CommandText = @" SELECT * FROM users LIMIT 1";

                    using (var reader = command.ExecuteReader())
                    {
                        ReadOnlyCollection<DbColumn> dbColumns = reader.GetColumnSchema();
                        foreach (DbColumn dbColumn in dbColumns)
                        {
                            string tn = reader.GetDataTypeName((int)dbColumn.ColumnOrdinal);

                            Console.WriteLine($"{dbColumn.ColumnName}\t{tn}");
                        }

                        Console.WriteLine("----------------------------");
                        while (reader.Read())
                        {
                            for (int i = 0; i < dbColumns.Count; i++)
                            {
                                Console.Write($"\t{reader.GetValue(i).ToString()}");
                            }
                            Console.WriteLine("");
                        }
                    }
                }
            }
        }
    }
}
