/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBModels_TestsGenerated.exe
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

namespace CSSPDBModels.Tests
{
    public partial class PolSourceSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceSite polSourceSite { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteTest()
        {
            polSourceSite = new PolSourceSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceSiteID", "PolSourceSiteTVItemID", "Temp_Locator_CanDelete", "Oldsiteid", "Site", "SiteID", "IsPointSource", "InactiveReason", "CivicAddressTVItemID", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceSite_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceSite.PolSourceSiteID = val1;
               Assert.Equal(val1, polSourceSite.PolSourceSiteID);
               int val2 = 45;
               polSourceSite.PolSourceSiteTVItemID = val2;
               Assert.Equal(val2, polSourceSite.PolSourceSiteTVItemID);
               string val3 = "Some text";
               polSourceSite.Temp_Locator_CanDelete = val3;
               Assert.Equal(val3, polSourceSite.Temp_Locator_CanDelete);
               int val4 = 45;
               polSourceSite.Oldsiteid = val4;
               Assert.Equal(val4, polSourceSite.Oldsiteid);
               int val5 = 45;
               polSourceSite.Site = val5;
               Assert.Equal(val5, polSourceSite.Site);
               int val6 = 45;
               polSourceSite.SiteID = val6;
               Assert.Equal(val6, polSourceSite.SiteID);
               bool val7 = true;
               polSourceSite.IsPointSource = val7;
               Assert.Equal(val7, polSourceSite.IsPointSource);
               PolSourceInactiveReasonEnum val8 = (PolSourceInactiveReasonEnum)3;
               polSourceSite.InactiveReason = val8;
               Assert.Equal(val8, polSourceSite.InactiveReason);
               int val9 = 45;
               polSourceSite.CivicAddressTVItemID = val9;
               Assert.Equal(val9, polSourceSite.CivicAddressTVItemID);
               DateTime val10 = new DateTime(2010, 3, 4);
               polSourceSite.LastUpdateDate_UTC = val10;
               Assert.Equal(val10, polSourceSite.LastUpdateDate_UTC);
               int val11 = 45;
               polSourceSite.LastUpdateContactTVItemID = val11;
               Assert.Equal(val11, polSourceSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}