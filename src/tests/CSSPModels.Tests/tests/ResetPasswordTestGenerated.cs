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

    public partial class ResetPasswordTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ResetPassword resetPassword { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordTest()
        {
            resetPassword = new ResetPassword();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void ResetPassword_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ResetPasswordID", "Email", "ExpireDate_Local", "Code", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ResetPassword).GetProperties().OrderBy(c => c.Name))
            {
                if (!propertyInfo.GetGetMethod().IsVirtual
                    && propertyInfo.Name != "ValidationResults"
                    && !propertyInfo.CustomAttributes.Where(c => c.AttributeType.Name.Contains("NotMappedAttribute")).Any())
                {
                    Assert.Equal(propNameList[index], propertyInfo.Name);
                    index += 1;
                }
            }

            Assert.Equal(propNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ResetPassword).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        Assert.Equal(propertyInfo.Name, propNameNotMappedList[index]);
                        index += 1;
                    }
                }
            }

            Assert.Equal(propNameNotMappedList.Count, index);

        }
        [Fact]
        public void ResetPassword_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ResetPassword).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ResetPassword).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameCollectionList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void ResetPassword_Has_ValidationResults_Test()
        {
             Assert.True(typeof(ResetPassword).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void ResetPassword_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               resetPassword.ResetPasswordID = val1;
               Assert.Equal(val1, resetPassword.ResetPasswordID);
               string val2 = "Some text";
               resetPassword.Email = val2;
               Assert.Equal(val2, resetPassword.Email);
               DateTime val3 = new DateTime(2010, 3, 4);
               resetPassword.ExpireDate_Local = val3;
               Assert.Equal(val3, resetPassword.ExpireDate_Local);
               string val4 = "Some text";
               resetPassword.Code = val4;
               Assert.Equal(val4, resetPassword.Code);
               DateTime val5 = new DateTime(2010, 3, 4);
               resetPassword.LastUpdateDate_UTC = val5;
               Assert.Equal(val5, resetPassword.LastUpdateDate_UTC);
               int val6 = 45;
               resetPassword.LastUpdateContactTVItemID = val6;
               Assert.Equal(val6, resetPassword.LastUpdateContactTVItemID);
               bool val7 = true;
               resetPassword.HasErrors = val7;
               Assert.Equal(val7, resetPassword.HasErrors);
               IEnumerable<ValidationResult> val24 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               resetPassword.ValidationResults = val24;
               Assert.Equal(val24, resetPassword.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
