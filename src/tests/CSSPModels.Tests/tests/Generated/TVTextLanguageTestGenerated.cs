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
            List<string> propNameList = new List<string>() { "TVText", "Language", "LanguageText", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVTextLanguage).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVTextLanguage_Has_ValidationResults_Test()
        {
             Assert.True(typeof(TVTextLanguage).GetProperties().Where(c => c.Name == "ValidationResults").Any());
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
               bool val4 = true;
               tVTextLanguage.HasErrors = val4;
               Assert.Equal(val4, tVTextLanguage.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               tVTextLanguage.ValidationResults = val15;
               Assert.Equal(val15, tVTextLanguage.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
