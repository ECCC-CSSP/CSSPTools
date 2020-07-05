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
    public partial class TideSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TideSite tideSite { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteTest()
        {
            tideSite = new TideSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TideSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TideSiteID", "TideSiteTVItemID", "TideSiteName", "Province", "sid", "Zone", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TideSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(TideSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TideSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TideSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(TideSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TideSite_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               tideSite.TideSiteID = val1;
               Assert.Equal(val1, tideSite.TideSiteID);
               int val2 = 45;
               tideSite.TideSiteTVItemID = val2;
               Assert.Equal(val2, tideSite.TideSiteTVItemID);
               string val3 = "Some text";
               tideSite.TideSiteName = val3;
               Assert.Equal(val3, tideSite.TideSiteName);
               string val4 = "Some text";
               tideSite.Province = val4;
               Assert.Equal(val4, tideSite.Province);
               int val5 = 45;
               tideSite.sid = val5;
               Assert.Equal(val5, tideSite.sid);
               int val6 = 45;
               tideSite.Zone = val6;
               Assert.Equal(val6, tideSite.Zone);
               DateTime val7 = new DateTime(2010, 3, 4);
               tideSite.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, tideSite.LastUpdateDate_UTC);
               int val8 = 45;
               tideSite.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, tideSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
