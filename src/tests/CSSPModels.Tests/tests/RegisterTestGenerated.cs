/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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

    public partial class RegisterTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Register register { get; set; }
        #endregion Properties

        #region Constructors
        public RegisterTest()
        {
            register = new Register();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Register_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LoginEmail", "FirstName", "Initial", "LastName", "WebName", "Password", "ConfirmPassword", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Register).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void Register_Has_ValidationResults_Test()
        {
             Assert.True(typeof(Register).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void Register_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               register.LoginEmail = val1;
               Assert.Equal(val1, register.LoginEmail);
               string val2 = "Some text";
               register.FirstName = val2;
               Assert.Equal(val2, register.FirstName);
               string val3 = "Some text";
               register.Initial = val3;
               Assert.Equal(val3, register.Initial);
               string val4 = "Some text";
               register.LastName = val4;
               Assert.Equal(val4, register.LastName);
               string val5 = "Some text";
               register.WebName = val5;
               Assert.Equal(val5, register.WebName);
               string val6 = "Some text";
               register.Password = val6;
               Assert.Equal(val6, register.Password);
               string val7 = "Some text";
               register.ConfirmPassword = val7;
               Assert.Equal(val7, register.ConfirmPassword);
               bool val8 = true;
               register.HasErrors = val8;
               Assert.Equal(val8, register.HasErrors);
               IEnumerable<ValidationResult> val27 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               register.ValidationResults = val27;
               Assert.Equal(val27, register.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
