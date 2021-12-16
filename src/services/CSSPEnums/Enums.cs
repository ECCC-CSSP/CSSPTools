/*
 * This document is manually edited. 
 * It's the only .cs document in CSSPEnums.proj the coder actually edits. 
 * Every other document is automatically generated using the list of applications below
 * 
 * EnumsCompareWithOldEnums.exe
 * EnumsGenerated_cs
 * EnumsPolSourceInfoRelatedFiles
 * EnumsTestGenerated_cs
 * 
 * You also need to edit the CSSPEnumsRes.resx and the CSSPEnumsRes.fr.resx for language
 * 
 * To produce documentation within code you need to include in project the EnumsWithDocGenerated.cs file
 * while excluding from project the Enums.cs file before recompiling. You then use the CSSPDoc project
 * and compile to generate the documentation in the form of a web site.
 * 
 * The same should be done for PolSourceObsInfoEnumWithDocGenerated.cs (to include in project) and 
 * PolSourceObsInfoEnumGenerated.cs (to exclude from project).
 * 
 */

namespace CSSPEnums;

public partial class Enums : IEnums
{
    public Enums(/*ICSSPCultureService CSSPCultureService*/)
    {
        //this.CSSPCultureService = CSSPCultureService;
    }
}

public enum ActionDBTypeEnum
{
    Create = 1,
    Read = 2,
    Update = 3,
    Delete = 4,
}
public enum AddContactTypeEnum
{
    First = 1,
    Register = 2,
    LoggedIn = 3,
}
public enum EntityQueryTypeEnum
{
    AsNoTracking = 1,
    WithTracking = 2,
}
// might be able to delete PolSourceObsInfoTypeEnum
public enum PolSourceObsInfoTypeEnum
{
    Description = 1,
    Report = 2,
    Text = 3,
    Initial = 4,
}

