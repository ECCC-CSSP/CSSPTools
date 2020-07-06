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
    public partial class LabSheetTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LabSheet labSheet { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetTest()
        {
            labSheet = new LabSheet();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LabSheet_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LabSheetID", "OtherServerLabSheetID", "SamplingPlanID", "SamplingPlanName", "Year", "Month", "Day", "RunNumber", "SubsectorTVItemID", "MWQMRunTVItemID", "SamplingPlanType", "SampleType", "LabSheetType", "LabSheetStatus", "FileName", "FileLastModifiedDate_Local", "FileContent", "AcceptedOrRejectedByContactTVItemID", "AcceptedOrRejectedDateTime", "RejectReason", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LabSheet).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(LabSheet).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LabSheet_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LabSheet).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(LabSheet).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void LabSheet_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               labSheet.LabSheetID = val1;
               Assert.Equal(val1, labSheet.LabSheetID);
               int val2 = 45;
               labSheet.OtherServerLabSheetID = val2;
               Assert.Equal(val2, labSheet.OtherServerLabSheetID);
               int val3 = 45;
               labSheet.SamplingPlanID = val3;
               Assert.Equal(val3, labSheet.SamplingPlanID);
               string val4 = "Some text";
               labSheet.SamplingPlanName = val4;
               Assert.Equal(val4, labSheet.SamplingPlanName);
               int val5 = 45;
               labSheet.Year = val5;
               Assert.Equal(val5, labSheet.Year);
               int val6 = 45;
               labSheet.Month = val6;
               Assert.Equal(val6, labSheet.Month);
               int val7 = 45;
               labSheet.Day = val7;
               Assert.Equal(val7, labSheet.Day);
               int val8 = 45;
               labSheet.RunNumber = val8;
               Assert.Equal(val8, labSheet.RunNumber);
               int val9 = 45;
               labSheet.SubsectorTVItemID = val9;
               Assert.Equal(val9, labSheet.SubsectorTVItemID);
               int val10 = 45;
               labSheet.MWQMRunTVItemID = val10;
               Assert.Equal(val10, labSheet.MWQMRunTVItemID);
               SamplingPlanTypeEnum val11 = (SamplingPlanTypeEnum)3;
               labSheet.SamplingPlanType = val11;
               Assert.Equal(val11, labSheet.SamplingPlanType);
               SampleTypeEnum val12 = (SampleTypeEnum)3;
               labSheet.SampleType = val12;
               Assert.Equal(val12, labSheet.SampleType);
               LabSheetTypeEnum val13 = (LabSheetTypeEnum)3;
               labSheet.LabSheetType = val13;
               Assert.Equal(val13, labSheet.LabSheetType);
               LabSheetStatusEnum val14 = (LabSheetStatusEnum)3;
               labSheet.LabSheetStatus = val14;
               Assert.Equal(val14, labSheet.LabSheetStatus);
               string val15 = "Some text";
               labSheet.FileName = val15;
               Assert.Equal(val15, labSheet.FileName);
               DateTime val16 = new DateTime(2010, 3, 4);
               labSheet.FileLastModifiedDate_Local = val16;
               Assert.Equal(val16, labSheet.FileLastModifiedDate_Local);
               string val17 = "Some text";
               labSheet.FileContent = val17;
               Assert.Equal(val17, labSheet.FileContent);
               int val18 = 45;
               labSheet.AcceptedOrRejectedByContactTVItemID = val18;
               Assert.Equal(val18, labSheet.AcceptedOrRejectedByContactTVItemID);
               DateTime val19 = new DateTime(2010, 3, 4);
               labSheet.AcceptedOrRejectedDateTime = val19;
               Assert.Equal(val19, labSheet.AcceptedOrRejectedDateTime);
               string val20 = "Some text";
               labSheet.RejectReason = val20;
               Assert.Equal(val20, labSheet.RejectReason);
               DateTime val21 = new DateTime(2010, 3, 4);
               labSheet.LastUpdateDate_UTC = val21;
               Assert.Equal(val21, labSheet.LastUpdateDate_UTC);
               int val22 = 45;
               labSheet.LastUpdateContactTVItemID = val22;
               Assert.Equal(val22, labSheet.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
