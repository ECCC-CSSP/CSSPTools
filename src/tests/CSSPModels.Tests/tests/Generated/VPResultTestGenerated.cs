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
    public partial class VPResultTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPResult vPResult { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultTest()
        {
            vPResult = new VPResult();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void VPResult_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "VPResultID", "VPScenarioID", "Ordinal", "Concentration_MPN_100ml", "Dilution", "FarFieldWidth_m", "DispersionDistance_m", "TravelTime_hour", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPResult).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(VPResult).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void VPResult_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPResult).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(VPResult).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void VPResult_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               vPResult.VPResultID = val1;
               Assert.Equal(val1, vPResult.VPResultID);
               int val2 = 45;
               vPResult.VPScenarioID = val2;
               Assert.Equal(val2, vPResult.VPScenarioID);
               int val3 = 45;
               vPResult.Ordinal = val3;
               Assert.Equal(val3, vPResult.Ordinal);
               int val4 = 45;
               vPResult.Concentration_MPN_100ml = val4;
               Assert.Equal(val4, vPResult.Concentration_MPN_100ml);
               double val5 = 87.9D;
               vPResult.Dilution = val5;
               Assert.Equal(val5, vPResult.Dilution);
               double val6 = 87.9D;
               vPResult.FarFieldWidth_m = val6;
               Assert.Equal(val6, vPResult.FarFieldWidth_m);
               double val7 = 87.9D;
               vPResult.DispersionDistance_m = val7;
               Assert.Equal(val7, vPResult.DispersionDistance_m);
               double val8 = 87.9D;
               vPResult.TravelTime_hour = val8;
               Assert.Equal(val8, vPResult.TravelTime_hour);
               DateTime val9 = new DateTime(2010, 3, 4);
               vPResult.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, vPResult.LastUpdateDate_UTC);
               int val10 = 45;
               vPResult.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, vPResult.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
