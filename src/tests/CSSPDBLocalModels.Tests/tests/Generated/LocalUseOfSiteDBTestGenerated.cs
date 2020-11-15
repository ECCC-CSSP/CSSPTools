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
    public partial class LocalUseOfSiteTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalUseOfSite localUseOfSite { get; set; }
        #endregion Properties

        #region Constructors
        public LocalUseOfSiteTest()
        {
            localUseOfSite = new LocalUseOfSite();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalUseOfSite_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "UseOfSiteID", "SiteTVItemID", "SubsectorTVItemID", "TVType", "Ordinal", "StartYear", "EndYear", "UseWeight", "Weight_perc", "UseEquation", "Param1", "Param2", "Param3", "Param4", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalUseOfSite).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalUseOfSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalUseOfSite_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalUseOfSite).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalUseOfSite).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalUseOfSite_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localUseOfSite.LocalDBCommand = val1;
               Assert.Equal(val1, localUseOfSite.LocalDBCommand);
               int val2 = 45;
               localUseOfSite.UseOfSiteID = val2;
               Assert.Equal(val2, localUseOfSite.UseOfSiteID);
               int val3 = 45;
               localUseOfSite.SiteTVItemID = val3;
               Assert.Equal(val3, localUseOfSite.SiteTVItemID);
               int val4 = 45;
               localUseOfSite.SubsectorTVItemID = val4;
               Assert.Equal(val4, localUseOfSite.SubsectorTVItemID);
               TVTypeEnum val5 = (TVTypeEnum)3;
               localUseOfSite.TVType = val5;
               Assert.Equal(val5, localUseOfSite.TVType);
               int val6 = 45;
               localUseOfSite.Ordinal = val6;
               Assert.Equal(val6, localUseOfSite.Ordinal);
               int val7 = 45;
               localUseOfSite.StartYear = val7;
               Assert.Equal(val7, localUseOfSite.StartYear);
               int val8 = 45;
               localUseOfSite.EndYear = val8;
               Assert.Equal(val8, localUseOfSite.EndYear);
               bool val9 = true;
               localUseOfSite.UseWeight = val9;
               Assert.Equal(val9, localUseOfSite.UseWeight);
               double val10 = 87.9D;
               localUseOfSite.Weight_perc = val10;
               Assert.Equal(val10, localUseOfSite.Weight_perc);
               bool val11 = true;
               localUseOfSite.UseEquation = val11;
               Assert.Equal(val11, localUseOfSite.UseEquation);
               double val12 = 87.9D;
               localUseOfSite.Param1 = val12;
               Assert.Equal(val12, localUseOfSite.Param1);
               double val13 = 87.9D;
               localUseOfSite.Param2 = val13;
               Assert.Equal(val13, localUseOfSite.Param2);
               double val14 = 87.9D;
               localUseOfSite.Param3 = val14;
               Assert.Equal(val14, localUseOfSite.Param3);
               double val15 = 87.9D;
               localUseOfSite.Param4 = val15;
               Assert.Equal(val15, localUseOfSite.Param4);
               DateTime val16 = new DateTime(2010, 3, 4);
               localUseOfSite.LastUpdateDate_UTC = val16;
               Assert.Equal(val16, localUseOfSite.LastUpdateDate_UTC);
               int val17 = 45;
               localUseOfSite.LastUpdateContactTVItemID = val17;
               Assert.Equal(val17, localUseOfSite.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}