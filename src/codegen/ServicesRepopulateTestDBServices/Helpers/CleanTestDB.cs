using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
    {
        private async Task<bool> CleanTestDB(List<Table> tableTestDBList, string TestDBConnectionString)
        {
            if (!await SetTestDBDeleteOrderedList(tableTestDBList)) return await Task.FromResult(false);

            try
            {
                using (SqlConnection cnn = new SqlConnection(TestDBConnectionString))
                {
                    if (!cnn.ConnectionString.Contains("TestDB"))
                    {
                        actionCommandDBService.ErrorText.AppendLine("Only use this command for the TestDB as it remove all the information from the DB and Reseed all tables");
                        return await Task.FromResult(false);
                    }

                    cnn.Open();

                    foreach (Table table in tableTestDBList.OrderBy(c => c.ordinalToDelete))
                    {
                        //actionCommandDBService.ExecutionStatusText.AppendLine($"Deleting Table  [{ table.TableName }]");

                        string queryString = "";

                        if (table.TableName == "TVItems")
                        {
                            for (int i = 10; i >= 0; i--)
                            {
                                queryString = $"DELETE FROM { table.TableName } WHERE TVLevel = { i }";

                                using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            queryString = $"DELETE FROM { table.TableName }";

                            using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        if (table.TableName == "AspNetRoles" || table.TableName == "AspNetUserLogins" || table.TableName == "AspNetUserRoles" || table.TableName == "AspNetUsers")
                        {
                            continue;
                        }

                        queryString = $"DBCC CHECKIDENT('{ table.TableName }', RESEED, 0)";

                        using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                string InnerExceptiion = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                actionCommandDBService.ErrorText.AppendLine($"{ ex.Message }{ InnerExceptiion }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
