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
    public partial class LocalMikeSourceStartEndTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalMikeSourceStartEnd localMikeSourceStartEnd { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMikeSourceStartEndTest()
        {
            localMikeSourceStartEnd = new LocalMikeSourceStartEnd();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalMikeSourceStartEnd_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "MikeSourceStartEndID", "MikeSourceID", "StartDateAndTime_Local", "EndDateAndTime_Local", "SourceFlowStart_m3_day", "SourceFlowEnd_m3_day", "SourcePollutionStart_MPN_100ml", "SourcePollutionEnd_MPN_100ml", "SourceTemperatureStart_C", "SourceTemperatureEnd_C", "SourceSalinityStart_PSU", "SourceSalinityEnd_PSU", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalMikeSourceStartEnd).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalMikeSourceStartEnd).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalMikeSourceStartEnd_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalMikeSourceStartEnd).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalMikeSourceStartEnd).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalMikeSourceStartEnd_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localMikeSourceStartEnd.LocalDBCommand = val1;
               Assert.Equal(val1, localMikeSourceStartEnd.LocalDBCommand);
               int val2 = 45;
               localMikeSourceStartEnd.MikeSourceStartEndID = val2;
               Assert.Equal(val2, localMikeSourceStartEnd.MikeSourceStartEndID);
               int val3 = 45;
               localMikeSourceStartEnd.MikeSourceID = val3;
               Assert.Equal(val3, localMikeSourceStartEnd.MikeSourceID);
               DateTime val4 = new DateTime(2010, 3, 4);
               localMikeSourceStartEnd.StartDateAndTime_Local = val4;
               Assert.Equal(val4, localMikeSourceStartEnd.StartDateAndTime_Local);
               DateTime val5 = new DateTime(2010, 3, 4);
               localMikeSourceStartEnd.EndDateAndTime_Local = val5;
               Assert.Equal(val5, localMikeSourceStartEnd.EndDateAndTime_Local);
               double val6 = 87.9D;
               localMikeSourceStartEnd.SourceFlowStart_m3_day = val6;
               Assert.Equal(val6, localMikeSourceStartEnd.SourceFlowStart_m3_day);
               double val7 = 87.9D;
               localMikeSourceStartEnd.SourceFlowEnd_m3_day = val7;
               Assert.Equal(val7, localMikeSourceStartEnd.SourceFlowEnd_m3_day);
               int val8 = 45;
               localMikeSourceStartEnd.SourcePollutionStart_MPN_100ml = val8;
               Assert.Equal(val8, localMikeSourceStartEnd.SourcePollutionStart_MPN_100ml);
               int val9 = 45;
               localMikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = val9;
               Assert.Equal(val9, localMikeSourceStartEnd.SourcePollutionEnd_MPN_100ml);
               double val10 = 87.9D;
               localMikeSourceStartEnd.SourceTemperatureStart_C = val10;
               Assert.Equal(val10, localMikeSourceStartEnd.SourceTemperatureStart_C);
               double val11 = 87.9D;
               localMikeSourceStartEnd.SourceTemperatureEnd_C = val11;
               Assert.Equal(val11, localMikeSourceStartEnd.SourceTemperatureEnd_C);
               double val12 = 87.9D;
               localMikeSourceStartEnd.SourceSalinityStart_PSU = val12;
               Assert.Equal(val12, localMikeSourceStartEnd.SourceSalinityStart_PSU);
               double val13 = 87.9D;
               localMikeSourceStartEnd.SourceSalinityEnd_PSU = val13;
               Assert.Equal(val13, localMikeSourceStartEnd.SourceSalinityEnd_PSU);
               DateTime val14 = new DateTime(2010, 3, 4);
               localMikeSourceStartEnd.LastUpdateDate_UTC = val14;
               Assert.Equal(val14, localMikeSourceStartEnd.LastUpdateDate_UTC);
               int val15 = 45;
               localMikeSourceStartEnd.LastUpdateContactTVItemID = val15;
               Assert.Equal(val15, localMikeSourceStartEnd.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}