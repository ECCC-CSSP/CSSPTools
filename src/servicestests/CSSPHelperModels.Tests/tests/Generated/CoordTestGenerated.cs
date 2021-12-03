/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net6.0\GenerateCSSPHelperModels_TestsGenerated.exe
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
    public partial class CoordTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Coord coord { get; set; }
        #endregion Properties

        #region Constructors
        public CoordTest()
        {
            coord = new Coord();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Coord_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Lat", "Lng", "Ordinal",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Coord).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void Coord_Every_Property_Has_Get_Set_Test()
        {
               double val1 = 87.9D;
               coord.Lat = val1;
               Assert.Equal(val1, coord.Lat);
               double val2 = 87.9D;
               coord.Lng = val2;
               Assert.Equal(val2, coord.Lng);
               int val3 = 45;
               coord.Ordinal = val3;
               Assert.Equal(val3, coord.Ordinal);
        }
        #endregion Tests Functions public
    }
}
