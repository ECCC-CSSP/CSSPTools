/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
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
            List<string> propNameList = new List<string>() { "ClimateSiteID", "DBCommand", "ClimateSiteTVItemID", "ECDBID", "ClimateSiteName", "Province", "Elevation_m", "ClimateID", "WMOID", "TCID", "IsQuebecSite", "IsCoCoRaHS", "TimeOffset_hour", "File_desc", "HourlyStartDate_Local", "HourlyEndDate_Local", "HourlyNow", "DailyStartDate_Local", "DailyEndDate_Local", "DailyNow", "MonthlyStartDate_Local", "MonthlyEndDate_Local", "MonthlyNow", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

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
               DBCommandEnum val2 = (DBCommandEnum)3;
               climateSite.DBCommand = val2;
               Assert.Equal(val2, climateSite.DBCommand);
               int val3 = 45;
               climateSite.ClimateSiteTVItemID = val3;
               Assert.Equal(val3, climateSite.ClimateSiteTVItemID);
               int val4 = 45;
               climateSite.ECDBID = val4;
               Assert.Equal(val4, climateSite.ECDBID);
               string val5 = "Some text";
               climateSite.ClimateSiteName = val5;
               Assert.Equal(val5, climateSite.ClimateSiteName);
               string val6 = "Some text";
               climateSite.Province = val6;
               Assert.Equal(val6, climateSite.Province);
               double val7 = 87.9D;
               climateSite.Elevation_m = val7;
               Assert.Equal(val7, climateSite.Elevation_m);
               string val8 = "Some text";
               climateSite.ClimateID = val8;
               Assert.Equal(val8, climateSite.ClimateID);
               int val9 = 45;
               climateSite.WMOID = val9;
               Assert.Equal(val9, climateSite.WMOID);
               string val10 = "Some text";
               climateSite.TCID = val10;
               Assert.Equal(val10, climateSite.TCID);
               bool val11 = true;
               climateSite.IsQuebecSite = val11;
               Assert.Equal(val11, climateSite.IsQuebecSite);
               bool val12 = true;
               climateSite.IsCoCoRaHS = val12;
               Assert.Equal(val12, climateSite.IsCoCoRaHS);
               double val13 = 87.9D;
               climateSite.TimeOffset_hour = val13;
               Assert.Equal(val13, climateSite.TimeOffset_hour);
               string val14 = "Some text";
               climateSite.File_desc = val14;
               Assert.Equal(val14, climateSite.File_desc);
               DateTime val15 = new DateTime(2010, 3, 4);
               climateSite.HourlyStartDate_Local = val15;
               Assert.Equal(val15, climateSite.HourlyStartDate_Local);
               DateTime val16 = new DateTime(2010, 3, 4);
               climateSite.HourlyEndDate_Local = val16;
               Assert.Equal(val16, climateSite.HourlyEndDate_Local);
               bool val17 = true;
               climateSite.HourlyNow = val17;
               Assert.Equal(val17, climateSite.HourlyNow);
               DateTime val18 = new DateTime(2010, 3, 4);
               climateSite.DailyStartDate_Local = val18;
               Assert.Equal(val18, climateSite.DailyStartDate_Local);
               DateTime val19 = new DateTime(2010, 3, 4);
               climateSite.DailyEndDate_Local = val19;
               Assert.Equal(val19, climateSite.DailyEndDate_Local);
               bool val20 = true;
               climateSite.DailyNow = val20;
               Assert.Equal(val20, climateSite.DailyNow);
               DateTime val21 = new DateTime(2010, 3, 4);
               climateSite.MonthlyStartDate_Local = val21;
               Assert.Equal(val21, climateSite.MonthlyStartDate_Local);
               DateTime val22 = new DateTime(2010, 3, 4);
               climateSite.MonthlyEndDate_Local = val22;
               Assert.Equal(val22, climateSite.MonthlyEndDate_Local);
               bool val23 = true;
               climateSite.MonthlyNow = val23;
               Assert.Equal(val23, climateSite.MonthlyNow);
               DateTime val24 = new DateTime(2010, 3, 4);
               climateSite.LastUpdateDate_UTC = val24;
               Assert.Equal(val24, climateSite.LastUpdateDate_UTC);
               int val25 = 45;
               climateSite.LastUpdateContactTVItemID = val25;
               Assert.Equal(val25, climateSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
