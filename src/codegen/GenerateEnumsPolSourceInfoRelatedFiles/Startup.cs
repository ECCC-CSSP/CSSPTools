using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Threading.Tasks;

namespace GenerateEnumsPolSourceInfoRelatedFiles
{
    public partial class Startup
    {
        private PolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService = new PolSourceGroupingExcelFileReadService();

        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
    }
}
