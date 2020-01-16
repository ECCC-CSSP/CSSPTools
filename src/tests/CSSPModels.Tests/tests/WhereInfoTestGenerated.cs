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
    public partial class WhereInfoTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private WhereInfo whereInfo { get; set; }
        #endregion Properties

        #region Constructors
        public WhereInfoTest()
        {
            whereInfo = new WhereInfo();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void WhereInfo_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PropertyName", "PropertyType", "WhereOperator", "Value", "ValueInt", "ValueDouble", "ValueBool", "ValueDateTime", "ValueEnumText", "EnumType", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(WhereInfo).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void WhereInfo_Has_ValidationResults_Test()
        {
             Assert.True(typeof(WhereInfo).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void WhereInfo_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               whereInfo.PropertyName = val1;
               Assert.Equal(val1, whereInfo.PropertyName);
               PropertyTypeEnum val2 = (PropertyTypeEnum)3;
               whereInfo.PropertyType = val2;
               Assert.Equal(val2, whereInfo.PropertyType);
               WhereOperatorEnum val3 = (WhereOperatorEnum)3;
               whereInfo.WhereOperator = val3;
               Assert.Equal(val3, whereInfo.WhereOperator);
               string val4 = "Some text";
               whereInfo.Value = val4;
               Assert.Equal(val4, whereInfo.Value);
               int val5 = 45;
               whereInfo.ValueInt = val5;
               Assert.Equal(val5, whereInfo.ValueInt);
               double val6 = 87.9D;
               whereInfo.ValueDouble = val6;
               Assert.Equal(val6, whereInfo.ValueDouble);
               bool val7 = true;
               whereInfo.ValueBool = val7;
               Assert.Equal(val7, whereInfo.ValueBool);
               DateTime val8 = new DateTime(2010, 3, 4);
               whereInfo.ValueDateTime = val8;
               Assert.Equal(val8, whereInfo.ValueDateTime);
               string val9 = "Some text";
               whereInfo.ValueEnumText = val9;
               Assert.Equal(val9, whereInfo.ValueEnumText);
               Type val10 = typeof(WhereInfo);
               whereInfo.EnumType = val10;
               Assert.Equal(val10, whereInfo.EnumType);
               bool val11 = true;
               whereInfo.HasErrors = val11;
               Assert.Equal(val11, whereInfo.HasErrors);
               IEnumerable<ValidationResult> val36 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               whereInfo.ValidationResults = val36;
               Assert.Equal(val36, whereInfo.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
