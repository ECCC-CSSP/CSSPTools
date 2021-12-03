/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net6.0\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class BoxModelTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private BoxModel boxModel { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelTest()
        {
            boxModel = new BoxModel();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void BoxModel_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "BoxModelID", "DBCommand", "InfrastructureTVItemID", "Discharge_m3_day", "Depth_m", "Temperature_C", "Dilution", "DecayRate_per_day", "FCUntreated_MPN_100ml", "FCPreDisinfection_MPN_100ml", "Concentration_MPN_100ml", "T90_hour", "DischargeDuration_hour", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(BoxModel).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(BoxModel).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void BoxModel_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(BoxModel).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(BoxModel).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void BoxModel_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               boxModel.BoxModelID = val1;
               Assert.Equal(val1, boxModel.BoxModelID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               boxModel.DBCommand = val2;
               Assert.Equal(val2, boxModel.DBCommand);
               int val3 = 45;
               boxModel.InfrastructureTVItemID = val3;
               Assert.Equal(val3, boxModel.InfrastructureTVItemID);
               double val4 = 87.9D;
               boxModel.Discharge_m3_day = val4;
               Assert.Equal(val4, boxModel.Discharge_m3_day);
               double val5 = 87.9D;
               boxModel.Depth_m = val5;
               Assert.Equal(val5, boxModel.Depth_m);
               double val6 = 87.9D;
               boxModel.Temperature_C = val6;
               Assert.Equal(val6, boxModel.Temperature_C);
               int val7 = 45;
               boxModel.Dilution = val7;
               Assert.Equal(val7, boxModel.Dilution);
               double val8 = 87.9D;
               boxModel.DecayRate_per_day = val8;
               Assert.Equal(val8, boxModel.DecayRate_per_day);
               int val9 = 45;
               boxModel.FCUntreated_MPN_100ml = val9;
               Assert.Equal(val9, boxModel.FCUntreated_MPN_100ml);
               int val10 = 45;
               boxModel.FCPreDisinfection_MPN_100ml = val10;
               Assert.Equal(val10, boxModel.FCPreDisinfection_MPN_100ml);
               int val11 = 45;
               boxModel.Concentration_MPN_100ml = val11;
               Assert.Equal(val11, boxModel.Concentration_MPN_100ml);
               double val12 = 87.9D;
               boxModel.T90_hour = val12;
               Assert.Equal(val12, boxModel.T90_hour);
               double val13 = 87.9D;
               boxModel.DischargeDuration_hour = val13;
               Assert.Equal(val13, boxModel.DischargeDuration_hour);
               DateTime val14 = new DateTime(2010, 3, 4);
               boxModel.LastUpdateDate_UTC = val14;
               Assert.Equal(val14, boxModel.LastUpdateDate_UTC);
               int val15 = 45;
               boxModel.LastUpdateContactTVItemID = val15;
               Assert.Equal(val15, boxModel.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
