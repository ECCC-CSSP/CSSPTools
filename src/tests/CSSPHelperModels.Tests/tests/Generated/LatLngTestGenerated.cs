/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperModels_TestsGenerated.exe
 *
 * Do not edit this file.
 *
 */ 
using System;
using System.Text;
using Xunit;
using System.Linq;
using System.Globalization;
using System.Transactions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;
using CSSPDBModels;

namespace CSSPHelperModels.Tests
{
    public partial class LatLngTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LatLng latLng { get; set; }
        #endregion Properties

        #region Constructors
        public LatLngTest()
        {
            latLng = new LatLng();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LatLng_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Lat", "Lng",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LatLng).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void LatLng_Every_Property_Has_Get_Set_Test()
        {
               double val1 = 87.9D;
               latLng.Lat = val1;
               Assert.Equal(val1, latLng.Lat);
               double val2 = 87.9D;
               latLng.Lng = val2;
               Assert.Equal(val2, latLng.Lng);
        }
        #endregion Tests Functions public
    }
}
