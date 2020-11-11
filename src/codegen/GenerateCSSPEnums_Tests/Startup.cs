﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GenerateCSSPEnums_Tests
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
