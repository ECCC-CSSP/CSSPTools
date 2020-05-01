using EnumsCompareWithOldEnumsServices.Resources;
using EnumsCompareWithOldEnumsServices.Services;
using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EnumsCompareWithOldEnums
{
    partial class Program
    {
        #region Variables
        private static IServiceCollection serviceCollection;
        private static IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Entry
        static void Main(string[] args)
        {
            try
            {
                serviceCollection = new ServiceCollection();

                serviceCollection.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();

                ServiceProvider provider = serviceCollection.BuildServiceProvider();
                if (provider == null)
                {
                    throw new Exception("EnumsCompareWithOldEnums provider == null");
                }

                enumsCompareWithOldEnumsService = provider.GetService<IEnumsCompareWithOldEnumsService>();
                if (enumsCompareWithOldEnumsService == null)
                {
                    throw new Exception("EnumsCompareWithOldEnums enumsCompareWithOldEnumsService == null");
                }

                enumsCompareWithOldEnumsService.Setup().GetAwaiter().GetResult();
                enumsCompareWithOldEnumsService.Run(args).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Entry

        #region Functions private
        #endregion Functions private
    }
}
