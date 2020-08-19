using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GenerateAllGzFiles
{
    partial class Program
    {
        static async Task<int> Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_generateallgzfiles.json")
               .AddUserSecrets("3b50ec27-7fa2-4e0a-a0da-c2aa6eef7198")
               .Build();

            Startup startup = new Startup(Configuration);

            if (!await startup.Run()) return await Task.FromResult(1);

            return await Task.FromResult(0);
        }
    }
}
