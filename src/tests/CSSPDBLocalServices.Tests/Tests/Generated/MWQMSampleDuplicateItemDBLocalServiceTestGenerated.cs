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
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    public partial class MWQMSampleDuplicateItemDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleDuplicateItemDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckMWQMSampleDuplicateItemFields(List<MWQMSampleDuplicateItem> mwqmSampleDuplicateItemList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mwqmSampleDuplicateItemList[0].ParentSite));
            Assert.False(string.IsNullOrWhiteSpace(mwqmSampleDuplicateItemList[0].DuplicateSite));
        }

        #endregion Functions private
    }
}
