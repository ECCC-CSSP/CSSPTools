using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ModelsCSSPModelsRes
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

            if (!await startup.Run(args)) return await Task.FromResult(0);

            return await Task.FromResult(1);
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private


    }
}
