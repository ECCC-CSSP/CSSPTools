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
    public partial class VPScenarioIDAndRawResultsServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPScenarioIDAndRawResultsService vpScenarioIDAndRawResultsService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioIDAndRawResultsServiceTest() : base()
        {
            //vpScenarioIDAndRawResultsService = new VPScenarioIDAndRawResultsService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private VPScenarioIDAndRawResults GetFilledRandomVPScenarioIDAndRawResults(string OmitPropName)
        {
            VPScenarioIDAndRawResults vpScenarioIDAndRawResults = new VPScenarioIDAndRawResults();

            if (OmitPropName != "VPScenarioID") vpScenarioIDAndRawResults.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "RawResults") vpScenarioIDAndRawResults.RawResults = GetRandomString("", 20);

            return vpScenarioIDAndRawResults;
        }
        #endregion Functions private
    }
}
