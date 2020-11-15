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
    public partial class LocalHelpDocTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalHelpDoc localHelpDoc { get; set; }
        #endregion Properties

        #region Constructors
        public LocalHelpDocTest()
        {
            localHelpDoc = new LocalHelpDoc();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalHelpDoc_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "HelpDocID", "DocKey", "Language", "DocHTMLText", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalHelpDoc).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalHelpDoc).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalHelpDoc_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalHelpDoc).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalHelpDoc).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalHelpDoc_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localHelpDoc.LocalDBCommand = val1;
               Assert.Equal(val1, localHelpDoc.LocalDBCommand);
               int val2 = 45;
               localHelpDoc.HelpDocID = val2;
               Assert.Equal(val2, localHelpDoc.HelpDocID);
               string val3 = "Some text";
               localHelpDoc.DocKey = val3;
               Assert.Equal(val3, localHelpDoc.DocKey);
               LanguageEnum val4 = (LanguageEnum)3;
               localHelpDoc.Language = val4;
               Assert.Equal(val4, localHelpDoc.Language);
               string val5 = "Some text";
               localHelpDoc.DocHTMLText = val5;
               Assert.Equal(val5, localHelpDoc.DocHTMLText);
               DateTime val6 = new DateTime(2010, 3, 4);
               localHelpDoc.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, localHelpDoc.LastUpdateDate_UTC);
               int val7 = 45;
               localHelpDoc.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, localHelpDoc.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}