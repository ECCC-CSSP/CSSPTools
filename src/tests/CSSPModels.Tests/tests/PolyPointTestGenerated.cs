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

    public partial class PolyPointTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolyPoint polyPoint { get; set; }
        #endregion Properties

        #region Constructors
        public PolyPointTest()
        {
            polyPoint = new PolyPoint();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolyPoint_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "XCoord", "YCoord", "Z", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolyPoint).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void PolyPoint_Has_ValidationResults_Test()
        {
             Assert.True(typeof(PolyPoint).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void PolyPoint_Every_Property_Has_Get_Set_Test()
        {
               double val1 = 87.9D;
               polyPoint.XCoord = val1;
               Assert.Equal(val1, polyPoint.XCoord);
               double val2 = 87.9D;
               polyPoint.YCoord = val2;
               Assert.Equal(val2, polyPoint.YCoord);
               double val3 = 87.9D;
               polyPoint.Z = val3;
               Assert.Equal(val3, polyPoint.Z);
               bool val4 = true;
               polyPoint.HasErrors = val4;
               Assert.Equal(val4, polyPoint.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               polyPoint.ValidationResults = val15;
               Assert.Equal(val15, polyPoint.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
