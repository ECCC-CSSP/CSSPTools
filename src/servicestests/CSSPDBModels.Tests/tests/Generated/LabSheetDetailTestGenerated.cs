/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateCSSPDBModels_TestsGenerated\bin\Debug\net6.0\GenerateCSSPDBModels_TestsGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

namespace CSSPDBModels.Tests;

public partial class LabSheetDetailTest
{
    private LabSheetDetail labSheetDetail { get; set; }

    public LabSheetDetailTest()
    {
        labSheetDetail = new LabSheetDetail();
    }
    [Fact]
    public void LabSheetDetail_Properties_Test()
    {
        List<string> propNameList = new List<string>() { "LabSheetDetailID", "DBCommand", "LabSheetID", "SamplingPlanID", "SubsectorTVItemID", "Version", "RunDate", "Tides", "SampleCrewInitials", "WaterBathCount", "IncubationBath1StartTime", "IncubationBath2StartTime", "IncubationBath3StartTime", "IncubationBath1EndTime", "IncubationBath2EndTime", "IncubationBath3EndTime", "IncubationBath1TimeCalculated_minutes", "IncubationBath2TimeCalculated_minutes", "IncubationBath3TimeCalculated_minutes", "WaterBath1", "WaterBath2", "WaterBath3", "TCField1", "TCLab1", "TCField2", "TCLab2", "TCFirst", "TCAverage", "ControlLot", "Positive35", "NonTarget35", "Negative35", "Bath1Positive44_5", "Bath2Positive44_5", "Bath3Positive44_5", "Bath1NonTarget44_5", "Bath2NonTarget44_5", "Bath3NonTarget44_5", "Bath1Negative44_5", "Bath2Negative44_5", "Bath3Negative44_5", "Blank35", "Bath1Blank44_5", "Bath2Blank44_5", "Bath3Blank44_5", "Lot35", "Lot44_5", "Weather", "RunComment", "RunWeatherComment", "SampleBottleLotNumber", "SalinitiesReadBy", "SalinitiesReadDate", "ResultsReadBy", "ResultsReadDate", "ResultsRecordedBy", "ResultsRecordedDate", "DailyDuplicateRLog", "DailyDuplicatePrecisionCriteria", "DailyDuplicateAcceptable", "IntertechDuplicateRLog", "IntertechDuplicatePrecisionCriteria", "IntertechDuplicateAcceptable", "IntertechReadAcceptable", "LastUpdateDate_UTC", "LastUpdateContactTVItemID",  }.OrderBy(c => c).ToList();

        int index = 0;
        foreach (PropertyInfo propertyInfo in typeof(LabSheetDetail).GetProperties().OrderBy(c => c.Name))
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
        foreach (PropertyInfo propertyInfo in typeof(LabSheetDetail).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
    public void LabSheetDetail_Navigation_Test()
    {
        List<string> foreignNameList = new List<string>() {  }.OrderBy(c => c).ToList();
        List<string> foreignNameCollectionList = new List<string>() {  }.OrderBy(c => c).ToList();

        int index = 0;
        foreach (PropertyInfo propertyInfo in typeof(LabSheetDetail).GetProperties())
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
        foreach (PropertyInfo propertyInfo in typeof(LabSheetDetail).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
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
    public void LabSheetDetail_Every_Property_Has_Get_Set_Test()
    {
           int val1 = 45;
           labSheetDetail.LabSheetDetailID = val1;
           Assert.Equal(val1, labSheetDetail.LabSheetDetailID);
           DBCommandEnum val2 = (DBCommandEnum)3;
           labSheetDetail.DBCommand = val2;
           Assert.Equal(val2, labSheetDetail.DBCommand);
           int val3 = 45;
           labSheetDetail.LabSheetID = val3;
           Assert.Equal(val3, labSheetDetail.LabSheetID);
           int val4 = 45;
           labSheetDetail.SamplingPlanID = val4;
           Assert.Equal(val4, labSheetDetail.SamplingPlanID);
           int val5 = 45;
           labSheetDetail.SubsectorTVItemID = val5;
           Assert.Equal(val5, labSheetDetail.SubsectorTVItemID);
           int val6 = 45;
           labSheetDetail.Version = val6;
           Assert.Equal(val6, labSheetDetail.Version);
           DateTime val7 = new DateTime(2010, 3, 4);
           labSheetDetail.RunDate = val7;
           Assert.Equal(val7, labSheetDetail.RunDate);
           string val8 = "Some text";
           labSheetDetail.Tides = val8;
           Assert.Equal(val8, labSheetDetail.Tides);
           string val9 = "Some text";
           labSheetDetail.SampleCrewInitials = val9;
           Assert.Equal(val9, labSheetDetail.SampleCrewInitials);
           int val10 = 45;
           labSheetDetail.WaterBathCount = val10;
           Assert.Equal(val10, labSheetDetail.WaterBathCount);
           DateTime val11 = new DateTime(2010, 3, 4);
           labSheetDetail.IncubationBath1StartTime = val11;
           Assert.Equal(val11, labSheetDetail.IncubationBath1StartTime);
           DateTime val12 = new DateTime(2010, 3, 4);
           labSheetDetail.IncubationBath2StartTime = val12;
           Assert.Equal(val12, labSheetDetail.IncubationBath2StartTime);
           DateTime val13 = new DateTime(2010, 3, 4);
           labSheetDetail.IncubationBath3StartTime = val13;
           Assert.Equal(val13, labSheetDetail.IncubationBath3StartTime);
           DateTime val14 = new DateTime(2010, 3, 4);
           labSheetDetail.IncubationBath1EndTime = val14;
           Assert.Equal(val14, labSheetDetail.IncubationBath1EndTime);
           DateTime val15 = new DateTime(2010, 3, 4);
           labSheetDetail.IncubationBath2EndTime = val15;
           Assert.Equal(val15, labSheetDetail.IncubationBath2EndTime);
           DateTime val16 = new DateTime(2010, 3, 4);
           labSheetDetail.IncubationBath3EndTime = val16;
           Assert.Equal(val16, labSheetDetail.IncubationBath3EndTime);
           int val17 = 45;
           labSheetDetail.IncubationBath1TimeCalculated_minutes = val17;
           Assert.Equal(val17, labSheetDetail.IncubationBath1TimeCalculated_minutes);
           int val18 = 45;
           labSheetDetail.IncubationBath2TimeCalculated_minutes = val18;
           Assert.Equal(val18, labSheetDetail.IncubationBath2TimeCalculated_minutes);
           int val19 = 45;
           labSheetDetail.IncubationBath3TimeCalculated_minutes = val19;
           Assert.Equal(val19, labSheetDetail.IncubationBath3TimeCalculated_minutes);
           string val20 = "Some text";
           labSheetDetail.WaterBath1 = val20;
           Assert.Equal(val20, labSheetDetail.WaterBath1);
           string val21 = "Some text";
           labSheetDetail.WaterBath2 = val21;
           Assert.Equal(val21, labSheetDetail.WaterBath2);
           string val22 = "Some text";
           labSheetDetail.WaterBath3 = val22;
           Assert.Equal(val22, labSheetDetail.WaterBath3);
           double val23 = 87.9D;
           labSheetDetail.TCField1 = val23;
           Assert.Equal(val23, labSheetDetail.TCField1);
           double val24 = 87.9D;
           labSheetDetail.TCLab1 = val24;
           Assert.Equal(val24, labSheetDetail.TCLab1);
           double val25 = 87.9D;
           labSheetDetail.TCField2 = val25;
           Assert.Equal(val25, labSheetDetail.TCField2);
           double val26 = 87.9D;
           labSheetDetail.TCLab2 = val26;
           Assert.Equal(val26, labSheetDetail.TCLab2);
           double val27 = 87.9D;
           labSheetDetail.TCFirst = val27;
           Assert.Equal(val27, labSheetDetail.TCFirst);
           double val28 = 87.9D;
           labSheetDetail.TCAverage = val28;
           Assert.Equal(val28, labSheetDetail.TCAverage);
           string val29 = "Some text";
           labSheetDetail.ControlLot = val29;
           Assert.Equal(val29, labSheetDetail.ControlLot);
           string val30 = "Some text";
           labSheetDetail.Positive35 = val30;
           Assert.Equal(val30, labSheetDetail.Positive35);
           string val31 = "Some text";
           labSheetDetail.NonTarget35 = val31;
           Assert.Equal(val31, labSheetDetail.NonTarget35);
           string val32 = "Some text";
           labSheetDetail.Negative35 = val32;
           Assert.Equal(val32, labSheetDetail.Negative35);
           string val33 = "Some text";
           labSheetDetail.Bath1Positive44_5 = val33;
           Assert.Equal(val33, labSheetDetail.Bath1Positive44_5);
           string val34 = "Some text";
           labSheetDetail.Bath2Positive44_5 = val34;
           Assert.Equal(val34, labSheetDetail.Bath2Positive44_5);
           string val35 = "Some text";
           labSheetDetail.Bath3Positive44_5 = val35;
           Assert.Equal(val35, labSheetDetail.Bath3Positive44_5);
           string val36 = "Some text";
           labSheetDetail.Bath1NonTarget44_5 = val36;
           Assert.Equal(val36, labSheetDetail.Bath1NonTarget44_5);
           string val37 = "Some text";
           labSheetDetail.Bath2NonTarget44_5 = val37;
           Assert.Equal(val37, labSheetDetail.Bath2NonTarget44_5);
           string val38 = "Some text";
           labSheetDetail.Bath3NonTarget44_5 = val38;
           Assert.Equal(val38, labSheetDetail.Bath3NonTarget44_5);
           string val39 = "Some text";
           labSheetDetail.Bath1Negative44_5 = val39;
           Assert.Equal(val39, labSheetDetail.Bath1Negative44_5);
           string val40 = "Some text";
           labSheetDetail.Bath2Negative44_5 = val40;
           Assert.Equal(val40, labSheetDetail.Bath2Negative44_5);
           string val41 = "Some text";
           labSheetDetail.Bath3Negative44_5 = val41;
           Assert.Equal(val41, labSheetDetail.Bath3Negative44_5);
           string val42 = "Some text";
           labSheetDetail.Blank35 = val42;
           Assert.Equal(val42, labSheetDetail.Blank35);
           string val43 = "Some text";
           labSheetDetail.Bath1Blank44_5 = val43;
           Assert.Equal(val43, labSheetDetail.Bath1Blank44_5);
           string val44 = "Some text";
           labSheetDetail.Bath2Blank44_5 = val44;
           Assert.Equal(val44, labSheetDetail.Bath2Blank44_5);
           string val45 = "Some text";
           labSheetDetail.Bath3Blank44_5 = val45;
           Assert.Equal(val45, labSheetDetail.Bath3Blank44_5);
           string val46 = "Some text";
           labSheetDetail.Lot35 = val46;
           Assert.Equal(val46, labSheetDetail.Lot35);
           string val47 = "Some text";
           labSheetDetail.Lot44_5 = val47;
           Assert.Equal(val47, labSheetDetail.Lot44_5);
           string val48 = "Some text";
           labSheetDetail.Weather = val48;
           Assert.Equal(val48, labSheetDetail.Weather);
           string val49 = "Some text";
           labSheetDetail.RunComment = val49;
           Assert.Equal(val49, labSheetDetail.RunComment);
           string val50 = "Some text";
           labSheetDetail.RunWeatherComment = val50;
           Assert.Equal(val50, labSheetDetail.RunWeatherComment);
           string val51 = "Some text";
           labSheetDetail.SampleBottleLotNumber = val51;
           Assert.Equal(val51, labSheetDetail.SampleBottleLotNumber);
           string val52 = "Some text";
           labSheetDetail.SalinitiesReadBy = val52;
           Assert.Equal(val52, labSheetDetail.SalinitiesReadBy);
           DateTime val53 = new DateTime(2010, 3, 4);
           labSheetDetail.SalinitiesReadDate = val53;
           Assert.Equal(val53, labSheetDetail.SalinitiesReadDate);
           string val54 = "Some text";
           labSheetDetail.ResultsReadBy = val54;
           Assert.Equal(val54, labSheetDetail.ResultsReadBy);
           DateTime val55 = new DateTime(2010, 3, 4);
           labSheetDetail.ResultsReadDate = val55;
           Assert.Equal(val55, labSheetDetail.ResultsReadDate);
           string val56 = "Some text";
           labSheetDetail.ResultsRecordedBy = val56;
           Assert.Equal(val56, labSheetDetail.ResultsRecordedBy);
           DateTime val57 = new DateTime(2010, 3, 4);
           labSheetDetail.ResultsRecordedDate = val57;
           Assert.Equal(val57, labSheetDetail.ResultsRecordedDate);
           double val58 = 87.9D;
           labSheetDetail.DailyDuplicateRLog = val58;
           Assert.Equal(val58, labSheetDetail.DailyDuplicateRLog);
           double val59 = 87.9D;
           labSheetDetail.DailyDuplicatePrecisionCriteria = val59;
           Assert.Equal(val59, labSheetDetail.DailyDuplicatePrecisionCriteria);
           bool val60 = true;
           labSheetDetail.DailyDuplicateAcceptable = val60;
           Assert.Equal(val60, labSheetDetail.DailyDuplicateAcceptable);
           double val61 = 87.9D;
           labSheetDetail.IntertechDuplicateRLog = val61;
           Assert.Equal(val61, labSheetDetail.IntertechDuplicateRLog);
           double val62 = 87.9D;
           labSheetDetail.IntertechDuplicatePrecisionCriteria = val62;
           Assert.Equal(val62, labSheetDetail.IntertechDuplicatePrecisionCriteria);
           bool val63 = true;
           labSheetDetail.IntertechDuplicateAcceptable = val63;
           Assert.Equal(val63, labSheetDetail.IntertechDuplicateAcceptable);
           bool val64 = true;
           labSheetDetail.IntertechReadAcceptable = val64;
           Assert.Equal(val64, labSheetDetail.IntertechReadAcceptable);
           DateTime val65 = new DateTime(2010, 3, 4);
           labSheetDetail.LastUpdateDate_UTC = val65;
           Assert.Equal(val65, labSheetDetail.LastUpdateDate_UTC);
           int val66 = 45;
           labSheetDetail.LastUpdateContactTVItemID = val66;
           Assert.Equal(val66, labSheetDetail.LastUpdateContactTVItemID);
    }
}
