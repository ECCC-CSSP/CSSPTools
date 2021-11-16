using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CSSPScrambleServices;

namespace CSSPFileServices.Tests
{
    [Collection("Sequential")]

    public partial class FileServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICSSPFileService CSSPFileService { get; set; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        public FileServiceTests()
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspfileservicestests.json")
               .AddUserSecrets("82e4fd10-d824-4d2a-afef-8a95e0902d75")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            List<string> DirList = new List<string>()
            {
                Configuration["CSSPFilesPath"],
                Configuration["CSSPJSONPath"],
                Configuration["CSSPTempFilesPath"],
                Configuration["CSSPOtherFilesPath"],
            };

            foreach (string dir in DirList)
            {
                // deleting directory CSSPJSONPath
                DirectoryInfo di = new DirectoryInfo(dir);
                if (di.Exists)
                {
                    try
                    {
                        di.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        Assert.True(false, ex.Message);
                    }
                }

                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }

                DirectoryCopy(dir.Replace("test\\", "\\"), dir, true);
            }
        }
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
        private async Task<bool> CSSPFileServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspfileservicestests.json")
               .AddUserSecrets("82e4fd10-d824-4d2a-afef-8a95e0902d75")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Assert.NotNull(Configuration["AzureStoreCSSPFilesPath"]);
            Assert.NotNull(Configuration["AzureStoreCSSPJSONPath"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["CSSPDatabasesPath"]);
            Assert.NotNull(Configuration["CSSPDB"]);
            Assert.NotNull(Configuration["CSSPDBManage"]);
            Assert.NotNull(Configuration["CSSPDesktopPath"]);
            Assert.NotNull(Configuration["CSSPFilesPath"]);
            Assert.NotNull(Configuration["CSSPJSONPath"]);
            Assert.NotNull(Configuration["CSSPOtherFilesPath"]);
            Assert.NotNull(Configuration["CSSPTempFilesPath"]);
            Assert.NotNull(Configuration["CSSPWebAPIsLocalPath"]);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"].Replace("_test", ""));
            Assert.True(fiCSSPDBManage.Exists);

            FileInfo fiCSSPDBManageTest = new FileInfo(Configuration["CSSPDBManage"]);
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

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManageTest.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            await CSSPLocalLoggedInService.SetLoggedInContactInfo();
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            CSSPFileService = Provider.GetService<ICSSPFileService>();
            Assert.NotNull(CSSPFileService);

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            Assert.NotNull(CSSPScrambleService);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                       select c).ToList();

            try
            {
                dbManage.CommandLogs.RemoveRange(commandLogToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all CommandLogs from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
            }

            List<ManageFile> manageFileToDeleteList = (from c in dbManage.ManageFiles
                                                       select c).ToList();

            try
            {
                dbManage.ManageFiles.RemoveRange(manageFileToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all ManageFiles from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
