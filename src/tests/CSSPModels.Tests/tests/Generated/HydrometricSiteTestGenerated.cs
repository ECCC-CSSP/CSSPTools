/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
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
    public partial class HydrometricSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private HydrometricSite hydrometricSite { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteTest()
        {
            hydrometricSite = new HydrometricSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void HydrometricSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "HydrometricSiteID", "HydrometricSiteTVItemID", "FedSiteNumber", "QuebecSiteNumber", "HydrometricSiteName", "Description", "Province", "Elevation_m", "StartDate_Local", "EndDate_Local", "TimeOffset_hour", "DrainageArea_km2", "IsNatural", "IsActive", "Sediment", "RHBN", "RealTime", "HasDischarge", "HasLevel", "HasRatingCurve", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(HydrometricSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(HydrometricSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void HydrometricSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(HydrometricSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(HydrometricSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void HydrometricSite_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               hydrometricSite.HydrometricSiteID = val1;
               Assert.Equal(val1, hydrometricSite.HydrometricSiteID);
               int val2 = 45;
               hydrometricSite.HydrometricSiteTVItemID = val2;
               Assert.Equal(val2, hydrometricSite.HydrometricSiteTVItemID);
               string val3 = "Some text";
               hydrometricSite.FedSiteNumber = val3;
               Assert.Equal(val3, hydrometricSite.FedSiteNumber);
               string val4 = "Some text";
               hydrometricSite.QuebecSiteNumber = val4;
               Assert.Equal(val4, hydrometricSite.QuebecSiteNumber);
               string val5 = "Some text";
               hydrometricSite.HydrometricSiteName = val5;
               Assert.Equal(val5, hydrometricSite.HydrometricSiteName);
               string val6 = "Some text";
               hydrometricSite.Description = val6;
               Assert.Equal(val6, hydrometricSite.Description);
               string val7 = "Some text";
               hydrometricSite.Province = val7;
               Assert.Equal(val7, hydrometricSite.Province);
               double val8 = 87.9D;
               hydrometricSite.Elevation_m = val8;
               Assert.Equal(val8, hydrometricSite.Elevation_m);
               DateTime val9 = new DateTime(2010, 3, 4);
               hydrometricSite.StartDate_Local = val9;
               Assert.Equal(val9, hydrometricSite.StartDate_Local);
               DateTime val10 = new DateTime(2010, 3, 4);
               hydrometricSite.EndDate_Local = val10;
               Assert.Equal(val10, hydrometricSite.EndDate_Local);
               double val11 = 87.9D;
               hydrometricSite.TimeOffset_hour = val11;
               Assert.Equal(val11, hydrometricSite.TimeOffset_hour);
               double val12 = 87.9D;
               hydrometricSite.DrainageArea_km2 = val12;
               Assert.Equal(val12, hydrometricSite.DrainageArea_km2);
               bool val13 = true;
               hydrometricSite.IsNatural = val13;
               Assert.Equal(val13, hydrometricSite.IsNatural);
               bool val14 = true;
               hydrometricSite.IsActive = val14;
               Assert.Equal(val14, hydrometricSite.IsActive);
               bool val15 = true;
               hydrometricSite.Sediment = val15;
               Assert.Equal(val15, hydrometricSite.Sediment);
               bool val16 = true;
               hydrometricSite.RHBN = val16;
               Assert.Equal(val16, hydrometricSite.RHBN);
               bool val17 = true;
               hydrometricSite.RealTime = val17;
               Assert.Equal(val17, hydrometricSite.RealTime);
               bool val18 = true;
               hydrometricSite.HasDischarge = val18;
               Assert.Equal(val18, hydrometricSite.HasDischarge);
               bool val19 = true;
               hydrometricSite.HasLevel = val19;
               Assert.Equal(val19, hydrometricSite.HasLevel);
               bool val20 = true;
               hydrometricSite.HasRatingCurve = val20;
               Assert.Equal(val20, hydrometricSite.HasRatingCurve);
               DateTime val21 = new DateTime(2010, 3, 4);
               hydrometricSite.LastUpdateDate_UTC = val21;
               Assert.Equal(val21, hydrometricSite.LastUpdateDate_UTC);
               int val22 = 45;
               hydrometricSite.LastUpdateContactTVItemID = val22;
               Assert.Equal(val22, hydrometricSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
