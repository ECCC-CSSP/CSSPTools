/* 
 *  Manually Edited
 *  
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPLogServices;
using System.Linq;
using CSSPScrambleServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class CSSPDBLocalServiceTest
    {
        private async Task<bool> ClearSomeTablesOfCSSPDBManageAsync()
        {
            List<string> TableList = new List<string>()
            {
                "CommandLogs",
                "ManageFiles",
            };


            foreach (string tableName in TableList)
            {
                try
                {
                    dbManage.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
