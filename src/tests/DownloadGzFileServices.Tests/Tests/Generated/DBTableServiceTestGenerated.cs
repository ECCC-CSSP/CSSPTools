/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;

namespace CSSPServices.Tests
{
    public partial class DBTableServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IDBTableService DBTableService { get; set; }
        private DBTable dBTable { get; set; }
        #endregion Properties

        #region Constructors
        public DBTableServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Basic Test Not Mapped
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DBTableService_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            dBTable = GetFilledRandomDBTable("");

            List<ValidationResult> ValidationResultsList = DBTableService.Validate(new ValidationContext(dBTable)).ToList();
            Assert.True(ValidationResultsList.Count == 0);
        }
        #endregion Tests Generated Basic Test Not Mapped

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IDBTableService, DBTableService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            DBTableService = Provider.GetService<IDBTableService>();
            Assert.NotNull(DBTableService);

            return await Task.FromResult(true);
        }
        private DBTable GetFilledRandomDBTable(string OmitPropName)
        {
            DBTable dBTable = new DBTable();

            if (OmitPropName != "TableName") dBTable.TableName = GetRandomString("", 6);
            if (OmitPropName != "Plurial") dBTable.Plurial = GetRandomString("", 3);

            return dBTable;
        }
        private void CheckDBTableFields(List<DBTable> dBTableList)
        {
            Assert.False(string.IsNullOrWhiteSpace(dBTableList[0].TableName));
            Assert.False(string.IsNullOrWhiteSpace(dBTableList[0].Plurial));
        }
        #endregion Functions private
    }
}
