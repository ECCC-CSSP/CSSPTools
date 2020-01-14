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

    public partial class ClassificationTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Classification classification { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationTest()
        {
            classification = new Classification();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Classification_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ClassificationID", "ClassificationTVItemID", "ClassificationType", "Ordinal", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Classification).GetProperties().OrderBy(c => c.Name))
            {
                if (!propertyInfo.GetGetMethod().IsVirtual
                    && propertyInfo.Name != "ValidationResults"
                    && !propertyInfo.CustomAttributes.Where(c => c.AttributeType.Name.Contains("NotMappedAttribute")).Any())
                {
                    Assert.Equal(propNameList[index], propertyInfo.Name);
                    index += 1;
                }
            }

            Assert.Equal(propNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Classification).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        Assert.Equal(propertyInfo.Name, propNameNotMappedList[index]);
                        index += 1;
                    }
                }
            }

            Assert.Equal(propNameNotMappedList.Count, index);

        }
        [Fact]
        public void Classification_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Classification).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Classification).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameCollectionList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void Classification_Has_ValidationResults_Test()
        {
             Assert.True(typeof(Classification).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void Classification_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               classification.ClassificationID = val1;
               Assert.Equal(val1, classification.ClassificationID);
               int val2 = 45;
               classification.ClassificationTVItemID = val2;
               Assert.Equal(val2, classification.ClassificationTVItemID);
               ClassificationTypeEnum val3 = (ClassificationTypeEnum)3;
               classification.ClassificationType = val3;
               Assert.Equal(val3, classification.ClassificationType);
               int val4 = 45;
               classification.Ordinal = val4;
               Assert.Equal(val4, classification.Ordinal);
               DateTime val5 = new DateTime(2010, 3, 4);
               classification.LastUpdateDate_UTC = val5;
               Assert.Equal(val5, classification.LastUpdateDate_UTC);
               int val6 = 45;
               classification.LastUpdateContactTVItemID = val6;
               Assert.Equal(val6, classification.LastUpdateContactTVItemID);
               bool val7 = true;
               classification.HasErrors = val7;
               Assert.Equal(val7, classification.HasErrors);
               IEnumerable<ValidationResult> val24 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               classification.ValidationResults = val24;
               Assert.Equal(val24, classification.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
