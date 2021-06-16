/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
 *
 * Do not edit this file.
 *
 */ 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    public partial class ManageServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ManageContext_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(db);
            Assert.NotNull(dbLocal);
            Assert.NotNull(dbManage);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(CommandLogService);
            Assert.NotNull(dbManage.CommandLogs);
            Assert.NotNull(dbManage.ManageFiles);
            Assert.NotNull(dbManage.Contacts);
            Assert.NotNull(dbManage.TVItemUserAuthorizations);
            Assert.NotNull(dbManage.TVTypeUserAuthorizations);
        }
        #endregion Tests

        #region private
        #endregion private
    }
}
