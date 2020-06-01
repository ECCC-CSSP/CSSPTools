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
    public partial class PolSourceGroupingLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceGroupingLanguage polSourceGroupingLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageTest()
        {
            polSourceGroupingLanguage = new PolSourceGroupingLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceGroupingLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceGroupingLanguageID", "PolSourceGroupingID", "Language", "SourceName", "SourceNameOrder", "TranslationStatusSourceName", "Init", "TranslationStatusInit", "Description", "TranslationStatusDescription", "Report", "TranslationStatusReport", "Text", "TranslationStatusText", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceGroupingLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceGroupingLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceGroupingLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceGroupingLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceGroupingLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceGroupingLanguage_Has_ValidationResults_Test()
        {
             Assert.True(typeof(PolSourceGroupingLanguage).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void PolSourceGroupingLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceGroupingLanguage.PolSourceGroupingLanguageID = val1;
               Assert.Equal(val1, polSourceGroupingLanguage.PolSourceGroupingLanguageID);
               int val2 = 45;
               polSourceGroupingLanguage.PolSourceGroupingID = val2;
               Assert.Equal(val2, polSourceGroupingLanguage.PolSourceGroupingID);
               LanguageEnum val3 = (LanguageEnum)3;
               polSourceGroupingLanguage.Language = val3;
               Assert.Equal(val3, polSourceGroupingLanguage.Language);
               string val4 = "Some text";
               polSourceGroupingLanguage.SourceName = val4;
               Assert.Equal(val4, polSourceGroupingLanguage.SourceName);
               int val5 = 45;
               polSourceGroupingLanguage.SourceNameOrder = val5;
               Assert.Equal(val5, polSourceGroupingLanguage.SourceNameOrder);
               TranslationStatusEnum val6 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusSourceName = val6;
               Assert.Equal(val6, polSourceGroupingLanguage.TranslationStatusSourceName);
               string val7 = "Some text";
               polSourceGroupingLanguage.Init = val7;
               Assert.Equal(val7, polSourceGroupingLanguage.Init);
               TranslationStatusEnum val8 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusInit = val8;
               Assert.Equal(val8, polSourceGroupingLanguage.TranslationStatusInit);
               string val9 = "Some text";
               polSourceGroupingLanguage.Description = val9;
               Assert.Equal(val9, polSourceGroupingLanguage.Description);
               TranslationStatusEnum val10 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusDescription = val10;
               Assert.Equal(val10, polSourceGroupingLanguage.TranslationStatusDescription);
               string val11 = "Some text";
               polSourceGroupingLanguage.Report = val11;
               Assert.Equal(val11, polSourceGroupingLanguage.Report);
               TranslationStatusEnum val12 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusReport = val12;
               Assert.Equal(val12, polSourceGroupingLanguage.TranslationStatusReport);
               string val13 = "Some text";
               polSourceGroupingLanguage.Text = val13;
               Assert.Equal(val13, polSourceGroupingLanguage.Text);
               TranslationStatusEnum val14 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusText = val14;
               Assert.Equal(val14, polSourceGroupingLanguage.TranslationStatusText);
               DateTime val15 = new DateTime(2010, 3, 4);
               polSourceGroupingLanguage.LastUpdateDate_UTC = val15;
               Assert.Equal(val15, polSourceGroupingLanguage.LastUpdateDate_UTC);
               int val16 = 45;
               polSourceGroupingLanguage.LastUpdateContactTVItemID = val16;
               Assert.Equal(val16, polSourceGroupingLanguage.LastUpdateContactTVItemID);
               bool val17 = true;
               polSourceGroupingLanguage.HasErrors = val17;
               Assert.Equal(val17, polSourceGroupingLanguage.HasErrors);
               IEnumerable<ValidationResult> val54 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               polSourceGroupingLanguage.ValidationResults = val54;
               Assert.Equal(val54, polSourceGroupingLanguage.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
