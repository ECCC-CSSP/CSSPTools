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
    public partial class CalDecayTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CalDecay calDecay { get; set; }
        #endregion Properties

        #region Constructors
        public CalDecayTest()
        {
            calDecay = new CalDecay();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void CalDecay_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Decay", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(CalDecay).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void CalDecay_Has_ValidationResults_Test()
        {
             Assert.True(typeof(CalDecay).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void CalDecay_Every_Property_Has_Get_Set_Test()
        {
               double val1 = 87.9D;
               calDecay.Decay = val1;
               Assert.Equal(val1, calDecay.Decay);
               bool val2 = true;
               calDecay.HasErrors = val2;
               Assert.Equal(val2, calDecay.HasErrors);
               IEnumerable<ValidationResult> val9 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               calDecay.ValidationResults = val9;
               Assert.Equal(val9, calDecay.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
