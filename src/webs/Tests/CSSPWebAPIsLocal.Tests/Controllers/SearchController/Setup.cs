/*
 * manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPWebAPIsLocal.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using LocalServices;
using CSSPDBSearchServices;

namespace SearchControllers.Tests
{
    public partial class SearchControllerTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ILocalService LocalService { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPDBSearchService CSSPDBSearchService { get; set; }
        private string LocalUrl { get; set; }
        #endregion Properties

        #region Constructors
        public SearchControllerTests()
        {
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspwebapistests.json")
               .AddUserSecrets("9d65c001-b7bc-4922-a0fc-1558b9ef927e")
               .Build();

            Services = new ServiceCollection();

            string LocalUrl = Configuration.GetValue<string>("LocalUrl");
            Assert.NotNull(LocalUrl);

            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearchFileName);

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchFileName);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            //string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            //Assert.NotNull(CSSPDBFilesManagementFileName);

            //FileInfo fiCSSPDBFilesManagementFileName = new FileInfo(CSSPDBFilesManagementFileName);

            //Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            //{
            //    options.UseSqlite($"Data Source={ fiCSSPDBFilesManagementFileName.FullName }");
            //});

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<ICSSPDBSearchService, CSSPDBSearchService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPDBSearchService = Provider.GetService<ICSSPDBSearchService>();
            Assert.NotNull(CSSPDBSearchService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
