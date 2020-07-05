/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class VectorTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Vector vector { get; set; }
        #endregion Properties

        #region Constructors
        public VectorTest()
        {
            vector = new Vector();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Vector_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "StartNode", "EndNode",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Vector).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void Vector_Every_Property_Has_Get_Set_Test()
        {
               Node val1 = new Node();
               vector.StartNode = val1;
               Assert.Equal(val1, vector.StartNode);
               Node val2 = new Node();
               vector.EndNode = val2;
               Assert.Equal(val2, vector.EndNode);
        }
        #endregion Tests Functions public
    }
}
