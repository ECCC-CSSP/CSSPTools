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
    public partial class LocalContactPreferenceTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalContactPreference localContactPreference { get; set; }
        #endregion Properties

        #region Constructors
        public LocalContactPreferenceTest()
        {
            localContactPreference = new LocalContactPreference();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalContactPreference_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "ContactPreferenceID", "ContactID", "TVType", "MarkerSize", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalContactPreference).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalContactPreference).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalContactPreference_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalContactPreference).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalContactPreference).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalContactPreference_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localContactPreference.LocalDBCommand = val1;
               Assert.Equal(val1, localContactPreference.LocalDBCommand);
               int val2 = 45;
               localContactPreference.ContactPreferenceID = val2;
               Assert.Equal(val2, localContactPreference.ContactPreferenceID);
               int val3 = 45;
               localContactPreference.ContactID = val3;
               Assert.Equal(val3, localContactPreference.ContactID);
               TVTypeEnum val4 = (TVTypeEnum)3;
               localContactPreference.TVType = val4;
               Assert.Equal(val4, localContactPreference.TVType);
               int val5 = 45;
               localContactPreference.MarkerSize = val5;
               Assert.Equal(val5, localContactPreference.MarkerSize);
               DateTime val6 = new DateTime(2010, 3, 4);
               localContactPreference.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, localContactPreference.LastUpdateDate_UTC);
               int val7 = 45;
               localContactPreference.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, localContactPreference.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
