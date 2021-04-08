using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GenerateCSSPDBModelsDocs
{
    partial class Program
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        #endregion Properties

        #region Entry
        public static async Task Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Startup startup = new Startup(Configuration);
            await startup.Generate();
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
