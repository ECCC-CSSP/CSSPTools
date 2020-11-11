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
    public partial class LocalVPScenarioLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalVPScenarioLanguage localVPScenarioLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalVPScenarioLanguageTest()
        {
            localVPScenarioLanguage = new LocalVPScenarioLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalVPScenarioLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "VPScenarioLanguageID", "VPScenarioID", "Language", "VPScenarioName", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenarioLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenarioLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalVPScenarioLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenarioLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalVPScenarioLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalVPScenarioLanguage_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localVPScenarioLanguage.LocalDBCommand = val1;
               Assert.Equal(val1, localVPScenarioLanguage.LocalDBCommand);
               int val2 = 45;
               localVPScenarioLanguage.VPScenarioLanguageID = val2;
               Assert.Equal(val2, localVPScenarioLanguage.VPScenarioLanguageID);
               int val3 = 45;
               localVPScenarioLanguage.VPScenarioID = val3;
               Assert.Equal(val3, localVPScenarioLanguage.VPScenarioID);
               LanguageEnum val4 = (LanguageEnum)3;
               localVPScenarioLanguage.Language = val4;
               Assert.Equal(val4, localVPScenarioLanguage.Language);
               string val5 = "Some text";
               localVPScenarioLanguage.VPScenarioName = val5;
               Assert.Equal(val5, localVPScenarioLanguage.VPScenarioName);
               TranslationStatusEnum val6 = (TranslationStatusEnum)3;
               localVPScenarioLanguage.TranslationStatus = val6;
               Assert.Equal(val6, localVPScenarioLanguage.TranslationStatus);
               DateTime val7 = new DateTime(2010, 3, 4);
               localVPScenarioLanguage.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, localVPScenarioLanguage.LastUpdateDate_UTC);
               int val8 = 45;
               localVPScenarioLanguage.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, localVPScenarioLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
