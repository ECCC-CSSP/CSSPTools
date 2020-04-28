using EnumsCompareWithOldEnumsServices.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnumsServices.Tests
{
    public class TestBase
    {
        #region Variables
        private static IServiceCollection serviceCollection;
        public static IConfiguration _configuration;
        public static IEnumsCompareWithOldEnumsService enumsCompareWithOldEnumsService;
        public static IGenerateCodeStatusDBService generateCodeStatusDBService;
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TestBase()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection = new ServiceCollection();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo($"{appDataPath}\\CSSP\\GenerateCodeStatusTest.db");

            serviceCollection.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            GenerateCodeStatusContext db = new GenerateCodeStatusContext();
            generateCodeStatusDBService = new GenerateCodeStatusDBService(db);
            enumsCompareWithOldEnumsService = new EnumsCompareWithOldEnumsService(_configuration, generateCodeStatusDBService);
        }
        #endregion Constructors

    }

}
