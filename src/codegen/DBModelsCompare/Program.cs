using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DBModelsCompare
{
    partial class Program
    {
        #region Variables
        #endregion Variables

        #region Entry
        static async Task<int> Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Startup startup = new Startup(Configuration);

            if (!await startup.Run(args)) return await Task.FromResult((int)ExitCode.Error);

            return await Task.FromResult((int)ExitCode.Success);
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private


    }
}
