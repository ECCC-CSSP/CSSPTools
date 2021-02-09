using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateRepopulateTestDB
{
    public partial class Startup
    {
        private IConfiguration Config { get; set; }
        public IServiceProvider Provider { get; set; }
        private TestDBContext dbTestDB { get; set; }
        private CSSPDBContext dbCSSPDB { get; set; }


        public Startup(IConfiguration Config)
        {
            this.Config = Config;

            ServiceCollection Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            if (TestDBConnString == null)
            {
                Console.WriteLine($"Could not find parameter TestDB in appsettings.json");
                return;
            }

            Services.AddDbContext<TestDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            string CSSPDBConnString = Config.GetValue<string>("CSSPDB");
            if (CSSPDBConnString == null)
            {
                Console.WriteLine($"Could not find parameter CSSPDB in appsettings.json");
                return;
            }

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine($"Provider should not be null");
                return;
            }

            dbTestDB = Provider.GetService<TestDBContext>();
            if (dbTestDB == null)
            {
                Console.WriteLine($"Could not get TestDBContext from Provider");
                return;
            }

            dbCSSPDB = Provider.GetService<CSSPDBContext>();
            if (dbCSSPDB == null)
            {
                Console.WriteLine($"Could not get CSSPDBContext from Provider");
                return;
            }
        }
    }
}
