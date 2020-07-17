/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
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
    public partial class RTBStringPosTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RTBStringPos rTBStringPos { get; set; }
        #endregion Properties

        #region Constructors
        public RTBStringPosTest()
        {
            rTBStringPos = new RTBStringPos();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void RTBStringPos_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "StartPos", "EndPos", "Text", "TagText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(RTBStringPos).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void RTBStringPos_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               rTBStringPos.StartPos = val1;
               Assert.Equal(val1, rTBStringPos.StartPos);
               int val2 = 45;
               rTBStringPos.EndPos = val2;
               Assert.Equal(val2, rTBStringPos.EndPos);
               string val3 = "Some text";
               rTBStringPos.Text = val3;
               Assert.Equal(val3, rTBStringPos.Text);
               string val4 = "Some text";
               rTBStringPos.TagText = val4;
               Assert.Equal(val4, rTBStringPos.TagText);
        }
        #endregion Tests Functions public
    }
}
