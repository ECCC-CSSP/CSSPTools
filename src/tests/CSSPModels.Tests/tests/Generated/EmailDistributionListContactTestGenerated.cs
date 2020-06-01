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
    public partial class EmailDistributionListContactTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private EmailDistributionListContact emailDistributionListContact { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactTest()
        {
            emailDistributionListContact = new EmailDistributionListContact();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void EmailDistributionListContact_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "EmailDistributionListContactID", "EmailDistributionListID", "IsCC", "Name", "Email", "CMPRainfallSeasonal", "CMPWastewater", "EmergencyWeather", "EmergencyWastewater", "ReopeningAllTypes", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionListContact).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionListContact).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void EmailDistributionListContact_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionListContact).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(EmailDistributionListContact).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void EmailDistributionListContact_Has_ValidationResults_Test()
        {
             Assert.True(typeof(EmailDistributionListContact).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void EmailDistributionListContact_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               emailDistributionListContact.EmailDistributionListContactID = val1;
               Assert.Equal(val1, emailDistributionListContact.EmailDistributionListContactID);
               int val2 = 45;
               emailDistributionListContact.EmailDistributionListID = val2;
               Assert.Equal(val2, emailDistributionListContact.EmailDistributionListID);
               bool val3 = true;
               emailDistributionListContact.IsCC = val3;
               Assert.Equal(val3, emailDistributionListContact.IsCC);
               string val4 = "Some text";
               emailDistributionListContact.Name = val4;
               Assert.Equal(val4, emailDistributionListContact.Name);
               string val5 = "Some text";
               emailDistributionListContact.Email = val5;
               Assert.Equal(val5, emailDistributionListContact.Email);
               bool val6 = true;
               emailDistributionListContact.CMPRainfallSeasonal = val6;
               Assert.Equal(val6, emailDistributionListContact.CMPRainfallSeasonal);
               bool val7 = true;
               emailDistributionListContact.CMPWastewater = val7;
               Assert.Equal(val7, emailDistributionListContact.CMPWastewater);
               bool val8 = true;
               emailDistributionListContact.EmergencyWeather = val8;
               Assert.Equal(val8, emailDistributionListContact.EmergencyWeather);
               bool val9 = true;
               emailDistributionListContact.EmergencyWastewater = val9;
               Assert.Equal(val9, emailDistributionListContact.EmergencyWastewater);
               bool val10 = true;
               emailDistributionListContact.ReopeningAllTypes = val10;
               Assert.Equal(val10, emailDistributionListContact.ReopeningAllTypes);
               DateTime val11 = new DateTime(2010, 3, 4);
               emailDistributionListContact.LastUpdateDate_UTC = val11;
               Assert.Equal(val11, emailDistributionListContact.LastUpdateDate_UTC);
               int val12 = 45;
               emailDistributionListContact.LastUpdateContactTVItemID = val12;
               Assert.Equal(val12, emailDistributionListContact.LastUpdateContactTVItemID);
               bool val13 = true;
               emailDistributionListContact.HasErrors = val13;
               Assert.Equal(val13, emailDistributionListContact.HasErrors);
               IEnumerable<ValidationResult> val42 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               emailDistributionListContact.ValidationResults = val42;
               Assert.Equal(val42, emailDistributionListContact.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
