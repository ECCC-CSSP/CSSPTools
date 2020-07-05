/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class MWQMSampleLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSampleLanguage mWQMSampleLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageTest()
        {
            mWQMSampleLanguage = new MWQMSampleLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSampleLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMSampleLanguageID", "MWQMSampleID", "Language", "MWQMSampleNote", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSampleLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSampleLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSampleLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSampleLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSampleLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSampleLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMSampleLanguage.MWQMSampleLanguageID = val1;
               Assert.Equal(val1, mWQMSampleLanguage.MWQMSampleLanguageID);
               int val2 = 45;
               mWQMSampleLanguage.MWQMSampleID = val2;
               Assert.Equal(val2, mWQMSampleLanguage.MWQMSampleID);
               LanguageEnum val3 = (LanguageEnum)3;
               mWQMSampleLanguage.Language = val3;
               Assert.Equal(val3, mWQMSampleLanguage.Language);
               string val4 = "Some text";
               mWQMSampleLanguage.MWQMSampleNote = val4;
               Assert.Equal(val4, mWQMSampleLanguage.MWQMSampleNote);
               TranslationStatusEnum val5 = (TranslationStatusEnum)3;
               mWQMSampleLanguage.TranslationStatus = val5;
               Assert.Equal(val5, mWQMSampleLanguage.TranslationStatus);
               DateTime val6 = new DateTime(2010, 3, 4);
               mWQMSampleLanguage.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, mWQMSampleLanguage.LastUpdateDate_UTC);
               int val7 = 45;
               mWQMSampleLanguage.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, mWQMSampleLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
