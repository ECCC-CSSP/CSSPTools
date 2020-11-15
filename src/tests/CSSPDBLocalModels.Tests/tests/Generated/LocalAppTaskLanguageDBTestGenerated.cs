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
    public partial class LocalAppTaskLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalAppTaskLanguage localAppTaskLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalAppTaskLanguageTest()
        {
            localAppTaskLanguage = new LocalAppTaskLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalAppTaskLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "AppTaskLanguageID", "AppTaskID", "Language", "StatusText", "ErrorText", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalAppTaskLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalAppTaskLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalAppTaskLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalAppTaskLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalAppTaskLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalAppTaskLanguage_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localAppTaskLanguage.LocalDBCommand = val1;
               Assert.Equal(val1, localAppTaskLanguage.LocalDBCommand);
               int val2 = 45;
               localAppTaskLanguage.AppTaskLanguageID = val2;
               Assert.Equal(val2, localAppTaskLanguage.AppTaskLanguageID);
               int val3 = 45;
               localAppTaskLanguage.AppTaskID = val3;
               Assert.Equal(val3, localAppTaskLanguage.AppTaskID);
               LanguageEnum val4 = (LanguageEnum)3;
               localAppTaskLanguage.Language = val4;
               Assert.Equal(val4, localAppTaskLanguage.Language);
               string val5 = "Some text";
               localAppTaskLanguage.StatusText = val5;
               Assert.Equal(val5, localAppTaskLanguage.StatusText);
               string val6 = "Some text";
               localAppTaskLanguage.ErrorText = val6;
               Assert.Equal(val6, localAppTaskLanguage.ErrorText);
               TranslationStatusEnum val7 = (TranslationStatusEnum)3;
               localAppTaskLanguage.TranslationStatus = val7;
               Assert.Equal(val7, localAppTaskLanguage.TranslationStatus);
               DateTime val8 = new DateTime(2010, 3, 4);
               localAppTaskLanguage.LastUpdateDate_UTC = val8;
               Assert.Equal(val8, localAppTaskLanguage.LastUpdateDate_UTC);
               int val9 = 45;
               localAppTaskLanguage.LastUpdateContactTVItemID = val9;
               Assert.Equal(val9, localAppTaskLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}