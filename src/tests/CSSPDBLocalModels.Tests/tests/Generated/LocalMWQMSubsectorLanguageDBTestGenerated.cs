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
    public partial class LocalMWQMSubsectorLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalMWQMSubsectorLanguage localMWQMSubsectorLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public LocalMWQMSubsectorLanguageTest()
        {
            localMWQMSubsectorLanguage = new LocalMWQMSubsectorLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalMWQMSubsectorLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "MWQMSubsectorLanguageID", "MWQMSubsectorID", "Language", "SubsectorDesc", "TranslationStatusSubsectorDesc", "LogBook", "TranslationStatusLogBook", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSubsectorLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSubsectorLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalMWQMSubsectorLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSubsectorLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalMWQMSubsectorLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalMWQMSubsectorLanguage_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localMWQMSubsectorLanguage.LocalDBCommand = val1;
               Assert.Equal(val1, localMWQMSubsectorLanguage.LocalDBCommand);
               int val2 = 45;
               localMWQMSubsectorLanguage.MWQMSubsectorLanguageID = val2;
               Assert.Equal(val2, localMWQMSubsectorLanguage.MWQMSubsectorLanguageID);
               int val3 = 45;
               localMWQMSubsectorLanguage.MWQMSubsectorID = val3;
               Assert.Equal(val3, localMWQMSubsectorLanguage.MWQMSubsectorID);
               LanguageEnum val4 = (LanguageEnum)3;
               localMWQMSubsectorLanguage.Language = val4;
               Assert.Equal(val4, localMWQMSubsectorLanguage.Language);
               string val5 = "Some text";
               localMWQMSubsectorLanguage.SubsectorDesc = val5;
               Assert.Equal(val5, localMWQMSubsectorLanguage.SubsectorDesc);
               TranslationStatusEnum val6 = (TranslationStatusEnum)3;
               localMWQMSubsectorLanguage.TranslationStatusSubsectorDesc = val6;
               Assert.Equal(val6, localMWQMSubsectorLanguage.TranslationStatusSubsectorDesc);
               string val7 = "Some text";
               localMWQMSubsectorLanguage.LogBook = val7;
               Assert.Equal(val7, localMWQMSubsectorLanguage.LogBook);
               TranslationStatusEnum val8 = (TranslationStatusEnum)3;
               localMWQMSubsectorLanguage.TranslationStatusLogBook = val8;
               Assert.Equal(val8, localMWQMSubsectorLanguage.TranslationStatusLogBook);
               DateTime val9 = new DateTime(2010, 3, 4);
               localMWQMSubsectorLanguage.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, localMWQMSubsectorLanguage.LastUpdateDate_UTC);
               int val10 = 45;
               localMWQMSubsectorLanguage.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, localMWQMSubsectorLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
