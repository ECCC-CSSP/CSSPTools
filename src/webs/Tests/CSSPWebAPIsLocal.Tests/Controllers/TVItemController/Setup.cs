/*
 * manually edited
 *
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPWebAPIsLocal.TVItemController.Tests
{
    public partial class TVItemControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string LocalUrl { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemControllerTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapislocaltests.json")
               .AddUserSecrets("61f396b6-8b79-4328-a2b7-a07921135f96")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            LocalUrl = Configuration.GetValue<string>("LocalUrl");
            Assert.NotNull(LocalUrl);

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(CSSPJSONPath);

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            Assert.NotNull(CSSPJSONPathLocal);

            DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
            Assert.True(di.Exists);

            try
            {
                di.Delete(true);
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(CSSPDBManage);

            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

            contact = LoggedInService.LoggedInContactInfo.LoggedInContact;

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            List<string> ExistingTableList = new List<string>();

            using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbLocal.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        ExistingTableList.Add(result.GetString(0));
                    }
                }
            }

            foreach (string tableName in ExistingTableList)
            {
                string TableIDName = "";

                if (tableName.StartsWith("AspNet") || tableName.StartsWith("DeviceCode") || tableName.StartsWith("Persisted")) continue;

                if (tableName == "Addresses")
                {
                    TableIDName = tableName.Substring(0, tableName.Length - 2) + "ID";
                }
                else
                {
                    TableIDName = tableName.Substring(0, tableName.Length - 1) + "ID";
                }

                dbLocal.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
