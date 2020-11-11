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
    public partial class LocalSpillTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalSpill localSpill { get; set; }
        #endregion Properties

        #region Constructors
        public LocalSpillTest()
        {
            localSpill = new LocalSpill();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalSpill_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "SpillID", "MunicipalityTVItemID", "InfrastructureTVItemID", "StartDateTime_Local", "EndDateTime_Local", "AverageFlow_m3_day", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalSpill).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalSpill).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalSpill_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalSpill).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalSpill).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalSpill_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localSpill.LocalDBCommand = val1;
               Assert.Equal(val1, localSpill.LocalDBCommand);
               int val2 = 45;
               localSpill.SpillID = val2;
               Assert.Equal(val2, localSpill.SpillID);
               int val3 = 45;
               localSpill.MunicipalityTVItemID = val3;
               Assert.Equal(val3, localSpill.MunicipalityTVItemID);
               int val4 = 45;
               localSpill.InfrastructureTVItemID = val4;
               Assert.Equal(val4, localSpill.InfrastructureTVItemID);
               DateTime val5 = new DateTime(2010, 3, 4);
               localSpill.StartDateTime_Local = val5;
               Assert.Equal(val5, localSpill.StartDateTime_Local);
               DateTime val6 = new DateTime(2010, 3, 4);
               localSpill.EndDateTime_Local = val6;
               Assert.Equal(val6, localSpill.EndDateTime_Local);
               double val7 = 87.9D;
               localSpill.AverageFlow_m3_day = val7;
               Assert.Equal(val7, localSpill.AverageFlow_m3_day);
               DateTime val8 = new DateTime(2010, 3, 4);
               localSpill.LastUpdateDate_UTC = val8;
               Assert.Equal(val8, localSpill.LastUpdateDate_UTC);
               int val9 = 45;
               localSpill.LastUpdateContactTVItemID = val9;
               Assert.Equal(val9, localSpill.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
