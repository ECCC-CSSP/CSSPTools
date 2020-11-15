/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBModels_TestsGenerated.exe
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
    public partial class MWQMRunTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMRun mWQMRun { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunTest()
        {
            mWQMRun = new MWQMRun();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void MWQMRun_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "MWQMRunID", "SubsectorTVItemID", "MWQMRunTVItemID", "RunSampleType", "DateTime_Local", "RunNumber", "StartDateTime_Local", "EndDateTime_Local", "LabReceivedDateTime_Local", "TemperatureControl1_C", "TemperatureControl2_C", "SeaStateAtStart_BeaufortScale", "SeaStateAtEnd_BeaufortScale", "WaterLevelAtBrook_m", "WaveHightAtStart_m", "WaveHightAtEnd_m", "SampleCrewInitials", "AnalyzeMethod", "SampleMatrix", "Laboratory", "SampleStatus", "LabSampleApprovalContactTVItemID", "LabAnalyzeBath1IncubationStartDateTime_Local", "LabAnalyzeBath2IncubationStartDateTime_Local", "LabAnalyzeBath3IncubationStartDateTime_Local", "LabRunSampleApprovalDateTime_Local", "Tide_Start", "Tide_End", "RainDay0_mm", "RainDay1_mm", "RainDay2_mm", "RainDay3_mm", "RainDay4_mm", "RainDay5_mm", "RainDay6_mm", "RainDay7_mm", "RainDay8_mm", "RainDay9_mm", "RainDay10_mm", "RemoveFromStat", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMRun).GetProperties().OrderBy(c => c.Name))
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMRun).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMRun_Navigation_Test()
        {
            List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
            List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(MWQMRun).GetProperties())
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
            foreach (PropertyInfo propertyInfo in typeof(MWQMRun).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
        public void MWQMRun_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               mWQMRun.MWQMRunID = val1;
               Assert.Equal(val1, mWQMRun.MWQMRunID);
               int val2 = 45;
               mWQMRun.SubsectorTVItemID = val2;
               Assert.Equal(val2, mWQMRun.SubsectorTVItemID);
               int val3 = 45;
               mWQMRun.MWQMRunTVItemID = val3;
               Assert.Equal(val3, mWQMRun.MWQMRunTVItemID);
               SampleTypeEnum val4 = (SampleTypeEnum)3;
               mWQMRun.RunSampleType = val4;
               Assert.Equal(val4, mWQMRun.RunSampleType);
               DateTime val5 = new DateTime(2010, 3, 4);
               mWQMRun.DateTime_Local = val5;
               Assert.Equal(val5, mWQMRun.DateTime_Local);
               int val6 = 45;
               mWQMRun.RunNumber = val6;
               Assert.Equal(val6, mWQMRun.RunNumber);
               DateTime val7 = new DateTime(2010, 3, 4);
               mWQMRun.StartDateTime_Local = val7;
               Assert.Equal(val7, mWQMRun.StartDateTime_Local);
               DateTime val8 = new DateTime(2010, 3, 4);
               mWQMRun.EndDateTime_Local = val8;
               Assert.Equal(val8, mWQMRun.EndDateTime_Local);
               DateTime val9 = new DateTime(2010, 3, 4);
               mWQMRun.LabReceivedDateTime_Local = val9;
               Assert.Equal(val9, mWQMRun.LabReceivedDateTime_Local);
               double val10 = 87.9D;
               mWQMRun.TemperatureControl1_C = val10;
               Assert.Equal(val10, mWQMRun.TemperatureControl1_C);
               double val11 = 87.9D;
               mWQMRun.TemperatureControl2_C = val11;
               Assert.Equal(val11, mWQMRun.TemperatureControl2_C);
               BeaufortScaleEnum val12 = (BeaufortScaleEnum)3;
               mWQMRun.SeaStateAtStart_BeaufortScale = val12;
               Assert.Equal(val12, mWQMRun.SeaStateAtStart_BeaufortScale);
               BeaufortScaleEnum val13 = (BeaufortScaleEnum)3;
               mWQMRun.SeaStateAtEnd_BeaufortScale = val13;
               Assert.Equal(val13, mWQMRun.SeaStateAtEnd_BeaufortScale);
               double val14 = 87.9D;
               mWQMRun.WaterLevelAtBrook_m = val14;
               Assert.Equal(val14, mWQMRun.WaterLevelAtBrook_m);
               double val15 = 87.9D;
               mWQMRun.WaveHightAtStart_m = val15;
               Assert.Equal(val15, mWQMRun.WaveHightAtStart_m);
               double val16 = 87.9D;
               mWQMRun.WaveHightAtEnd_m = val16;
               Assert.Equal(val16, mWQMRun.WaveHightAtEnd_m);
               string val17 = "Some text";
               mWQMRun.SampleCrewInitials = val17;
               Assert.Equal(val17, mWQMRun.SampleCrewInitials);
               AnalyzeMethodEnum val18 = (AnalyzeMethodEnum)3;
               mWQMRun.AnalyzeMethod = val18;
               Assert.Equal(val18, mWQMRun.AnalyzeMethod);
               SampleMatrixEnum val19 = (SampleMatrixEnum)3;
               mWQMRun.SampleMatrix = val19;
               Assert.Equal(val19, mWQMRun.SampleMatrix);
               LaboratoryEnum val20 = (LaboratoryEnum)3;
               mWQMRun.Laboratory = val20;
               Assert.Equal(val20, mWQMRun.Laboratory);
               SampleStatusEnum val21 = (SampleStatusEnum)3;
               mWQMRun.SampleStatus = val21;
               Assert.Equal(val21, mWQMRun.SampleStatus);
               int val22 = 45;
               mWQMRun.LabSampleApprovalContactTVItemID = val22;
               Assert.Equal(val22, mWQMRun.LabSampleApprovalContactTVItemID);
               DateTime val23 = new DateTime(2010, 3, 4);
               mWQMRun.LabAnalyzeBath1IncubationStartDateTime_Local = val23;
               Assert.Equal(val23, mWQMRun.LabAnalyzeBath1IncubationStartDateTime_Local);
               DateTime val24 = new DateTime(2010, 3, 4);
               mWQMRun.LabAnalyzeBath2IncubationStartDateTime_Local = val24;
               Assert.Equal(val24, mWQMRun.LabAnalyzeBath2IncubationStartDateTime_Local);
               DateTime val25 = new DateTime(2010, 3, 4);
               mWQMRun.LabAnalyzeBath3IncubationStartDateTime_Local = val25;
               Assert.Equal(val25, mWQMRun.LabAnalyzeBath3IncubationStartDateTime_Local);
               DateTime val26 = new DateTime(2010, 3, 4);
               mWQMRun.LabRunSampleApprovalDateTime_Local = val26;
               Assert.Equal(val26, mWQMRun.LabRunSampleApprovalDateTime_Local);
               TideTextEnum val27 = (TideTextEnum)3;
               mWQMRun.Tide_Start = val27;
               Assert.Equal(val27, mWQMRun.Tide_Start);
               TideTextEnum val28 = (TideTextEnum)3;
               mWQMRun.Tide_End = val28;
               Assert.Equal(val28, mWQMRun.Tide_End);
               double val29 = 87.9D;
               mWQMRun.RainDay0_mm = val29;
               Assert.Equal(val29, mWQMRun.RainDay0_mm);
               double val30 = 87.9D;
               mWQMRun.RainDay1_mm = val30;
               Assert.Equal(val30, mWQMRun.RainDay1_mm);
               double val31 = 87.9D;
               mWQMRun.RainDay2_mm = val31;
               Assert.Equal(val31, mWQMRun.RainDay2_mm);
               double val32 = 87.9D;
               mWQMRun.RainDay3_mm = val32;
               Assert.Equal(val32, mWQMRun.RainDay3_mm);
               double val33 = 87.9D;
               mWQMRun.RainDay4_mm = val33;
               Assert.Equal(val33, mWQMRun.RainDay4_mm);
               double val34 = 87.9D;
               mWQMRun.RainDay5_mm = val34;
               Assert.Equal(val34, mWQMRun.RainDay5_mm);
               double val35 = 87.9D;
               mWQMRun.RainDay6_mm = val35;
               Assert.Equal(val35, mWQMRun.RainDay6_mm);
               double val36 = 87.9D;
               mWQMRun.RainDay7_mm = val36;
               Assert.Equal(val36, mWQMRun.RainDay7_mm);
               double val37 = 87.9D;
               mWQMRun.RainDay8_mm = val37;
               Assert.Equal(val37, mWQMRun.RainDay8_mm);
               double val38 = 87.9D;
               mWQMRun.RainDay9_mm = val38;
               Assert.Equal(val38, mWQMRun.RainDay9_mm);
               double val39 = 87.9D;
               mWQMRun.RainDay10_mm = val39;
               Assert.Equal(val39, mWQMRun.RainDay10_mm);
               bool val40 = true;
               mWQMRun.RemoveFromStat = val40;
               Assert.Equal(val40, mWQMRun.RemoveFromStat);
               DateTime val41 = new DateTime(2010, 3, 4);
               mWQMRun.LastUpdateDate_UTC = val41;
               Assert.Equal(val41, mWQMRun.LastUpdateDate_UTC);
               int val42 = 45;
               mWQMRun.LastUpdateContactTVItemID = val42;
               Assert.Equal(val42, mWQMRun.LastUpdateContactTVItemID);
        }
        #endregion Tests Functions public
    }
}