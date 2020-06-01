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
    public partial class MapInfoPointTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MapInfoPoint mapInfoPoint { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointTest()
        {
            mapInfoPoint = new MapInfoPoint();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MapInfoPoint_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MapInfoPointID", "MapInfoID", "Ordinal", "Lat", "Lng", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MapInfoPoint).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MapInfoPoint).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        Assert.Equal(propertyInfo.Name, propNameNotMappedList[index]);
                        index += 1;
                    }
                }
            }

            Assert.Equal(propNameNotMappedList.Count, index);

        }
        [Fact]
        public void MapInfoPoint_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MapInfoPoint).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MapInfoPoint).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MapInfoPoint_Has_ValidationResults_Test()
        {
             Assert.True(typeof(MapInfoPoint).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void MapInfoPoint_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mapInfoPoint.MapInfoPointID = val1;
               Assert.Equal(val1, mapInfoPoint.MapInfoPointID);
               int val2 = 45;
               mapInfoPoint.MapInfoID = val2;
               Assert.Equal(val2, mapInfoPoint.MapInfoID);
               int val3 = 45;
               mapInfoPoint.Ordinal = val3;
               Assert.Equal(val3, mapInfoPoint.Ordinal);
               double val4 = 87.9D;
               mapInfoPoint.Lat = val4;
               Assert.Equal(val4, mapInfoPoint.Lat);
               double val5 = 87.9D;
               mapInfoPoint.Lng = val5;
               Assert.Equal(val5, mapInfoPoint.Lng);
               DateTime val6 = new DateTime(2010, 3, 4);
               mapInfoPoint.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, mapInfoPoint.LastUpdateDate_UTC);
               int val7 = 45;
               mapInfoPoint.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, mapInfoPoint.LastUpdateContactTVItemID);
               bool val8 = true;
               mapInfoPoint.HasErrors = val8;
               Assert.Equal(val8, mapInfoPoint.HasErrors);
               IEnumerable<ValidationResult> val27 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               mapInfoPoint.ValidationResults = val27;
               Assert.Equal(val27, mapInfoPoint.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
