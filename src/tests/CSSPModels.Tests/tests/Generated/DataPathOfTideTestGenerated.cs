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
    public partial class DataPathOfTideTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private DataPathOfTide dataPathOfTide { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideTest()
        {
            dataPathOfTide = new DataPathOfTide();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void DataPathOfTide_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Text", "WebTideDataSet", "WebTideDataSetText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(DataPathOfTide).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void DataPathOfTide_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               dataPathOfTide.Text = val1;
               Assert.Equal(val1, dataPathOfTide.Text);
               WebTideDataSetEnum val2 = (WebTideDataSetEnum)3;
               dataPathOfTide.WebTideDataSet = val2;
               Assert.Equal(val2, dataPathOfTide.WebTideDataSet);
               string val3 = "Some text";
               dataPathOfTide.WebTideDataSetText = val3;
               Assert.Equal(val3, dataPathOfTide.WebTideDataSetText);
        }
        #endregion Tests Functions public
    }
}
