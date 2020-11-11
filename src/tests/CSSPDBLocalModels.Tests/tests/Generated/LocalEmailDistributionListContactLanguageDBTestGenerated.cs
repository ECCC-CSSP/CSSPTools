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
    public partial class LocalEmailDistributionListContactLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalEmailDistributionListContactLanguage localEmailDistributionListContactLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalEmailDistributionListContactLanguageTest()
        {
            localEmailDistributionListContactLanguage = new LocalEmailDistributionListContactLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalEmailDistributionListContactLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "EmailDistributionListContactLanguageID", "EmailDistributionListContactID", "Language", "Agency", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalEmailDistributionListContactLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalEmailDistributionListContactLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalEmailDistributionListContactLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalEmailDistributionListContactLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalEmailDistributionListContactLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalEmailDistributionListContactLanguage_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localEmailDistributionListContactLanguage.LocalDBCommand = val1;
               Assert.Equal(val1, localEmailDistributionListContactLanguage.LocalDBCommand);
               int val2 = 45;
               localEmailDistributionListContactLanguage.EmailDistributionListContactLanguageID = val2;
               Assert.Equal(val2, localEmailDistributionListContactLanguage.EmailDistributionListContactLanguageID);
               int val3 = 45;
               localEmailDistributionListContactLanguage.EmailDistributionListContactID = val3;
               Assert.Equal(val3, localEmailDistributionListContactLanguage.EmailDistributionListContactID);
               LanguageEnum val4 = (LanguageEnum)3;
               localEmailDistributionListContactLanguage.Language = val4;
               Assert.Equal(val4, localEmailDistributionListContactLanguage.Language);
               string val5 = "Some text";
               localEmailDistributionListContactLanguage.Agency = val5;
               Assert.Equal(val5, localEmailDistributionListContactLanguage.Agency);
               TranslationStatusEnum val6 = (TranslationStatusEnum)3;
               localEmailDistributionListContactLanguage.TranslationStatus = val6;
               Assert.Equal(val6, localEmailDistributionListContactLanguage.TranslationStatus);
               DateTime val7 = new DateTime(2010, 3, 4);
               localEmailDistributionListContactLanguage.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, localEmailDistributionListContactLanguage.LastUpdateDate_UTC);
               int val8 = 45;
               localEmailDistributionListContactLanguage.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, localEmailDistributionListContactLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
