/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
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
    public partial class InputSummaryTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private InputSummary inputSummary { get; set; }
        #endregion Properties

        #region Constructors
        public InputSummaryTest()
        {
            inputSummary = new InputSummary();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void InputSummary_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Summary",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(InputSummary).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void InputSummary_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               inputSummary.Summary = val1;
               Assert.Equal(val1, inputSummary.Summary);
        }
        #endregion Tests Functions public
    }
}
