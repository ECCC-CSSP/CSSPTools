namespace CSSPWebModels;

[NotMapped]
public partial class UserPreferenceModel
{
    public List<TVItemModel> History { get; set; }
    public int StatRunsForDetail { get; set; }
    public int AnalysisRuns { get; set; }
    public bool AnalysisFullYear { get; set; }
    [CSSPEnumType]
    public AnalysisCalculationTypeEnum AnalysisCalculationType { get; set; }
    public int AnalysisHighlightSalFromAverage { get; set; }
    public int AnalysisShortRange { get; set; }
    public int AnalysisMidRange { get; set; }
    public int AnalysisDry24h { get; set; }
    public int AnalysisDry48h { get; set; }
    public int AnalysisDry72h { get; set; }
    public int AnalysisDry96h { get; set; }
    public int AnalysisWet24h { get; set; }
    public int AnalysisWet48h { get; set; }
    public int AnalysisWet72h { get; set; }
    public int AnalysisWet96h { get; set; }
    public bool AnalysisFCDataVisible { get; set; }
    public bool AnalysisTempDataVisible { get; set; }
    public bool AnalysisSalDataVisible { get; set; }
    public bool AnalysisP90DataVisible { get; set; }
    public bool AnalysisGeoMeanDataVisible { get; set; }
    public bool AnalysisMedianDataVisible { get; set; }
    public bool AnalysisPerOver43DataVisible { get; set; }
    public bool AnalysisPerOver260DataVisible { get; set; }
    [CSSPEnumType]
    public TopComponentEnum TopComponent { get; set; }
    [CSSPEnumType]
    public ShellSubComponentEnum ShellSubComponent { get; set; }
    [CSSPEnumType]
    public RootSubComponentEnum RootSubComponent { get; set; }
    [CSSPEnumType]
    public CountrySubComponentEnum CountrySubComponent { get; set; }
    [CSSPEnumType]
    public ProvinceSubComponentEnum ProvinceSubComponent { get; set; }
    [CSSPEnumType]
    public AreaSubComponentEnum AreaSubComponent { get; set; }
    [CSSPEnumType]
    public SectorSubComponentEnum SectorSubComponent { get; set; }
    [CSSPEnumType]
    public SubsectorSubComponentEnum SubsectorSubComponent { get; set; }
    [CSSPEnumType]
    public MunicipalitySubComponentEnum MunicipalitySubComponent { get; set; }
    public int CurrentRootTVItemID { get; set; }
    public int CurrentCountryTVItemID { get; set; }
    public int CurrentProvinceTVItemID { get; set; }
    public int CurrentMunicipalityTVItemID { get; set; }
    public int CurrentAreaTVItemID { get; set; }
    public int CurrentSectorTVItemID { get; set; }
    public int CurrentSubsectorTVItemID { get; set; }
    public bool DetailVisible { get; set; }
    public bool StatCountVisible { get; set; }
    public bool LastUpdateVisible { get; set; }
    public bool InactVisible { get; set; }
    public bool LeftSideNavVisible { get; set; }
    public bool EditVisible { get; set; }
    public bool MapVisible { get; set; }
    [CSSPEnumType]
    public MapSizeEnum MapSize { get; set; }
    public string MapMarkerColorArea { get; set; }
    public string MapMarkerColorClimateSite { get; set; }
    public string MapMarkerColorCountry { get; set; }
    public string MapMarkerColorFailed { get; set; }
    public string MapMarkerColorHydrometricSite { get; set; }
    public string MapMarkerColorInfrastructure { get; set; }
    public string MapMarkerColorLessThan10 { get; set; }
    public string MapMarkerColorLiftStation { get; set; }
    public string MapMarkerColorLineOverflow { get; set; }
    public string MapMarkerColorMeshNode { get; set; }
    public string MapMarkerColorMikeBoundaryConditionMesh { get; set; }
    public string MapMarkerColorMikeBoundaryConditionWebTide { get; set; }
    public string MapMarkerColorMikeScenario { get; set; }
    public string MapMarkerColorMikeSource { get; set; }
    public string MapMarkerColorMikeSourceIncluded { get; set; }
    public string MapMarkerColorMikeSourceIsRiver { get; set; }
    public string MapMarkerColorMikeSourceNotIncluded { get; set; }
    public string MapMarkerColorMunicipality { get; set; }
    public string MapMarkerColorMWQMRun { get; set; }
    public string MapMarkerColorMWQMSite { get; set; }
    public string MapMarkerColorNoData { get; set; }
    public string MapMarkerColorNoDepuration { get; set; }
    public string MapMarkerColorOtherInfrastructure { get; set; }
    public string MapMarkerColorOutfall { get; set; }
    public string MapMarkerColorPassed { get; set; }
    public string MapMarkerColorPolSourceSite { get; set; }
    public string MapMarkerColorProvince { get; set; }
    public string MapMarkerColorSector { get; set; }
    public string MapMarkerColorSeeOtherMunicipality { get; set; }
    public string MapMarkerColorSubsector { get; set; }
    public string MapMarkerColorTideSite { get; set; }
    public string MapMarkerColorWasteWaterTreatmentPlant { get; set; }
    public string MapMarkerColorWebTideNode { get; set; }
    public string ClassificationColorApproved { get; set; }
    public string ClassificationColorConditionallyApproved { get; set; }
    public string ClassificationColorConditionallyRestricted { get; set; }
    public string ClassificationColorProhibited { get; set; }
    public string ClassificationColorRestricted { get; set; }
    public string MapPolylineColorInfrastructureLineOverflowToOutfall { get; set; }
    public string MapPolylineColorInfrastructureLiftStationToLiftStation { get; set; }
    public string MapPolylineColorInfrastructureLiftStationToOutfall { get; set; }
    public string MapPolylineColorInfrastructureLiftStationToWWTP { get; set; }
    public string MapPolylineColorInfrastructureWWTPToOutfall { get; set; }
    public string MapPolygonColorArea { get; set; }
    public string MapPolygonColorCountry { get; set; }
    public string MapPolygonColorProvince { get; set; }
    public string MapPolygonColorSector { get; set; }
    public string MapPolygonColorSubsector { get; set; }
    public string MapColorNotFound { get; set; }
    [CSSPEnumType]
    public AscDescEnum AreaSectorsSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum AreaFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum CountryProvincesSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum CountryFilesSortByProp { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum InfrastructureFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum MunicipalityContactsSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum MunicipalityFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum MunicipalityInfrastructuresSortOrder { get; set; }
    [CSSPEnumType]
    public AscDescEnum MunicipalityMikeScenariosSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum MWQMSiteFilesSortByProp { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum PolSourceSiteFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum ProvinceAreasSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum ProvinceFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum ProvinceMunicipalitiesSortOrder { get; set; }
    [CSSPEnumType]
    public AscDescEnum RootCountriesSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum RootFilesSortByProp { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum SectorFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum SectorSubsectorsSortOrder { get; set; }
    [CSSPEnumType]
    public FilesSortPropEnum SubsectorFilesSortByProp { get; set; }
    [CSSPEnumType]
    public AscDescEnum SubsectorMWQMRunsSortOrder { get; set; }
    [CSSPEnumType]
    public AscDescEnum SubsectorMWQMSitesSortOrder { get; set; }
    [CSSPEnumType]
    public AscDescEnum SubsectorPolSourceSitesSortOrder { get; set; }

    public UserPreferenceModel()
    {
        History = new List<TVItemModel>();
    }
}

