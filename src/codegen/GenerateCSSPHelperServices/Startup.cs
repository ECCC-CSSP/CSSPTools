using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GenerateCSSPHelperServices;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GenerateCSSPHelperServices
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
