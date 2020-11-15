/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class TVItemLinkTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemLink tVItemLink { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkTest()
        {
            tVItemLink = new TVItemLink();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVItemLink_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "TVItemLinkID", "FromTVItemID", "ToTVItemID", "FromTVType", "ToTVType", "StartDateTime_Local", "EndDateTime_Local", "Ordinal", "TVLevel", "TVPath", "ParentTVItemLinkID", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemLink).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(TVItemLink).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TVItemLink_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemLink).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(TVItemLink).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void TVItemLink_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               tVItemLink.TVItemLinkID = val1;
               Assert.Equal(val1, tVItemLink.TVItemLinkID);
               int val2 = 45;
               tVItemLink.FromTVItemID = val2;
               Assert.Equal(val2, tVItemLink.FromTVItemID);
               int val3 = 45;
               tVItemLink.ToTVItemID = val3;
               Assert.Equal(val3, tVItemLink.ToTVItemID);
               TVTypeEnum val4 = (TVTypeEnum)3;
               tVItemLink.FromTVType = val4;
               Assert.Equal(val4, tVItemLink.FromTVType);
               TVTypeEnum val5 = (TVTypeEnum)3;
               tVItemLink.ToTVType = val5;
               Assert.Equal(val5, tVItemLink.ToTVType);
               DateTime val6 = new DateTime(2010, 3, 4);
               tVItemLink.StartDateTime_Local = val6;
               Assert.Equal(val6, tVItemLink.StartDateTime_Local);
               DateTime val7 = new DateTime(2010, 3, 4);
               tVItemLink.EndDateTime_Local = val7;
               Assert.Equal(val7, tVItemLink.EndDateTime_Local);
               int val8 = 45;
               tVItemLink.Ordinal = val8;
               Assert.Equal(val8, tVItemLink.Ordinal);
               int val9 = 45;
               tVItemLink.TVLevel = val9;
               Assert.Equal(val9, tVItemLink.TVLevel);
               string val10 = "Some text";
               tVItemLink.TVPath = val10;
               Assert.Equal(val10, tVItemLink.TVPath);
               int val11 = 45;
               tVItemLink.ParentTVItemLinkID = val11;
               Assert.Equal(val11, tVItemLink.ParentTVItemLinkID);
               DateTime val12 = new DateTime(2010, 3, 4);
               tVItemLink.LastUpdateDate_UTC = val12;
               Assert.Equal(val12, tVItemLink.LastUpdateDate_UTC);
               int val13 = 45;
               tVItemLink.LastUpdateContactTVItemID = val13;
               Assert.Equal(val13, tVItemLink.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}