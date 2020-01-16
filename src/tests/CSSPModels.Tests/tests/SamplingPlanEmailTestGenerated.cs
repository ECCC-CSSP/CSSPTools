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
    public partial class SamplingPlanEmailTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SamplingPlanEmail samplingPlanEmail { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailTest()
        {
            samplingPlanEmail = new SamplingPlanEmail();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SamplingPlanEmail_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "SamplingPlanEmailID", "SamplingPlanID", "Email", "IsContractor", "LabSheetHasValueOver500", "LabSheetReceived", "LabSheetAccepted", "LabSheetRejected", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanEmail).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanEmail).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SamplingPlanEmail_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanEmail).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanEmail).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SamplingPlanEmail_Has_ValidationResults_Test()
        {
             Assert.True(typeof(SamplingPlanEmail).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void SamplingPlanEmail_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               samplingPlanEmail.SamplingPlanEmailID = val1;
               Assert.Equal(val1, samplingPlanEmail.SamplingPlanEmailID);
               int val2 = 45;
               samplingPlanEmail.SamplingPlanID = val2;
               Assert.Equal(val2, samplingPlanEmail.SamplingPlanID);
               string val3 = "Some text";
               samplingPlanEmail.Email = val3;
               Assert.Equal(val3, samplingPlanEmail.Email);
               bool val4 = true;
               samplingPlanEmail.IsContractor = val4;
               Assert.Equal(val4, samplingPlanEmail.IsContractor);
               bool val5 = true;
               samplingPlanEmail.LabSheetHasValueOver500 = val5;
               Assert.Equal(val5, samplingPlanEmail.LabSheetHasValueOver500);
               bool val6 = true;
               samplingPlanEmail.LabSheetReceived = val6;
               Assert.Equal(val6, samplingPlanEmail.LabSheetReceived);
               bool val7 = true;
               samplingPlanEmail.LabSheetAccepted = val7;
               Assert.Equal(val7, samplingPlanEmail.LabSheetAccepted);
               bool val8 = true;
               samplingPlanEmail.LabSheetRejected = val8;
               Assert.Equal(val8, samplingPlanEmail.LabSheetRejected);
               DateTime val9 = new DateTime(2010, 3, 4);
               samplingPlanEmail.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, samplingPlanEmail.LastUpdateDate_UTC);
               int val10 = 45;
               samplingPlanEmail.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, samplingPlanEmail.LastUpdateContactTVItemID);
               bool val11 = true;
               samplingPlanEmail.HasErrors = val11;
               Assert.Equal(val11, samplingPlanEmail.HasErrors);
               IEnumerable<ValidationResult> val36 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               samplingPlanEmail.ValidationResults = val36;
               Assert.Equal(val36, samplingPlanEmail.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
