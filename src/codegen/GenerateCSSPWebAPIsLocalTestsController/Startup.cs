using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateCSSPWebAPIsLocal_TestsController
{
    public partial class Startup
    {
        private IConfiguration Configuration { get; set; }


        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
    }
}
