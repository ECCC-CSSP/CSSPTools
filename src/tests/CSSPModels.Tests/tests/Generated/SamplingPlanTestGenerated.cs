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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;

namespace CSSPModels.Tests
{
    public partial class SamplingPlanTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SamplingPlan samplingPlan { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanTest()
        {
            samplingPlan = new SamplingPlan();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SamplingPlan_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "SamplingPlanID", "IsActive", "SamplingPlanName", "ForGroupName", "SampleType", "SamplingPlanType", "LabSheetType", "ProvinceTVItemID", "CreatorTVItemID", "Year", "AccessCode", "DailyDuplicatePrecisionCriteria", "IntertechDuplicatePrecisionCriteria", "IncludeLaboratoryQAQC", "ApprovalCode", "SamplingPlanFileTVItemID", "AnalyzeMethodDefault", "SampleMatrixDefault", "LaboratoryDefault", "BackupDirectory", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlan).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlan).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SamplingPlan_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlan).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlan).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void SamplingPlan_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               samplingPlan.SamplingPlanID = val1;
               Assert.Equal(val1, samplingPlan.SamplingPlanID);
               bool val2 = true;
               samplingPlan.IsActive = val2;
               Assert.Equal(val2, samplingPlan.IsActive);
               string val3 = "Some text";
               samplingPlan.SamplingPlanName = val3;
               Assert.Equal(val3, samplingPlan.SamplingPlanName);
               string val4 = "Some text";
               samplingPlan.ForGroupName = val4;
               Assert.Equal(val4, samplingPlan.ForGroupName);
               SampleTypeEnum val5 = (SampleTypeEnum)3;
               samplingPlan.SampleType = val5;
               Assert.Equal(val5, samplingPlan.SampleType);
               SamplingPlanTypeEnum val6 = (SamplingPlanTypeEnum)3;
               samplingPlan.SamplingPlanType = val6;
               Assert.Equal(val6, samplingPlan.SamplingPlanType);
               LabSheetTypeEnum val7 = (LabSheetTypeEnum)3;
               samplingPlan.LabSheetType = val7;
               Assert.Equal(val7, samplingPlan.LabSheetType);
               int val8 = 45;
               samplingPlan.ProvinceTVItemID = val8;
               Assert.Equal(val8, samplingPlan.ProvinceTVItemID);
               int val9 = 45;
               samplingPlan.CreatorTVItemID = val9;
               Assert.Equal(val9, samplingPlan.CreatorTVItemID);
               int val10 = 45;
               samplingPlan.Year = val10;
               Assert.Equal(val10, samplingPlan.Year);
               string val11 = "Some text";
               samplingPlan.AccessCode = val11;
               Assert.Equal(val11, samplingPlan.AccessCode);
               double val12 = 87.9D;
               samplingPlan.DailyDuplicatePrecisionCriteria = val12;
               Assert.Equal(val12, samplingPlan.DailyDuplicatePrecisionCriteria);
               double val13 = 87.9D;
               samplingPlan.IntertechDuplicatePrecisionCriteria = val13;
               Assert.Equal(val13, samplingPlan.IntertechDuplicatePrecisionCriteria);
               bool val14 = true;
               samplingPlan.IncludeLaboratoryQAQC = val14;
               Assert.Equal(val14, samplingPlan.IncludeLaboratoryQAQC);
               string val15 = "Some text";
               samplingPlan.ApprovalCode = val15;
               Assert.Equal(val15, samplingPlan.ApprovalCode);
               int val16 = 45;
               samplingPlan.SamplingPlanFileTVItemID = val16;
               Assert.Equal(val16, samplingPlan.SamplingPlanFileTVItemID);
               AnalyzeMethodEnum val17 = (AnalyzeMethodEnum)3;
               samplingPlan.AnalyzeMethodDefault = val17;
               Assert.Equal(val17, samplingPlan.AnalyzeMethodDefault);
               SampleMatrixEnum val18 = (SampleMatrixEnum)3;
               samplingPlan.SampleMatrixDefault = val18;
               Assert.Equal(val18, samplingPlan.SampleMatrixDefault);
               LaboratoryEnum val19 = (LaboratoryEnum)3;
               samplingPlan.LaboratoryDefault = val19;
               Assert.Equal(val19, samplingPlan.LaboratoryDefault);
               string val20 = "Some text";
               samplingPlan.BackupDirectory = val20;
               Assert.Equal(val20, samplingPlan.BackupDirectory);
               DateTime val21 = new DateTime(2010, 3, 4);
               samplingPlan.LastUpdateDate_UTC = val21;
               Assert.Equal(val21, samplingPlan.LastUpdateDate_UTC);
               int val22 = 45;
               samplingPlan.LastUpdateContactTVItemID = val22;
               Assert.Equal(val22, samplingPlan.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}
