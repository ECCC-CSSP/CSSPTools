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
    public partial class BoxModelLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private BoxModelLanguage boxModelLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageTest()
        {
            boxModelLanguage = new BoxModelLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void BoxModelLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "BoxModelLanguageID", "BoxModelID", "Language", "ScenarioName", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(BoxModelLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(BoxModelLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void BoxModelLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(BoxModelLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(BoxModelLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void BoxModelLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               boxModelLanguage.BoxModelLanguageID = val1;
               Assert.Equal(val1, boxModelLanguage.BoxModelLanguageID);
               int val2 = 45;
               boxModelLanguage.BoxModelID = val2;
               Assert.Equal(val2, boxModelLanguage.BoxModelID);
               LanguageEnum val3 = (LanguageEnum)3;
               boxModelLanguage.Language = val3;
               Assert.Equal(val3, boxModelLanguage.Language);
               string val4 = "Some text";
               boxModelLanguage.ScenarioName = val4;
               Assert.Equal(val4, boxModelLanguage.ScenarioName);
               TranslationStatusEnum val5 = (TranslationStatusEnum)3;
               boxModelLanguage.TranslationStatus = val5;
               Assert.Equal(val5, boxModelLanguage.TranslationStatus);
               DateTime val6 = new DateTime(2010, 3, 4);
               boxModelLanguage.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, boxModelLanguage.LastUpdateDate_UTC);
               int val7 = 45;
               boxModelLanguage.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, boxModelLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
