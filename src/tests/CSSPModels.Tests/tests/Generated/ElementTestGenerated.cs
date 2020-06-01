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
    public partial class ElementTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Element element { get; set; }
        #endregion Properties

        #region Constructors
        public ElementTest()
        {
            element = new Element();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Element_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ID", "Type", "NumbOfNodes", "Value", "XNode0", "YNode0", "ZNode0", "NodeList", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Element).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void Element_Has_ValidationResults_Test()
        {
             Assert.True(typeof(Element).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void Element_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               element.ID = val1;
               Assert.Equal(val1, element.ID);
               int val2 = 45;
               element.Type = val2;
               Assert.Equal(val2, element.Type);
               int val3 = 45;
               element.NumbOfNodes = val3;
               Assert.Equal(val3, element.NumbOfNodes);
               double val4 = 87.9D;
               element.Value = val4;
               Assert.Equal(val4, element.Value);
               double val5 = 87.9D;
               element.XNode0 = val5;
               Assert.Equal(val5, element.XNode0);
               double val6 = 87.9D;
               element.YNode0 = val6;
               Assert.Equal(val6, element.YNode0);
               double val7 = 87.9D;
               element.ZNode0 = val7;
               Assert.Equal(val7, element.ZNode0);
               List<Node> val8 = new List<Node>() { new Node(), new Node() };
               element.NodeList = val8;
               Assert.Equal(val8, element.NodeList);
               bool val9 = true;
               element.HasErrors = val9;
               Assert.Equal(val9, element.HasErrors);
               IEnumerable<ValidationResult> val30 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               element.ValidationResults = val30;
               Assert.Equal(val30, element.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
