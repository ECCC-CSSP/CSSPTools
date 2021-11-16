//using GenerateCodeBaseServices.Models;
//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> CleanTestDB(List<Table> tableTestDBList, string TestDB)
//        {
//            if (!await SetTestDBDeleteOrderedList(tableTestDBList)) return await Task.FromResult(false);

//            try
//            {
//                using (SqlConnection cnn = new SqlConnection(TestDB))
//                {
//                    if (!cnn.ConnectionString.Contains("TestDB"))
//                    {
//                        Console.WriteLine("Only use this command for the TestDB as it remove all the information from the DB and Reseed all tables");
//                        return await Task.FromResult(false);
//                    }

//                    cnn.Open();

//                    foreach (Table table in tableTestDBList.OrderBy(c => c.ordinalToDelete))
//                    {
//                        //Console.WriteLine($"Deleting Table  [{ table.TableName }]");

//                        string queryString = "";

//                        if (table.TableName == "TVItems")
//                        {
//                            for (int i = 10; i >= 0; i--)
//                            {
//                                queryString = $"DELETE FROM { table.TableName } WHERE TVLevel = { i }";

//                                using (SqlCommand cmd = new SqlCommand(queryString, cnn))
//                                {
//                                    cmd.ExecuteNonQuery();
//                                }
//                            }
//                        }
//                        else
//                        {
//                            queryString = $"DELETE FROM { table.TableName }";

//                            using (SqlCommand cmd = new SqlCommand(queryString, cnn))
//                            {
//                                cmd.ExecuteNonQuery();
//                            }
//                        }

//                        if (table.TableName.StartsWith("AspNet") || table.TableName == "PersistedGrants" || table.TableName == "DeviceCodes")
//                        {
//                            continue;
//                        }

//                        queryString = $"DBCC CHECKIDENT('{ table.TableName }', RESEED, 0)";

//                        using (SqlCommand cmd = new SqlCommand(queryString, cnn))
//                        {
//                            cmd.ExecuteNonQuery();
//                        }
//                    }

//                    cnn.Close();
//                }
//            }
//            catch (Exception ex)
//            {
//                string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                Console.WriteLine($"{ ex.Message }{ InnerExceptiion }");
//                return await Task.FromResult(false);
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}
