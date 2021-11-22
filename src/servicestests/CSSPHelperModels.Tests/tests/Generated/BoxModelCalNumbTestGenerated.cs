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
    public partial class BoxModelCalNumbTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private BoxModelCalNumb boxModelCalNumb { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelCalNumbTest()
        {
            boxModelCalNumb = new BoxModelCalNumb();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void BoxModelCalNumb_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "BoxModelResultType", "CalLength_m", "CalRadius_m", "CalSurface_m2", "CalVolume_m3", "CalWidth_m", "FixLength", "FixWidth", "BoxModelResultTypeText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(BoxModelCalNumb).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void BoxModelCalNumb_Every_Property_Has_Get_Set_Test()
        {
               BoxModelResultTypeEnum val1 = (BoxModelResultTypeEnum)3;
               boxModelCalNumb.BoxModelResultType = val1;
               Assert.Equal(val1, boxModelCalNumb.BoxModelResultType);
               double val2 = 87.9D;
               boxModelCalNumb.CalLength_m = val2;
               Assert.Equal(val2, boxModelCalNumb.CalLength_m);
               double val3 = 87.9D;
               boxModelCalNumb.CalRadius_m = val3;
               Assert.Equal(val3, boxModelCalNumb.CalRadius_m);
               double val4 = 87.9D;
               boxModelCalNumb.CalSurface_m2 = val4;
               Assert.Equal(val4, boxModelCalNumb.CalSurface_m2);
               double val5 = 87.9D;
               boxModelCalNumb.CalVolume_m3 = val5;
               Assert.Equal(val5, boxModelCalNumb.CalVolume_m3);
               double val6 = 87.9D;
               boxModelCalNumb.CalWidth_m = val6;
               Assert.Equal(val6, boxModelCalNumb.CalWidth_m);
               bool val7 = true;
               boxModelCalNumb.FixLength = val7;
               Assert.Equal(val7, boxModelCalNumb.FixLength);
               bool val8 = true;
               boxModelCalNumb.FixWidth = val8;
               Assert.Equal(val8, boxModelCalNumb.FixWidth);
               string val9 = "Some text";
               boxModelCalNumb.BoxModelResultTypeText = val9;
               Assert.Equal(val9, boxModelCalNumb.BoxModelResultTypeText);
        }
        #endregion Tests Functions public
    }
}