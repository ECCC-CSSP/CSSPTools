/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPHelperServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPHelperModels;
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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    public partial class LabSheetA1MeasurementDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckLabSheetA1MeasurementFields(List<LabSheetA1Measurement> labSheetA1MeasurementList)
        {
            Assert.False(string.IsNullOrWhiteSpace(labSheetA1MeasurementList[0].Site));
            if (labSheetA1MeasurementList[0].Time != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].Time);
            }
            if (labSheetA1MeasurementList[0].MPN != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].MPN);
            }
            if (labSheetA1MeasurementList[0].Tube10 != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].Tube10);
            }
            if (labSheetA1MeasurementList[0].Tube1_0 != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].Tube1_0);
            }
            if (labSheetA1MeasurementList[0].Tube0_1 != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].Tube0_1);
            }
            if (labSheetA1MeasurementList[0].Salinity != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].Salinity);
            }
            if (!string.IsNullOrWhiteSpace(labSheetA1MeasurementList[0].ProcessedBy))
            {
                Assert.False(string.IsNullOrWhiteSpace(labSheetA1MeasurementList[0].ProcessedBy));
            }
            if (labSheetA1MeasurementList[0].SampleType != null)
            {
                Assert.NotNull(labSheetA1MeasurementList[0].SampleType);
            }
            Assert.False(string.IsNullOrWhiteSpace(labSheetA1MeasurementList[0].SiteComment));
            if (!string.IsNullOrWhiteSpace(labSheetA1MeasurementList[0].SampleTypeText))
            {
                Assert.False(string.IsNullOrWhiteSpace(labSheetA1MeasurementList[0].SampleTypeText));
            }
        }

        #endregion Functions private
    }
}
