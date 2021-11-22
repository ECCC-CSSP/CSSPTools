/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net5.0\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class DrogueRunTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private DrogueRun drogueRun { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunTest()
        {
            drogueRun = new DrogueRun();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void DrogueRun_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "DrogueRunID", "DBCommand", "SubsectorTVItemID", "DrogueNumber", "DrogueType", "RunStartDateTime", "IsRisingTide", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(DrogueRun).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(DrogueRun).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void DrogueRun_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(DrogueRun).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(DrogueRun).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void DrogueRun_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               drogueRun.DrogueRunID = val1;
               Assert.Equal(val1, drogueRun.DrogueRunID);
               DBCommandEnum val2 = (DBCommandEnum)3;
               drogueRun.DBCommand = val2;
               Assert.Equal(val2, drogueRun.DBCommand);
               int val3 = 45;
               drogueRun.SubsectorTVItemID = val3;
               Assert.Equal(val3, drogueRun.SubsectorTVItemID);
               int val4 = 45;
               drogueRun.DrogueNumber = val4;
               Assert.Equal(val4, drogueRun.DrogueNumber);
               DrogueTypeEnum val5 = (DrogueTypeEnum)3;
               drogueRun.DrogueType = val5;
               Assert.Equal(val5, drogueRun.DrogueType);
               DateTime val6 = new DateTime(2010, 3, 4);
               drogueRun.RunStartDateTime = val6;
               Assert.Equal(val6, drogueRun.RunStartDateTime);
               bool val7 = true;
               drogueRun.IsRisingTide = val7;
               Assert.Equal(val7, drogueRun.IsRisingTide);
               DateTime val8 = new DateTime(2010, 3, 4);
               drogueRun.LastUpdateDate_UTC = val8;
               Assert.Equal(val8, drogueRun.LastUpdateDate_UTC);
               int val9 = 45;
               drogueRun.LastUpdateContactTVItemID = val9;
               Assert.Equal(val9, drogueRun.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}