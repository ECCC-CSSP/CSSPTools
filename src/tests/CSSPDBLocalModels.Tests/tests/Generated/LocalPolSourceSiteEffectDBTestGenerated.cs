/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalModels_TestsGenerated.exe
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

namespace CSSPDBLocalModels.Tests
{
    public partial class LocalPolSourceSiteEffectTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalPolSourceSiteEffect localPolSourceSiteEffect { get; set; }
        #endregion Properties

        #region Constructors
        public LocalPolSourceSiteEffectTest()
        {
            localPolSourceSiteEffect = new LocalPolSourceSiteEffect();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalPolSourceSiteEffect_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "PolSourceSiteEffectID", "PolSourceSiteOrInfrastructureTVItemID", "MWQMSiteTVItemID", "PolSourceSiteEffectTermIDs", "Comments", "AnalysisDocumentTVItemID", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalPolSourceSiteEffect).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalPolSourceSiteEffect).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalPolSourceSiteEffect_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalPolSourceSiteEffect).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalPolSourceSiteEffect).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalPolSourceSiteEffect_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localPolSourceSiteEffect.LocalDBCommand = val1;
               Assert.Equal(val1, localPolSourceSiteEffect.LocalDBCommand);
               int val2 = 45;
               localPolSourceSiteEffect.PolSourceSiteEffectID = val2;
               Assert.Equal(val2, localPolSourceSiteEffect.PolSourceSiteEffectID);
               int val3 = 45;
               localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = val3;
               Assert.Equal(val3, localPolSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID);
               int val4 = 45;
               localPolSourceSiteEffect.MWQMSiteTVItemID = val4;
               Assert.Equal(val4, localPolSourceSiteEffect.MWQMSiteTVItemID);
               string val5 = "Some text";
               localPolSourceSiteEffect.PolSourceSiteEffectTermIDs = val5;
               Assert.Equal(val5, localPolSourceSiteEffect.PolSourceSiteEffectTermIDs);
               string val6 = "Some text";
               localPolSourceSiteEffect.Comments = val6;
               Assert.Equal(val6, localPolSourceSiteEffect.Comments);
               int val7 = 45;
               localPolSourceSiteEffect.AnalysisDocumentTVItemID = val7;
               Assert.Equal(val7, localPolSourceSiteEffect.AnalysisDocumentTVItemID);
               DateTime val8 = new DateTime(2010, 3, 4);
               localPolSourceSiteEffect.LastUpdateDate_UTC = val8;
               Assert.Equal(val8, localPolSourceSiteEffect.LastUpdateDate_UTC);
               int val9 = 45;
               localPolSourceSiteEffect.LastUpdateContactTVItemID = val9;
               Assert.Equal(val9, localPolSourceSiteEffect.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}