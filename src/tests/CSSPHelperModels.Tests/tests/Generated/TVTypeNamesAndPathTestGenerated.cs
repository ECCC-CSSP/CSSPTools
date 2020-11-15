/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPHelperModels_TestsGenerated.exe
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
using CSSPDBModels;

namespace CSSPHelperModels.Tests
{
    public partial class TVTypeNamesAndPathTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVTypeNamesAndPath tVTypeNamesAndPath { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathTest()
        {
            tVTypeNamesAndPath = new TVTypeNamesAndPath();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVTypeNamesAndPath_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVTypeName", "Index", "TVPath",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVTypeNamesAndPath).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVTypeNamesAndPath_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               tVTypeNamesAndPath.TVTypeName = val1;
               Assert.Equal(val1, tVTypeNamesAndPath.TVTypeName);
               int val2 = 45;
               tVTypeNamesAndPath.Index = val2;
               Assert.Equal(val2, tVTypeNamesAndPath.Index);
               string val3 = "Some text";
               tVTypeNamesAndPath.TVPath = val3;
               Assert.Equal(val3, tVTypeNamesAndPath.TVPath);
        }
        #endregion Tests Functions public
    }
}