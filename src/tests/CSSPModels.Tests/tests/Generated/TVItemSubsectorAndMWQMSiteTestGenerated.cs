/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
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
    public partial class TVItemSubsectorAndMWQMSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemSubsectorAndMWQMSite tVItemSubsectorAndMWQMSite { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemSubsectorAndMWQMSiteTest()
        {
            tVItemSubsectorAndMWQMSite = new TVItemSubsectorAndMWQMSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVItemSubsectorAndMWQMSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVItemSubsector", "TVItemMWQMSiteList", "TVItemMWQMSiteDuplicate",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemSubsectorAndMWQMSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVItemSubsectorAndMWQMSite_Every_Property_Has_Get_Set_Test()
        {
               TVItem val1 = new TVItem();
               tVItemSubsectorAndMWQMSite.TVItemSubsector = val1;
               Assert.Equal(val1, tVItemSubsectorAndMWQMSite.TVItemSubsector);
               List<TVItem> val2 = new List<TVItem>() { new TVItem(), new TVItem() };
               tVItemSubsectorAndMWQMSite.TVItemMWQMSiteList = val2;
               Assert.Equal(val2, tVItemSubsectorAndMWQMSite.TVItemMWQMSiteList);
               TVItem val3 = new TVItem();
               tVItemSubsectorAndMWQMSite.TVItemMWQMSiteDuplicate = val3;
               Assert.Equal(val3, tVItemSubsectorAndMWQMSite.TVItemMWQMSiteDuplicate);
        }
        #endregion Tests Functions public
    }
}
