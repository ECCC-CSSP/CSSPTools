/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
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
    public partial class ClimateDataValueTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ClimateDataValue climateDataValue { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueTest()
        {
            climateDataValue = new ClimateDataValue();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ClimateDataValue_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ClimateDataValueID", "ClimateSiteID", "DateTime_Local", "Keep", "StorageDataType", "HasBeenRead", "Snow_cm", "Rainfall_mm", "RainfallEntered_mm", "TotalPrecip_mm_cm", "MaxTemp_C", "MinTemp_C", "HeatDegDays_C", "CoolDegDays_C", "SnowOnGround_cm", "DirMaxGust_0North", "SpdMaxGust_kmh", "HourlyValues", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ClimateDataValue).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(ClimateDataValue).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void ClimateDataValue_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ClimateDataValue).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(ClimateDataValue).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void ClimateDataValue_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               climateDataValue.ClimateDataValueID = val1;
               Assert.Equal(val1, climateDataValue.ClimateDataValueID);
               int val2 = 45;
               climateDataValue.ClimateSiteID = val2;
               Assert.Equal(val2, climateDataValue.ClimateSiteID);
               DateTime val3 = new DateTime(2010, 3, 4);
               climateDataValue.DateTime_Local = val3;
               Assert.Equal(val3, climateDataValue.DateTime_Local);
               bool val4 = true;
               climateDataValue.Keep = val4;
               Assert.Equal(val4, climateDataValue.Keep);
               StorageDataTypeEnum val5 = (StorageDataTypeEnum)3;
               climateDataValue.StorageDataType = val5;
               Assert.Equal(val5, climateDataValue.StorageDataType);
               bool val6 = true;
               climateDataValue.HasBeenRead = val6;
               Assert.Equal(val6, climateDataValue.HasBeenRead);
               double val7 = 87.9D;
               climateDataValue.Snow_cm = val7;
               Assert.Equal(val7, climateDataValue.Snow_cm);
               double val8 = 87.9D;
               climateDataValue.Rainfall_mm = val8;
               Assert.Equal(val8, climateDataValue.Rainfall_mm);
               double val9 = 87.9D;
               climateDataValue.RainfallEntered_mm = val9;
               Assert.Equal(val9, climateDataValue.RainfallEntered_mm);
               double val10 = 87.9D;
               climateDataValue.TotalPrecip_mm_cm = val10;
               Assert.Equal(val10, climateDataValue.TotalPrecip_mm_cm);
               double val11 = 87.9D;
               climateDataValue.MaxTemp_C = val11;
               Assert.Equal(val11, climateDataValue.MaxTemp_C);
               double val12 = 87.9D;
               climateDataValue.MinTemp_C = val12;
               Assert.Equal(val12, climateDataValue.MinTemp_C);
               double val13 = 87.9D;
               climateDataValue.HeatDegDays_C = val13;
               Assert.Equal(val13, climateDataValue.HeatDegDays_C);
               double val14 = 87.9D;
               climateDataValue.CoolDegDays_C = val14;
               Assert.Equal(val14, climateDataValue.CoolDegDays_C);
               double val15 = 87.9D;
               climateDataValue.SnowOnGround_cm = val15;
               Assert.Equal(val15, climateDataValue.SnowOnGround_cm);
               double val16 = 87.9D;
               climateDataValue.DirMaxGust_0North = val16;
               Assert.Equal(val16, climateDataValue.DirMaxGust_0North);
               double val17 = 87.9D;
               climateDataValue.SpdMaxGust_kmh = val17;
               Assert.Equal(val17, climateDataValue.SpdMaxGust_kmh);
               string val18 = "Some text";
               climateDataValue.HourlyValues = val18;
               Assert.Equal(val18, climateDataValue.HourlyValues);
               DateTime val19 = new DateTime(2010, 3, 4);
               climateDataValue.LastUpdateDate_UTC = val19;
               Assert.Equal(val19, climateDataValue.LastUpdateDate_UTC);
               int val20 = 45;
               climateDataValue.LastUpdateContactTVItemID = val20;
               Assert.Equal(val20, climateDataValue.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
