using Azure.Storage.Blobs;
using CSSPCultureServices.Services;
using CSSPLocalLoggedInServices;
using CSSPScrambleServices;
using ManageServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuild
{
    partial class Program
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Entry
        static async Task<int> Main(string[] args)
        {
            IConfiguration Configuration;
            IServiceProvider Provider;
            IServiceCollection Services;
            ICSSPScrambleService CSSPScrambleService;
            //ICSSPCultureService CSSPCultureService;
            //IManageFileService ManageFileService;
            //ICSSPLocalLoggedInService CSSPLocalLoggedInService;

            Configuration = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                              .AddJsonFile("appsettings_csspdesktopinstallpostbuild.json")
                              .AddUserSecrets("1f0910b7-2452-49bd-b68e-4661df5d54d7")
                              .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            //Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            //Services.AddSingleton<IManageFileService, ManageFileService>();
            //Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null) return await Task.FromResult(1);

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            if (CSSPScrambleService == null) return await Task.FromResult(1);

            //CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            //if (CSSPCultureService == null) return await Task.FromResult(1);

            //ManageFileService = Provider.GetService<IManageFileService>();
            //if (ManageFileService == null) return await Task.FromResult(1);

            //CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            //if (CSSPLocalLoggedInService == null) return await Task.FromResult(1);

            //Startup startup = new Startup(Configuration, CSSPScrambleService, CSSPLocalLoggedInService);

            Startup startup = new Startup(Configuration, CSSPScrambleService);

            if (!await startup.Run()) return await Task.FromResult(1);

            return await Task.FromResult(0);
        }

        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
