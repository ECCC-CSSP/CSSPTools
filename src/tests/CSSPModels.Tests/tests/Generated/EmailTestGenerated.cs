/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ModelsModelClassNameTestGenerated_cs.exe
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
    public partial class EmailTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Email email { get; set; }
        #endregion Properties

        #region Constructors
        public EmailTest()
        {
            email = new Email();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Email_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "EmailID", "EmailTVItemID", "EmailAddress", "EmailType", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Email).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(Email).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Email_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Email).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(Email).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Email_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               email.EmailID = val1;
               Assert.Equal(val1, email.EmailID);
               int val2 = 45;
               email.EmailTVItemID = val2;
               Assert.Equal(val2, email.EmailTVItemID);
               string val3 = "Some text";
               email.EmailAddress = val3;
               Assert.Equal(val3, email.EmailAddress);
               EmailTypeEnum val4 = (EmailTypeEnum)3;
               email.EmailType = val4;
               Assert.Equal(val4, email.EmailType);
               DateTime val5 = new DateTime(2010, 3, 4);
               email.LastUpdateDate_UTC = val5;
               Assert.Equal(val5, email.LastUpdateDate_UTC);
               int val6 = 45;
               email.LastUpdateContactTVItemID = val6;
               Assert.Equal(val6, email.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
