/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperModels_TestsGenerated.exe
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
using CSSPDBModels;

namespace CSSPHelperModels.Tests
{
    public partial class TVTextLanguageTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVTextLanguage tVTextLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public TVTextLanguageTest()
        {
            tVTextLanguage = new TVTextLanguage();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVTextLanguage_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVText", "Language", "LanguageText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVTextLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVTextLanguage_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               tVTextLanguage.TVText = val1;
               Assert.Equal(val1, tVTextLanguage.TVText);
               LanguageEnum val2 = (LanguageEnum)3;
               tVTextLanguage.Language = val2;
               Assert.Equal(val2, tVTextLanguage.Language);
               string val3 = "Some text";
               tVTextLanguage.LanguageText = val3;
               Assert.Equal(val3, tVTextLanguage.LanguageText);
        }
        #endregion Tests Functions public
    }
}
