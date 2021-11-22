/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class MWQMSubsectorLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSubsectorLanguage mWQMSubsectorLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageTest()
        {
            mWQMSubsectorLanguage = new MWQMSubsectorLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSubsectorLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMSubsectorLanguageID", "DBCommand", "MWQMSubsectorID", "Language", "SubsectorDesc", "TranslationStatusSubsectorDesc", "LogBook", "TranslationStatusLogBook", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsectorLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsectorLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSubsectorLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsectorLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsectorLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSubsectorLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMSubsectorLanguage.MWQMSubsectorLanguageID = val1;
               Assert.Equal(val1, mWQMSubsectorLanguage.MWQMSubsectorLanguageID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               mWQMSubsectorLanguage.DBCommand = val2;
               Assert.Equal(val2, mWQMSubsectorLanguage.DBCommand);
               int val3 = 45;
               mWQMSubsectorLanguage.MWQMSubsectorID = val3;
               Assert.Equal(val3, mWQMSubsectorLanguage.MWQMSubsectorID);
               LanguageEnum val4 = (LanguageEnum)3;
               mWQMSubsectorLanguage.Language = val4;
               Assert.Equal(val4, mWQMSubsectorLanguage.Language);
               string val5 = "Some text";
               mWQMSubsectorLanguage.SubsectorDesc = val5;
               Assert.Equal(val5, mWQMSubsectorLanguage.SubsectorDesc);
               TranslationStatusEnum val6 = (TranslationStatusEnum)3;
               mWQMSubsectorLanguage.TranslationStatusSubsectorDesc = val6;
               Assert.Equal(val6, mWQMSubsectorLanguage.TranslationStatusSubsectorDesc);
               string val7 = "Some text";
               mWQMSubsectorLanguage.LogBook = val7;
               Assert.Equal(val7, mWQMSubsectorLanguage.LogBook);
               TranslationStatusEnum val8 = (TranslationStatusEnum)3;
               mWQMSubsectorLanguage.TranslationStatusLogBook = val8;
               Assert.Equal(val8, mWQMSubsectorLanguage.TranslationStatusLogBook);
               DateTime val9 = new DateTime(2010, 3, 4);
               mWQMSubsectorLanguage.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, mWQMSubsectorLanguage.LastUpdateDate_UTC);
               int val10 = 45;
               mWQMSubsectorLanguage.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, mWQMSubsectorLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}