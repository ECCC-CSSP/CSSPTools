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
    public partial class LastUpdateAndContactTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LastUpdateAndContact lastUpdateAndContact { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndContactTest()
        {
            lastUpdateAndContact = new LastUpdateAndContact();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LastUpdateAndContact_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LastUpdateAndContactDate_UTC", "LastUpdateAndContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LastUpdateAndContact).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void LastUpdateAndContact_Every_Property_Has_Get_Set_Test()
        {
               DateTime val1 = new DateTime(2010, 3, 4);
               lastUpdateAndContact.LastUpdateAndContactDate_UTC = val1;
               Assert.Equal(val1, lastUpdateAndContact.LastUpdateAndContactDate_UTC);
               int val2 = 45;
               lastUpdateAndContact.LastUpdateAndContactTVItemID = val2;
               Assert.Equal(val2, lastUpdateAndContact.LastUpdateAndContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
