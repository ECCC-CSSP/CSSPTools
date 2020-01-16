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
    public partial class PolSourceSiteEffectTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceSiteEffect polSourceSiteEffect { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTest()
        {
            polSourceSiteEffect = new PolSourceSiteEffect();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceSiteEffect_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceSiteEffectID", "PolSourceSiteOrInfrastructureTVItemID", "MWQMSiteTVItemID", "PolSourceSiteEffectTermIDs", "Comments", "AnalysisDocumentTVItemID", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffect).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffect).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceSiteEffect_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffect).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffect).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceSiteEffect_Has_ValidationResults_Test()
        {
             Assert.True(typeof(PolSourceSiteEffect).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void PolSourceSiteEffect_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceSiteEffect.PolSourceSiteEffectID = val1;
               Assert.Equal(val1, polSourceSiteEffect.PolSourceSiteEffectID);
               int val2 = 45;
               polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = val2;
               Assert.Equal(val2, polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID);
               int val3 = 45;
               polSourceSiteEffect.MWQMSiteTVItemID = val3;
               Assert.Equal(val3, polSourceSiteEffect.MWQMSiteTVItemID);
               string val4 = "Some text";
               polSourceSiteEffect.PolSourceSiteEffectTermIDs = val4;
               Assert.Equal(val4, polSourceSiteEffect.PolSourceSiteEffectTermIDs);
               string val5 = "Some text";
               polSourceSiteEffect.Comments = val5;
               Assert.Equal(val5, polSourceSiteEffect.Comments);
               int val6 = 45;
               polSourceSiteEffect.AnalysisDocumentTVItemID = val6;
               Assert.Equal(val6, polSourceSiteEffect.AnalysisDocumentTVItemID);
               DateTime val7 = new DateTime(2010, 3, 4);
               polSourceSiteEffect.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, polSourceSiteEffect.LastUpdateDate_UTC);
               int val8 = 45;
               polSourceSiteEffect.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, polSourceSiteEffect.LastUpdateContactTVItemID);
               bool val9 = true;
               polSourceSiteEffect.HasErrors = val9;
               Assert.Equal(val9, polSourceSiteEffect.HasErrors);
               IEnumerable<ValidationResult> val30 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               polSourceSiteEffect.ValidationResults = val30;
               Assert.Equal(val30, polSourceSiteEffect.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
