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
    public partial class NodeTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Node node { get; set; }
        #endregion Properties

        #region Constructors
        public NodeTest()
        {
            node = new Node();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Node_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ID", "X", "Y", "Z", "Code", "Value", "ElementList", "ConnectNodeList",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Node).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void Node_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               node.ID = val1;
               Assert.Equal(val1, node.ID);
               double val2 = 87.9D;
               node.X = val2;
               Assert.Equal(val2, node.X);
               double val3 = 87.9D;
               node.Y = val3;
               Assert.Equal(val3, node.Y);
               double val4 = 87.9D;
               node.Z = val4;
               Assert.Equal(val4, node.Z);
               int val5 = 45;
               node.Code = val5;
               Assert.Equal(val5, node.Code);
               double val6 = 87.9D;
               node.Value = val6;
               Assert.Equal(val6, node.Value);
               List<Element> val7 = new List<Element>() { new Element(), new Element() };
               node.ElementList = val7;
               Assert.Equal(val7, node.ElementList);
               List<Node> val8 = new List<Node>() { new Node(), new Node() };
               node.ConnectNodeList = val8;
               Assert.Equal(val8, node.ConnectNodeList);
        }
        #endregion Tests Functions public
    }
}
