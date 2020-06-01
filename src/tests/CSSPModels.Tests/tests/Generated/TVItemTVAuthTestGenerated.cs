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
    public partial class TVItemTVAuthTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemTVAuth tVItemTVAuth { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTVAuthTest()
        {
            tVItemTVAuth = new TVItemTVAuth();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVItemTVAuth_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVItemUserAuthID", "TVText", "TVItemID1", "TVTypeStr", "TVAuth", "TVAuthText", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemTVAuth).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVItemTVAuth_Has_ValidationResults_Test()
        {
             Assert.True(typeof(TVItemTVAuth).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void TVItemTVAuth_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               tVItemTVAuth.TVItemUserAuthID = val1;
               Assert.Equal(val1, tVItemTVAuth.TVItemUserAuthID);
               string val2 = "Some text";
               tVItemTVAuth.TVText = val2;
               Assert.Equal(val2, tVItemTVAuth.TVText);
               int val3 = 45;
               tVItemTVAuth.TVItemID1 = val3;
               Assert.Equal(val3, tVItemTVAuth.TVItemID1);
               string val4 = "Some text";
               tVItemTVAuth.TVTypeStr = val4;
               Assert.Equal(val4, tVItemTVAuth.TVTypeStr);
               TVAuthEnum val5 = (TVAuthEnum)3;
               tVItemTVAuth.TVAuth = val5;
               Assert.Equal(val5, tVItemTVAuth.TVAuth);
               string val6 = "Some text";
               tVItemTVAuth.TVAuthText = val6;
               Assert.Equal(val6, tVItemTVAuth.TVAuthText);
               bool val7 = true;
               tVItemTVAuth.HasErrors = val7;
               Assert.Equal(val7, tVItemTVAuth.HasErrors);
               IEnumerable<ValidationResult> val24 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               tVItemTVAuth.ValidationResults = val24;
               Assert.Equal(val24, tVItemTVAuth.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
