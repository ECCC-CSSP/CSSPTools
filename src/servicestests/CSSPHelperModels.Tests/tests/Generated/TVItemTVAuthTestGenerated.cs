/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperModels_TestsGenerated.exe
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
    public partial class TVItemTVAuthTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemTVAuth tVItemTVAuth { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTVAuthTest()
        {
            tVItemTVAuth = new TVItemTVAuth();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVItemTVAuth_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVItemUserAuthID", "TVText", "TVItemID1", "TVTypeStr", "TVAuth", "TVAuthText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemTVAuth).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVItemTVAuth_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               tVItemTVAuth.TVItemUserAuthID = val1;
               Assert.Equal(val1, tVItemTVAuth.TVItemUserAuthID);
               string val2 = "Some text";
               tVItemTVAuth.TVText = val2;
               Assert.Equal(val2, tVItemTVAuth.TVText);
               int val3 = 45;
               tVItemTVAuth.TVItemID1 = val3;
               Assert.Equal(val3, tVItemTVAuth.TVItemID1);
               string val4 = "Some text";
               tVItemTVAuth.TVTypeStr = val4;
               Assert.Equal(val4, tVItemTVAuth.TVTypeStr);
               TVAuthEnum val5 = (TVAuthEnum)3;
               tVItemTVAuth.TVAuth = val5;
               Assert.Equal(val5, tVItemTVAuth.TVAuth);
               string val6 = "Some text";
               tVItemTVAuth.TVAuthText = val6;
               Assert.Equal(val6, tVItemTVAuth.TVAuthText);
        }
        #endregion Tests Functions public
    }
}