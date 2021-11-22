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
    public partial class RainExceedanceTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RainExceedance rainExceedance { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceTest()
        {
            rainExceedance = new RainExceedance();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void RainExceedance_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "RainExceedanceID", "DBCommand", "RainExceedanceTVItemID", "StartMonth", "StartDay", "EndMonth", "EndDay", "RainMaximum_mm", "StakeholdersEmailDistributionListID", "OnlyStaffEmailDistributionListID", "IsActive", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(RainExceedance).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(RainExceedance).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void RainExceedance_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(RainExceedance).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(RainExceedance).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void RainExceedance_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               rainExceedance.RainExceedanceID = val1;
               Assert.Equal(val1, rainExceedance.RainExceedanceID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               rainExceedance.DBCommand = val2;
               Assert.Equal(val2, rainExceedance.DBCommand);
               int val3 = 45;
               rainExceedance.RainExceedanceTVItemID = val3;
               Assert.Equal(val3, rainExceedance.RainExceedanceTVItemID);
               int val4 = 45;
               rainExceedance.StartMonth = val4;
               Assert.Equal(val4, rainExceedance.StartMonth);
               int val5 = 45;
               rainExceedance.StartDay = val5;
               Assert.Equal(val5, rainExceedance.StartDay);
               int val6 = 45;
               rainExceedance.EndMonth = val6;
               Assert.Equal(val6, rainExceedance.EndMonth);
               int val7 = 45;
               rainExceedance.EndDay = val7;
               Assert.Equal(val7, rainExceedance.EndDay);
               double val8 = 87.9D;
               rainExceedance.RainMaximum_mm = val8;
               Assert.Equal(val8, rainExceedance.RainMaximum_mm);
               int val9 = 45;
               rainExceedance.StakeholdersEmailDistributionListID = val9;
               Assert.Equal(val9, rainExceedance.StakeholdersEmailDistributionListID);
               int val10 = 45;
               rainExceedance.OnlyStaffEmailDistributionListID = val10;
               Assert.Equal(val10, rainExceedance.OnlyStaffEmailDistributionListID);
               bool val11 = true;
               rainExceedance.IsActive = val11;
               Assert.Equal(val11, rainExceedance.IsActive);
               DateTime val12 = new DateTime(2010, 3, 4);
               rainExceedance.LastUpdateDate_UTC = val12;
               Assert.Equal(val12, rainExceedance.LastUpdateDate_UTC);
               int val13 = 45;
               rainExceedance.LastUpdateContactTVItemID = val13;
               Assert.Equal(val13, rainExceedance.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}