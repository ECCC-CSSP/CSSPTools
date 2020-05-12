using ExecuteDotNetCommandServices.Models;
using ExecuteDotNetCommandServices.Resources;
using ExecuteDotNetCommandServices.Services;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExecuteDotNetCommand
{
    partial class Program
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Entry
        static int Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Startup startup = new Startup(Configuration);

            IServiceCollection serviceCollection = new ServiceCollection();

            string retStr = startup.ConfigureServices(serviceCollection);
            if (retStr != "")
            {
                Console.WriteLine(retStr);
                return 1;
            }

            retStr = startup.Run(args);
            if (retStr != "")
            {
                Console.WriteLine(retStr);
                return 1;
            }

            return 0;
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
