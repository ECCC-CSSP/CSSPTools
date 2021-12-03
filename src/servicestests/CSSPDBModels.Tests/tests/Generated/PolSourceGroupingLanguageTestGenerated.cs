/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net6.0\GenerateCSSPDBModels_TestsGenerated.exe
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

namespace CSSPDBModels.Tests
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
            List<string> propNameList = new List<string>() { "PolSourceGroupingLanguageID", "DBCommand", "PolSourceGroupingID", "Language", "SourceName", "SourceNameOrder", "TranslationStatusSourceName", "Init", "TranslationStatusInit", "Description", "TranslationStatusDescription", "Report", "TranslationStatusReport", "Text", "TranslationStatusText", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

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
                    }
                }
            }


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
        public void PolSourceGroupingLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceGroupingLanguage.PolSourceGroupingLanguageID = val1;
               Assert.Equal(val1, polSourceGroupingLanguage.PolSourceGroupingLanguageID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               polSourceGroupingLanguage.DBCommand = val2;
               Assert.Equal(val2, polSourceGroupingLanguage.DBCommand);
               int val3 = 45;
               polSourceGroupingLanguage.PolSourceGroupingID = val3;
               Assert.Equal(val3, polSourceGroupingLanguage.PolSourceGroupingID);
               LanguageEnum val4 = (LanguageEnum)3;
               polSourceGroupingLanguage.Language = val4;
               Assert.Equal(val4, polSourceGroupingLanguage.Language);
               string val5 = "Some text";
               polSourceGroupingLanguage.SourceName = val5;
               Assert.Equal(val5, polSourceGroupingLanguage.SourceName);
               int val6 = 45;
               polSourceGroupingLanguage.SourceNameOrder = val6;
               Assert.Equal(val6, polSourceGroupingLanguage.SourceNameOrder);
               TranslationStatusEnum val7 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusSourceName = val7;
               Assert.Equal(val7, polSourceGroupingLanguage.TranslationStatusSourceName);
               string val8 = "Some text";
               polSourceGroupingLanguage.Init = val8;
               Assert.Equal(val8, polSourceGroupingLanguage.Init);
               TranslationStatusEnum val9 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusInit = val9;
               Assert.Equal(val9, polSourceGroupingLanguage.TranslationStatusInit);
               string val10 = "Some text";
               polSourceGroupingLanguage.Description = val10;
               Assert.Equal(val10, polSourceGroupingLanguage.Description);
               TranslationStatusEnum val11 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusDescription = val11;
               Assert.Equal(val11, polSourceGroupingLanguage.TranslationStatusDescription);
               string val12 = "Some text";
               polSourceGroupingLanguage.Report = val12;
               Assert.Equal(val12, polSourceGroupingLanguage.Report);
               TranslationStatusEnum val13 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusReport = val13;
               Assert.Equal(val13, polSourceGroupingLanguage.TranslationStatusReport);
               string val14 = "Some text";
               polSourceGroupingLanguage.Text = val14;
               Assert.Equal(val14, polSourceGroupingLanguage.Text);
               TranslationStatusEnum val15 = (TranslationStatusEnum)3;
               polSourceGroupingLanguage.TranslationStatusText = val15;
               Assert.Equal(val15, polSourceGroupingLanguage.TranslationStatusText);
               DateTime val16 = new DateTime(2010, 3, 4);
               polSourceGroupingLanguage.LastUpdateDate_UTC = val16;
               Assert.Equal(val16, polSourceGroupingLanguage.LastUpdateDate_UTC);
               int val17 = 45;
               polSourceGroupingLanguage.LastUpdateContactTVItemID = val17;
               Assert.Equal(val17, polSourceGroupingLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
