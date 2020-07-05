/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class PolSourceSiteEffectTermTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceSiteEffectTerm polSourceSiteEffectTerm { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermTest()
        {
            polSourceSiteEffectTerm = new PolSourceSiteEffectTerm();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceSiteEffectTerm_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceSiteEffectTermID", "IsGroup", "UnderGroupID", "EffectTermEN", "EffectTermFR", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceSiteEffectTerm_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceSiteEffectTerm_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceSiteEffectTerm.PolSourceSiteEffectTermID = val1;
               Assert.Equal(val1, polSourceSiteEffectTerm.PolSourceSiteEffectTermID);
               bool val2 = true;
               polSourceSiteEffectTerm.IsGroup = val2;
               Assert.Equal(val2, polSourceSiteEffectTerm.IsGroup);
               int val3 = 45;
               polSourceSiteEffectTerm.UnderGroupID = val3;
               Assert.Equal(val3, polSourceSiteEffectTerm.UnderGroupID);
               string val4 = "Some text";
               polSourceSiteEffectTerm.EffectTermEN = val4;
               Assert.Equal(val4, polSourceSiteEffectTerm.EffectTermEN);
               string val5 = "Some text";
               polSourceSiteEffectTerm.EffectTermFR = val5;
               Assert.Equal(val5, polSourceSiteEffectTerm.EffectTermFR);
               DateTime val6 = new DateTime(2010, 3, 4);
               polSourceSiteEffectTerm.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, polSourceSiteEffectTerm.LastUpdateDate_UTC);
               int val7 = 45;
               polSourceSiteEffectTerm.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, polSourceSiteEffectTerm.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
