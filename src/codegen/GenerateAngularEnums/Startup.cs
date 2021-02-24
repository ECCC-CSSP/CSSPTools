using CSSPCultureServices.Services;
using CSSPEnums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateAngularEnums
{
    public partial class Startup
    {
        private IConfiguration Configuration { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }
        public ICSSPCultureService CSSPCultureService { get; set; }
        public IEnums Enums { get; set; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                throw new Exception($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
            }

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            if (CSSPCultureService == null)
            {
                throw new Exception($"{ AppDomain.CurrentDomain.FriendlyName } CultureService == null");
            }

            CSSPCultureService.SetCulture(Configuration.GetValue<string>("CSSPCulture"));

            Enums = Provider.GetService<IEnums>();
            if (Enums == null)
            {
                throw new Exception($"Enums == null");
            }

        }

    }
}
