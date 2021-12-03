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
    public partial class MikeSourceStartEndTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MikeSourceStartEnd mikeSourceStartEnd { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndTest()
        {
            mikeSourceStartEnd = new MikeSourceStartEnd();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MikeSourceStartEnd_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MikeSourceStartEndID", "DBCommand", "MikeSourceID", "StartDateAndTime_Local", "EndDateAndTime_Local", "SourceFlowStart_m3_day", "SourceFlowEnd_m3_day", "SourcePollutionStart_MPN_100ml", "SourcePollutionEnd_MPN_100ml", "SourceTemperatureStart_C", "SourceTemperatureEnd_C", "SourceSalinityStart_PSU", "SourceSalinityEnd_PSU", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MikeSourceStartEnd).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MikeSourceStartEnd).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MikeSourceStartEnd_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MikeSourceStartEnd).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MikeSourceStartEnd).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MikeSourceStartEnd_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mikeSourceStartEnd.MikeSourceStartEndID = val1;
               Assert.Equal(val1, mikeSourceStartEnd.MikeSourceStartEndID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               mikeSourceStartEnd.DBCommand = val2;
               Assert.Equal(val2, mikeSourceStartEnd.DBCommand);
               int val3 = 45;
               mikeSourceStartEnd.MikeSourceID = val3;
               Assert.Equal(val3, mikeSourceStartEnd.MikeSourceID);
               DateTime val4 = new DateTime(2010, 3, 4);
               mikeSourceStartEnd.StartDateAndTime_Local = val4;
               Assert.Equal(val4, mikeSourceStartEnd.StartDateAndTime_Local);
               DateTime val5 = new DateTime(2010, 3, 4);
               mikeSourceStartEnd.EndDateAndTime_Local = val5;
               Assert.Equal(val5, mikeSourceStartEnd.EndDateAndTime_Local);
               double val6 = 87.9D;
               mikeSourceStartEnd.SourceFlowStart_m3_day = val6;
               Assert.Equal(val6, mikeSourceStartEnd.SourceFlowStart_m3_day);
               double val7 = 87.9D;
               mikeSourceStartEnd.SourceFlowEnd_m3_day = val7;
               Assert.Equal(val7, mikeSourceStartEnd.SourceFlowEnd_m3_day);
               int val8 = 45;
               mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = val8;
               Assert.Equal(val8, mikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
               int val9 = 45;
               mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = val9;
               Assert.Equal(val9, mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
               double val10 = 87.9D;
               mikeSourceStartEnd.SourceTemperatureStart_C = val10;
               Assert.Equal(val10, mikeSourceStartEnd.SourceTemperatureStart_C);
               double val11 = 87.9D;
               mikeSourceStartEnd.SourceTemperatureEnd_C = val11;
               Assert.Equal(val11, mikeSourceStartEnd.SourceTemperatureEnd_C);
               double val12 = 87.9D;
               mikeSourceStartEnd.SourceSalinityStart_PSU = val12;
               Assert.Equal(val12, mikeSourceStartEnd.SourceSalinityStart_PSU);
               double val13 = 87.9D;
               mikeSourceStartEnd.SourceSalinityEnd_PSU = val13;
               Assert.Equal(val13, mikeSourceStartEnd.SourceSalinityEnd_PSU);
               DateTime val14 = new DateTime(2010, 3, 4);
               mikeSourceStartEnd.LastUpdateDate_UTC = val14;
               Assert.Equal(val14, mikeSourceStartEnd.LastUpdateDate_UTC);
               int val15 = 45;
               mikeSourceStartEnd.LastUpdateContactTVItemID = val15;
               Assert.Equal(val15, mikeSourceStartEnd.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
