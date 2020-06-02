/*
 * Auto generated from C:\CSSPTools\src\codegen\ModelsModelClassNameTestGenerated_cs\bin\Debug\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
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
using CSSPModels.Resources;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class RatingCurveValueTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RatingCurveValue ratingCurveValue { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueTest()
        {
            ratingCurveValue = new RatingCurveValue();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void RatingCurveValue_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "RatingCurveValueID", "RatingCurveID", "StageValue_m", "DischargeValue_m3_s", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(RatingCurveValue).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(RatingCurveValue).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void RatingCurveValue_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(RatingCurveValue).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(RatingCurveValue).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void RatingCurveValue_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               ratingCurveValue.RatingCurveValueID = val1;
               Assert.Equal(val1, ratingCurveValue.RatingCurveValueID);
               int val2 = 45;
               ratingCurveValue.RatingCurveID = val2;
               Assert.Equal(val2, ratingCurveValue.RatingCurveID);
               double val3 = 87.9D;
               ratingCurveValue.StageValue_m = val3;
               Assert.Equal(val3, ratingCurveValue.StageValue_m);
               double val4 = 87.9D;
               ratingCurveValue.DischargeValue_m3_s = val4;
               Assert.Equal(val4, ratingCurveValue.DischargeValue_m3_s);
               DateTime val5 = new DateTime(2010, 3, 4);
               ratingCurveValue.LastUpdateDate_UTC = val5;
               Assert.Equal(val5, ratingCurveValue.LastUpdateDate_UTC);
               int val6 = 45;
               ratingCurveValue.LastUpdateContactTVItemID = val6;
               Assert.Equal(val6, ratingCurveValue.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
