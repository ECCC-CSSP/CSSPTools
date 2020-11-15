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
    public partial class LocalSamplingPlanEmailTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalSamplingPlanEmail localSamplingPlanEmail { get; set; }
        #endregion Properties

        #region Constructors
        public LocalSamplingPlanEmailTest()
        {
            localSamplingPlanEmail = new LocalSamplingPlanEmail();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalSamplingPlanEmail_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "SamplingPlanEmailID", "SamplingPlanID", "Email", "IsContractor", "LabSheetHasValueOver500", "LabSheetReceived", "LabSheetAccepted", "LabSheetRejected", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalSamplingPlanEmail).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalSamplingPlanEmail).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalSamplingPlanEmail_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalSamplingPlanEmail).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalSamplingPlanEmail).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalSamplingPlanEmail_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localSamplingPlanEmail.LocalDBCommand = val1;
               Assert.Equal(val1, localSamplingPlanEmail.LocalDBCommand);
               int val2 = 45;
               localSamplingPlanEmail.SamplingPlanEmailID = val2;
               Assert.Equal(val2, localSamplingPlanEmail.SamplingPlanEmailID);
               int val3 = 45;
               localSamplingPlanEmail.SamplingPlanID = val3;
               Assert.Equal(val3, localSamplingPlanEmail.SamplingPlanID);
               string val4 = "Some text";
               localSamplingPlanEmail.Email = val4;
               Assert.Equal(val4, localSamplingPlanEmail.Email);
               bool val5 = true;
               localSamplingPlanEmail.IsContractor = val5;
               Assert.Equal(val5, localSamplingPlanEmail.IsContractor);
               bool val6 = true;
               localSamplingPlanEmail.LabSheetHasValueOver500 = val6;
               Assert.Equal(val6, localSamplingPlanEmail.LabSheetHasValueOver500);
               bool val7 = true;
               localSamplingPlanEmail.LabSheetReceived = val7;
               Assert.Equal(val7, localSamplingPlanEmail.LabSheetReceived);
               bool val8 = true;
               localSamplingPlanEmail.LabSheetAccepted = val8;
               Assert.Equal(val8, localSamplingPlanEmail.LabSheetAccepted);
               bool val9 = true;
               localSamplingPlanEmail.LabSheetRejected = val9;
               Assert.Equal(val9, localSamplingPlanEmail.LabSheetRejected);
               DateTime val10 = new DateTime(2010, 3, 4);
               localSamplingPlanEmail.LastUpdateDate_UTC = val10;
               Assert.Equal(val10, localSamplingPlanEmail.LastUpdateDate_UTC);
               int val11 = 45;
               localSamplingPlanEmail.LastUpdateContactTVItemID = val11;
               Assert.Equal(val11, localSamplingPlanEmail.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}