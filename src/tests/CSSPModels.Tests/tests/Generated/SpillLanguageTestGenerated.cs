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
    public partial class SpillLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SpillLanguage spillLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageTest()
        {
            spillLanguage = new SpillLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SpillLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "SpillLanguageID", "SpillID", "Language", "SpillComment", "TranslationStatus", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SpillLanguage).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(SpillLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SpillLanguage_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SpillLanguage).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(SpillLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SpillLanguage_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               spillLanguage.SpillLanguageID = val1;
               Assert.Equal(val1, spillLanguage.SpillLanguageID);
               int val2 = 45;
               spillLanguage.SpillID = val2;
               Assert.Equal(val2, spillLanguage.SpillID);
               LanguageEnum val3 = (LanguageEnum)3;
               spillLanguage.Language = val3;
               Assert.Equal(val3, spillLanguage.Language);
               string val4 = "Some text";
               spillLanguage.SpillComment = val4;
               Assert.Equal(val4, spillLanguage.SpillComment);
               TranslationStatusEnum val5 = (TranslationStatusEnum)3;
               spillLanguage.TranslationStatus = val5;
               Assert.Equal(val5, spillLanguage.TranslationStatus);
               DateTime val6 = new DateTime(2010, 3, 4);
               spillLanguage.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, spillLanguage.LastUpdateDate_UTC);
               int val7 = 45;
               spillLanguage.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, spillLanguage.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
