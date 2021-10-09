/* 
 *  Manually Edited
 *  
 */

using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
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

        private async Task<bool> DirectoryAndDBSetup()
        {
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            //Assert.True(di.Exists);

            try
            {
                di.Delete(true);
            }
            catch (Exception)
            {
                // might not exist, no assert needed
            }

            try
            {
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            /* ---------------------------------------------------------------------------------
            * CSSPDBContext
            * ---------------------------------------------------------------------------------      
            */

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["CSSPDB"]);
            });

            /* ---------------------------------------------------------------------------------
            * CSSPDBLocalContext
            * ---------------------------------------------------------------------------------      
            */

            fiCSSPDBLocal = new FileInfo(Configuration["CSSPDBLocal"].Replace("_test", ""));
            Assert.True(fiCSSPDBLocal.Exists);

            fiCSSPDBLocalTest = new FileInfo(Configuration["CSSPDBLocal"]);
            if (!fiCSSPDBLocalTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBLocal.FullName, fiCSSPDBLocalTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not copy {fiCSSPDBLocal.FullName} to {fiCSSPDBLocalTest.FullName}. Ex: {ex.Message}");
                }
            }

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocalTest.FullName }");
            });


            /* ---------------------------------------------------------------------------------
            * CSSPDBManageContext
            * ---------------------------------------------------------------------------------      
            */

            fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"].Replace("_test", ""));
            Assert.True(fiCSSPDBManage.Exists);

            fiCSSPDBManageTest = new FileInfo(Configuration["CSSPDBManage"]);
            if (!fiCSSPDBManageTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not copy {fiCSSPDBManage.FullName} to {fiCSSPDBManageTest.FullName}. Ex: {ex.Message}");
                }
            }

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            return await Task.FromResult(true);
        }
    }
}
