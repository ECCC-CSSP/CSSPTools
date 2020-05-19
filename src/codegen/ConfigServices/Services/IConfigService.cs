using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConfigServices.Services
{
    public interface IConfigService
    {
        IConfiguration Config { get; set; }
        IServiceProvider Provider { get; set; }
        IServiceCollection Services { get; set; }
        IActionCommandDBService ActionCommandDBService { get; set; }
        string DBFileName { get; set; }
        //CSSPDBContext CSSPDBCtx { get; set; }
        //TestDBContext TestDBCtx { get; set; }


        Task<bool> BuildServiceProvider();
        Task<bool> ConfigureBaseServices();
        Task<bool> ConfigureCSSPDBContext();
        Task<bool> ConfigureTestDBContext();
    }
}
