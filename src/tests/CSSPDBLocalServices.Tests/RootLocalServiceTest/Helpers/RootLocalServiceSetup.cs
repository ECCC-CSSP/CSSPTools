/* 
 *  Manually Edited
 *  
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPLogServices;
using System.Linq;
using CSSPScrambleServices;
using CSSPWebModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class RootLocalServiceTest : CSSPDBLocalServiceTest
    {
        #region Properties

        #endregion Properties

        #region Constructors
        public RootLocalServiceTest() : base()
        {


        }
        #endregion Constructors

        #region Functions private
        private async Task<bool> RootLocalServiceSetup(string culture)
        {
            List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages", "MapInfos", "MapInfoPoints" };

            Assert.True(await CSSPDBLocalServiceSetup(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}