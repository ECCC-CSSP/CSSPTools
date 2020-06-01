/*
 * Auto generated from C:\CSSPTools\src\codegen\ModelsModelClassNameTestGenerated_cs\bin\Debug\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
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
using CSSPModels.Resources;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class LastUpdateAndTVTextTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LastUpdateAndTVText lastUpdateAndTVText { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextTest()
        {
            lastUpdateAndTVText = new LastUpdateAndTVText();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LastUpdateAndTVText_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LastUpdateAndTVTextDate_UTC", "LastUpdateDate_Local", "TVText", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LastUpdateAndTVText).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void LastUpdateAndTVText_Has_ValidationResults_Test()
        {
             Assert.True(typeof(LastUpdateAndTVText).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void LastUpdateAndTVText_Every_Property_Has_Get_Set_Test()
        {
               DateTime val1 = new DateTime(2010, 3, 4);
               lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC = val1;
               Assert.Equal(val1, lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC);
               DateTime val2 = new DateTime(2010, 3, 4);
               lastUpdateAndTVText.LastUpdateDate_Local = val2;
               Assert.Equal(val2, lastUpdateAndTVText.LastUpdateDate_Local);
               string val3 = "Some text";
               lastUpdateAndTVText.TVText = val3;
               Assert.Equal(val3, lastUpdateAndTVText.TVText);
               bool val4 = true;
               lastUpdateAndTVText.HasErrors = val4;
               Assert.Equal(val4, lastUpdateAndTVText.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               lastUpdateAndTVText.ValidationResults = val15;
               Assert.Equal(val15, lastUpdateAndTVText.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
