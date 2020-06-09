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
    public partial class TVItemUserAuthorizationTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemUserAuthorization tVItemUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationTest()
        {
            tVItemUserAuthorization = new TVItemUserAuthorization();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVItemUserAuthorization_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVItemUserAuthorizationID", "ContactTVItemID", "TVItemID1", "TVItemID2", "TVItemID3", "TVItemID4", "TVAuth", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemUserAuthorization).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(TVItemUserAuthorization).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TVItemUserAuthorization_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemUserAuthorization).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(TVItemUserAuthorization).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TVItemUserAuthorization_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               tVItemUserAuthorization.TVItemUserAuthorizationID = val1;
               Assert.Equal(val1, tVItemUserAuthorization.TVItemUserAuthorizationID);
               int val2 = 45;
               tVItemUserAuthorization.ContactTVItemID = val2;
               Assert.Equal(val2, tVItemUserAuthorization.ContactTVItemID);
               int val3 = 45;
               tVItemUserAuthorization.TVItemID1 = val3;
               Assert.Equal(val3, tVItemUserAuthorization.TVItemID1);
               int val4 = 45;
               tVItemUserAuthorization.TVItemID2 = val4;
               Assert.Equal(val4, tVItemUserAuthorization.TVItemID2);
               int val5 = 45;
               tVItemUserAuthorization.TVItemID3 = val5;
               Assert.Equal(val5, tVItemUserAuthorization.TVItemID3);
               int val6 = 45;
               tVItemUserAuthorization.TVItemID4 = val6;
               Assert.Equal(val6, tVItemUserAuthorization.TVItemID4);
               TVAuthEnum val7 = (TVAuthEnum)3;
               tVItemUserAuthorization.TVAuth = val7;
               Assert.Equal(val7, tVItemUserAuthorization.TVAuth);
               DateTime val8 = new DateTime(2010, 3, 4);
               tVItemUserAuthorization.LastUpdateDate_UTC = val8;
               Assert.Equal(val8, tVItemUserAuthorization.LastUpdateDate_UTC);
               int val9 = 45;
               tVItemUserAuthorization.LastUpdateContactTVItemID = val9;
               Assert.Equal(val9, tVItemUserAuthorization.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
