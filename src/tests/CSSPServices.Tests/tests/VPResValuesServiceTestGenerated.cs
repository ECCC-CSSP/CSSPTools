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

    public partial class VPResValuesServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPResValuesService vpResValuesService { get; set; }
        #endregion Properties

        #region Constructors
        public VPResValuesServiceTest() : base()
        {
            //vpResValuesService = new VPResValuesService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private VPResValues GetFilledRandomVPResValues(string OmitPropName)
        {
            VPResValues vpResValues = new VPResValues();

            if (OmitPropName != "Conc") vpResValues.Conc = GetRandomInt(0, 10);
            // should implement a Range for the property Dilu and type VPResValues
            // should implement a Range for the property FarfieldWidth and type VPResValues
            // should implement a Range for the property Distance and type VPResValues
            // should implement a Range for the property TheTime and type VPResValues
            // should implement a Range for the property Decay and type VPResValues

            return vpResValues;
        }
        #endregion Functions private
    }
}
