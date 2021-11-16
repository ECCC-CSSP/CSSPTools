using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
    {
        private IConfiguration Configuration { get; set; }
        public IServiceProvider Provider { get; set; }
        private CSSPDBContext db { get; set; }


        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;

            ServiceCollection Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string CSSPDBConnString = Configuration["CSSPDB"];
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

            db = Provider.GetService<CSSPDBContext>();
        }
    }
}
