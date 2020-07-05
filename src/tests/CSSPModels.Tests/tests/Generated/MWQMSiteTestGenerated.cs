/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class MWQMSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSite mWQMSite { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteTest()
        {
            mWQMSite = new MWQMSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMSiteID", "MWQMSiteTVItemID", "MWQMSiteNumber", "MWQMSiteDescription", "MWQMSiteLatestClassification", "Ordinal", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSite_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMSite.MWQMSiteID = val1;
               Assert.Equal(val1, mWQMSite.MWQMSiteID);
               int val2 = 45;
               mWQMSite.MWQMSiteTVItemID = val2;
               Assert.Equal(val2, mWQMSite.MWQMSiteTVItemID);
               string val3 = "Some text";
               mWQMSite.MWQMSiteNumber = val3;
               Assert.Equal(val3, mWQMSite.MWQMSiteNumber);
               string val4 = "Some text";
               mWQMSite.MWQMSiteDescription = val4;
               Assert.Equal(val4, mWQMSite.MWQMSiteDescription);
               MWQMSiteLatestClassificationEnum val5 = (MWQMSiteLatestClassificationEnum)3;
               mWQMSite.MWQMSiteLatestClassification = val5;
               Assert.Equal(val5, mWQMSite.MWQMSiteLatestClassification);
               int val6 = 45;
               mWQMSite.Ordinal = val6;
               Assert.Equal(val6, mWQMSite.Ordinal);
               DateTime val7 = new DateTime(2010, 3, 4);
               mWQMSite.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, mWQMSite.LastUpdateDate_UTC);
               int val8 = 45;
               mWQMSite.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, mWQMSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
