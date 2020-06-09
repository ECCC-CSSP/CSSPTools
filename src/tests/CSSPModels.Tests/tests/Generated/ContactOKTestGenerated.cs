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
    public partial class ContactOKTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactOK contactOK { get; set; }
        #endregion Properties

        #region Constructors
        public ContactOKTest()
        {
            contactOK = new ContactOK();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ContactOK_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ContactID", "ContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ContactOK).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void ContactOK_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               contactOK.ContactID = val1;
               Assert.Equal(val1, contactOK.ContactID);
               int val2 = 45;
               contactOK.ContactTVItemID = val2;
               Assert.Equal(val2, contactOK.ContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
