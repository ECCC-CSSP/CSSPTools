/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class ContactTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        public ContactTest()
        {
            contact = new Contact();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void Contact_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "ContactID", "DBCommand", "Id", "ContactTVItemID", "LoginEmail", "FirstName", "LastName", "Initial", "CellNumber", "CellNumberConfirmed", "WebName", "ContactTitle", "IsAdmin", "EmailValidated", "Disabled", "IsNew", "SamplingPlanner_ProvincesTVItemID", "PasswordHash", "Token", "HasInternetConnection", "IsLoggedIn", "GoogleMapKeyHash", "AccessFailedCount", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Contact).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(Contact).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Contact_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(Contact).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(Contact).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void Contact_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               contact.ContactID = val1;
               Assert.Equal(val1, contact.ContactID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               contact.DBCommand = val2;
               Assert.Equal(val2, contact.DBCommand);
               string val3 = "Some text";
               contact.Id = val3;
               Assert.Equal(val3, contact.Id);
               int val4 = 45;
               contact.ContactTVItemID = val4;
               Assert.Equal(val4, contact.ContactTVItemID);
               string val5 = "Some text";
               contact.LoginEmail = val5;
               Assert.Equal(val5, contact.LoginEmail);
               string val6 = "Some text";
               contact.FirstName = val6;
               Assert.Equal(val6, contact.FirstName);
               string val7 = "Some text";
               contact.LastName = val7;
               Assert.Equal(val7, contact.LastName);
               string val8 = "Some text";
               contact.Initial = val8;
               Assert.Equal(val8, contact.Initial);
               string val9 = "Some text";
               contact.CellNumber = val9;
               Assert.Equal(val9, contact.CellNumber);
               bool val10 = true;
               contact.CellNumberConfirmed = val10;
               Assert.Equal(val10, contact.CellNumberConfirmed);
               string val11 = "Some text";
               contact.WebName = val11;
               Assert.Equal(val11, contact.WebName);
               ContactTitleEnum val12 = (ContactTitleEnum)3;
               contact.ContactTitle = val12;
               Assert.Equal(val12, contact.ContactTitle);
               bool val13 = true;
               contact.IsAdmin = val13;
               Assert.Equal(val13, contact.IsAdmin);
               bool val14 = true;
               contact.EmailValidated = val14;
               Assert.Equal(val14, contact.EmailValidated);
               bool val15 = true;
               contact.Disabled = val15;
               Assert.Equal(val15, contact.Disabled);
               bool val16 = true;
               contact.IsNew = val16;
               Assert.Equal(val16, contact.IsNew);
               string val17 = "Some text";
               contact.SamplingPlanner_ProvincesTVItemID = val17;
               Assert.Equal(val17, contact.SamplingPlanner_ProvincesTVItemID);
               string val18 = "Some text";
               contact.PasswordHash = val18;
               Assert.Equal(val18, contact.PasswordHash);
               string val19 = "Some text";
               contact.Token = val19;
               Assert.Equal(val19, contact.Token);
               bool val20 = true;
               contact.HasInternetConnection = val20;
               Assert.Equal(val20, contact.HasInternetConnection);
               bool val21 = true;
               contact.IsLoggedIn = val21;
               Assert.Equal(val21, contact.IsLoggedIn);
               string val22 = "Some text";
               contact.GoogleMapKeyHash = val22;
               Assert.Equal(val22, contact.GoogleMapKeyHash);
               int val23 = 45;
               contact.AccessFailedCount = val23;
               Assert.Equal(val23, contact.AccessFailedCount);
               DateTime val24 = new DateTime(2010, 3, 4);
               contact.LastUpdateDate_UTC = val24;
               Assert.Equal(val24, contact.LastUpdateDate_UTC);
               int val25 = 45;
               contact.LastUpdateContactTVItemID = val25;
               Assert.Equal(val25, contact.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
