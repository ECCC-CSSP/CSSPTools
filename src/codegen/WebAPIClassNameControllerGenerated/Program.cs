using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace WebAPIClassNameControllerGeneratedServices
{
    partial class Program
    {
        #region Variables
        #endregion Variables

        #region Entry
        static void Main(string[] args)
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
                throw new Exception(retStr);
            }

            retStr = startup.Run(args);
            if (retStr != "")
            {
                Console.WriteLine(retStr);
                throw new Exception(retStr);
            }
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private


    }
}
