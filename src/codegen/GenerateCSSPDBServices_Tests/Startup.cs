using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices_Tests
{
    public partial class Startup
    {
        private IConfiguration Configuration { get; set; }
        public IServiceProvider Provider { get; set; }
        private TestDBContext dbTestDB { get; set; }


        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;

            ServiceCollection Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string TestDBConnString = Configuration.GetValue<string>("TestDB");
            if (TestDBConnString == null)
            {
                Console.WriteLine($"Could not find parameter TestDB in appsettings.json");
                return;
            }

            Services.AddDbContext<TestDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine($"Provider should not be null");
                return;
            }

            dbTestDB = Provider.GetService<TestDBContext>();
        }
    }
}
