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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class SamplingPlanSubsectorSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SamplingPlanSubsectorSite samplingPlanSubsectorSite { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteTest()
        {
            samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SamplingPlanSubsectorSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "SamplingPlanSubsectorSiteID", "SamplingPlanSubsectorID", "MWQMSiteTVItemID", "IsDuplicate", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanSubsectorSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanSubsectorSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                    }
                }
            }


        }
        [Fact]
        public void SamplingPlanSubsectorSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanSubsectorSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanSubsectorSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SamplingPlanSubsectorSite_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = val1;
               Assert.Equal(val1, samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
               int val2 = 45;
               samplingPlanSubsectorSite.SamplingPlanSubsectorID = val2;
               Assert.Equal(val2, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
               int val3 = 45;
               samplingPlanSubsectorSite.MWQMSiteTVItemID = val3;
               Assert.Equal(val3, samplingPlanSubsectorSite.MWQMSiteTVItemID);
               bool val4 = true;
               samplingPlanSubsectorSite.IsDuplicate = val4;
               Assert.Equal(val4, samplingPlanSubsectorSite.IsDuplicate);
               DateTime val5 = new DateTime(2010, 3, 4);
               samplingPlanSubsectorSite.LastUpdateDate_UTC = val5;
               Assert.Equal(val5, samplingPlanSubsectorSite.LastUpdateDate_UTC);
               int val6 = 45;
               samplingPlanSubsectorSite.LastUpdateContactTVItemID = val6;
               Assert.Equal(val6, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
