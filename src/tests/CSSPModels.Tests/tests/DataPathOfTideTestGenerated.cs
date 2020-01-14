/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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

    public partial class DataPathOfTideTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private DataPathOfTide dataPathOfTide { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideTest()
        {
            dataPathOfTide = new DataPathOfTide();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void DataPathOfTide_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Text", "WebTideDataSet", "WebTideDataSetText", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(DataPathOfTide).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void DataPathOfTide_Has_ValidationResults_Test()
        {
             Assert.True(typeof(DataPathOfTide).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void DataPathOfTide_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               dataPathOfTide.Text = val1;
               Assert.Equal(val1, dataPathOfTide.Text);
               WebTideDataSetEnum val2 = (WebTideDataSetEnum)3;
               dataPathOfTide.WebTideDataSet = val2;
               Assert.Equal(val2, dataPathOfTide.WebTideDataSet);
               string val3 = "Some text";
               dataPathOfTide.WebTideDataSetText = val3;
               Assert.Equal(val3, dataPathOfTide.WebTideDataSetText);
               bool val4 = true;
               dataPathOfTide.HasErrors = val4;
               Assert.Equal(val4, dataPathOfTide.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               dataPathOfTide.ValidationResults = val15;
               Assert.Equal(val15, dataPathOfTide.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
