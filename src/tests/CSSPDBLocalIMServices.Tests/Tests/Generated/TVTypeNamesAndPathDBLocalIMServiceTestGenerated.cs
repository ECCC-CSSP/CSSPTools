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
using LocalServices;

namespace CSSPDBLocalIMServices.Tests
{
    public partial class TVTypeNamesAndPathDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckTVTypeNamesAndPathFields(List<TVTypeNamesAndPath> tvTypeNamesAndPathList)
        {
            Assert.False(string.IsNullOrWhiteSpace(tvTypeNamesAndPathList[0].TVTypeName));
            Assert.False(string.IsNullOrWhiteSpace(tvTypeNamesAndPathList[0].TVPath));
        }

        #endregion Functions private
    }
}
