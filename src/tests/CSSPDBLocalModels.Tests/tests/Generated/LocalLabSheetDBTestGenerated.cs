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
    public partial class LocalLabSheetTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LocalLabSheet localLabSheet { get; set; }
        #endregion Properties

        #region Constructors
        public LocalLabSheetTest()
        {
            localLabSheet = new LocalLabSheet();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LocalLabSheet_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LocalDBCommand", "LabSheetID", "OtherServerLabSheetID", "SamplingPlanID", "SamplingPlanName", "Year", "Month", "Day", "RunNumber", "SubsectorTVItemID", "MWQMRunTVItemID", "SamplingPlanType", "SampleType", "LabSheetType", "LabSheetStatus", "FileName", "FileLastModifiedDate_Local", "FileContent", "AcceptedOrRejectedByContactTVItemID", "AcceptedOrRejectedDateTime", "RejectReason", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalLabSheet).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LocalLabSheet).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalLabSheet_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LocalLabSheet).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LocalLabSheet).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LocalLabSheet_Every_Property_Has_Get_Set_Test()
        {
               LocalDBCommandEnum val1 = (LocalDBCommandEnum)3;
               localLabSheet.LocalDBCommand = val1;
               Assert.Equal(val1, localLabSheet.LocalDBCommand);
               int val2 = 45;
               localLabSheet.LabSheetID = val2;
               Assert.Equal(val2, localLabSheet.LabSheetID);
               int val3 = 45;
               localLabSheet.OtherServerLabSheetID = val3;
               Assert.Equal(val3, localLabSheet.OtherServerLabSheetID);
               int val4 = 45;
               localLabSheet.SamplingPlanID = val4;
               Assert.Equal(val4, localLabSheet.SamplingPlanID);
               string val5 = "Some text";
               localLabSheet.SamplingPlanName = val5;
               Assert.Equal(val5, localLabSheet.SamplingPlanName);
               int val6 = 45;
               localLabSheet.Year = val6;
               Assert.Equal(val6, localLabSheet.Year);
               int val7 = 45;
               localLabSheet.Month = val7;
               Assert.Equal(val7, localLabSheet.Month);
               int val8 = 45;
               localLabSheet.Day = val8;
               Assert.Equal(val8, localLabSheet.Day);
               int val9 = 45;
               localLabSheet.RunNumber = val9;
               Assert.Equal(val9, localLabSheet.RunNumber);
               int val10 = 45;
               localLabSheet.SubsectorTVItemID = val10;
               Assert.Equal(val10, localLabSheet.SubsectorTVItemID);
               int val11 = 45;
               localLabSheet.MWQMRunTVItemID = val11;
               Assert.Equal(val11, localLabSheet.MWQMRunTVItemID);
               SamplingPlanTypeEnum val12 = (SamplingPlanTypeEnum)3;
               localLabSheet.SamplingPlanType = val12;
               Assert.Equal(val12, localLabSheet.SamplingPlanType);
               SampleTypeEnum val13 = (SampleTypeEnum)3;
               localLabSheet.SampleType = val13;
               Assert.Equal(val13, localLabSheet.SampleType);
               LabSheetTypeEnum val14 = (LabSheetTypeEnum)3;
               localLabSheet.LabSheetType = val14;
               Assert.Equal(val14, localLabSheet.LabSheetType);
               LabSheetStatusEnum val15 = (LabSheetStatusEnum)3;
               localLabSheet.LabSheetStatus = val15;
               Assert.Equal(val15, localLabSheet.LabSheetStatus);
               string val16 = "Some text";
               localLabSheet.FileName = val16;
               Assert.Equal(val16, localLabSheet.FileName);
               DateTime val17 = new DateTime(2010, 3, 4);
               localLabSheet.FileLastModifiedDate_Local = val17;
               Assert.Equal(val17, localLabSheet.FileLastModifiedDate_Local);
               string val18 = "Some text";
               localLabSheet.FileContent = val18;
               Assert.Equal(val18, localLabSheet.FileContent);
               int val19 = 45;
               localLabSheet.AcceptedOrRejectedByContactTVItemID = val19;
               Assert.Equal(val19, localLabSheet.AcceptedOrRejectedByContactTVItemID);
               DateTime val20 = new DateTime(2010, 3, 4);
               localLabSheet.AcceptedOrRejectedDateTime = val20;
               Assert.Equal(val20, localLabSheet.AcceptedOrRejectedDateTime);
               string val21 = "Some text";
               localLabSheet.RejectReason = val21;
               Assert.Equal(val21, localLabSheet.RejectReason);
               DateTime val22 = new DateTime(2010, 3, 4);
               localLabSheet.LastUpdateDate_UTC = val22;
               Assert.Equal(val22, localLabSheet.LastUpdateDate_UTC);
               int val23 = 45;
               localLabSheet.LastUpdateContactTVItemID = val23;
               Assert.Equal(val23, localLabSheet.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}