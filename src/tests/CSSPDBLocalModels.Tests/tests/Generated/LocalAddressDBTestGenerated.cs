/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalModels_TestsGenerated.exe
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

namespace CSSPDBLocalModels.Tests
{
    public partial class LocalAddressTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalAddress localAddress { get; set; }
        #endregion Properties

        #region Constructors
        public LocalAddressTest()
        {
            localAddress = new LocalAddress();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalAddress_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "AddressID", "AddressTVItemID", "AddressType", "CountryTVItemID", "ProvinceTVItemID", "MunicipalityTVItemID", "StreetName", "StreetNumber", "StreetType", "PostalCode", "GoogleAddressText", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalAddress).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalAddress).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalAddress_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalAddress).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalAddress).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalAddress_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localAddress.LocalDBCommand = val1;
               Assert.Equal(val1, localAddress.LocalDBCommand);
               int val2 = 45;
               localAddress.AddressID = val2;
               Assert.Equal(val2, localAddress.AddressID);
               int val3 = 45;
               localAddress.AddressTVItemID = val3;
               Assert.Equal(val3, localAddress.AddressTVItemID);
               AddressTypeEnum val4 = (AddressTypeEnum)3;
               localAddress.AddressType = val4;
               Assert.Equal(val4, localAddress.AddressType);
               int val5 = 45;
               localAddress.CountryTVItemID = val5;
               Assert.Equal(val5, localAddress.CountryTVItemID);
               int val6 = 45;
               localAddress.ProvinceTVItemID = val6;
               Assert.Equal(val6, localAddress.ProvinceTVItemID);
               int val7 = 45;
               localAddress.MunicipalityTVItemID = val7;
               Assert.Equal(val7, localAddress.MunicipalityTVItemID);
               string val8 = "Some text";
               localAddress.StreetName = val8;
               Assert.Equal(val8, localAddress.StreetName);
               string val9 = "Some text";
               localAddress.StreetNumber = val9;
               Assert.Equal(val9, localAddress.StreetNumber);
               StreetTypeEnum val10 = (StreetTypeEnum)3;
               localAddress.StreetType = val10;
               Assert.Equal(val10, localAddress.StreetType);
               string val11 = "Some text";
               localAddress.PostalCode = val11;
               Assert.Equal(val11, localAddress.PostalCode);
               string val12 = "Some text";
               localAddress.GoogleAddressText = val12;
               Assert.Equal(val12, localAddress.GoogleAddressText);
               DateTime val13 = new DateTime(2010, 3, 4);
               localAddress.LastUpdateDate_UTC = val13;
               Assert.Equal(val13, localAddress.LastUpdateDate_UTC);
               int val14 = 45;
               localAddress.LastUpdateContactTVItemID = val14;
               Assert.Equal(val14, localAddress.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
