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
    public partial class NodeLayerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private NodeLayer nodeLayer { get; set; }
        #endregion Properties

        #region Constructors
        public NodeLayerTest()
        {
            nodeLayer = new NodeLayer();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void NodeLayer_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Layer", "Z", "Node", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(NodeLayer).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void NodeLayer_Has_ValidationResults_Test()
        {
             Assert.True(typeof(NodeLayer).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void NodeLayer_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               nodeLayer.Layer = val1;
               Assert.Equal(val1, nodeLayer.Layer);
               double val2 = 87.9D;
               nodeLayer.Z = val2;
               Assert.Equal(val2, nodeLayer.Z);
               Node val3 = new Node();
               nodeLayer.Node = val3;
               Assert.Equal(val3, nodeLayer.Node);
               bool val4 = true;
               nodeLayer.HasErrors = val4;
               Assert.Equal(val4, nodeLayer.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               nodeLayer.ValidationResults = val15;
               Assert.Equal(val15, nodeLayer.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
