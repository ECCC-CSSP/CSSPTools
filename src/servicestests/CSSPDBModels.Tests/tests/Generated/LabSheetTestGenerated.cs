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
            List<string> propNameList = new List<string>() { "LabSheetID", "DBCommand", "OtherServerLabSheetID", "SamplingPlanID", "SamplingPlanName", "Year", "Month", "Day", "RunNumber", "SubsectorTVItemID", "MWQMRunTVItemID", "SamplingPlanType", "SampleType", "LabSheetType", "LabSheetStatus", "FileName", "FileLastModifiedDate_Local", "FileContent", "AcceptedOrRejectedByContactTVItemID", "AcceptedOrRejectedDateTime", "RejectReason", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

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
               DBCommandEnum val2 = (DBCommandEnum)3;
               labSheet.DBCommand = val2;
               Assert.Equal(val2, labSheet.DBCommand);
               int val3 = 45;
               labSheet.OtherServerLabSheetID = val3;
               Assert.Equal(val3, labSheet.OtherServerLabSheetID);
               int val4 = 45;
               labSheet.SamplingPlanID = val4;
               Assert.Equal(val4, labSheet.SamplingPlanID);
               string val5 = "Some text";
               labSheet.SamplingPlanName = val5;
               Assert.Equal(val5, labSheet.SamplingPlanName);
               int val6 = 45;
               labSheet.Year = val6;
               Assert.Equal(val6, labSheet.Year);
               int val7 = 45;
               labSheet.Month = val7;
               Assert.Equal(val7, labSheet.Month);
               int val8 = 45;
               labSheet.Day = val8;
               Assert.Equal(val8, labSheet.Day);
               int val9 = 45;
               labSheet.RunNumber = val9;
               Assert.Equal(val9, labSheet.RunNumber);
               int val10 = 45;
               labSheet.SubsectorTVItemID = val10;
               Assert.Equal(val10, labSheet.SubsectorTVItemID);
               int val11 = 45;
               labSheet.MWQMRunTVItemID = val11;
               Assert.Equal(val11, labSheet.MWQMRunTVItemID);
               SamplingPlanTypeEnum val12 = (SamplingPlanTypeEnum)3;
               labSheet.SamplingPlanType = val12;
               Assert.Equal(val12, labSheet.SamplingPlanType);
               SampleTypeEnum val13 = (SampleTypeEnum)3;
               labSheet.SampleType = val13;
               Assert.Equal(val13, labSheet.SampleType);
               LabSheetTypeEnum val14 = (LabSheetTypeEnum)3;
               labSheet.LabSheetType = val14;
               Assert.Equal(val14, labSheet.LabSheetType);
               LabSheetStatusEnum val15 = (LabSheetStatusEnum)3;
               labSheet.LabSheetStatus = val15;
               Assert.Equal(val15, labSheet.LabSheetStatus);
               string val16 = "Some text";
               labSheet.FileName = val16;
               Assert.Equal(val16, labSheet.FileName);
               DateTime val17 = new DateTime(2010, 3, 4);
               labSheet.FileLastModifiedDate_Local = val17;
               Assert.Equal(val17, labSheet.FileLastModifiedDate_Local);
               string val18 = "Some text";
               labSheet.FileContent = val18;
               Assert.Equal(val18, labSheet.FileContent);
               int val19 = 45;
               labSheet.AcceptedOrRejectedByContactTVItemID = val19;
               Assert.Equal(val19, labSheet.AcceptedOrRejectedByContactTVItemID);
               DateTime val20 = new DateTime(2010, 3, 4);
               labSheet.AcceptedOrRejectedDateTime = val20;
               Assert.Equal(val20, labSheet.AcceptedOrRejectedDateTime);
               string val21 = "Some text";
               labSheet.RejectReason = val21;
               Assert.Equal(val21, labSheet.RejectReason);
               DateTime val22 = new DateTime(2010, 3, 4);
               labSheet.LastUpdateDate_UTC = val22;
               Assert.Equal(val22, labSheet.LastUpdateDate_UTC);
               int val23 = 45;
               labSheet.LastUpdateContactTVItemID = val23;
               Assert.Equal(val23, labSheet.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