public enum AddressTypeEnum
{
    Mailing = 1,
    Shipping = 2,
    Civic = 3,
}
public enum AreaSubComponentEnum
{
    Sectors = 1,
    Files = 2,
}
public enum AerationTypeEnum
{
    MechanicalAirLines = 1,
    MechanicalSurfaceMixers = 2,
}
public enum AlarmSystemTypeEnum
{
    SCADA = 1,
    None = 2,
    OnlyVisualLight = 3,
    SCADAAndLight = 4,
    PagerAndLight = 5,
}
public enum AnalysisCalculationTypeEnum
{
    All = 1,
    Wet = 2,
    Dry = 3,
}
public enum AnalysisReportExportCommandEnum
{
    Report = 1,
    Excel = 2,
}
public enum AnalyzeMethodEnum
{
    MF = 1,
    ZZ_510Q = 2,
    ZZ_509Q = 3,
    ZZ_0 = 4,
    ZZ_525Q = 5,
    MPN = 6,
    ZZ_0Q = 7,
    AnalyzeMethod8 = 8,
    AnalyzeMethod9 = 9,
    AnalyzeMethod10 = 10,
    AnalyzeMethod11 = 11,
    AnalyzeMethod12 = 12,
}
public enum AppTaskCommandEnum
{
    GenerateWebTide = 1,
    MikeScenarioAskToRun = 2,
    MikeScenarioImport = 3,
    MikeScenarioOtherFileImport = 4,
    MikeScenarioRunning = 5,
    MikeScenarioToCancel = 6,
    MikeScenarioWaitingToRun = 7,
    SetupWebTide = 8,
    UpdateClimateSiteInformation = 9,
    UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate = 10,
    UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate = 11,
    CreateFCForm = 12,
    CreateSamplingPlanSamplingPlanTextFile = 13,
    CreateDocumentFromTemplate = 14,
    GetClimateSitesDataForRunsOfYear = 15,
    CreateWebTideDataWLAtFirstNode = 16,
    ExportEmailDistributionLists = 17,
    ExportAnalysisToExcel = 18,
    CreateDocumentFromParameters = 19,
    CreateDocxPDF = 20,
    CreateXlsxPDF = 21,
    OpenDataCSVOfMWQMSites = 22,
    OpenDataKMZOfMWQMSites = 23,
    OpenDataXlsxOfMWQMSitesAndSamples = 24,
    OpenDataCSVOfMWQMSamples = 25,
    GetAllPrecipitationForYear = 26,
    FillRunPrecipByClimateSitePriorityForYear = 27,
    FindMissingPrecipForProvince = 28,
    ExportToArcGIS = 29,
    GenerateClassificationForCSSPWebToolsVisualization = 30,
    GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization = 31,
    OpenDataCSVNationalOfMWQMSites = 32,
    OpenDataCSVNationalOfMWQMSamples = 33,
    ProvinceToolsCreateClassificationInputsKML = 34,
    ProvinceToolsCreateGroupingInputsKML = 35,
    ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML = 36,
    UpdateHydrometricSiteInformation = 37,
    UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate = 38,
    UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate = 39,
    GetHydrometricSitesDataForRunsOfYear = 40,
    GetAllDischargesForYear = 41,
    FillRunDischargesByHydrometricSitePriorityForYear = 42,
    FindMissingDischargesForProvince = 43,
    LoadHydrometricDataValue = 44,
    GenerateKMLFileClassificationForCSSPWebToolsVisualization = 45,
    ProvinceToolsGenerateStats = 46,
    MikeScenarioPrepareResults = 47,
    ClimateSiteLoadCoCoRaHSData = 48,
    SyncDBs = 49,
}
public enum AppTaskStatusEnum
{
    Created = 1,
    Running = 2,
    Completed = 3,
    Cancelled = 4,
}
public enum AscDescEnum
{
    Ascending = 1,
    Descending = 2
}
public enum DBCommandEnum
{
    Original = 1,
    Modified = 2,
    Created = 3,
    Deleted = 4,
}
public enum BeaufortScaleEnum
{
    Calm = 0,
    LightAir = 1,
    LightBreeze = 2,
    GentleBreeze = 3,
    ModerateBreeze = 4,
    FreshBreeze = 5,
    StrongBreeze = 6,
    HighWind_ModerateGale_NearGale = 7,
    Gale_FreshGale = 8,
    Strong_SevereGale = 9,
    Storm_WholeGale = 10,
    ViolentStorm = 11,
    HurricaneForce = 12,
}
public enum BoxModelResultTypeEnum
{
    Dilution = 1,
    NoDecayUntreated = 2,
    NoDecayPreDisinfection = 3,
    DecayUntreated = 4,
    DecayPreDisinfection = 5,
}
public enum CanOverflowTypeEnum
{
    Yes = 1,
    No = 2,
    Unknown = 3,
}
public enum ClassificationTypeEnum
{
    Approved = 1,
    Restricted = 2,
    Prohibited = 3,
    ConditionallyApproved = 4,
    ConditionallyRestricted = 5,
}
public enum CollectionSystemTypeEnum
{
    CompletelySeparated = 1,
    CompletelyCombined = 2,
    Combined90Separated10 = 3,
    Combined80Separated20 = 4,
    Combined70Separated30 = 5,
    Combined60Separated40 = 6,
    Combined50Separated50 = 7,
    Combined40Separated60 = 8,
    Combined30Separated70 = 9,
    Combined20Separated80 = 10,
    Combined10Separated90 = 11,
}
public enum ContactTitleEnum
{
    DirectorGeneral = 1,
    DirectorPublicWorks = 2,
    Superintendent = 3,
    Engineer = 4,
    Foreman = 5,
    Operator = 6,
    FacilitiesManager = 7,
    Supervisor = 8,
    Technician = 9,
}
public enum ContentSizeEnum
{
    Size30 = 1,
    Size40 = 2,
    Size50 = 3,
    Size60 = 4,
    Size70 = 5,
}
public enum CountrySubComponentEnum
{
    Provinces = 1,
    Files = 2,
    OpenDataNational = 3,
    EmailDistributionList = 4,
    RainExceedance = 5,
}
//public enum CSSPAppNameEnum
//{
//    Unknown = 1,
//    CSSPUpdate = 2,
//}
//public enum CSSPCommandNameEnum
//{
//    Unknown = 1,
//    ClearOldUnnecessaryStats = 2,
//    RemoveAzureDirectoriesNotFoundInTVFiles = 3,
//    RemoveAzureFilesNotFoundInTVFiles = 4,
//    RemoveLocalDirectoriesNotFoundInTVFiles = 5,
//    RemoveLocalFilesNotFoundInTVFiles = 6,
//    RemoveNationalBackupDirectoriesNotFoundInTVFiles = 7,
//    RemoveNationalBackupFilesNotFoundInTVFiles = 8,
//    RemoveTVFilesDoubleAssociatedWithTVItemsTypeFile = 9,
//    RemoveTVItemsNoAssociatedWithTVFiles = 10,
//    UpdateAllTVItemStats = 11,
//    UpdateChangedTVItemStats = 12,
//    UploadAllFilesToAzure = 13,
//    UploadAllJsonFilesToAzure = 14,
//    UploadChangedFilesToAzure = 15,
//    UploadChangedJsonFilesToAzure = 16,
//}
public enum CSSPWQInputSheetTypeEnum
{
    A1 = 1,
    LTB = 2,
    EC = 3,
}
public enum CSSPWQInputTypeEnum
{
    Subsector = 1,
    Municipality = 2,
}
public enum DailyOrHourlyDataEnum
{
    Daily = 1,
    Hourly = 2,
}
public enum DisinfectionTypeEnum
{
    None = 1,
    UV = 2,
    ChlorinationNoDechlorination = 3,
    ChlorinationWithDechlorination = 4,
    UVSeasonal = 5,
    ChlorinationNoDechlorinationSeasonal = 6,
    ChlorinationWithDechlorinationSeasonal = 7,
}
public enum DrogueTypeEnum
{
    SmallDrogue = 1,
    LargeDrogue = 2,
}
public enum EmailTypeEnum
{
    Personal = 1,
    Work = 2,
    Personal2 = 3,
    Work2 = 4,
}
public enum ExcelExportShowDataTypeEnum
{
    FecalColiform = 1,
    Temperature = 2,
    Salinity = 3,
    P90 = 4,
    GemetricMean = 5,
    Median = 6,
    PercOfP90Over43 = 7,
    PercOfP90Over260 = 8,
}
public enum FacilityTypeEnum
{
    Lagoon = 1,
    Plant = 2,
}
public enum FilePurposeEnum
{
    MikeInput = 1,
    MikeInputMDF = 2,
    MikeResultDFSU = 3,
    MikeResultKMZ = 4,
    Information = 5,
    Image = 6,
    Picture = 7,
    ReportGenerated = 8,
    TemplateGenerated = 9,
    GeneratedFCForm = 10,
    Template = 11,
    Map = 12,
    Analysis = 13,
    OpenData = 14,
}
public enum FilesSortPropEnum
{
    FileName = 1,
    FileSize = 2,
    FileType = 3,
    FilePurpose = 4,
    FileDate = 5,
}
public enum FileStatusEnum
{
    Changed = 1,
    Sent = 2,
    Accepted = 3,
    Rejected = 4,
    Fail = 5,
}
public enum FileTypeEnum
{
    DFS0 = 1,
    DFS1 = 2,
    DFSU = 3,
    KMZ = 4,
    LOG = 5,
    M21FM = 6,
    M3FM = 7,
    MDF = 8,
    MESH = 9,
    XLSX = 10,
    DOCX = 11,
    PDF = 12,
    JPG = 13,
    JPEG = 14,
    GIF = 15,
    PNG = 16,
    HTML = 17,
    TXT = 18,
    XYZ = 19,
    KML = 20,
    CSV = 21,
    WMV = 22,
}
public enum InfrastructureTypeEnum
{
    WWTP = 1,
    LiftStation = 2,
    Other = 3,
    SeeOtherMunicipality = 4,
    LineOverflow = 5,
}
public enum KMZActionEnum
{
    DoNothing = 1,
    GenerateKMZContourAnimation = 2,
    GenerateKMZContourLimit = 3,
    GenerateKMZCurrentAnimation = 4,
    GenerateKMZCurrentMaximum = 5,
    GenerateKMZMesh = 6,
    GenerateKMZStudyArea = 7,
    GenerateKMZBoundaryConditionNodes = 8,
}
public enum LaboratoryEnum
{
    ZZ_0 = 1,
    ZZ_1 = 2,
    ZZ_2 = 3,
    ZZ_3 = 4,
    ZZ_4 = 5,
    ZZ_1Q = 6,
    ZZ_2Q = 7,
    ZZ_3Q = 8,
    ZZ_4Q = 9,
    ZZ_5Q = 10,
    ZZ_11BC = 11,
    ZZ_12BC = 12,
    ZZ_13BC = 13,
    ZZ_14BC = 14,
    ZZ_15BC = 15,
    ZZ_16BC = 16,
    ZZ_17BC = 17,
    ZZ_18BC = 18,
    MonctonEnvironmentCanada = 19,
    BIOEnvironmentCanada = 20,
    EasternCharlotteWaterwayLaboratory = 21,
    InstitutDeRechercheSurLesZonesCotieres = 22,
    CentreDeRechercheSurLesAliments = 23,
    CaraquetMobileLaboratoryEnvironmentCanada = 24,
    MaxxamAnalyticsBedford = 25,
    MaxxamAnalyticsSydney = 26,
    PEIAnalyticalLaboratory = 27,
    NLMobileLaboratory = 28,
    AvalonLaboratoriesInc = 29,
    Maxxam = 30,
}
public enum LabSheetStatusEnum
{
    Created = 1,
    Transferred = 2,
    Accepted = 3,
    Rejected = 4,
}
public enum LabSheetTypeEnum
{
    A1 = 1,
    LTB = 2,
    EC = 3,
}
public enum LanguageEnum
{
    en = 1,
    fr = 2,
    enAndfr = 3,
    es = 4,
}
public enum LogCommandEnum
{
    Add = 1,
    Change = 2,
    Delete = 3,
}
public enum MapInfoDrawTypeEnum
{
    Point = 1,
    Polyline = 2,
    Polygon = 3,
}
public enum MikeBoundaryConditionLevelOrVelocityEnum
{
    Level = 1,
    Velocity = 2,
}
public enum MikeScenarioSpecialResultKMLTypeEnum
{
    Mesh = 1,
    StudyArea = 2,
    BoundaryConditions = 3,
    PollutionLimit = 4,
    PollutionAnimation = 5,
}
public enum MikeScenarioSubComponentEnum
{
    GeneralParameters = 1,
    Sources = 2,
    InputSummary = 3,
    Files = 4,
    GeneralResults = 5
}
public enum MonthEnum
{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November = 11,
    December = 12,
}
public enum MWQMRunSubComponentEnum
{
    Information = 1,
    Files = 2,
}
public enum MWQMSiteLatestClassificationEnum
{
    Approved = 1,
    ConditionallyApproved = 2,
    Restricted = 3,
    ConditionallyRestricted = 4,
    Prohibited = 5,
    Unclassified = 6,
}
public enum MWQMSiteSubComponentEnum
{
    Information = 1,
    Files = 2,
}
public enum MunicipalitySubComponentEnum
{
    Infrastructures = 1,
    MIKEScenarios = 2,
    Contacts = 3,
    Files = 4
}
public enum PolSourceInactiveReasonEnum
{
    Abandoned = 1,
    Closed = 2,
    Removed = 3,
}
public enum PolSourceIssueRiskEnum
{
    LowRisk = 1,
    ModerateRisk = 2,
    HighRisk = 3,
}
public enum PolSourceSiteSubComponentEnum
{
    Information = 1,
    Files = 2,
}
public enum PositionEnum
{
    LeftBottom = 1,
    RightBottom = 2,
    LeftTop = 3,
    RightTop = 4,
}
//public enum PolSourceObsInfoEnum is under file EnumsPolSourceInfoGenerated.cs
public enum PreliminaryTreatmentTypeEnum
{
    NotApplicable = 1,
    BarScreen = 2,
    Grinder = 3,
    MechanicalScreening = 4,
}
public enum PrimaryTreatmentTypeEnum
{
    NotApplicable = 1,
    Sedimentation = 2,
    ChemicalCoagulation = 3,
    Filtration = 4,
    PrimaryClarification = 5,
}
public enum PropertyTypeEnum
{
    Int = 1,
    Double = 2,
    String = 3,
    Boolean = 4,
    DateTime = 5,
    Enum = 6,
}
public enum ProvinceSubComponentEnum
{
    Areas = 1,
    Municipalities = 2,
    Files = 3,
    SamplingPlan = 4,
    OpenData = 5,
    ProvinceTools = 6,
}
public enum ReportConditionEnum
{
    ReportConditionTrue = 1,
    ReportConditionFalse = 2,
    ReportConditionContain = 3,
    ReportConditionStart = 4,
    ReportConditionEnd = 5,
    ReportConditionBigger = 6,
    ReportConditionSmaller = 7,
    ReportConditionEqual = 8,
}
public enum ReportFieldTypeEnum
{
    NumberWhole = 1,
    NumberWithDecimal = 2,
    DateAndTime = 3,
    Text = 4,
    TrueOrFalse = 5,
    FilePurpose = 6,
    FileType = 7,
    TranslationStatus = 8,
    BoxModelResultType = 9,
    InfrastructureType = 10,
    FacilityType = 11,
    AerationType = 12,
    PreliminaryTreatmentType = 13,
    PrimaryTreatmentType = 14,
    SecondaryTreatmentType = 15,
    TertiaryTreatmentType = 16,
    TreatmentType = 17,
    DisinfectionType = 18,
    CollectionSystemType = 19,
    AlarmSystemType = 20,
    ScenarioStatus = 21,
    StorageDataType = 22,
    Language = 23,
    SampleType = 24,
    BeaufortScale = 25,
    AnalyzeMethod = 26,
    SampleMatrix = 27,
    Laboratory = 28,
    SampleStatus = 29,
    SamplingPlanType = 30,
    LabSheetSampleType = 31,
    LabSheetType = 32,
    LabSheetStatus = 33,
    PolSourceInactiveReason = 34,
    PolSourceObsInfo = 35,
    AddressType = 36,
    StreetType = 37,
    ContactTitle = 38,
    EmailType = 39,
    TelType = 40,
    TideText = 41,
    TideDataType = 42,
    SpecialTableType = 43,
    MWQMSiteLatestClassification = 44,
    PolSourceIssueRisk = 45,
    MikeScenarioSpecialResultKMLType = 46
}
public enum ReportFileTypeEnum
{
    CSV = 1,
    Word = 2,
    Excel = 3,
    KML = 4,
}
public enum ReportFormatingDateEnum
{
    ReportFormatingDateYearOnly = 1,
    ReportFormatingDateMonthDecimalOnly = 2,
    ReportFormatingDateMonthShortTextOnly = 3,
    ReportFormatingDateMonthFullTextOnly = 4,
    ReportFormatingDateDayOnly = 5,
    ReportFormatingDateHourOnly = 6,
    ReportFormatingDateMinuteOnly = 7,
    ReportFormatingDateYearMonthDecimalDay = 8,
    ReportFormatingDateYearMonthShortTextDay = 9,
    ReportFormatingDateYearMonthFullTextDay = 10,
    ReportFormatingDateYearMonthDecimalDayHourMinute = 11,
    ReportFormatingDateYearMonthShortTextDayHourMinute = 12,
    ReportFormatingDateYearMonthFullTextDayHourMinute = 13,
}
public enum ReportFormatingNumberEnum
{
    ReportFormatingNumber0Decimal = 1,
    ReportFormatingNumber1Decimal = 2,
    ReportFormatingNumber2Decimal = 3,
    ReportFormatingNumber3Decimal = 4,
    ReportFormatingNumber4Decimal = 5,
    ReportFormatingNumber5Decimal = 6,
    ReportFormatingNumber6Decimal = 7,
    ReportFormatingNumberScientific0Decimal = 8,
    ReportFormatingNumberScientific1Decimal = 9,
    ReportFormatingNumberScientific2Decimal = 10,
    ReportFormatingNumberScientific3Decimal = 11,
    ReportFormatingNumberScientific4Decimal = 12,
    ReportFormatingNumberScientific5Decimal = 13,
    ReportFormatingNumberScientific6Decimal = 14,
}
public enum ReportGenerateObjectsKeywordEnum
{
    SUBSECTOR_RE_EVALUATION_COVER_PAGE = 1,
    SUBSECTOR_FC_SUMMARY_STAT_ALL = 2,
    SUBSECTOR_FC_SUMMARY_STAT_WET = 3,
    SUBSECTOR_FC_SUMMARY_STAT_DRY = 4,
    SUBSECTOR_MWQM_SITES_DATA_AVAILABILITY = 5,
    SUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR = 6,
    SUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR = 7,
    SUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR = 8,
    SUBSECTOR_MWQM_SITES_FC_TABLE = 9,
    SUBSECTOR_MWQM_SITES_SALINITY_TABLE = 10,
    SUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE = 11,
    SUBSECTOR_POLLUTION_SOURCE_SITES = 12,
    SUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT = 13,
    SUBSECTOR_MUNICIPALITIES_COMPACT = 14,
    SUBSECTOR_MUNICIPALITIES_FULL = 15,
    SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP = 16,
    SUBSECTOR_ECCC_AND_SWCP_LOGO = 17,
    SUBSECTOR_CSSP_LOGO = 18,
    SUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP = 19,
    SUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP = 20,
    SUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP = 21,
    SUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP = 22,
}
public enum ReportSortingEnum
{
    ReportSortingAscending = 1,
    ReportSortingDescending = 2,
}
public enum ReportTreeNodeSubTypeEnum
{
    TableSelectable = 1,
    Field = 2,
    FieldsHolder = 3,
    TableNotSelectable = 4,
}
public enum ReportTreeNodeTypeEnum
{
    ReportRootType = 1,
    ReportCountryType = 2,
    ReportProvinceType = 3,
    ReportAreaType = 4,
    ReportSectorType = 5,
    ReportSubsectorType = 6,
    ReportMWQMSiteType = 7,
    ReportMWQMRunType = 8,
    ReportPolSourceSiteType = 9,
    ReportMunicipalityType = 10,
    ReportRootFileType = 11,
    ReportInfrastructureType = 12,
    ReportBoxModelType = 13,
    ReportVisualPlumesScenarioType = 14,
    ReportMikeScenarioType = 15,
    ReportMikeSourceType = 16,
    ReportMWQMSiteSampleType = 17,
    ReportPolSourceSiteObsType = 18,
    ReportPolSourceSiteObsIssueType = 19,
    ReportMikeScenarioGeneralParameterType = 20,
    ReportMunicipalityContactType = 21,
    ReportConditionType = 22,
    ReportStatisticType = 23,
    ReportFieldsType = 24,
    ReportFieldType = 25,
    ReportPolSourceSiteAddressType = 26,
    ReportMunicipalityContactTelType = 27,
    ReportMunicipalityContactEmailType = 28,
    ReportBoxModelResultType = 29,
    ReportClimateSiteType = 30,
    ReportClimateSiteDataType = 31,
    ReportHydrometricSiteType = 32,
    ReportHydrometricSiteDataType = 33,
    ReportHydrometricSiteRatingCurveType = 34,
    ReportHydrometricSiteRatingCurveValueType = 35,
    ReportInfrastructureAddressType = 36,
    ReportSubsectorLabSheetType = 37,
    ReportSubsectorLabSheetDetailType = 38,
    ReportSubsectorLabSheetTubeMPNDetailType = 39,
    ReportMWQMRunSampleType = 40,
    ReportCountryFileType = 41,
    ReportProvinceFileType = 42,
    ReportAreaFileType = 43,
    ReportSectorFileType = 44,
    ReportSubsectorFileType = 45,
    ReportMWQMSiteFileType = 46,
    ReportMWQMRunFileType = 47,
    ReportPolSourceSiteFileType = 48,
    ReportMunicipalityFileType = 49,
    ReportInfrastructureFileType = 50,
    ReportMikeScenarioFileType = 51,
    ReportMikeSourceStartEndType = 52,
    ReportMWQMRunLabSheetType = 53,
    ReportMWQMRunLabSheetDetailType = 54,
    ReportMWQMRunLabSheetTubeMPNDetailType = 55,
    ReportSamplingPlanLabSheetType = 56,
    ReportSamplingPlanLabSheetDetailType = 57,
    ReportSamplingPlanLabSheetTubeMPNDetailType = 58,
    ReportSamplingPlanType = 59,
    ReportSamplingPlanSubsectorType = 60,
    ReportSamplingPlanSubsectorSiteType = 61,
    ReportMikeBoundaryConditionType = 62,
    ReportVisualPlumesScenarioAmbientType = 63,
    ReportVisualPlumesScenarioResultType = 64,
    ReportMPNLookupType = 65,
    ReportMWQMSiteStartAndEndType = 66,
    ReportSubsectorTideSiteType = 67,
    ReportSubsectorTideSiteDataType = 68,
    ReportOrderType = 69,
    ReportFormatType = 70,
    ReportMunicipalityContactAddressType = 71,
    ReportSubsectorClimateSiteType = 72,
    ReportSubsectorHydrometricSiteType = 73,
    ReportSubsectorHydrometricSiteDataType = 74,
    ReportSubsectorHydrometricSiteRatingCurveType = 75,
    ReportSubsectorClimateSiteDataType = 76,
    ReportSubsectorHydrometricSiteRatingCurveValueType = 77,
    ReportSubsectorSpecialTableType = 78,
    ReportMikeScenarioSpecialResultKMLType = 79,
}
public enum RootSubComponentEnum
{
    Countries = 1,
    Files = 2,
    ExportArcGIS = 3,
}
public enum RunningOnEnum
{
    Azure = 1,
    Local = 2,
}
public enum SameDayNextDayEnum
{
    SameDay = 1,
    NextDay = 2,
}
public enum SampleMatrixEnum
{
    W = 1,
    S = 2,
    B = 3,
    MPNQ = 4,
    SampleMatrix5 = 5,
    SampleMatrix6 = 6,
    Water = 7,
}
public enum SampleStatusEnum
{
    Active = 1,
    Archived = 2,
    SampleStatus3 = 3,
    SampleStatus4 = 4,
    SampleStatus5 = 5,
}
public enum SampleTypeEnum
{
    DailyDuplicate = 101,
    Infrastructure = 102,
    IntertechDuplicate = 103,
    IntertechRead = 104,
    RainCMP = 105,
    RainRun = 106,
    ReopeningEmergencyRain = 107,
    ReopeningSpill = 108,
    Routine = 109,
    Sanitary = 110,
    Study = 111,
    Sediment = 112,
    Bivalve = 113,
}
public enum SamplingPlanTypeEnum
{
    Subsector = 1,
    Municipality = 2,
}
public enum ScenarioStatusEnum
{
    Normal = 1,
    Copying = 2,
    Copied = 3,
    Changing = 4,
    Changed = 5,
    AskToRun = 6,
    Running = 7,
    Completed = 8,
    Cancelled = 9,
}
public enum SearchTagEnum
{
    c = 1,
    e = 2,
    t = 3,
    fi = 4,
    fp = 5,
    frg = 6,
    ftg = 7,
    fpdf = 8,
    fdocx = 9,
    fxlsx = 10,
    fkmz = 11,
    fxyz = 12,
    fdfs = 13,
    fmike = 14,
    fmdf = 15,
    fm21fm = 16,
    fm3fm = 17,
    fmesh = 18,
    flog = 19,
    ftxt = 20,
    m = 21,
    p = 22,
    ms = 23,
    cs = 24,
    hs = 25,
    ts = 26,
    ww = 27,
    ls = 28,
    st = 29,
    ps = 30,
    a = 31,
    s = 32,
    ss = 33,
    u = 34,
    notag = 35,
    fcsv = 36,
}
public enum SeasonEnum
{
    Winter = 1,
    Spring = 2,
    Summer = 3,
    Fall = 4,
}
public enum SecondaryTreatmentTypeEnum
{
    NotApplicable = 1,
    RotatingBiologicalContactor = 2,
    TricklingFilters = 3,
    SequencingBatchReactor = 4,
    OxidationDitch = 5,
    ExtendedAeration = 6,
    ContactStabilization = 7,
    PhysicalChemicalProcesses = 8,
    //MechanicalMixer = 9,
    MovingBedBioReactor = 10,
    BiologicalAearatedFilters = 11,
    AeratedSubmergedBioFilmReactor = 12,
    IntegratedFixedFilmActivatedSludge = 13,
    ActivatedSludge = 14,
    ExtendedActivatedSludge = 15,
}
public enum SectorSubComponentEnum
{
    Subsectors = 1,
    Files = 2,
    MIKEScenarios = 3,
}
public enum ShellSubComponentEnum
{
    Area = 1,
    Country = 2,
    MikeScenario = 3,
    Municipality = 4,
    MWQMRun = 5,
    MWQMSite = 6,
    PolSourceSite = 7,
    Province = 8,
    Root = 9,
    Sector = 10,
    Subsector = 11,
}
public enum SiteTypeEnum
{
    Climate = 1,
    Hydrometric = 2,
    Tide = 3,
}
public enum SortOrderAngularEnum
{
    AreaSectors = 1,
    CountryProvinces = 2,
    MunicipalityMIKEScenarios = 3,
    ProvinceAreas = 4,
    ProvinceMunicipalities = 5,
    RootCountries = 6,
    SectorSubsectors = 7,
    SectorMikeScenarios = 8,
    SubsectorMWQMRuns = 9,
    SubsectorMWQMSites = 10,
    SubsectorPolSourceSites = 11,
}
public enum SpecialTableTypeEnum
{
    FCDensitiesTable = 1,
    SalinityTable = 2,
    TemperatureTable = 3,
    GeometricMeanTable = 4,
    MedianTable = 5,
    P90Table = 6,
    PercentOver43Table = 7,
    PercentOver260Table = 8,
}
public enum StorageDataTypeEnum
{
    Archived = 1,
    Forcasted = 2,
    Observed = 3,
}
public enum StreetTypeEnum
{
    Street = 1,
    Road = 2,
    Avenue = 3,
    Crescent = 4,
    Court = 5,
    Alley = 6,
    Drive = 7,
    Blvd = 8,
    Route = 9,
    Lane = 10,
}
public enum SubsectorSubComponentEnum
{
    MWQMSites = 1,
    Analysis = 2,
    MWQMRuns = 3,
    PollutionSourceSites = 4,
    Files = 5,
    SubsectorTools = 6,
    LogBook = 7,
}
public enum TelTypeEnum
{
    Personal = 1,
    Work = 2,
    Mobile = 3,
    Personal2 = 4,
    Work2 = 5,
    Mobile2 = 6,
}
public enum TertiaryTreatmentTypeEnum
{
    NotApplicable = 1,
    Adsorption = 2,
    Flocculation = 3,
    MembraneFiltration = 4,
    IonExchange = 5,
    ReverseOsmosis = 6,
    BiologicalNutrientRemoval = 7,
}
public enum TideDataTypeEnum
{
    Min15 = 1,
    Min60 = 2,
}
public enum TideTextEnum
{
    LowTide = 1,
    LowTideFalling = 2,
    LowTideRising = 3,
    MidTide = 4,
    MidTideFalling = 5,
    MidTideRising = 6,
    HighTide = 7,
    HighTideFalling = 8,
    HighTideRising = 9,
}
public enum TopComponentEnum
{
    Home = 1,
    Shell = 2,
}
public enum TranslationStatusEnum
{
    NotTranslated = 1,
    ElectronicallyTranslated = 2,
    Translated = 3,
}
public enum TreatmentTypeEnum
{
    ActivatedSludge = 1,
    ActivatedSludgeWithBiofilter = 2,
    LagoonNoAeration1Cell = 3,
    LagoonNoAeration2Cell = 4,
    LagoonNoAeration3Cell = 5,
    LagoonNoAeration4Cell = 6,
    LagoonNoAeration5Cell = 7,
    LagoonWithAeration1Cell = 8,
    LagoonWithAeration2Cell = 9,
    LagoonWithAeration3Cell = 10,
    LagoonWithAeration4Cell = 11,
    LagoonWithAeration5Cell = 12,
    LagoonWithAeration6Cell = 13,
    StabalizingPondOnly = 14,
    OxidationDitchOnly = 15,
    CirculatingFluidizedBed = 16,
    TricklingFilter = 17,
    RecirculatingSandFilter = 18,
    TrashRackRakeOnly = 19,
    SepticTank = 20,
    Secondary = 21,
    Tertiary = 22,
    VolumeFermenter = 23,
    BioFilmReactor = 24,
    BioGreen = 25,
    BioDisks = 26,
    ChemicalPrimary = 27,
    Chromoglass = 28,
    Primary = 29,
    SequencingBatchReactor = 30,
    PeatSystem = 31,
    Physicochimique = 32,
    RotatingBiologicalContactor = 33,
}
public enum TVAuthEnum
{
    NoAccess = 1,
    Read = 2,
    Write = 3,
    Create = 4,
    Delete = 5,
    Admin = 6,
}
public enum TVTypeEnum
{
    Root = 1,
    Address = 2,
    Area = 3,
    ClimateSite = 4,
    Contact = 5,
    Country = 6,
    Email = 7,
    File = 8,
    HydrometricSite = 9,
    Infrastructure = 10,
    MikeBoundaryConditionWebTide = 11,
    MikeBoundaryConditionMesh = 12,
    MikeScenario = 13,
    MikeSource = 14,
    Municipality = 15,
    MWQMSite = 16,
    PolSourceSite = 17,
    Province = 18,
    Sector = 19,
    Subsector = 20,
    Tel = 21,
    TideSite = 22,
    MWQMSiteSample = 23,
    WasteWaterTreatmentPlant = 24,
    LiftStation = 25,
    Spill = 26,
    BoxModel = 27,
    VisualPlumesScenario = 28,
    Outfall = 29,
    OtherInfrastructure = 30,
    MWQMRun = 31,
    NoDepuration = 33,
    Failed = 34,
    Passed = 35,
    NoData = 36,
    LessThan10 = 37,
    MeshNode = 38,
    WebTideNode = 39,
    SamplingPlan = 40,
    SeeOtherMunicipality = 41,
    LineOverflow = 42,
    BoxModelInputs = 43,
    BoxModelResults = 44,
    ClimateSiteInfo = 45,
    ClimateSiteData = 46,
    HydrometricSiteInfo = 47,
    HydrometricSiteData = 48,
    InfrastructureInfo = 49,
    LabSheetInfo = 50,
    LabSheetDetailInfo = 51,
    MapInfo = 52,
    MapInfoPoint = 53,
    MikeSourceStartEndInfo = 54,
    MWQMLookupMPNInfo = 55,
    SamplingPlanInfo = 56,
    SamplingPlanSubsectorInfo = 57,
    SamplingPlanSubsectorSiteInfo = 58,
    MWQMSiteStartEndInfo = 59,
    MWQMSubsectorInfo = 60,
    PolSourceSiteInfo = 61,
    PolSourceSiteObsInfo = 62,
    HydrometricRatingCurveInfo = 63,
    HydrometricRatingCurveDataInfo = 64,
    TideLocationInfo = 65,
    TideSiteDataInfo = 66,
    UseOfSite = 67,
    VisualPlumesScenarioInfo = 68,
    VisualPlumesScenarioAmbient = 69,
    VisualPlumesScenarioResults = 70,
    TotalFile = 71,
    MikeSourceIsRiver = 72,
    MikeSourceIncluded = 73,
    MikeSourceNotIncluded = 74,
    RainExceedance = 75,
    EmailDistributionList = 76,
    OpenData = 77,
    ProvinceTools = 78,
    Classification = 79,
    Approved = 80,
    Restricted = 81,
    Prohibited = 82,
    ConditionallyApproved = 83,
    ConditionallyRestricted = 84,
    OpenDataNational = 85,
    PolSourceSiteMikeScenario = 86,
    SubsectorTools = 87,
    Unclassified = 88,
}
public enum ValveTypeEnum
{
    Manually = 1,
    Automatically = 2,
    None = 3,
}
public enum WebChartAndTableTypeEnum
{
    MonitoringStatsByYear = 1,
    MonitoringStatsByMonth = 2,
    MonitoringStatsBySeason = 3,
    MWQMSiteFCSalTempData = 4,
    MWQMSiteFCStats = 5,
    MWQMRunData = 6,
    InfrastructureSingle = 7,
    InfrastructureUnderMunicipality = 8
}
public enum WebTypeEnum
{
    WebAllAddresses = 1,
    WebAllContacts = 2,
    WebAllCountries = 3,
    WebAllEmails = 4,
    WebAllHelpDocs = 5,
    WebAllMunicipalities = 6,
    WebAllMWQMLookupMPNs = 7,
    WebAllPolSourceGroupings = 8,
    WebAllPolSourceSiteEffectTerms = 9,
    WebAllProvinces = 10,
    WebAllReportTypes = 11,
    WebAllTels = 12,
    WebAllTideLocations = 13,
    WebAllSearch = 14,
    WebArea = 15,
    WebClimateSites = 16,
    WebCountry = 17,
    WebDrogueRuns = 18,
    WebHydrometricSites = 19,
    WebLabSheets = 20,
    WebMikeScenarios = 21,
    WebMunicipality = 22,
    WebMWQMRuns = 23,
    WebMWQMSamples1980_2020 = 24,
    WebMWQMSamples2021_2060 = 25,
    WebMWQMSites = 26,
    WebPolSourceSites = 27,
    WebProvince = 28,
    WebRoot = 29,
    WebSector = 30,
    WebSubsector = 31,
    WebTideSites = 32,
    WebMonitoringRoutineStatsCountry = 33,
    WebMonitoringOtherStatsCountry = 34,
    WebMonitoringRoutineStatsProvince = 35,
    WebMonitoringOtherStatsProvince = 36,
    WebAllMWQMAnalysisReportParameters = 37,
    WebAllMWQMSubsectors = 38,
    WebAllUseOfSites = 39,
}
public enum WebTideDataSetEnum
{
    arctic9 = 1,            // Arctic
    brador = 2,             // Brador
    HRglobal = 3,           // Global (LEGOS France)
    h3o = 4,                // Halifax Harbour
    hudson = 5,             // Hudson Bay (IML) 
    ne_pac4 = 6,            // North East Pacific (IOS)
    nwatl = 7,              // North West Atlantic 
    QuatsinoModel14 = 8,    // Quatsino Sound
    sshelf = 9,             // Scotian Fundy Maine
    flood = 10,             // Upper Bay of Fundy
    vigf8 = 11,             // Vancouver Island (Mike Foreman)
}

