using GenerateCodeBaseServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenerateCompareDBFieldsAndCSSPDBModelsProp
{
    partial class Startup
    {
        private IConfiguration Config { get; set; }

        private List<TableFieldEnumException> TableFieldEnumExceptionList { get; set; }
        private List<TableFieldEmail> TableFieldEmailList { get; set; }
        private List<TableFieldIDException> TableFieldIDExceptionList { get; set; }


        public Startup(IConfiguration Config)
        {
            this.Config = Config;
        }

    }
}
