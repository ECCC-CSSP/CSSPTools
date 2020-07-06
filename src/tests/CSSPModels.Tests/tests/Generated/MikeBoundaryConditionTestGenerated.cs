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
    public partial class MikeBoundaryConditionTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MikeBoundaryCondition mikeBoundaryCondition { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionTest()
        {
            mikeBoundaryCondition = new MikeBoundaryCondition();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MikeBoundaryCondition_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MikeBoundaryConditionID", "MikeBoundaryConditionTVItemID", "MikeBoundaryConditionCode", "MikeBoundaryConditionName", "MikeBoundaryConditionLength_m", "MikeBoundaryConditionFormat", "MikeBoundaryConditionLevelOrVelocity", "WebTideDataSet", "NumberOfWebTideNodes", "WebTideDataFromStartToEndDate", "TVType", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MikeBoundaryCondition).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MikeBoundaryCondition).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MikeBoundaryCondition_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MikeBoundaryCondition).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MikeBoundaryCondition).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MikeBoundaryCondition_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mikeBoundaryCondition.MikeBoundaryConditionID = val1;
               Assert.Equal(val1, mikeBoundaryCondition.MikeBoundaryConditionID);
               int val2 = 45;
               mikeBoundaryCondition.MikeBoundaryConditionTVItemID = val2;
               Assert.Equal(val2, mikeBoundaryCondition.MikeBoundaryConditionTVItemID);
               string val3 = "Some text";
               mikeBoundaryCondition.MikeBoundaryConditionCode = val3;
               Assert.Equal(val3, mikeBoundaryCondition.MikeBoundaryConditionCode);
               string val4 = "Some text";
               mikeBoundaryCondition.MikeBoundaryConditionName = val4;
               Assert.Equal(val4, mikeBoundaryCondition.MikeBoundaryConditionName);
               double val5 = 87.9D;
               mikeBoundaryCondition.MikeBoundaryConditionLength_m = val5;
               Assert.Equal(val5, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
               string val6 = "Some text";
               mikeBoundaryCondition.MikeBoundaryConditionFormat = val6;
               Assert.Equal(val6, mikeBoundaryCondition.MikeBoundaryConditionFormat);
               MikeBoundaryConditionLevelOrVelocityEnum val7 = (MikeBoundaryConditionLevelOrVelocityEnum)3;
               mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = val7;
               Assert.Equal(val7, mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
               WebTideDataSetEnum val8 = (WebTideDataSetEnum)3;
               mikeBoundaryCondition.WebTideDataSet = val8;
               Assert.Equal(val8, mikeBoundaryCondition.WebTideDataSet);
               int val9 = 45;
               mikeBoundaryCondition.NumberOfWebTideNodes = val9;
               Assert.Equal(val9, mikeBoundaryCondition.NumberOfWebTideNodes);
               string val10 = "Some text";
               mikeBoundaryCondition.WebTideDataFromStartToEndDate = val10;
               Assert.Equal(val10, mikeBoundaryCondition.WebTideDataFromStartToEndDate);
               TVTypeEnum val11 = (TVTypeEnum)3;
               mikeBoundaryCondition.TVType = val11;
               Assert.Equal(val11, mikeBoundaryCondition.TVType);
               DateTime val12 = new DateTime(2010, 3, 4);
               mikeBoundaryCondition.LastUpdateDate_UTC = val12;
               Assert.Equal(val12, mikeBoundaryCondition.LastUpdateDate_UTC);
               int val13 = 45;
               mikeBoundaryCondition.LastUpdateContactTVItemID = val13;
               Assert.Equal(val13, mikeBoundaryCondition.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
