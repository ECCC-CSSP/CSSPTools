/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
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

namespace CSSPDBModels.Tests
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
            List<string> propNameList = new List<string>() { "ResetPasswordID", "DBCommand", "Email", "ExpireDate_Local", "Code", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

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
                    }
                }
            }


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
                    bool foreignNameExist = foreignNameList.Contains(propertyInfo.Name);
                    Assert.True(foreignNameExist);
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(ResetPassword).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    bool foreignNameCollectionExist = foreignNameCollectionList.Contains(propertyInfo.Name);
                    Assert.True(foreignNameCollectionExist);
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void ResetPassword_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               resetPassword.ResetPasswordID = val1;
               Assert.Equal(val1, resetPassword.ResetPasswordID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               resetPassword.DBCommand = val2;
               Assert.Equal(val2, resetPassword.DBCommand);
               string val3 = "Some text";
               resetPassword.Email = val3;
               Assert.Equal(val3, resetPassword.Email);
               DateTime val4 = new DateTime(2010, 3, 4);
               resetPassword.ExpireDate_Local = val4;
               Assert.Equal(val4, resetPassword.ExpireDate_Local);
               string val5 = "Some text";
               resetPassword.Code = val5;
               Assert.Equal(val5, resetPassword.Code);
               DateTime val6 = new DateTime(2010, 3, 4);
               resetPassword.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, resetPassword.LastUpdateDate_UTC);
               int val7 = 45;
               resetPassword.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, resetPassword.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
