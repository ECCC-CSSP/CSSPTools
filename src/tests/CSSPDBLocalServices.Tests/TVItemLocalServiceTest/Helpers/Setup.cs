///* 
// *  Manually Edited
// *  
// */

//using CreateGzFileServices;
//using CSSPCultureServices.Services;
//using CSSPDBModels;
//using CSSPEnums;
//using FileServices;
//using LoggedInServices;
//using ManageServices;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using ReadGzFileServices;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;
//using Xunit;

//namespace CSSPDBLocalServices.Tests
//{
//    public partial class TVItemLocalServiceTest
//    {
//        #region Properties
//        private IConfiguration Configuration { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private IServiceCollection Services { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        private ILoggedInService LoggedInService { get; set; }
//        private ITVItemLocalService PostTVItemModelService { get; set; }
//        private IReadGzFileService ReadGzFileService { get; set; }
//        private ICreateGzFileService CreateGzFileService { get; set; }
//        private CSSPDBLocalContext dbLocal { get; set; }
//        private string AzureStoreCSSPJSONPath { get; set; }
//        private string CSSPJSONPath { get; set; }
//        private string CSSPJSONPathLocal { get; set; }
//        private string CSSPAzureUrl { get; set; }
//        #endregion Properties

//        #region Constructors
//        public TVItemLocalServiceTest()
//        {

//        }
//        #endregion Constructors

//        private async Task<bool> Setup(string culture, bool ClearLocalDB)
//        {
//            Configuration = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//               .AddJsonFile("appsettings_csspdblocalservicestests.json")
//               .AddUserSecrets("86d17aa8-ffaa-4834-b06c-95bdec59d59b")
//               .Build();

//            Services = new ServiceCollection();

//            Services.AddSingleton<IConfiguration>(Configuration);

//            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
//            Assert.NotNull(AzureStoreCSSPJSONPath);

//            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
//            Assert.NotNull(CSSPJSONPath);

//            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
//            Assert.NotNull(CSSPJSONPathLocal);

//            DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
//            Assert.True(di.Exists);

//            try
//            {
//                di.Delete(true);
//                di.Create();
//            }
//            catch (Exception ex)
//            {
//                Assert.True(false, ex.Message);
//            }

//            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
//            Assert.NotNull(CSSPDBLocal);

//            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

//            /* ---------------------------------------------------------------------------------
//             * CSSPDBLocalContext
//             * ---------------------------------------------------------------------------------      
//             */

//            Services.AddDbContext<CSSPDBLocalContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
//            });

//            /* ---------------------------------------------------------------------------------
//             * CSSPDBManageContext
//             * ---------------------------------------------------------------------------------      
//             */
//            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
//            Assert.NotNull(CSSPDBManage);

//            FileInfo fiCSSPDBManageFileName = new FileInfo(CSSPDBManage);

//            Services.AddDbContext<CSSPDBManageContext>(options =>
//            {
//                options.UseSqlite($"Data Source={ fiCSSPDBManageFileName.FullName }");
//            });

//            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
//            Services.AddSingleton<ILoggedInService, LoggedInService>();
//            Services.AddSingleton<IEnums, Enums>();
//            Services.AddSingleton<IManageFileService, ManageFileService>();
//            Services.AddSingleton<IFileService, FileService>();
//            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
//            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
//            Services.AddSingleton<ITVItemLocalService, TVItemLocalService>();

//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
//            Assert.NotNull(CSSPCultureService);

//            CSSPCultureService.SetCulture(culture);

//            LoggedInService = Provider.GetService<ILoggedInService>();
//            Assert.NotNull(LoggedInService);

//            Assert.True(await LoggedInService.SetLoggedInLocalContactInfo());

//            dbLocal = Provider.GetService<CSSPDBLocalContext>();
//            Assert.NotNull(dbLocal);

//            PostTVItemModelService = Provider.GetService<ITVItemLocalService>();
//            Assert.NotNull(PostTVItemModelService);

//            ReadGzFileService = Provider.GetService<IReadGzFileService>();
//            Assert.NotNull(ReadGzFileService);

//            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
//            Assert.NotNull(CreateGzFileService);

//            if (ClearLocalDB)
//            {
//                List<string> ExistingTableList = new List<string>();

//                using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
//                {
//                    command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
//                    dbLocal.Database.OpenConnection();
//                    using (var result = command.ExecuteReader())
//                    {
//                        while (result.Read())
//                        {
//                            ExistingTableList.Add(result.GetString(0));
//                        }
//                    }
//                }

//                foreach (string tableName in ExistingTableList)
//                {
//                    string TableIDName = "";

//                    if (tableName.StartsWith("AspNet") || tableName.StartsWith("DeviceCode") || tableName.StartsWith("Persisted")) continue;

//                    if (tableName == "Addresses")
//                    {
//                        TableIDName = tableName.Substring(0, tableName.Length - 2) + "ID";
//                    }
//                    else
//                    {
//                        TableIDName = tableName.Substring(0, tableName.Length - 1) + "ID";
//                    }

//                    dbLocal.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
//                }
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}
