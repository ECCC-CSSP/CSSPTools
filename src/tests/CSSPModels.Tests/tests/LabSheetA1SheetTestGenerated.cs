/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]TestGenerated.cs] button
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
    public partial class LabSheetA1SheetTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LabSheetA1Sheet labSheetA1Sheet { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetA1SheetTest()
        {
            labSheetA1Sheet = new LabSheetA1Sheet();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void LabSheetA1Sheet_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Version", "SamplingPlanType", "SampleType", "LabSheetType", "SubsectorName", "SubsectorLocation", "SubsectorTVItemID", "RunYear", "RunMonth", "RunDay", "RunNumber", "Tides", "SampleCrewInitials", "IncubationStartSameDay", "WaterBathCount", "IncubationBath1StartTime", "IncubationBath2StartTime", "IncubationBath3StartTime", "IncubationBath1EndTime", "IncubationBath2EndTime", "IncubationBath3EndTime", "IncubationBath1TimeCalculated", "IncubationBath2TimeCalculated", "IncubationBath3TimeCalculated", "WaterBath1", "WaterBath2", "WaterBath3", "TCField1", "TCLab1", "TCHas2Coolers", "TCField2", "TCLab2", "TCFirst", "TCAverage", "ControlLot", "Positive35", "NonTarget35", "Negative35", "Bath1Positive44_5", "Bath2Positive44_5", "Bath3Positive44_5", "Bath1NonTarget44_5", "Bath2NonTarget44_5", "Bath3NonTarget44_5", "Bath1Negative44_5", "Bath2Negative44_5", "Bath3Negative44_5", "Blank35", "Bath1Blank44_5", "Bath2Blank44_5", "Bath3Blank44_5", "Lot35", "Lot44_5", "RunComment", "RunWeatherComment", "SampleBottleLotNumber", "SalinitiesReadBy", "SalinitiesReadYear", "SalinitiesReadMonth", "SalinitiesReadDay", "ResultsReadBy", "ResultsReadYear", "ResultsReadMonth", "ResultsReadDay", "ResultsRecordedBy", "ResultsRecordedYear", "ResultsRecordedMonth", "ResultsRecordedDay", "DailyDuplicateRLog", "DailyDuplicatePrecisionCriteria", "DailyDuplicateAcceptableOrUnacceptable", "IntertechDuplicateRLog", "IntertechDuplicatePrecisionCriteria", "IntertechDuplicateAcceptableOrUnacceptable", "IntertechReadAcceptableOrUnacceptable", "ApprovalYear", "ApprovalMonth", "ApprovalDay", "ApprovedBySupervisorInitials", "IncludeLaboratoryQAQC", "BackupDirectory", "Log", "SamplingPlanTypeText", "SampleTypeText", "LabSheetTypeText", "LabSheetA1MeasurementList", "HasErrors",  }.OrderBy(c => c).ToList();
            List<string> propNameNotMappedList = new List<string>() {  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(LabSheetA1Sheet).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void LabSheetA1Sheet_Has_ValidationResults_Test()
        {
             Assert.True(typeof(LabSheetA1Sheet).GetProperties().Where(c => c.Name == "ValidationResults").Any());
        }
        [Fact]
        public void LabSheetA1Sheet_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               labSheetA1Sheet.Version = val1;
               Assert.Equal(val1, labSheetA1Sheet.Version);
               SamplingPlanTypeEnum val2 = (SamplingPlanTypeEnum)3;
               labSheetA1Sheet.SamplingPlanType = val2;
               Assert.Equal(val2, labSheetA1Sheet.SamplingPlanType);
               SampleTypeEnum val3 = (SampleTypeEnum)3;
               labSheetA1Sheet.SampleType = val3;
               Assert.Equal(val3, labSheetA1Sheet.SampleType);
               LabSheetTypeEnum val4 = (LabSheetTypeEnum)3;
               labSheetA1Sheet.LabSheetType = val4;
               Assert.Equal(val4, labSheetA1Sheet.LabSheetType);
               string val5 = "Some text";
               labSheetA1Sheet.SubsectorName = val5;
               Assert.Equal(val5, labSheetA1Sheet.SubsectorName);
               string val6 = "Some text";
               labSheetA1Sheet.SubsectorLocation = val6;
               Assert.Equal(val6, labSheetA1Sheet.SubsectorLocation);
               int val7 = 45;
               labSheetA1Sheet.SubsectorTVItemID = val7;
               Assert.Equal(val7, labSheetA1Sheet.SubsectorTVItemID);
               string val8 = "Some text";
               labSheetA1Sheet.RunYear = val8;
               Assert.Equal(val8, labSheetA1Sheet.RunYear);
               string val9 = "Some text";
               labSheetA1Sheet.RunMonth = val9;
               Assert.Equal(val9, labSheetA1Sheet.RunMonth);
               string val10 = "Some text";
               labSheetA1Sheet.RunDay = val10;
               Assert.Equal(val10, labSheetA1Sheet.RunDay);
               int val11 = 45;
               labSheetA1Sheet.RunNumber = val11;
               Assert.Equal(val11, labSheetA1Sheet.RunNumber);
               string val12 = "Some text";
               labSheetA1Sheet.Tides = val12;
               Assert.Equal(val12, labSheetA1Sheet.Tides);
               string val13 = "Some text";
               labSheetA1Sheet.SampleCrewInitials = val13;
               Assert.Equal(val13, labSheetA1Sheet.SampleCrewInitials);
               string val14 = "Some text";
               labSheetA1Sheet.IncubationStartSameDay = val14;
               Assert.Equal(val14, labSheetA1Sheet.IncubationStartSameDay);
               int val15 = 45;
               labSheetA1Sheet.WaterBathCount = val15;
               Assert.Equal(val15, labSheetA1Sheet.WaterBathCount);
               string val16 = "Some text";
               labSheetA1Sheet.IncubationBath1StartTime = val16;
               Assert.Equal(val16, labSheetA1Sheet.IncubationBath1StartTime);
               string val17 = "Some text";
               labSheetA1Sheet.IncubationBath2StartTime = val17;
               Assert.Equal(val17, labSheetA1Sheet.IncubationBath2StartTime);
               string val18 = "Some text";
               labSheetA1Sheet.IncubationBath3StartTime = val18;
               Assert.Equal(val18, labSheetA1Sheet.IncubationBath3StartTime);
               string val19 = "Some text";
               labSheetA1Sheet.IncubationBath1EndTime = val19;
               Assert.Equal(val19, labSheetA1Sheet.IncubationBath1EndTime);
               string val20 = "Some text";
               labSheetA1Sheet.IncubationBath2EndTime = val20;
               Assert.Equal(val20, labSheetA1Sheet.IncubationBath2EndTime);
               string val21 = "Some text";
               labSheetA1Sheet.IncubationBath3EndTime = val21;
               Assert.Equal(val21, labSheetA1Sheet.IncubationBath3EndTime);
               string val22 = "Some text";
               labSheetA1Sheet.IncubationBath1TimeCalculated = val22;
               Assert.Equal(val22, labSheetA1Sheet.IncubationBath1TimeCalculated);
               string val23 = "Some text";
               labSheetA1Sheet.IncubationBath2TimeCalculated = val23;
               Assert.Equal(val23, labSheetA1Sheet.IncubationBath2TimeCalculated);
               string val24 = "Some text";
               labSheetA1Sheet.IncubationBath3TimeCalculated = val24;
               Assert.Equal(val24, labSheetA1Sheet.IncubationBath3TimeCalculated);
               string val25 = "Some text";
               labSheetA1Sheet.WaterBath1 = val25;
               Assert.Equal(val25, labSheetA1Sheet.WaterBath1);
               string val26 = "Some text";
               labSheetA1Sheet.WaterBath2 = val26;
               Assert.Equal(val26, labSheetA1Sheet.WaterBath2);
               string val27 = "Some text";
               labSheetA1Sheet.WaterBath3 = val27;
               Assert.Equal(val27, labSheetA1Sheet.WaterBath3);
               string val28 = "Some text";
               labSheetA1Sheet.TCField1 = val28;
               Assert.Equal(val28, labSheetA1Sheet.TCField1);
               string val29 = "Some text";
               labSheetA1Sheet.TCLab1 = val29;
               Assert.Equal(val29, labSheetA1Sheet.TCLab1);
               string val30 = "Some text";
               labSheetA1Sheet.TCHas2Coolers = val30;
               Assert.Equal(val30, labSheetA1Sheet.TCHas2Coolers);
               string val31 = "Some text";
               labSheetA1Sheet.TCField2 = val31;
               Assert.Equal(val31, labSheetA1Sheet.TCField2);
               string val32 = "Some text";
               labSheetA1Sheet.TCLab2 = val32;
               Assert.Equal(val32, labSheetA1Sheet.TCLab2);
               string val33 = "Some text";
               labSheetA1Sheet.TCFirst = val33;
               Assert.Equal(val33, labSheetA1Sheet.TCFirst);
               string val34 = "Some text";
               labSheetA1Sheet.TCAverage = val34;
               Assert.Equal(val34, labSheetA1Sheet.TCAverage);
               string val35 = "Some text";
               labSheetA1Sheet.ControlLot = val35;
               Assert.Equal(val35, labSheetA1Sheet.ControlLot);
               string val36 = "Some text";
               labSheetA1Sheet.Positive35 = val36;
               Assert.Equal(val36, labSheetA1Sheet.Positive35);
               string val37 = "Some text";
               labSheetA1Sheet.NonTarget35 = val37;
               Assert.Equal(val37, labSheetA1Sheet.NonTarget35);
               string val38 = "Some text";
               labSheetA1Sheet.Negative35 = val38;
               Assert.Equal(val38, labSheetA1Sheet.Negative35);
               string val39 = "Some text";
               labSheetA1Sheet.Bath1Positive44_5 = val39;
               Assert.Equal(val39, labSheetA1Sheet.Bath1Positive44_5);
               string val40 = "Some text";
               labSheetA1Sheet.Bath2Positive44_5 = val40;
               Assert.Equal(val40, labSheetA1Sheet.Bath2Positive44_5);
               string val41 = "Some text";
               labSheetA1Sheet.Bath3Positive44_5 = val41;
               Assert.Equal(val41, labSheetA1Sheet.Bath3Positive44_5);
               string val42 = "Some text";
               labSheetA1Sheet.Bath1NonTarget44_5 = val42;
               Assert.Equal(val42, labSheetA1Sheet.Bath1NonTarget44_5);
               string val43 = "Some text";
               labSheetA1Sheet.Bath2NonTarget44_5 = val43;
               Assert.Equal(val43, labSheetA1Sheet.Bath2NonTarget44_5);
               string val44 = "Some text";
               labSheetA1Sheet.Bath3NonTarget44_5 = val44;
               Assert.Equal(val44, labSheetA1Sheet.Bath3NonTarget44_5);
               string val45 = "Some text";
               labSheetA1Sheet.Bath1Negative44_5 = val45;
               Assert.Equal(val45, labSheetA1Sheet.Bath1Negative44_5);
               string val46 = "Some text";
               labSheetA1Sheet.Bath2Negative44_5 = val46;
               Assert.Equal(val46, labSheetA1Sheet.Bath2Negative44_5);
               string val47 = "Some text";
               labSheetA1Sheet.Bath3Negative44_5 = val47;
               Assert.Equal(val47, labSheetA1Sheet.Bath3Negative44_5);
               string val48 = "Some text";
               labSheetA1Sheet.Blank35 = val48;
               Assert.Equal(val48, labSheetA1Sheet.Blank35);
               string val49 = "Some text";
               labSheetA1Sheet.Bath1Blank44_5 = val49;
               Assert.Equal(val49, labSheetA1Sheet.Bath1Blank44_5);
               string val50 = "Some text";
               labSheetA1Sheet.Bath2Blank44_5 = val50;
               Assert.Equal(val50, labSheetA1Sheet.Bath2Blank44_5);
               string val51 = "Some text";
               labSheetA1Sheet.Bath3Blank44_5 = val51;
               Assert.Equal(val51, labSheetA1Sheet.Bath3Blank44_5);
               string val52 = "Some text";
               labSheetA1Sheet.Lot35 = val52;
               Assert.Equal(val52, labSheetA1Sheet.Lot35);
               string val53 = "Some text";
               labSheetA1Sheet.Lot44_5 = val53;
               Assert.Equal(val53, labSheetA1Sheet.Lot44_5);
               string val54 = "Some text";
               labSheetA1Sheet.RunComment = val54;
               Assert.Equal(val54, labSheetA1Sheet.RunComment);
               string val55 = "Some text";
               labSheetA1Sheet.RunWeatherComment = val55;
               Assert.Equal(val55, labSheetA1Sheet.RunWeatherComment);
               string val56 = "Some text";
               labSheetA1Sheet.SampleBottleLotNumber = val56;
               Assert.Equal(val56, labSheetA1Sheet.SampleBottleLotNumber);
               string val57 = "Some text";
               labSheetA1Sheet.SalinitiesReadBy = val57;
               Assert.Equal(val57, labSheetA1Sheet.SalinitiesReadBy);
               string val58 = "Some text";
               labSheetA1Sheet.SalinitiesReadYear = val58;
               Assert.Equal(val58, labSheetA1Sheet.SalinitiesReadYear);
               string val59 = "Some text";
               labSheetA1Sheet.SalinitiesReadMonth = val59;
               Assert.Equal(val59, labSheetA1Sheet.SalinitiesReadMonth);
               string val60 = "Some text";
               labSheetA1Sheet.SalinitiesReadDay = val60;
               Assert.Equal(val60, labSheetA1Sheet.SalinitiesReadDay);
               string val61 = "Some text";
               labSheetA1Sheet.ResultsReadBy = val61;
               Assert.Equal(val61, labSheetA1Sheet.ResultsReadBy);
               string val62 = "Some text";
               labSheetA1Sheet.ResultsReadYear = val62;
               Assert.Equal(val62, labSheetA1Sheet.ResultsReadYear);
               string val63 = "Some text";
               labSheetA1Sheet.ResultsReadMonth = val63;
               Assert.Equal(val63, labSheetA1Sheet.ResultsReadMonth);
               string val64 = "Some text";
               labSheetA1Sheet.ResultsReadDay = val64;
               Assert.Equal(val64, labSheetA1Sheet.ResultsReadDay);
               string val65 = "Some text";
               labSheetA1Sheet.ResultsRecordedBy = val65;
               Assert.Equal(val65, labSheetA1Sheet.ResultsRecordedBy);
               string val66 = "Some text";
               labSheetA1Sheet.ResultsRecordedYear = val66;
               Assert.Equal(val66, labSheetA1Sheet.ResultsRecordedYear);
               string val67 = "Some text";
               labSheetA1Sheet.ResultsRecordedMonth = val67;
               Assert.Equal(val67, labSheetA1Sheet.ResultsRecordedMonth);
               string val68 = "Some text";
               labSheetA1Sheet.ResultsRecordedDay = val68;
               Assert.Equal(val68, labSheetA1Sheet.ResultsRecordedDay);
               string val69 = "Some text";
               labSheetA1Sheet.DailyDuplicateRLog = val69;
               Assert.Equal(val69, labSheetA1Sheet.DailyDuplicateRLog);
               string val70 = "Some text";
               labSheetA1Sheet.DailyDuplicatePrecisionCriteria = val70;
               Assert.Equal(val70, labSheetA1Sheet.DailyDuplicatePrecisionCriteria);
               string val71 = "Some text";
               labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable = val71;
               Assert.Equal(val71, labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable);
               string val72 = "Some text";
               labSheetA1Sheet.IntertechDuplicateRLog = val72;
               Assert.Equal(val72, labSheetA1Sheet.IntertechDuplicateRLog);
               string val73 = "Some text";
               labSheetA1Sheet.IntertechDuplicatePrecisionCriteria = val73;
               Assert.Equal(val73, labSheetA1Sheet.IntertechDuplicatePrecisionCriteria);
               string val74 = "Some text";
               labSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable = val74;
               Assert.Equal(val74, labSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable);
               string val75 = "Some text";
               labSheetA1Sheet.IntertechReadAcceptableOrUnacceptable = val75;
               Assert.Equal(val75, labSheetA1Sheet.IntertechReadAcceptableOrUnacceptable);
               string val76 = "Some text";
               labSheetA1Sheet.ApprovalYear = val76;
               Assert.Equal(val76, labSheetA1Sheet.ApprovalYear);
               string val77 = "Some text";
               labSheetA1Sheet.ApprovalMonth = val77;
               Assert.Equal(val77, labSheetA1Sheet.ApprovalMonth);
               string val78 = "Some text";
               labSheetA1Sheet.ApprovalDay = val78;
               Assert.Equal(val78, labSheetA1Sheet.ApprovalDay);
               string val79 = "Some text";
               labSheetA1Sheet.ApprovedBySupervisorInitials = val79;
               Assert.Equal(val79, labSheetA1Sheet.ApprovedBySupervisorInitials);
               bool val80 = true;
               labSheetA1Sheet.IncludeLaboratoryQAQC = val80;
               Assert.Equal(val80, labSheetA1Sheet.IncludeLaboratoryQAQC);
               string val81 = "Some text";
               labSheetA1Sheet.BackupDirectory = val81;
               Assert.Equal(val81, labSheetA1Sheet.BackupDirectory);
               string val82 = "Some text";
               labSheetA1Sheet.Log = val82;
               Assert.Equal(val82, labSheetA1Sheet.Log);
               string val83 = "Some text";
               labSheetA1Sheet.SamplingPlanTypeText = val83;
               Assert.Equal(val83, labSheetA1Sheet.SamplingPlanTypeText);
               string val84 = "Some text";
               labSheetA1Sheet.SampleTypeText = val84;
               Assert.Equal(val84, labSheetA1Sheet.SampleTypeText);
               string val85 = "Some text";
               labSheetA1Sheet.LabSheetTypeText = val85;
               Assert.Equal(val85, labSheetA1Sheet.LabSheetTypeText);
               List<LabSheetA1Measurement> val86 = new List<LabSheetA1Measurement>() { new LabSheetA1Measurement(), new LabSheetA1Measurement() };
               labSheetA1Sheet.LabSheetA1MeasurementList = val86;
               Assert.Equal(val86, labSheetA1Sheet.LabSheetA1MeasurementList);
               bool val87 = true;
               labSheetA1Sheet.HasErrors = val87;
               Assert.Equal(val87, labSheetA1Sheet.HasErrors);
               IEnumerable<ValidationResult> val264 = new List<ValidationResult>() { new ValidationResult("First CSSPError Message") }.AsEnumerable();
               labSheetA1Sheet.ValidationResults = val264;
               Assert.Equal(val264, labSheetA1Sheet.ValidationResults);
        }
        #endregion Tests Functions public
    }
}
