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
    public partial class TVItemInfrastructureTypeTVItemLinkTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemInfrastructureTypeTVItemLink tVItemInfrastructureTypeTVItemLink { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkTest()
        {
            tVItemInfrastructureTypeTVItemLink = new TVItemInfrastructureTypeTVItemLink();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void TVItemInfrastructureTypeTVItemLink_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "InfrastructureType", "SeeOtherMunicipalityTVItemID", "InfrastructureTypeText", "TVItem", "TVItemLinkList", "FlowTo", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(TVItemInfrastructureTypeTVItemLink).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void TVItemInfrastructureTypeTVItemLink_Has_ValidationResults_Test()
        {
             Assert.True(typeof(TVItemInfrastructureTypeTVItemLink).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void TVItemInfrastructureTypeTVItemLink_Every_Property_Has_Get_Set_Test()
        {
               InfrastructureTypeEnum val1 = (InfrastructureTypeEnum)3;
               tVItemInfrastructureTypeTVItemLink.InfrastructureType = val1;
               Assert.Equal(val1, tVItemInfrastructureTypeTVItemLink.InfrastructureType);
               int val2 = 45;
               tVItemInfrastructureTypeTVItemLink.SeeOtherMunicipalityTVItemID = val2;
               Assert.Equal(val2, tVItemInfrastructureTypeTVItemLink.SeeOtherMunicipalityTVItemID);
               string val3 = "Some text";
               tVItemInfrastructureTypeTVItemLink.InfrastructureTypeText = val3;
               Assert.Equal(val3, tVItemInfrastructureTypeTVItemLink.InfrastructureTypeText);
               TVItem val4 = new TVItem();
               tVItemInfrastructureTypeTVItemLink.TVItem = val4;
               Assert.Equal(val4, tVItemInfrastructureTypeTVItemLink.TVItem);
               List<TVItemLink> val5 = new List<TVItemLink>() { new TVItemLink(), new TVItemLink() };
               tVItemInfrastructureTypeTVItemLink.TVItemLinkList = val5;
               Assert.Equal(val5, tVItemInfrastructureTypeTVItemLink.TVItemLinkList);
               TVItemInfrastructureTypeTVItemLink val6 = new TVItemInfrastructureTypeTVItemLink();
               tVItemInfrastructureTypeTVItemLink.FlowTo = val6;
               Assert.Equal(val6, tVItemInfrastructureTypeTVItemLink.FlowTo);
               bool val7 = true;
               tVItemInfrastructureTypeTVItemLink.HasErrors = val7;
               Assert.Equal(val7, tVItemInfrastructureTypeTVItemLink.HasErrors);
               IEnumerable<ValidationResult> val24 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               tVItemInfrastructureTypeTVItemLink.ValidationResults = val24;
               Assert.Equal(val24, tVItemInfrastructureTypeTVItemLink.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
