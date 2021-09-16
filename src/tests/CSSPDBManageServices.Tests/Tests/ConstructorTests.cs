using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await CSSPDBManageServiceSetup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CommandLogService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(dbManage);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
