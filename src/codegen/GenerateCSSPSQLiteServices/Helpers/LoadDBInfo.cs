using GenerateCodeBaseServices.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GenerateCSSPSQLiteServices
{
    public partial class Startup
    {
        private async Task<bool> LoadDBInfo(List<Table> tableList, string ConnectionString)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    DataTable tblList = cnn.GetSchema("Tables");
                    DataTable clmList = cnn.GetSchema("Columns");

                    foreach (DataRow tbl in tblList.Rows)
                    {
                        Table table = new Table();
                        table.TableName = tbl.ItemArray[2].ToString();

                        if (table.TableName == "sysdiagrams") continue;
                        if (table.TableName == "AspNetRoleClaims") continue;
                        if (table.TableName == "AspNetRoles") continue;
                        if (table.TableName == "AspNetUserClaims") continue;
                        if (table.TableName == "AspNetUserLogins") continue;
                        if (table.TableName == "AspNetUserRoles") continue;
                        if (table.TableName == "AspNetUserTokens") continue;
                        if (table.TableName == "PersistedGrants") continue;
                        if (table.TableName == "DeviceCodes") continue;
                        if (table.TableName == "AspNetUsers") continue;

                        tableList.Add(table);

                        foreach (DataRow dr in clmList.Rows)
                        {
                            if (dr[2].ToString() == table.TableName)
                            {
                                Col col = new Col();
                                col.FieldName = dr[3].ToString();
                                col.AllowNull = (dr[6].ToString() == "NO" ? false : true);
                                col.DataType = dr[7].ToString();
                                col.StringLength = (string.IsNullOrWhiteSpace(dr[8].ToString()) ? 0 : int.Parse(dr[8].ToString()));

                                table.colList.Add(col);
                            }
                        }
                    }

                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                Console.WriteLine($"{ ex.Message }{ InnerException }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
