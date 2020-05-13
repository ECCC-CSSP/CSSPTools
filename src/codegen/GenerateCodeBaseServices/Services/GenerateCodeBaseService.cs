using CSSPEnums;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Resources;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodeBaseServices.Services
{
    public partial class GenerateCodeBaseService : IGenerateCodeBaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        #endregion Properties

        #region Constructors
        public GenerateCodeBaseService(IConfiguration configuration, IActionCommandDBService actionCommandDBService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
        }
        #endregion Constructors

        #region Functions public
        public async Task SetCulture(CultureInfo culture)
        {
            await actionCommandDBService.SetCulture(culture);
            GenerateCodeBaseServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
