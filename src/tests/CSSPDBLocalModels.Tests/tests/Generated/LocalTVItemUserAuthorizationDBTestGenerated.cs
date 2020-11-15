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
    public partial class LocalTVItemUserAuthorizationTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalTVItemUserAuthorization localTVItemUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVItemUserAuthorizationTest()
        {
            localTVItemUserAuthorization = new LocalTVItemUserAuthorization();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalTVItemUserAuthorization_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "TVItemUserAuthorizationID", "ContactTVItemID", "TVItemID1", "TVItemID2", "TVItemID3", "TVItemID4", "TVAuth", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItemUserAuthorization).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItemUserAuthorization).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalTVItemUserAuthorization_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItemUserAuthorization).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalTVItemUserAuthorization).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalTVItemUserAuthorization_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localTVItemUserAuthorization.LocalDBCommand = val1;
               Assert.Equal(val1, localTVItemUserAuthorization.LocalDBCommand);
               int val2 = 45;
               localTVItemUserAuthorization.TVItemUserAuthorizationID = val2;
               Assert.Equal(val2, localTVItemUserAuthorization.TVItemUserAuthorizationID);
               int val3 = 45;
               localTVItemUserAuthorization.ContactTVItemID = val3;
               Assert.Equal(val3, localTVItemUserAuthorization.ContactTVItemID);
               int val4 = 45;
               localTVItemUserAuthorization.TVItemID1 = val4;
               Assert.Equal(val4, localTVItemUserAuthorization.TVItemID1);
               int val5 = 45;
               localTVItemUserAuthorization.TVItemID2 = val5;
               Assert.Equal(val5, localTVItemUserAuthorization.TVItemID2);
               int val6 = 45;
               localTVItemUserAuthorization.TVItemID3 = val6;
               Assert.Equal(val6, localTVItemUserAuthorization.TVItemID3);
               int val7 = 45;
               localTVItemUserAuthorization.TVItemID4 = val7;
               Assert.Equal(val7, localTVItemUserAuthorization.TVItemID4);
               TVAuthEnum val8 = (TVAuthEnum)3;
               localTVItemUserAuthorization.TVAuth = val8;
               Assert.Equal(val8, localTVItemUserAuthorization.TVAuth);
               DateTime val9 = new DateTime(2010, 3, 4);
               localTVItemUserAuthorization.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, localTVItemUserAuthorization.LastUpdateDate_UTC);
               int val10 = 45;
               localTVItemUserAuthorization.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, localTVItemUserAuthorization.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}