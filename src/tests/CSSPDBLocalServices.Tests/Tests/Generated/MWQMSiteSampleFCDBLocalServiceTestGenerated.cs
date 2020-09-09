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
    public partial class MWQMSiteSampleFCDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckMWQMSiteSampleFCFields(List<MWQMSiteSampleFC> mwqmSiteSampleFCList)
        {
            if (mwqmSiteSampleFCList[0].FC != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].FC);
            }
            if (mwqmSiteSampleFCList[0].Sal != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].Sal);
            }
            if (mwqmSiteSampleFCList[0].Temp != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].Temp);
            }
            if (mwqmSiteSampleFCList[0].PH != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].PH);
            }
            if (mwqmSiteSampleFCList[0].DO != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].DO);
            }
            if (mwqmSiteSampleFCList[0].Depth != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].Depth);
            }
            if (mwqmSiteSampleFCList[0].SampCount != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].SampCount);
            }
            if (mwqmSiteSampleFCList[0].MinFC != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].MinFC);
            }
            if (mwqmSiteSampleFCList[0].MaxFC != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].MaxFC);
            }
            if (mwqmSiteSampleFCList[0].GeoMean != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].GeoMean);
            }
            if (mwqmSiteSampleFCList[0].Median != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].Median);
            }
            if (mwqmSiteSampleFCList[0].P90 != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].P90);
            }
            if (mwqmSiteSampleFCList[0].PercOver43 != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].PercOver43);
            }
            if (mwqmSiteSampleFCList[0].PercOver260 != null)
            {
                Assert.NotNull(mwqmSiteSampleFCList[0].PercOver260);
            }
        }

        #endregion Functions private
    }
}
