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
    public partial class ClimateSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ClimateSite climateSite { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteTest()
        {
            climateSite = new ClimateSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ClimateSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ClimateSiteID", "ClimateSiteTVItemID", "ECDBID", "ClimateSiteName", "Province", "Elevation_m", "ClimateID", "WMOID", "TCID", "IsQuebecSite", "IsCoCoRaHS", "TimeOffset_hour", "File_desc", "HourlyStartDate_Local", "HourlyEndDate_Local", "HourlyNow", "DailyStartDate_Local", "DailyEndDate_Local", "DailyNow", "MonthlyStartDate_Local", "MonthlyEndDate_Local", "MonthlyNow", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ClimateSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(ClimateSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void ClimateSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ClimateSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(ClimateSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void ClimateSite_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               climateSite.ClimateSiteID = val1;
               Assert.Equal(val1, climateSite.ClimateSiteID);
               int val2 = 45;
               climateSite.ClimateSiteTVItemID = val2;
               Assert.Equal(val2, climateSite.ClimateSiteTVItemID);
               int val3 = 45;
               climateSite.ECDBID = val3;
               Assert.Equal(val3, climateSite.ECDBID);
               string val4 = "Some text";
               climateSite.ClimateSiteName = val4;
               Assert.Equal(val4, climateSite.ClimateSiteName);
               string val5 = "Some text";
               climateSite.Province = val5;
               Assert.Equal(val5, climateSite.Province);
               double val6 = 87.9D;
               climateSite.Elevation_m = val6;
               Assert.Equal(val6, climateSite.Elevation_m);
               string val7 = "Some text";
               climateSite.ClimateID = val7;
               Assert.Equal(val7, climateSite.ClimateID);
               int val8 = 45;
               climateSite.WMOID = val8;
               Assert.Equal(val8, climateSite.WMOID);
               string val9 = "Some text";
               climateSite.TCID = val9;
               Assert.Equal(val9, climateSite.TCID);
               bool val10 = true;
               climateSite.IsQuebecSite = val10;
               Assert.Equal(val10, climateSite.IsQuebecSite);
               bool val11 = true;
               climateSite.IsCoCoRaHS = val11;
               Assert.Equal(val11, climateSite.IsCoCoRaHS);
               double val12 = 87.9D;
               climateSite.TimeOffset_hour = val12;
               Assert.Equal(val12, climateSite.TimeOffset_hour);
               string val13 = "Some text";
               climateSite.File_desc = val13;
               Assert.Equal(val13, climateSite.File_desc);
               DateTime val14 = new DateTime(2010, 3, 4);
               climateSite.HourlyStartDate_Local = val14;
               Assert.Equal(val14, climateSite.HourlyStartDate_Local);
               DateTime val15 = new DateTime(2010, 3, 4);
               climateSite.HourlyEndDate_Local = val15;
               Assert.Equal(val15, climateSite.HourlyEndDate_Local);
               bool val16 = true;
               climateSite.HourlyNow = val16;
               Assert.Equal(val16, climateSite.HourlyNow);
               DateTime val17 = new DateTime(2010, 3, 4);
               climateSite.DailyStartDate_Local = val17;
               Assert.Equal(val17, climateSite.DailyStartDate_Local);
               DateTime val18 = new DateTime(2010, 3, 4);
               climateSite.DailyEndDate_Local = val18;
               Assert.Equal(val18, climateSite.DailyEndDate_Local);
               bool val19 = true;
               climateSite.DailyNow = val19;
               Assert.Equal(val19, climateSite.DailyNow);
               DateTime val20 = new DateTime(2010, 3, 4);
               climateSite.MonthlyStartDate_Local = val20;
               Assert.Equal(val20, climateSite.MonthlyStartDate_Local);
               DateTime val21 = new DateTime(2010, 3, 4);
               climateSite.MonthlyEndDate_Local = val21;
               Assert.Equal(val21, climateSite.MonthlyEndDate_Local);
               bool val22 = true;
               climateSite.MonthlyNow = val22;
               Assert.Equal(val22, climateSite.MonthlyNow);
               DateTime val23 = new DateTime(2010, 3, 4);
               climateSite.LastUpdateDate_UTC = val23;
               Assert.Equal(val23, climateSite.LastUpdateDate_UTC);
               int val24 = 45;
               climateSite.LastUpdateContactTVItemID = val24;
               Assert.Equal(val24, climateSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
