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
    public partial class NewContactTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private NewContact newContact { get; set; }
        #endregion Properties

        #region Constructors
        public NewContactTest()
        {
            newContact = new NewContact();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void NewContact_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LoginEmail", "FirstName", "LastName", "Initial", "ContactTitle", "ContactTitleText",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(NewContact).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void NewContact_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               newContact.LoginEmail = val1;
               Assert.Equal(val1, newContact.LoginEmail);
               string val2 = "Some text";
               newContact.FirstName = val2;
               Assert.Equal(val2, newContact.FirstName);
               string val3 = "Some text";
               newContact.LastName = val3;
               Assert.Equal(val3, newContact.LastName);
               string val4 = "Some text";
               newContact.Initial = val4;
               Assert.Equal(val4, newContact.Initial);
               ContactTitleEnum val5 = (ContactTitleEnum)3;
               newContact.ContactTitle = val5;
               Assert.Equal(val5, newContact.ContactTitle);
               string val6 = "Some text";
               newContact.ContactTitleText = val6;
               Assert.Equal(val6, newContact.ContactTitleText);
        }
        #endregion Tests Functions public
    }
}
