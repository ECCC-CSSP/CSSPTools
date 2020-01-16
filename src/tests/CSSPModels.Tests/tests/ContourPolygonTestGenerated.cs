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
    public partial class ContourPolygonTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContourPolygon contourPolygon { get; set; }
        #endregion Properties

        #region Constructors
        public ContourPolygonTest()
        {
            contourPolygon = new ContourPolygon();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ContourPolygon_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ContourValue", "Layer", "Depth_m", "ContourNodeList", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ContourPolygon).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void ContourPolygon_Has_ValidationResults_Test()
        {
             Assert.True(typeof(ContourPolygon).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void ContourPolygon_Every_Property_Has_Get_Set_Test()
        {
               double val1 = 87.9D;
               contourPolygon.ContourValue = val1;
               Assert.Equal(val1, contourPolygon.ContourValue);
               int val2 = 45;
               contourPolygon.Layer = val2;
               Assert.Equal(val2, contourPolygon.Layer);
               double val3 = 87.9D;
               contourPolygon.Depth_m = val3;
               Assert.Equal(val3, contourPolygon.Depth_m);
               List<Node> val4 = new List<Node>() { new Node(), new Node() };
               contourPolygon.ContourNodeList = val4;
               Assert.Equal(val4, contourPolygon.ContourNodeList);
               bool val5 = true;
               contourPolygon.HasErrors = val5;
               Assert.Equal(val5, contourPolygon.HasErrors);
               IEnumerable<ValidationResult> val18 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               contourPolygon.ValidationResults = val18;
               Assert.Equal(val18, contourPolygon.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
