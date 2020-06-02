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
    public partial class TVFullTextTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVFullText tVFullText { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextTest()
        {
            tVFullText = new TVFullText();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVFullText_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVPath", "FullText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVFullText).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVFullText_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               tVFullText.TVPath = val1;
               Assert.Equal(val1, tVFullText.TVPath);
               string val2 = "Some text";
               tVFullText.FullText = val2;
               Assert.Equal(val2, tVFullText.FullText);
        }
        #endregion Tests Functions public
    }
}
