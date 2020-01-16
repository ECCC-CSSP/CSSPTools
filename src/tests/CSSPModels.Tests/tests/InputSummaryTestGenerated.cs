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
    public partial class InputSummaryTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private InputSummary inputSummary { get; set; }
        #endregion Properties

        #region Constructors
        public InputSummaryTest()
        {
            inputSummary = new InputSummary();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void InputSummary_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Summary", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(InputSummary).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void InputSummary_Has_ValidationResults_Test()
        {
             Assert.True(typeof(InputSummary).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void InputSummary_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               inputSummary.Summary = val1;
               Assert.Equal(val1, inputSummary.Summary);
               bool val2 = true;
               inputSummary.HasErrors = val2;
               Assert.Equal(val2, inputSummary.HasErrors);
               IEnumerable<ValidationResult> val9 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               inputSummary.ValidationResults = val9;
               Assert.Equal(val9, inputSummary.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
