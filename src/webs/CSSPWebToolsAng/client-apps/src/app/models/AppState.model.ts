import { HttpErrorResponse } from '@angular/common/http';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapSizeEnum } from 'src/app/enums/generated/MapSizeEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { MWQMRunSubComponentEnum } from 'src/app/enums/generated/MWQMRunSubComponentEnum';
import { MWQMSiteSubComponentEnum } from 'src/app/enums/generated/MWQMSiteSubComponentEnum';
import { PolSourceSiteSubComponentEnum } from 'src/app/enums/generated/PolSourceSiteSubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AnalysisCalculationTypeEnum } from '../enums/generated/AnalysisCalculationTypeEnum';
import { MikeScenarioSubComponentEnum } from '../enums/generated/MikeScenarioSubComponentEnum';
import { StatMWQMRun } from './generated/web/StatMWQMRun.model';
import { TVFileModel } from './generated/web/TVFileModel.model';
import { TVItemModel } from './generated/web/TVItemModel.model';

export interface AppState {
    // http loading related
    Working?: boolean;
    Error?: HttpErrorResponse;
    Status?: string;

    // http history related
    History: TVItemModel[],

    // search http loading related
    SearchWorking?: boolean;

    // stat
    StatRunsForDetail?: number;

    // showing item
    ShowTVItemModelList?: TVItemModel[];

    // showing file item
    ShowTVFileModelList?: TVFileModel[];

    // Analysis
    AnalysisStartRun?: StatMWQMRun;
    AnalysisEndRun?: StatMWQMRun;
    AnalysisRuns?: number;
    AnalysisFullYear?: boolean;
    AnalysisShowOnlyUsed?: boolean;
    AnalysisCalculationType?: AnalysisCalculationTypeEnum;
    AnalysisHighlightSalFromAverage?: number;
    AnalysisShortRange?: number;
    AnalysisMidRange?: number;
    AnalysisDry24h?: number;
    AnalysisDry48h?: number;
    AnalysisDry72h?: number;
    AnalysisDry96h?: number;
    AnalysisWet24h?: number;
    AnalysisWet48h?: number;
    AnalysisWet72h?: number;
    AnalysisWet96h?: number;
    AnalysisFCDataVisible?: boolean;
    AnalysisTempDataVisible?: boolean;
    AnalysisSalDataVisible?: boolean;
    AnalysisP90DataVisible?: boolean;
    AnalysisGeoMeanDataVisible?: boolean;
    AnalysisMedianDataVisible?: boolean;
    AnalysisPerOver43DataVisible?: boolean;
    AnalysisPerOver260DataVisible?: boolean;

    // visual related
    TopComponent?: TopComponentEnum; // home | shell
    ShellSubComponent?: ShellSubComponentEnum; // Area | Country | MikeScenario | Municipality | MWQMRun | MWQMSite | PolSourceSite | Province | Root | Sector | Subsector
    RootSubComponent?: RootSubComponentEnum; // Countries | Files | ExportArcGIS
    CountrySubComponent?: CountrySubComponentEnum; // Provinces | Files | OpenDataNational | EmailDistributionList | RainExceedance
    ProvinceSubComponent?: ProvinceSubComponentEnum; // Areas | Municipalities | Files | SamplingPlan | OpenData | ProvinceTools
    AreaSubComponent?: AreaSubComponentEnum, // Sectors | Files 
    SectorSubComponent?: SectorSubComponentEnum, // Subsectors | Files | MIKEScenarios
    SubsectorSubComponent?: SubsectorSubComponentEnum, // MWQMSites | Analysis | MWQMRuns | PollutionSourceSites | Files | SubsectorTools | LogBook
    MunicipalitySubComponent?: MunicipalitySubComponentEnum, // Infrastructures | MIKEScenarios | Contacts | Files
    MikeScenarioSubComponent?: MikeScenarioSubComponentEnum, // GeneralParameters | Sources | InputSummary | Files | GeneralResults
    MWQMSiteSubComponent?: MWQMSiteSubComponentEnum, // Information | Files
    MWQMRunSubComponent?: MWQMRunSubComponentEnum, // Information | Files
    PolSourceSiteSubComponent?: PolSourceSiteSubComponentEnum, // Information | Files
    CurrentTVItemID?: number;
    SamplingPlanID?: number;
    Language?: LanguageEnum; // en | fr | enAndfr | es
    BaseApiUrl?: string;
    DetailVisible?: boolean;
    StatCountVisible?: boolean;
    LastUpdateVisible?: boolean;
    InactVisible?: boolean;
    MenuVisible?: boolean;
    EditVisible?: boolean;

    // map
    MapVisible?: boolean;
    EditMapVisible?: boolean;
    EditMapChanged?: boolean;
    MarkerDragStartPos: google.maps.LatLng;
    MarkerDragEndPos: google.maps.LatLng;
    MarkerTVItemID: number;
    MarkerMapInfoID: number;
    MarkerLabel: string;

    MapSize?: MapSizeEnum; // Size30 | Size40 | Size50 | Size60 | Size70

    MapMarkerPathCharacters: string[];

