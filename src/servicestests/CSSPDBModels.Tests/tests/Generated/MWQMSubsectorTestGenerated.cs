/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net6.0\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class MWQMSubsectorTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSubsector mWQMSubsector { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorTest()
        {
            mWQMSubsector = new MWQMSubsector();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMSubsector_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMSubsectorID", "DBCommand", "MWQMSubsectorTVItemID", "SubsectorHistoricKey", "TideLocationSIDText", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsector).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsector).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSubsector_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsector).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMSubsector).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMSubsector_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMSubsector.MWQMSubsectorID = val1;
               Assert.Equal(val1, mWQMSubsector.MWQMSubsectorID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               mWQMSubsector.DBCommand = val2;
               Assert.Equal(val2, mWQMSubsector.DBCommand);
               int val3 = 45;
               mWQMSubsector.MWQMSubsectorTVItemID = val3;
               Assert.Equal(val3, mWQMSubsector.MWQMSubsectorTVItemID);
               string val4 = "Some text";
               mWQMSubsector.SubsectorHistoricKey = val4;
               Assert.Equal(val4, mWQMSubsector.SubsectorHistoricKey);
               string val5 = "Some text";
               mWQMSubsector.TideLocationSIDText = val5;
               Assert.Equal(val5, mWQMSubsector.TideLocationSIDText);
               DateTime val6 = new DateTime(2010, 3, 4);
               mWQMSubsector.LastUpdateDate_UTC = val6;
               Assert.Equal(val6, mWQMSubsector.LastUpdateDate_UTC);
               int val7 = 45;
               mWQMSubsector.LastUpdateContactTVItemID = val7;
               Assert.Equal(val7, mWQMSubsector.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
