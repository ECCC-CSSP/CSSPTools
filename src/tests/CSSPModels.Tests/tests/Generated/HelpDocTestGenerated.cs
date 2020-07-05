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
    public partial class HelpDocTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private HelpDoc helpDoc { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocTest()
        {
            helpDoc = new HelpDoc();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void HelpDoc_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "HelpDocID", "DocKey", "Language", "DocHTMLText", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(HelpDoc).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(HelpDoc).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void HelpDoc_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(HelpDoc).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(HelpDoc).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void HelpDoc_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               helpDoc.HelpDocID = val1;
               Assert.Equal(val1, helpDoc.HelpDocID);
               string val2 = "Some text";
               helpDoc.DocKey = val2;
               Assert.Equal(val2, helpDoc.DocKey);
               LanguageEnum val3 = (LanguageEnum)3;
               helpDoc.Language = val3;
               Assert.Equal(val3, helpDoc.Language);
               string val4 = "Some text";
               helpDoc.DocHTMLText = val4;
               Assert.Equal(val4, helpDoc.DocHTMLText);
               DateTime val5 = new DateTime(2010, 3, 4);
               helpDoc.LastUpdateDate_UTC = val5;
               Assert.Equal(val5, helpDoc.LastUpdateDate_UTC);
               int val6 = 45;
               helpDoc.LastUpdateContactTVItemID = val6;
               Assert.Equal(val6, helpDoc.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
