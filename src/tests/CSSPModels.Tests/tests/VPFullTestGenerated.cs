/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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

    public partial class VPFullTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPFull vPFull { get; set; }
        #endregion Properties

        #region Constructors
        public VPFullTest()
        {
            vPFull = new VPFull();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void VPFull_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "VPScenario", "VPAmbientList", "VPResultList", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(VPFull).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void VPFull_Has_ValidationResults_Test()
        {
             Assert.True(typeof(VPFull).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void VPFull_Every_Property_Has_Get_Set_Test()
        {
               VPScenario val1 = new VPScenario();
               vPFull.VPScenario = val1;
               Assert.Equal(val1, vPFull.VPScenario);
               List<VPAmbient> val2 = new List<VPAmbient>() { new VPAmbient(), new VPAmbient() };
               vPFull.VPAmbientList = val2;
               Assert.Equal(val2, vPFull.VPAmbientList);
               List<VPResult> val3 = new List<VPResult>() { new VPResult(), new VPResult() };
               vPFull.VPResultList = val3;
               Assert.Equal(val3, vPFull.VPResultList);
               bool val4 = true;
               vPFull.HasErrors = val4;
               Assert.Equal(val4, vPFull.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               vPFull.ValidationResults = val15;
               Assert.Equal(val15, vPFull.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
