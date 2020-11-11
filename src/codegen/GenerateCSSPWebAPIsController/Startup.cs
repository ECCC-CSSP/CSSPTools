using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GenerateCSSPWebAPIsController
{
    public partial class Startup
    {
        private IConfiguration Config { get; set; }


        public Startup(IConfiguration Config)
        {
            this.Config = Config;
        }
    }
}
