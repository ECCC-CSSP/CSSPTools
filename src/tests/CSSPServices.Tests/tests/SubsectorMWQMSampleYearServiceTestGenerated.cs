 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    public partial class SubsectorMWQMSampleYearServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SubsectorMWQMSampleYearService subsectorMWQMSampleYearService { get; set; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearServiceTest() : base()
        {
            //subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private SubsectorMWQMSampleYear GetFilledRandomSubsectorMWQMSampleYear(string OmitPropName)
        {
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();

            if (OmitPropName != "SubsectorTVItemID") subsectorMWQMSampleYear.SubsectorTVItemID = GetRandomInt(1, 11);
            // should implement a Range for the property Year and type SubsectorMWQMSampleYear
            if (OmitPropName != "EarliestDate") subsectorMWQMSampleYear.EarliestDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "LatestDate") subsectorMWQMSampleYear.LatestDate = new DateTime(2005, 3, 6);

            return subsectorMWQMSampleYear;
        }
        #endregion Functions private
    }
}
