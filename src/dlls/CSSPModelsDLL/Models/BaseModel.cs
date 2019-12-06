using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
   
    #region Class
    public class AppTaskParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class BoxModelCalNumb
    {
        public BoxModelCalNumb()
        {
        }

        public string Error { get; set; }
        public BoxModelResultTypeEnum ResultType { get; set; }
        public float CalLength_m { get; set; }
        public float CalRadius_m { get; set; }
        public float CalSurface_m2 { get; set; }
        public float CalVolume_m3 { get; set; }
        public float CalWidth_m { get; set; }
        public bool FixLength { get; set; }
        public bool FixWidth { get; set; }

    }
    public class DBTable
    {
        public string TableName { get; set; }
        public string Plurial { get; set; }
    }
    public class CalDecay
    {
        public CalDecay()
        {
            Error = "";
        }

        public string Error { get; set; }
        public double Decay { get; set; }
    }
    public class ContactOK
    {
        public int ContactID { get; set; }
        public int ContactTVItemID { get; set; }
        public string Error { get; set; }
    }
    public class ContactSearchModel
    {
        public int ContactID { get; set; }
        public int ContactTVItemID { get; set; }
        public string FullName { get; set; }
    }
    public class ContourPolygon
    {
        public ContourPolygon()
        {
            Error = "";
            ContourNodeList = new List<Node>();
        }
        public string Error { get; set; }
        public List<Node> ContourNodeList { get; set; }
        public float ContourValue { get; set; }
        public int Layer { get; set; }
        public float Depth { get; set; }
        public int ParamCount { get; set; }
    }
    public class Coord
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
        public int Ordinal { get; set; }
    }
    public class CoordMap
    {
        public Coord SouthWest { get; set; }
        public Coord NorthEast { get; set; }
    }
    public class CoordModel
    {
        public string Error { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public int Ordinal { get; set; }
    }
    public class CSSPMPNTable
    {
        public int Tube10 { get; set; }
        public int Tube1_0 { get; set; }
        public int Tube0_1 { get; set; }
        public int MPN { get; set; }
    }
    public class CSSPWQInputApp
    {
        public string AccessCode { get; set; }
        public string ActiveYear { get; set; }
        public float DailyDuplicatePrecisionCriteria { get; set; }
        public float IntertechDuplicatePrecisionCriteria { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        public string ApprovalCode { get; set; }
        public DateTime ApprovalDate { get; set; }
    }
    public class CSSPWQInputParam
    {
        public CSSPWQInputParam()
        {
            sidList = new List<string>();
            MWQMSiteList = new List<string>();
            MWQMSiteTVItemIDList = new List<int>();
            DailyDuplicateMWQMSiteList = new List<string>();
            DailyDuplicateMWQMSiteTVItemIDList = new List<int>();
            InfrastructureList = new List<string>();
            InfrastructureTVItemIDList = new List<int>();
        }

        public CSSPWQInputTypeEnum CSSPWQInputType { get; set; }
        public string Name { get; set; }
        public int TVItemID { get; set; }
        public List<string> sidList { get; set; }
        public List<string> MWQMSiteList { get; set; }
        public List<int> MWQMSiteTVItemIDList { get; set; }
        public List<string> DailyDuplicateMWQMSiteList { get; set; }
        public List<int> DailyDuplicateMWQMSiteTVItemIDList { get; set; }
        public List<string> InfrastructureList { get; set; }
        public List<int> InfrastructureTVItemIDList { get; set; }
    }
    public class CurrentResult
    {
        public CurrentResult()
        {

        }
        public DateTime Date { get; set; }
        public double x_velocity { get; set; }
        public double y_velocity { get; set; }
    }
    public class DataPathOfTide
    {
        public DataPathOfTide()
        {
            Text = "";
            WebTideDataSet = WebTideDataSetEnum.Error;
        }
        public string Text { get; set; }
        public WebTideDataSetEnum WebTideDataSet { get; set; }
    }
    public class Element
    {
        public Element()
        {
            NodeList = new List<Node>();
        }
        public int ID { get; set; }
        public int Type { get; set; }
        public int NumbOfNodes { get; set; }
        public List<Node> NodeList { get; set; }
        public float Value { get; set; }
        public float XNode0 { get; set; }
        public float YNode0 { get; set; }
        public float ZNode0 { get; set; }
        public int Flag { get; set; }
    }
    public class ElementLayer
    {
        public int Layer { get; set; }
        public Element Element { get; set; }
        public float ZMin { get; set; }
        public float ZMax { get; set; }
    }
    public class FileItem
    {
        public FileItem(string name, int tvItemID)
        {
            Name = name;
            TVItemID = tvItemID;
        }

        public string Name { get; set; }
        public int TVItemID { get; set; }
    }
    public class FileItemList
    {
        public FileItemList(string text, string fileName)
        {
            Text = text;
            FileName = fileName;
        }

        public string Text { get; set; }
        public string FileName { get; set; }
    }
    public class FilePurposeAndText
    {
        public FilePurposeEnum FilePurpose { get; set; }
        public string FilePurposeText { get; set; }
    }
    public class InputSummary
    {
        public string Error { get; set; }
        public string Summary { get; set; }
    }
    public class LabelPosition
    {
        public int TVItemID { get; set; }
        public Coord SitePoint { get; set; }
        public Coord LabelPoint { get; set; }
        public PositionEnum Position { get; set; }
        public Coord LabelNorthEast { get; set; }
        public Coord LabelSouthWest { get; set; }
        public float Distance { get; set; }
        public int Ordinal { get; set; }
        public MapInfoPointModel MapInfoPointModel { get; set; }

    }
    public class LabSheetSiteMonitoredCounts
    {
        public LabSheetSiteMonitoredCounts()
        {

        }

        public string Error { get; set; }
        public int SamplingPlanID { get; set; }
        public int LabSheetID { get; set; }
        public int SamplingPlanSubsectorSiteCount { get; set; }
        public int LabSheetSiteRoutineCount { get; set; }
        public bool LabSheetHasDuplicate { get; set; }
    }
    public class LabSheetA1Sheet
    {
        public LabSheetA1Sheet()
        {
            LabSheetA1MeasurementList = new List<LabSheetA1Measurement>();
        }

        public string Error { get; set; }
        public int Version { get; set; }
        public SamplingPlanTypeEnum SamplingPlanType { get; set; }
        public SampleTypeEnum SampleType { get; set; }
        public LabSheetTypeEnum LabSheetType { get; set; }
        public string SubsectorName { get; set; }
        public string SubsectorLocation { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string RunYear { get; set; }
        public string RunMonth { get; set; }
        public string RunDay { get; set; }
        public int RunNumber { get; set; }
        public string Tides { get; set; }
        public string SampleCrewInitials { get; set; }
        public string IncubationStartSameDay { get; set; }
        public int WaterBathCount { get; set; }
        public string IncubationBath1StartTime { get; set; }
        public string IncubationBath2StartTime { get; set; }
        public string IncubationBath3StartTime { get; set; }
        public string IncubationBath1EndTime { get; set; }
        public string IncubationBath2EndTime { get; set; }
        public string IncubationBath3EndTime { get; set; }
        public string IncubationBath1TimeCalculated { get; set; }
        public string IncubationBath2TimeCalculated { get; set; }
        public string IncubationBath3TimeCalculated { get; set; }
        public string WaterBath1 { get; set; }
        public string WaterBath2 { get; set; }
        public string WaterBath3 { get; set; }
        public string TCField1 { get; set; }
        public string TCLab1 { get; set; }
        public string TCHas2Coolers { get; set; }
        public string TCField2 { get; set; }
        public string TCLab2 { get; set; }
        public string TCFirst { get; set; }
        public string TCAverage { get; set; }
        public string ControlLot { get; set; }
        public string Positive35 { get; set; }
        public string NonTarget35 { get; set; }
        public string Negative35 { get; set; }
        public string Bath1Positive44_5 { get; set; }
        public string Bath2Positive44_5 { get; set; }
        public string Bath3Positive44_5 { get; set; }
        public string Bath1NonTarget44_5 { get; set; }
        public string Bath2NonTarget44_5 { get; set; }
        public string Bath3NonTarget44_5 { get; set; }
        public string Bath1Negative44_5 { get; set; }
        public string Bath2Negative44_5 { get; set; }
        public string Bath3Negative44_5 { get; set; }
        public string Blank35 { get; set; }
        public string Bath1Blank44_5 { get; set; }
        public string Bath2Blank44_5 { get; set; }
        public string Bath3Blank44_5 { get; set; }
        public string Lot35 { get; set; }
        public string Lot44_5 { get; set; }
        public string RunComment { get; set; }
        public string RunWeatherComment { get; set; }
        public string SampleBottleLotNumber { get; set; }
        public string SalinitiesReadBy { get; set; }
        public string SalinitiesReadYear { get; set; }
        public string SalinitiesReadMonth { get; set; }
        public string SalinitiesReadDay { get; set; }
        public string ResultsReadBy { get; set; }
        public string ResultsReadYear { get; set; }
        public string ResultsReadMonth { get; set; }
        public string ResultsReadDay { get; set; }
        public string ResultsRecordedBy { get; set; }
        public string ResultsRecordedYear { get; set; }
        public string ResultsRecordedMonth { get; set; }
        public string ResultsRecordedDay { get; set; }
        public string DailyDuplicateRLog { get; set; }
        public string DailyDuplicatePrecisionCriteria { get; set; }
        public string DailyDuplicateAcceptableOrUnacceptable { get; set; }
        public string IntertechDuplicateRLog { get; set; }
        public string IntertechDuplicatePrecisionCriteria { get; set; }
        public string IntertechDuplicateAcceptableOrUnacceptable { get; set; }
        public string IntertechReadAcceptableOrUnacceptable { get; set; }
        public string ApprovalYear { get; set; }
        public string ApprovalMonth { get; set; }
        public string ApprovalDay { get; set; }
        public string ApprovedBySupervisorInitials { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        public string BackupDirectory { get; set; }

        public List<LabSheetA1Measurement> LabSheetA1MeasurementList { get; set; }

        public string Log { get; set; }
    }
    public class LabSheetA1Measurement
    {
        public string Site { get; set; }
        public int TVItemID { get; set; }
        public Nullable<DateTime> Time { get; set; }
        public Nullable<int> MPN { get; set; }
        public Nullable<int> Tube10 { get; set; }
        public Nullable<int> Tube1_0 { get; set; }
        public Nullable<int> Tube0_1 { get; set; }
        public Nullable<float> Salinity { get; set; }
        public Nullable<float> Temperature { get; set; }
        public string ProcessedBy { get; set; }
        public Nullable<SampleTypeEnum> SampleType { get; set; }
        public string SiteComment { get; set; }
    }
    public class LabSheetModelAndA1Sheet
    {
        public LabSheetModelAndA1Sheet()
        {
        }

        public LabSheetModel LabSheetModel { get; set; }
        public LabSheetA1Sheet LabSheetA1Sheet { get; set; }
    }
    public class LastUpdateAndContactModel
    {
        public string Error { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
    public class LastUpdateAndTVText
    {
        public string Error { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public System.DateTime LastUpdateDate_Local { get; set; }
        public string TVText { get; set; }
    }
    public class LatLng
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
    public class LoginModel
    {
        public string Error { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnURL { get; set; }
        public List<TVTypeUserAuthorizationModel> TVTypeUserAuthList { get; set; }
        public List<TVItemUserAuthorizationModel> TVItemUserAuthList { get; set; }
    }
    public class MapObj
    {
        public MapObj()
        {
            CoordList = new List<Coord>();
        }

        public int MapInfoID { get; set; }
        public MapInfoDrawTypeEnum MapInfoDrawType { get; set; } // 0 = point, 1 = polyline, 2 = polygon
        public List<Coord> CoordList { get; set; }
    }
    public class SamplingPlanAndFilesLabSheetCountModel
    {
        public SamplingPlanAndFilesLabSheetCountModel()
        {
        }

        public SamplingPlanModel SamplingPlanModel { get; set; }
        public int LabSheetHistoryCount { get; set; }
        public int LabSheetTransferredCount { get; set; }
        public TVFileModel TVFileModelSamplingPlanFileTXT { get; set; }
    }
    public class MWQMSampleDuplicateItem
    {
        public string ParentSite { get; set; }
        public string DuplicateSite { get; set; }
    }
    public class MWQMSiteSampleFCModel
    {
        public string Error { get; set; }
        public DateTime SampleDate { get; set; }
        public int? FC { get; set; }
        public float? Sal { get; set; }
        public float? Temp { get; set; }
        public float? PH { get; set; }
        public float? DO { get; set; }
        public float? Depth { get; set; }
        public int? SampCount { get; set; }
        public int? MinFC { get; set; }
        public int? MaxFC { get; set; }
        public float? GeoMean { get; set; }
        public float? Median { get; set; }
        public float? P90 { get; set; }
        public float? PercOver43 { get; set; }
        public float? PercOver260 { get; set; }
    }
    public class NewContactModel
    {
        public string LoginEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public Nullable<ContactTitleEnum> ContactTitle { get; set; }
    }
    public class Node
    {
        public Node()
        {
            ElementList = new List<Element>();
            ConnectNodeList = new List<Node>();
        }
        public int ID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public int Code { get; set; }
        public List<Element> ElementList { get; set; }
        public List<Node> ConnectNodeList { get; set; }
        public float Value { get; set; }
        public int Flag { get; set; }
    }
    public class NodeLayer
    {
        public int Layer { get; set; }
        public Node Node { get; set; }
        public float Z { get; set; }
    }
    public class OtherFilesToUpload
    {
        public OtherFilesToUpload()
        {
            TVFileList = new List<TVFileModel>();
        }
        public string Error { get; set; }
        public int MikeScenarioID { get; set; }
        public List<TVFileModel> TVFileList { get; set; }
    }
    public class PolyPoint
    {
        public float XCoord { get; set; }
        public float YCoord { get; set; }
        public float Z { get; set; }
    }
    public class PolSourceInactiveReasonEnumTextAndID
    {
        public PolSourceInactiveReasonEnumTextAndID()
        {
        }

        public string Text { get; set; }
        public int ID { get; set; }
    }
    public class PolSourceObsInfoEnumHideAndID
    {
        public string Hide { get; set; }
        public int ID { get; set; }
    }
    public class PolSourceObsInfoEnumTextAndID
    {
        public string Text { get; set; }
        public int ID { get; set; }
    }
    public class PolSourceObsInfoChild
    {
        public PolSourceObsInfoEnum PolSourceObsInfo { get; set; }
        public PolSourceObsInfoEnum PolSourceObsInfoChildStart { get; set; }
    }

    public class RegisterModel
    {
        public string Error { get; set; }
        public string FirstName { get; set; }
        public string Initial { get; set; }
        public string LastName { get; set; }
        public string WebName { get; set; }
        public string LoginEmail { get; set; }
        public bool IsAdmin { get; set; }
        public bool EmailValidated { get; set; }
        public bool Disabled { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ReturnURL { get; set; }
    }
    public class RTBStringPos
    {
        public RTBStringPos()
        {
        }

        public int StartPos { get; set; }
        public int EndPos { get; set; }
        public string Text { get; set; }
        public string TagText { get; set; }
    }
    public class SearchModel
    {
        public string value { get; set; }
        public int id { get; set; }
    }
    public class SearchTagAndTerms
    {
        public SearchTagAndTerms()
        {
            SearchTermList = new List<string>();
        }

        public SearchTagEnum SearchTag { get; set; }
        public List<string> SearchTermList { get; set; }
    }
    public class SubsectorMWQMSampleYear
    {
        public SubsectorMWQMSampleYear()
        {
        }

        public int SubsectorTVItemID { get; set; }
        public int Year { get; set; }
        public DateTime EarliestDate { get; set; }
        public DateTime LatestDate { get; set; }
    }
    public class TVFullText
    {
        public string TVPath { get; set; }
        public string FullText { get; set; }
    }
    public class TVItemModelSubsectorAndMWQMSite
    {
        public TVItemModelSubsectorAndMWQMSite()
        {
            TVItemMWQMSiteList = new List<TVItemModel>();
        }

        public TVItemModel TVItemModelSubsector { get; set; }
        public List<TVItemModel> TVItemMWQMSiteList { get; set; }
        public TVItemModel TVItemMWQMSiteDuplicate { get; set; }
    }
    public class TVItemModelInfrastructureTypeTVItemLinkModel
    {
        public TVItemModelInfrastructureTypeTVItemLinkModel()
        {
            TVItemModelLinkList = new List<TVItemLinkModel>();
        }

        public TVItemModel TVItemModel { get; set; }
        public InfrastructureTypeEnum InfrastructureType { get; set; }
        public List<TVItemLinkModel> TVItemModelLinkList { get; set; }
        public TVItemModelInfrastructureTypeTVItemLinkModel FlowTo { get; set; }
        public Nullable<int> SeeOtherMunicipalityTVItemID { get; set; }
    }
    public class OpenDataStat
    {
        public OpenDataStat()
        {
        }

        public string Error { get; set; }
        public int TotalNumberOfSamples { get; set; }
        public int NumberOfUseForOpenDataSamples { get; set; }
    }
    public class TVItemTVAuth
    {
        public string Error { get; set; }
        public int TVItemUserAuthID { get; set; }
        public string TVText { get; set; }
        public int TVItemID1 { get; set; }
        public string TVTypeStr { get; set; }
        public TVAuthEnum TVAuth { get; set; }
    }
    public class TVLocation
    {
        public TVLocation()
        {
            MapObjList = new List<MapObj>();
        }

        public string Error { get; set; }
        public int TVItemID { get; set; }
        public string TVText { get; set; }
        public TVTypeEnum TVType { get; set; }
        public TVTypeEnum SubTVType { get; set; }
        public List<MapObj> MapObjList { get; set; }
    }
    public class TVTextLanguage
    {
        public string TVText { get; set; }
        public LanguageEnum Language { get; set; }
    }
    public class TVTypeNamesAndPath
    {
        public string TVTypeName { get; set; }
        public int Index { get; set; }
        public string TVPath { get; set; }
    }
    public class Vector
    {
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
    }
    public class VPFullModel : VPScenarioModel
    {
        public VPFullModel()
        {
            AmbientList = new List<VPAmbientModel>();
            ResultList = new List<VPResultModel>();
        }
        public string RawResults { get; set; }
        public List<VPAmbientModel> AmbientList { get; set; }
        public List<VPResultModel> ResultList { get; set; }
    }
    public class VPResValues
    {
        public int Conc { get; set; }
        public double Dilu { get; set; }
        public double FarfieldWidth { get; set; }
        public double Distance { get; set; }
        public double TheTime { get; set; }
        public double Decay { get; set; }
    }
    public class VPScenarioIDAndRawResults
    {
        public int VPScenarioID { get; set; }
        public string RawResults { get; set; }
    }
    public class URLNumberOfSamples
    {
        public URLNumberOfSamples()
        {
        }

        public string url { get; set; }
        public int NumberOfSamples { get; set; }
    }
    public class WaterLevelResult
    {
        public WaterLevelResult()
        {

        }
        public DateTime Date { get; set; }
        public double WaterLevel { get; set; }
    }
    #endregion Class

}
