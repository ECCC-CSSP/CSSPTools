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
    public partial class MWQMSampleDuplicateItemTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSampleDuplicateItem mWQMSampleDuplicateItem { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleDuplicateItemTest()
        {
            mWQMSampleDuplicateItem = new MWQMSampleDuplicateItem();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSampleDuplicateItem_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ParentSite", "DuplicateSite",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSampleDuplicateItem).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void MWQMSampleDuplicateItem_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               mWQMSampleDuplicateItem.ParentSite = val1;
               Assert.Equal(val1, mWQMSampleDuplicateItem.ParentSite);
               string val2 = "Some text";
               mWQMSampleDuplicateItem.DuplicateSite = val2;
               Assert.Equal(val2, mWQMSampleDuplicateItem.DuplicateSite);
        }
        #endregion Tests Functions public
    }
}