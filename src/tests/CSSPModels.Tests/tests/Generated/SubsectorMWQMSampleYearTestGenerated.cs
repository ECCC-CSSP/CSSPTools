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
    public partial class SubsectorMWQMSampleYearTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SubsectorMWQMSampleYear subsectorMWQMSampleYear { get; set; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearTest()
        {
            subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SubsectorMWQMSampleYear_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "SubsectorTVItemID", "Year", "EarliestDate", "LatestDate", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SubsectorMWQMSampleYear).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void SubsectorMWQMSampleYear_Has_ValidationResults_Test()
        {
             Assert.True(typeof(SubsectorMWQMSampleYear).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void SubsectorMWQMSampleYear_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               subsectorMWQMSampleYear.SubsectorTVItemID = val1;
               Assert.Equal(val1, subsectorMWQMSampleYear.SubsectorTVItemID);
               int val2 = 45;
               subsectorMWQMSampleYear.Year = val2;
               Assert.Equal(val2, subsectorMWQMSampleYear.Year);
               DateTime val3 = new DateTime(2010, 3, 4);
               subsectorMWQMSampleYear.EarliestDate = val3;
               Assert.Equal(val3, subsectorMWQMSampleYear.EarliestDate);
               DateTime val4 = new DateTime(2010, 3, 4);
               subsectorMWQMSampleYear.LatestDate = val4;
               Assert.Equal(val4, subsectorMWQMSampleYear.LatestDate);
               bool val5 = true;
               subsectorMWQMSampleYear.HasErrors = val5;
               Assert.Equal(val5, subsectorMWQMSampleYear.HasErrors);
               IEnumerable<ValidationResult> val18 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               subsectorMWQMSampleYear.ValidationResults = val18;
               Assert.Equal(val18, subsectorMWQMSampleYear.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
