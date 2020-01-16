/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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
    public partial class AppTaskLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private AppTaskLanguage appTaskLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageTest()
        {
            appTaskLanguage = new AppTaskLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void AppTaskLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "AppTaskLanguageID", "AppTaskID", "Language", "StatusText", "ErrorText", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppTaskLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(AppTaskLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void AppTaskLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(AppTaskLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(AppTaskLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void AppTaskLanguage_Has_ValidationResults_Test()
        {
             Assert.True(typeof(AppTaskLanguage).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void AppTaskLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               appTaskLanguage.AppTaskLanguageID = val1;
               Assert.Equal(val1, appTaskLanguage.AppTaskLanguageID);
               int val2 = 45;
               appTaskLanguage.AppTaskID = val2;
               Assert.Equal(val2, appTaskLanguage.AppTaskID);
               LanguageEnum val3 = (LanguageEnum)3;
               appTaskLanguage.Language = val3;
               Assert.Equal(val3, appTaskLanguage.Language);
               string val4 = "Some text";
               appTaskLanguage.StatusText = val4;
               Assert.Equal(val4, appTaskLanguage.StatusText);
               string val5 = "Some text";
               appTaskLanguage.ErrorText = val5;
               Assert.Equal(val5, appTaskLanguage.ErrorText);
               TranslationStatusEnum val6 = (TranslationStatusEnum)3;
               appTaskLanguage.TranslationStatus = val6;
               Assert.Equal(val6, appTaskLanguage.TranslationStatus);
               DateTime val7 = new DateTime(2010, 3, 4);
               appTaskLanguage.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, appTaskLanguage.LastUpdateDate_UTC);
               int val8 = 45;
               appTaskLanguage.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, appTaskLanguage.LastUpdateContactTVItemID);
               bool val9 = true;
               appTaskLanguage.HasErrors = val9;
               Assert.Equal(val9, appTaskLanguage.HasErrors);
               IEnumerable<ValidationResult> val30 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               appTaskLanguage.ValidationResults = val30;
               Assert.Equal(val30, appTaskLanguage.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
