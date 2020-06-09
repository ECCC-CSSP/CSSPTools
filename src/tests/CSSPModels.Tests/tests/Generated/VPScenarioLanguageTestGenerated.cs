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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class VPScenarioLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPScenarioLanguage vPScenarioLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageTest()
        {
            vPScenarioLanguage = new VPScenarioLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void VPScenarioLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "VPScenarioLanguageID", "VPScenarioID", "Language", "VPScenarioName", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPScenarioLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(VPScenarioLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void VPScenarioLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPScenarioLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(VPScenarioLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void VPScenarioLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               vPScenarioLanguage.VPScenarioLanguageID = val1;
               Assert.Equal(val1, vPScenarioLanguage.VPScenarioLanguageID);
               int val2 = 45;
               vPScenarioLanguage.VPScenarioID = val2;
               Assert.Equal(val2, vPScenarioLanguage.VPScenarioID);
               LanguageEnum val3 = (LanguageEnum)3;
               vPScenarioLanguage.Language = val3;
               Assert.Equal(val3, vPScenarioLanguage.Language);
               string val4 = "Some text";
               vPScenarioLanguage.VPScenarioName = val4;
               Assert.Equal(val4, vPScenarioLanguage.VPScenarioName);
               TranslationStatusEnum val5 = (TranslationStatusEnum)3;
               vPScenarioLanguage.TranslationStatus = val5;
               Assert.Equal(val5, vPScenarioLanguage.TranslationStatus);
               DateTime val6 = new DateTime(2010, 3, 4);
               vPScenarioLanguage.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, vPScenarioLanguage.LastUpdateDate_UTC);
               int val7 = 45;
               vPScenarioLanguage.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, vPScenarioLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
