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
using CSSPModels.Resources;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class DrogueRunPositionTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private DrogueRunPosition drogueRunPosition { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionTest()
        {
            drogueRunPosition = new DrogueRunPosition();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void DrogueRunPosition_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "DrogueRunPositionID", "DrogueRunID", "Ordinal", "StepLat", "StepLng", "StepDateTime_Local", "CalculatedSpeed_m_s", "CalculatedDirection_deg", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() { "HasErrors",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(DrogueRunPosition).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(DrogueRunPosition).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void DrogueRunPosition_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(DrogueRunPosition).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(DrogueRunPosition).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void DrogueRunPosition_Has_ValidationResults_Test()
        {
             Assert.True(typeof(DrogueRunPosition).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void DrogueRunPosition_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               drogueRunPosition.DrogueRunPositionID = val1;
               Assert.Equal(val1, drogueRunPosition.DrogueRunPositionID);
               int val2 = 45;
               drogueRunPosition.DrogueRunID = val2;
               Assert.Equal(val2, drogueRunPosition.DrogueRunID);
               int val3 = 45;
               drogueRunPosition.Ordinal = val3;
               Assert.Equal(val3, drogueRunPosition.Ordinal);
               double val4 = 87.9D;
               drogueRunPosition.StepLat = val4;
               Assert.Equal(val4, drogueRunPosition.StepLat);
               double val5 = 87.9D;
               drogueRunPosition.StepLng = val5;
               Assert.Equal(val5, drogueRunPosition.StepLng);
               DateTime val6 = new DateTime(2010, 3, 4);
               drogueRunPosition.StepDateTime_Local = val6;
               Assert.Equal(val6, drogueRunPosition.StepDateTime_Local);
               double val7 = 87.9D;
               drogueRunPosition.CalculatedSpeed_m_s = val7;
               Assert.Equal(val7, drogueRunPosition.CalculatedSpeed_m_s);
               double val8 = 87.9D;
               drogueRunPosition.CalculatedDirection_deg = val8;
               Assert.Equal(val8, drogueRunPosition.CalculatedDirection_deg);
               DateTime val9 = new DateTime(2010, 3, 4);
               drogueRunPosition.LastUpdateDate_UTC = val9;
               Assert.Equal(val9, drogueRunPosition.LastUpdateDate_UTC);
               int val10 = 45;
               drogueRunPosition.LastUpdateContactTVItemID = val10;
               Assert.Equal(val10, drogueRunPosition.LastUpdateContactTVItemID);
               bool val11 = true;
               drogueRunPosition.HasErrors = val11;
               Assert.Equal(val11, drogueRunPosition.HasErrors);
               IEnumerable<ValidationResult> val36 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               drogueRunPosition.ValidationResults = val36;
               Assert.Equal(val36, drogueRunPosition.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
