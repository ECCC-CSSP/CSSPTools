using GenerateCodeBaseServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteGeneratedServices.Services
{
    public partial class SQLiteGeneratedService : ISQLiteGeneratedService
    {
        private async Task<bool> CheckAllModelExist(FileInfo fiDLL)
        {
            List<Table> tableCSSPDBList = new List<Table>();
            List<string> ListCSSPDBTableList = new List<string>();

            string CSSPDBConnectionString = Config.GetValue<string>("CSSPDBConnectionString");

            if (!await LoadDBInfo(tableCSSPDBList, CSSPDBConnectionString)) return await Task.FromResult(false);
            if (! await FillCSSPDBTableList(ListCSSPDBTableList)) return await Task.FromResult(false);


            bool ErrorExist = false;
            foreach(string CSSPDBTableName in ListCSSPDBTableList)
            {
                if (!tableCSSPDBList.Select(c => c.TableName).Contains(CSSPDBTableName))
                {
                    await ActionCommandDBService.ConsoleWriteError($"Model does not contain [{ CSSPDBTableName }]. Might have to delete it from the ListCSSPDBTableList in the FillCSSPDBTableList.cs code file");
                    ErrorExist = true;
                }
            }

            foreach (string CSSPDBTableName in tableCSSPDBList.Select(c => c.TableName).ToList())
            {
                if (!ListCSSPDBTableList.Contains(CSSPDBTableName))
                {
                    await ActionCommandDBService.ConsoleWriteError($"Model does not contain [{ CSSPDBTableName  }]. Might have to add it to the ListCSSPDBTableList in the FillCSSPDBTableList.cs code file");
                    ErrorExist = true;
                }
            }

            if (ErrorExist)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