    MapMarkerColorArea?: string;
    MapMarkerColorClimateSite?: string;
    MapMarkerColorCountry?: string;
    MapMarkerColorFailed?: string;
    MapMarkerColorHydrometricSite?: string;
    MapMarkerColorInfrastructure?: string;
    MapMarkerColorLessThan10?: string;
    MapMarkerColorLiftStation?: string;
    MapMarkerColorLineOverflow?: string;
    MapMarkerColorMeshNode?: string;
    MapMarkerColorMikeBoundaryConditionMesh?: string;
    MapMarkerColorMikeBoundaryConditionWebTide?: string;
    MapMarkerColorMikeScenario?: string;
    MapMarkerColorMikeSource?: string;
    MapMarkerColorMikeSourceIncluded?: string;
    MapMarkerColorMikeSourceIsRiver?: string;
    MapMarkerColorMikeSourceNotIncluded?: string;
    MapMarkerColorMunicipality?: string;
    MapMarkerColorMWQMRun?: string;
    MapMarkerColorMWQMSite?: string;
    MapMarkerColorNoData?: string;
    MapMarkerColorNoDepuration?: string;
    MapMarkerColorOtherInfrastructure?: string;
    MapMarkerColorOutfall?: string;
    MapMarkerColorPassed?: string;
    MapMarkerColorPolSourceSite?: string;
    MapMarkerColorProvince?: string;
    MapMarkerColorSector?: string;
    MapMarkerColorSeeOtherMunicipality?: string;
    MapMarkerColorSubsector?: string;
    MapMarkerColorTideSite?: string;
    MapMarkerColorWasteWaterTreatmentPlant?: string;
    MapMarkerColorWebTideNode?: string;

    ClassificationColorApproved?: string;
    ClassificationColorConditionallyApproved?: string;
    ClassificationColorConditionallyRestricted?: string;
    ClassificationColorProhibited?: string;
    ClassificationColorRestricted?: string;

    MapPolylineColorInfrastructureLineOverflowToOutfall?: string;
    MapPolylineColorInfrastructureLiftStationToLiftStation?: string;
    MapPolylineColorInfrastructureLiftStationToOutfall?: string;
    MapPolylineColorInfrastructureLiftStationToWWTP?: string;
    MapPolylineColorInfrastructureWWTPToOutfall?: string;

    MapPolygonColorArea?: string;
    MapPolygonColorCountry?: string;
    MapPolygonColorProvince?: string;
    MapPolygonColorSector?: string;
    MapPolygonColorSubsector?: string;

    MapColorNotFound?: string;

    zoom?: number;
    center?: google.maps.LatLngLiteral;
    options?: google.maps.MapOptions;
    infoContent?: string;

    //HasInternetConnection?: boolean;
    //GoogleMapKey?: string;
    CSSLoaded?: boolean;
    IconLoaded?: boolean;
    GoogleJSLoaded?: boolean;

    // sorting
    AreaSectorsSortOrder?: AscDescEnum;
    AreaFilesSortByProp?: FilesSortPropEnum;
    AreaFilesSortOrder?: AscDescEnum;
    CountryProvincesSortOrder?: AscDescEnum;
    CountryFilesSortByProp?: FilesSortPropEnum;
    CountryFilesSortOrder?: AscDescEnum;
    MunicipalityContactsSortOrder?: AscDescEnum;
    MunicipalityFilesSortByProp?: FilesSortPropEnum;
    MunicipalityFilesSortOrder?: AscDescEnum;
    MunicipalityInfrastructuresSortOrder?: AscDescEnum;
    MunicipalityMIKEScenariosSortOrder?: AscDescEnum;
    MWQMRunFilesSortByProp?: FilesSortPropEnum;
    MWQMRunFilesSortOrder?: AscDescEnum;
    MWQMSiteFilesSortByProp?: FilesSortPropEnum;
    MWQMSiteFilesSortOrder?: AscDescEnum;
    PolSourceSiteFilesSortByProp?: FilesSortPropEnum;
    PolSourceSiteFilesSortOrder?: AscDescEnum;
    ProvinceAreasSortOrder?: AscDescEnum;
    ProvinceFilesSortByProp?: FilesSortPropEnum;
    ProvinceFilesSortOrder?: AscDescEnum;
    ProvinceMunicipalitiesSortOrder?: AscDescEnum;
    RootCountriesSortOrder?: AscDescEnum;
    RootFilesSortByProp?: FilesSortPropEnum;
    RootFilesSortOrder?: AscDescEnum;
    SectorFilesSortByProp?: FilesSortPropEnum;
    SectorFilesSortOrder?: AscDescEnum;
    SectorMikeScenariosSortOrder?: AscDescEnum;
    SectorSubsectorsSortOrder?: AscDescEnum;
    SubsectorFilesSortByProp?: FilesSortPropEnum;
    SubsectorFilesSortOrder?: AscDescEnum;
    SubsectorMWQMRunsSortOrder?: AscDescEnum;
    SubsectorMWQMSitesSortOrder?: AscDescEnum;
    SubsectorPolSourceSitesSortOrder?: AscDescEnum;
}
