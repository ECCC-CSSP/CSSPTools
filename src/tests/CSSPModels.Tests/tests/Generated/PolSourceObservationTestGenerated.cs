/*
 * Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
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
    public partial class PolSourceObservationTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObservation polSourceObservation { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationTest()
        {
            polSourceObservation = new PolSourceObservation();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void PolSourceObservation_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "PolSourceObservationID", "PolSourceSiteID", "ObservationDate_Local", "ContactTVItemID", "DesktopReviewed", "Observation_ToBeDeleted", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservation).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservation).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceObservation_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservation).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(PolSourceObservation).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void PolSourceObservation_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               polSourceObservation.PolSourceObservationID = val1;
               Assert.Equal(val1, polSourceObservation.PolSourceObservationID);
               int val2 = 45;
               polSourceObservation.PolSourceSiteID = val2;
               Assert.Equal(val2, polSourceObservation.PolSourceSiteID);
               DateTime val3 = new DateTime(2010, 3, 4);
               polSourceObservation.ObservationDate_Local = val3;
               Assert.Equal(val3, polSourceObservation.ObservationDate_Local);
               int val4 = 45;
               polSourceObservation.ContactTVItemID = val4;
               Assert.Equal(val4, polSourceObservation.ContactTVItemID);
               bool val5 = true;
               polSourceObservation.DesktopReviewed = val5;
               Assert.Equal(val5, polSourceObservation.DesktopReviewed);
               string val6 = "Some text";
               polSourceObservation.Observation_ToBeDeleted = val6;
               Assert.Equal(val6, polSourceObservation.Observation_ToBeDeleted);
               DateTime val7 = new DateTime(2010, 3, 4);
               polSourceObservation.LastUpdateDate_UTC = val7;
               Assert.Equal(val7, polSourceObservation.LastUpdateDate_UTC);
               int val8 = 45;
               polSourceObservation.LastUpdateContactTVItemID = val8;
               Assert.Equal(val8, polSourceObservation.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
