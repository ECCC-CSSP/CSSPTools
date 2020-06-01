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
    public partial class ContactSearchTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactSearch contactSearch { get; set; }
        #endregion Properties

        #region Constructors
        public ContactSearchTest()
        {
            contactSearch = new ContactSearch();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ContactSearch_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ContactID", "ContactTVItemID", "FullName", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ContactSearch).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void ContactSearch_Has_ValidationResults_Test()
        {
             Assert.True(typeof(ContactSearch).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void ContactSearch_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               contactSearch.ContactID = val1;
               Assert.Equal(val1, contactSearch.ContactID);
               int val2 = 45;
               contactSearch.ContactTVItemID = val2;
               Assert.Equal(val2, contactSearch.ContactTVItemID);
               string val3 = "Some text";
               contactSearch.FullName = val3;
               Assert.Equal(val3, contactSearch.FullName);
               bool val4 = true;
               contactSearch.HasErrors = val4;
               Assert.Equal(val4, contactSearch.HasErrors);
               IEnumerable<ValidationResult> val15 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               contactSearch.ValidationResults = val15;
               Assert.Equal(val15, contactSearch.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
