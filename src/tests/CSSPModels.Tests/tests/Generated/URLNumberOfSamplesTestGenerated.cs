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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class URLNumberOfSamplesTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private URLNumberOfSamples uRLNumberOfSamples { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesTest()
        {
            uRLNumberOfSamples = new URLNumberOfSamples();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void URLNumberOfSamples_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "url", "NumberOfSamples",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(URLNumberOfSamples).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void URLNumberOfSamples_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               uRLNumberOfSamples.url = val1;
               Assert.Equal(val1, uRLNumberOfSamples.url);
               int val2 = 45;
               uRLNumberOfSamples.NumberOfSamples = val2;
               Assert.Equal(val2, uRLNumberOfSamples.NumberOfSamples);
        }
        #endregion Tests Functions public
    }
}
