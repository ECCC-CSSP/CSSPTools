/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 
using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
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
        [TestMethod]
        public void PolSourceSiteEffectTerm_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceSiteEffectTermID", "IsGroup", "UnderGroupID", "EffectTermEN", "EffectTermFR", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties().OrderBy(c => c.Name))
            {
                if (!propertyInfo.GetGetMethod().IsVirtual
                    && propertyInfo.Name != "ValidationResults"
                    && !propertyInfo.CustomAttributes.Where(c => c.AttributeType.Name.Contains("NotMappedAttribute")).Any())
                {
                    Assert.AreEqual(propNameList[index], propertyInfo.Name);
                    index += 1;
                }
            }

            Assert.AreEqual(propNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    if (customAttributeData.AttributeType.Name == "NotMappedAttribute")
                    {
                        Assert.AreEqual(propertyInfo.Name, propNameNotMappedList[index]);
                        index += 1;
                    }
                }
            }

            Assert.AreEqual(propNameNotMappedList.Count, index);

        }
        [TestMethod]
        public void PolSourceSiteEffectTerm_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties())
            {
                if (propertyInfo.GetGetMethod().IsVirtual && !propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.IsTrue(foreignNameList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.AreEqual(foreignNameList.Count, index);

            index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceSiteEffectTerm).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                if (propertyInfo.GetGetMethod().ReturnType.Name.StartsWith("ICollection"))
                {
                    Assert.IsTrue(foreignNameCollectionList.Contains(propertyInfo.Name));
                    index += 1;
                }
            }

            Assert.AreEqual(foreignNameCollectionList.Count, index);

        }
        [TestMethod]
        public void PolSourceSiteEffectTerm_Has_ValidationResults_Test()
        {
             Assert.IsTrue(typeof(PolSourceSiteEffectTerm).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [TestMethod]
        public void PolSourceSiteEffectTerm_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceSiteEffectTerm.PolSourceSiteEffectTermID = val1;
               Assert.AreEqual(val1, polSourceSiteEffectTerm.PolSourceSiteEffectTermID);
               bool val2 = true;
               polSourceSiteEffectTerm.IsGroup = val2;
               Assert.AreEqual(val2, polSourceSiteEffectTerm.IsGroup);
               int val3 = 45;
               polSourceSiteEffectTerm.UnderGroupID = val3;
               Assert.AreEqual(val3, polSourceSiteEffectTerm.UnderGroupID);
               string val4 = "Some text";
               polSourceSiteEffectTerm.EffectTermEN = val4;
               Assert.AreEqual(val4, polSourceSiteEffectTerm.EffectTermEN);
               string val5 = "Some text";
               polSourceSiteEffectTerm.EffectTermFR = val5;
               Assert.AreEqual(val5, polSourceSiteEffectTerm.EffectTermFR);
               DateTime val6 = new DateTime(2010, 3, 4);
               polSourceSiteEffectTerm.LastUpdateDate_UTC = val6;
               Assert.AreEqual(val6, polSourceSiteEffectTerm.LastUpdateDate_UTC);
               int val7 = 45;
               polSourceSiteEffectTerm.LastUpdateContactTVItemID = val7;
               Assert.AreEqual(val7, polSourceSiteEffectTerm.LastUpdateContactTVItemID);
               bool val8 = true;
               polSourceSiteEffectTerm.HasErrors = val8;
               Assert.AreEqual(val8, polSourceSiteEffectTerm.HasErrors);
               IEnumerable<ValidationResult> val27 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               polSourceSiteEffectTerm.ValidationResults = val27;
               Assert.AreEqual(val27, polSourceSiteEffectTerm.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
