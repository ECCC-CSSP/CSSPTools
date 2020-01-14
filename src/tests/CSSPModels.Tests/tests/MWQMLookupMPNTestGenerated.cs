/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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

    public partial class MWQMLookupMPNTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMLookupMPN mWQMLookupMPN { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNTest()
        {
            mWQMLookupMPN = new MWQMLookupMPN();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMLookupMPN_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMLookupMPNID", "Tubes10", "Tubes1", "Tubes01", "MPN_100ml", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMLookupMPN).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMLookupMPN).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMLookupMPN_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMLookupMPN).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMLookupMPN).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.True(foreignNameCollectionList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.Equal(foreignNameCollectionList.Count, index);

        }
        [Fact]
        public void MWQMLookupMPN_Has_ValidationResults_Test()
        {
             Assert.True(typeof(MWQMLookupMPN).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void MWQMLookupMPN_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMLookupMPN.MWQMLookupMPNID = val1;
               Assert.Equal(val1, mWQMLookupMPN.MWQMLookupMPNID);
               int val2 = 45;
               mWQMLookupMPN.Tubes10 = val2;
               Assert.Equal(val2, mWQMLookupMPN.Tubes10);
               int val3 = 45;
               mWQMLookupMPN.Tubes1 = val3;
               Assert.Equal(val3, mWQMLookupMPN.Tubes1);
               int val4 = 45;
               mWQMLookupMPN.Tubes01 = val4;
               Assert.Equal(val4, mWQMLookupMPN.Tubes01);
               int val5 = 45;
               mWQMLookupMPN.MPN_100ml = val5;
               Assert.Equal(val5, mWQMLookupMPN.MPN_100ml);
               DateTime val6 = new DateTime(2010, 3, 4);
               mWQMLookupMPN.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, mWQMLookupMPN.LastUpdateDate_UTC);
               int val7 = 45;
               mWQMLookupMPN.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, mWQMLookupMPN.LastUpdateContactTVItemID);
               bool val8 = true;
               mWQMLookupMPN.HasErrors = val8;
               Assert.Equal(val8, mWQMLookupMPN.HasErrors);
               IEnumerable<ValidationResult> val27 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               mWQMLookupMPN.ValidationResults = val27;
               Assert.Equal(val27, mWQMLookupMPN.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
