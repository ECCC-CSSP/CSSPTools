using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AngularInterfacesGenerated
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

            startup.Run(args).GetAwaiter().GetResult();
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private


    }
}
