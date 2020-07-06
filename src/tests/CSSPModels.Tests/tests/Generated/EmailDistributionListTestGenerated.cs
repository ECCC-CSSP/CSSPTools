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
    public partial class EmailDistributionListTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private EmailDistributionList emailDistributionList { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListTest()
        {
            emailDistributionList = new EmailDistributionList();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void EmailDistributionList_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "EmailDistributionListID", "ParentTVItemID", "Ordinal", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionList).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionList).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void EmailDistributionList_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionList).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionList).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void EmailDistributionList_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               emailDistributionList.EmailDistributionListID = val1;
               Assert.Equal(val1, emailDistributionList.EmailDistributionListID);
               int val2 = 45;
               emailDistributionList.ParentTVItemID = val2;
               Assert.Equal(val2, emailDistributionList.ParentTVItemID);
               int val3 = 45;
               emailDistributionList.Ordinal = val3;
               Assert.Equal(val3, emailDistributionList.Ordinal);
               DateTime val4 = new DateTime(2010, 3, 4);
               emailDistributionList.LastUpdateDate_UTC = val4;
               Assert.Equal(val4, emailDistributionList.LastUpdateDate_UTC);
               int val5 = 45;
               emailDistributionList.LastUpdateContactTVItemID = val5;
               Assert.Equal(val5, emailDistributionList.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
