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
        private async Task<bool> CompareDBs(List<Table> tableCSSPDBList, List<Table> tableTestDBList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Table tableCSSP in tableCSSPDBList)
            {
                //actionCommandDBService.ExecutionStatusText.AppendLine($"{ tableCSSP.TableName }");

                if (tableCSSP.TableName == "sysdiagrams") continue;

                Table tableTest = (from c in tableTestDBList
                                   where c.TableName == tableCSSP.TableName
                                   select c).FirstOrDefault();

                if (tableTest == null)
                {
                    sb.AppendLine($"{ tableCSSP.TableName } does not exist in TestDB");
                    continue;
                }

                foreach (Col col in tableCSSP.colList)
                {
                    //actionCommandDBService.ExecutionStatusText.AppendLine($"{ tableCSSP.TableName }    { col.FieldName }");

                    Col colTest = (from c in tableTest.colList
                                   where c.FieldName == col.FieldName
                                   select c).FirstOrDefault();

                    if (colTest == null)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } does not exist in TestDB");
                    }

                    if (col.AllowNull != colTest.AllowNull)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } Allow Null does not match in TestDB");
                    }

                    if (col.DataType != colTest.DataType)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } Data Type does not match in TestDB");
                    }

                    if (col.StringLength != colTest.StringLength)
                    {
                        sb.AppendLine($"{ tableCSSP.TableName }\t{ col.FieldName } String Length does not match in TestDB");
                    }
                }
            }

            if (sb.ToString().Length > 0)
            {
                actionCommandDBService.ErrorText.AppendLine($"{ sb.ToString() }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
