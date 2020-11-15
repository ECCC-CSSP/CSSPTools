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
    public partial class LocalTVItemTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalTVItem localTVItem { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVItemTest()
        {
            localTVItem = new LocalTVItem();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalTVItem_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "TVItemID", "TVLevel", "TVPath", "TVType", "ParentID", "IsActive", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItem).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItem).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalTVItem_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItem).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItem).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalTVItem_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localTVItem.LocalDBCommand = val1;
               Assert.Equal(val1, localTVItem.LocalDBCommand);
               int val2 = 45;
               localTVItem.TVItemID = val2;
               Assert.Equal(val2, localTVItem.TVItemID);
               int val3 = 45;
               localTVItem.TVLevel = val3;
               Assert.Equal(val3, localTVItem.TVLevel);
               string val4 = "Some text";
               localTVItem.TVPath = val4;
               Assert.Equal(val4, localTVItem.TVPath);
               TVTypeEnum val5 = (TVTypeEnum)3;
               localTVItem.TVType = val5;
               Assert.Equal(val5, localTVItem.TVType);
               int val6 = 45;
               localTVItem.ParentID = val6;
               Assert.Equal(val6, localTVItem.ParentID);
               bool val7 = true;
               localTVItem.IsActive = val7;
               Assert.Equal(val7, localTVItem.IsActive);
               DateTime val8 = new DateTime(2010, 3, 4);
               localTVItem.LastUpdateDate_UTC = val8;
               Assert.Equal(val8, localTVItem.LastUpdateDate_UTC);
               int val9 = 45;
               localTVItem.LastUpdateContactTVItemID = val9;
               Assert.Equal(val9, localTVItem.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}