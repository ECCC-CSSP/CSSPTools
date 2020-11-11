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
    public partial class SearchResultTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SearchResult searchResult { get; set; }
        #endregion Properties

        #region Constructors
        public SearchResultTest()
        {
            searchResult = new SearchResult();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SearchResult_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVItem", "TVItemLanguage",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SearchResult).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void SearchResult_Every_Property_Has_Get_Set_Test()
        {
               TVItem val1 = new TVItem();
               searchResult.TVItem = val1;
               Assert.Equal(val1, searchResult.TVItem);
               TVItemLanguage val2 = new TVItemLanguage();
               searchResult.TVItemLanguage = val2;
               Assert.Equal(val2, searchResult.TVItemLanguage);
        }
        #endregion Tests Functions public
    }
}
