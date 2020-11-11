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
    public partial class LocalBoxModelResultTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalBoxModelResult localBoxModelResult { get; set; }
        #endregion Properties

        #region Constructors
        public LocalBoxModelResultTest()
        {
            localBoxModelResult = new LocalBoxModelResult();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalBoxModelResult_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "BoxModelResultID", "BoxModelID", "BoxModelResultType", "Volume_m3", "Surface_m2", "Radius_m", "LeftSideDiameterLineAngle_deg", "CircleCenterLatitude", "CircleCenterLongitude", "FixLength", "FixWidth", "RectLength_m", "RectWidth_m", "LeftSideLineAngle_deg", "LeftSideLineStartLatitude", "LeftSideLineStartLongitude", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalBoxModelResult).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalBoxModelResult).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalBoxModelResult_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalBoxModelResult).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalBoxModelResult).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalBoxModelResult_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localBoxModelResult.LocalDBCommand = val1;
               Assert.Equal(val1, localBoxModelResult.LocalDBCommand);
               int val2 = 45;
               localBoxModelResult.BoxModelResultID = val2;
               Assert.Equal(val2, localBoxModelResult.BoxModelResultID);
               int val3 = 45;
               localBoxModelResult.BoxModelID = val3;
               Assert.Equal(val3, localBoxModelResult.BoxModelID);
               BoxModelResultTypeEnum val4 = (BoxModelResultTypeEnum)3;
               localBoxModelResult.BoxModelResultType = val4;
               Assert.Equal(val4, localBoxModelResult.BoxModelResultType);
               double val5 = 87.9D;
               localBoxModelResult.Volume_m3 = val5;
               Assert.Equal(val5, localBoxModelResult.Volume_m3);
               double val6 = 87.9D;
               localBoxModelResult.Surface_m2 = val6;
               Assert.Equal(val6, localBoxModelResult.Surface_m2);
               double val7 = 87.9D;
               localBoxModelResult.Radius_m = val7;
               Assert.Equal(val7, localBoxModelResult.Radius_m);
               double val8 = 87.9D;
               localBoxModelResult.LeftSideDiameterLineAngle_deg = val8;
               Assert.Equal(val8, localBoxModelResult.LeftSideDiameterLineAngle_deg);
               double val9 = 87.9D;
               localBoxModelResult.CircleCenterLatitude = val9;
               Assert.Equal(val9, localBoxModelResult.CircleCenterLatitude);
               double val10 = 87.9D;
               localBoxModelResult.CircleCenterLongitude = val10;
               Assert.Equal(val10, localBoxModelResult.CircleCenterLongitude);
               bool val11 = true;
               localBoxModelResult.FixLength = val11;
               Assert.Equal(val11, localBoxModelResult.FixLength);
               bool val12 = true;
               localBoxModelResult.FixWidth = val12;
               Assert.Equal(val12, localBoxModelResult.FixWidth);
               double val13 = 87.9D;
               localBoxModelResult.RectLength_m = val13;
               Assert.Equal(val13, localBoxModelResult.RectLength_m);
               double val14 = 87.9D;
               localBoxModelResult.RectWidth_m = val14;
               Assert.Equal(val14, localBoxModelResult.RectWidth_m);
               double val15 = 87.9D;
               localBoxModelResult.LeftSideLineAngle_deg = val15;
               Assert.Equal(val15, localBoxModelResult.LeftSideLineAngle_deg);
               double val16 = 87.9D;
               localBoxModelResult.LeftSideLineStartLatitude = val16;
               Assert.Equal(val16, localBoxModelResult.LeftSideLineStartLatitude);
               double val17 = 87.9D;
               localBoxModelResult.LeftSideLineStartLongitude = val17;
               Assert.Equal(val17, localBoxModelResult.LeftSideLineStartLongitude);
               DateTime val18 = new DateTime(2010, 3, 4);
               localBoxModelResult.LastUpdateDate_UTC = val18;
               Assert.Equal(val18, localBoxModelResult.LastUpdateDate_UTC);
               int val19 = 45;
               localBoxModelResult.LastUpdateContactTVItemID = val19;
               Assert.Equal(val19, localBoxModelResult.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
