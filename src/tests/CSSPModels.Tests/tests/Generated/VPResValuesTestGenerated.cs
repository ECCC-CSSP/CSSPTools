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
    public partial class VPResValuesTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPResValues vPResValues { get; set; }
        #endregion Properties

        #region Constructors
        public VPResValuesTest()
        {
            vPResValues = new VPResValues();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void VPResValues_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Conc", "Dilu", "FarfieldWidth", "Distance", "TheTime", "Decay",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPResValues).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void VPResValues_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               vPResValues.Conc = val1;
               Assert.Equal(val1, vPResValues.Conc);
               double val2 = 87.9D;
               vPResValues.Dilu = val2;
               Assert.Equal(val2, vPResValues.Dilu);
               double val3 = 87.9D;
               vPResValues.FarfieldWidth = val3;
               Assert.Equal(val3, vPResValues.FarfieldWidth);
               double val4 = 87.9D;
               vPResValues.Distance = val4;
               Assert.Equal(val4, vPResValues.Distance);
               double val5 = 87.9D;
               vPResValues.TheTime = val5;
               Assert.Equal(val5, vPResValues.TheTime);
               double val6 = 87.9D;
               vPResValues.Decay = val6;
               Assert.Equal(val6, vPResValues.Decay);
        }
        #endregion Tests Functions public
    }
}
