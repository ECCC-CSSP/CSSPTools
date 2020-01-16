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
    public partial class PolSourceObservationIssueTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObservationIssue polSourceObservationIssue { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueTest()
        {
            polSourceObservationIssue = new PolSourceObservationIssue();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceObservationIssue_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceObservationIssueID", "PolSourceObservationID", "ObservationInfo", "Ordinal", "ExtraComment", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservationIssue).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservationIssue).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceObservationIssue_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservationIssue).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    bool foreignNameExist = foreignNameList.Contains(propertyInfo.Name);
                    Assert.True(foreignNameExist);
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservationIssue).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    bool foreignNameCollectionExist = foreignNameCollectionList.Contains(propertyInfo.Name);
                    Assert.True(foreignNameCollectionExist);
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void PolSourceObservationIssue_Has_ValidationResults_Test()
        {
             Assert.True(typeof(PolSourceObservationIssue).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void PolSourceObservationIssue_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceObservationIssue.PolSourceObservationIssueID = val1;
               Assert.Equal(val1, polSourceObservationIssue.PolSourceObservationIssueID);
               int val2 = 45;
               polSourceObservationIssue.PolSourceObservationID = val2;
               Assert.Equal(val2, polSourceObservationIssue.PolSourceObservationID);
               string val3 = "Some text";
               polSourceObservationIssue.ObservationInfo = val3;
               Assert.Equal(val3, polSourceObservationIssue.ObservationInfo);
               int val4 = 45;
               polSourceObservationIssue.Ordinal = val4;
               Assert.Equal(val4, polSourceObservationIssue.Ordinal);
               string val5 = "Some text";
               polSourceObservationIssue.ExtraComment = val5;
               Assert.Equal(val5, polSourceObservationIssue.ExtraComment);
               DateTime val6 = new DateTime(2010, 3, 4);
               polSourceObservationIssue.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, polSourceObservationIssue.LastUpdateDate_UTC);
               int val7 = 45;
               polSourceObservationIssue.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, polSourceObservationIssue.LastUpdateContactTVItemID);
               bool val8 = true;
               polSourceObservationIssue.HasErrors = val8;
               Assert.Equal(val8, polSourceObservationIssue.HasErrors);
               IEnumerable<ValidationResult> val27 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               polSourceObservationIssue.ValidationResults = val27;
               Assert.Equal(val27, polSourceObservationIssue.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
