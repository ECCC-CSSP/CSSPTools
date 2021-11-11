/*
 * manually edited
 *
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPScrambleServices;
using CSSPDBLocalServices;

namespace CSSPWebAPIsLocal.Tests
{
    public partial class CountryLocalControllerTests : CSSPWebAPIsLocalTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CountryLocalControllerTests() : base()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CountryLocalControllerSetup(string culture)
        {
            List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

            Assert.True(await CSSPWebAPIsLocalSetup(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
