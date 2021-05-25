import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { MapSizeEnum } from 'src/app/enums/generated/MapSizeEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AnalysisCalculationTypeEnum } from '../enums/generated/AnalysisCalculationTypeEnum';
import { StatMWQMRun } from '../models/generated/web/StatMWQMRun.model';
import { TVFileModel } from '../models/generated/web/TVFileModel.model';
import { TVItemModel } from '../models/generated/web/TVItemModel.model';
import { UserPreferenceModel } from '../models/generated/web/UserPreferenceModel.model';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  // http loading related
  Working?: boolean = false;
  Error?: HttpErrorResponse = null;
  Status?: string = '';

  UserPreference?: UserPreferenceModel =
    {
      // http history related
      History: [],
      // stat
      StatRunsForDetail: 30,
      // Analysis
      AnalysisRuns: 30,
      AnalysisFullYear: true,
      AnalysisCalculationType: AnalysisCalculationTypeEnum.All,
      AnalysisHighlightSalFromAverage: 8,
      AnalysisShortRange: 3,
      AnalysisMidRange: 3,
      AnalysisDry24h: 4,
      AnalysisDry48h: 8,
      AnalysisDry72h: 12,
      AnalysisDry96h: 16,
      AnalysisWet24h: 12,
      AnalysisWet48h: 25,
      AnalysisWet72h: 37,
      AnalysisWet96h: 50,
      AnalysisFCDataVisible: true,
      AnalysisTempDataVisible: false,
      AnalysisSalDataVisible: false,
      AnalysisP90DataVisible: false,
      AnalysisGeoMeanDataVisible: false,
      AnalysisMedianDataVisible: false,
      AnalysisPerOver43DataVisible: false,
      AnalysisPerOver260DataVisible: false,
      // visual related
      TopComponent: TopComponentEnum.Home, // home | shell
      ShellSubComponent: ShellSubComponentEnum.Root, // Root | Country | Province | Area | Sector | Subsector | Municipality
      RootSubComponent: RootSubComponentEnum.Countries, // Countries | Files | ExportArcGIS
      CountrySubComponent: CountrySubComponentEnum.Provinces, // Provinces | Files | OpenDataNational | EmailDistributionList | RainExceedance
      ProvinceSubComponent: ProvinceSubComponentEnum.Areas, // Areas | Municipalities | Files | SamplingPlan | OpenData | ProvinceTools
      AreaSubComponent: AreaSubComponentEnum.Sectors, // Sectors | Files 
      SectorSubComponent: SectorSubComponentEnum.Subsectors, // Subsectors | Files
      SubsectorSubComponent: SubsectorSubComponentEnum.MWQMSites, // MWQMSites | Analysis | MWQMRuns | PollutionSourceSites | Files | SubsectorTools | LogBook
      MunicipalitySubComponent: MunicipalitySubComponentEnum.Infrastructures, // Infrastructures | MikeScenarios | Contacts | Files
      CurrentRootTVItemID: 1,
      CurrentCountryTVItemID: 0,
      CurrentProvinceTVItemID: 0,
      CurrentMunicipalityTVItemID: 0,
      CurrentAreaTVItemID: 0,
      CurrentSectorTVItemID: 0,
      CurrentSubsectorTVItemID: 0,
      DetailVisible: false,
      StatCountVisible: false,
      LastUpdateVisible: false,
      InactVisible: false,
      LeftSideNavVisible: false,
      EditVisible: false,
      // map
      MapVisible: true,
      MapSize: MapSizeEnum.Size50, // Size30 | Size40 | Size50 | Size60 | Size70
      MapMarkerColorArea: '#0ffff0',
      MapMarkerColorClimateSite: '#ff0000',
      MapMarkerColorCountry: '#00ff00',
      MapMarkerColorFailed: '#ff0000',
      MapMarkerColorHydrometricSite: '#ff0000',
      MapMarkerColorInfrastructure: '#ff0000',
      MapMarkerColorLessThan10: '#ff0000',
      MapMarkerColorLiftStation: '#ff0000',
      MapMarkerColorLineOverflow: '#ff0000',
      MapMarkerColorMeshNode: '#ff0000',
      MapMarkerColorMikeBoundaryConditionMesh: '#ff0000',
      MapMarkerColorMikeBoundaryConditionWebTide: '#ff0000',
      MapMarkerColorMikeScenario: '#ff0000',
      MapMarkerColorMikeSource: '#ff0000',
      MapMarkerColorMikeSourceIncluded: '#ff0000',
      MapMarkerColorMikeSourceIsRiver: '#ff0000',
      MapMarkerColorMikeSourceNotIncluded: '#ff0000',
      MapMarkerColorMunicipality: '#fff000',
      MapMarkerColorMWQMRun: '#ff0000',
      MapMarkerColorMWQMSite: '#f0f000',
      MapMarkerColorNoData: '#ff0000',
      MapMarkerColorNoDepuration: '#ff0000',
      MapMarkerColorOtherInfrastructure: '#ff0000',
      MapMarkerColorOutfall: '#ff0000',
      MapMarkerColorPassed: '#ff0000',
      MapMarkerColorPolSourceSite: '#ff0000',
      MapMarkerColorProvince: '#ff00ff',
      MapMarkerColorSector: '#ff00ff',
      MapMarkerColorSeeOtherMunicipality: '#ff0000',
      MapMarkerColorSubsector: '#0f0ff0',
      MapMarkerColorTideSite: '#ff0000',
      MapMarkerColorWasteWaterTreatmentPlant: '#ff0000',
      MapMarkerColorWebTideNode: '#ff0000',

      ClassificationColorApproved: '#ff0000',
      ClassificationColorConditionallyApproved: '#ff0000',
      ClassificationColorConditionallyRestricted: '#ff0000',
      ClassificationColorProhibited: '#ff0000',
      ClassificationColorRestricted: '#ff0000',

      MapPolylineColorInfrastructureLineOverflowToOutfall: '#00ff00',
      MapPolylineColorInfrastructureLiftStationToLiftStation: '#ff0000',
      MapPolylineColorInfrastructureLiftStationToOutfall: '#ff00ff',
      MapPolylineColorInfrastructureLiftStationToWWTP: '#ffff00',
      MapPolylineColorInfrastructureWWTPToOutfall: '#00ffff',

      MapPolygonColorArea: '#ff0000',
      MapPolygonColorCountry: '#00ff00',
      MapPolygonColorProvince: '#0000ff',
      MapPolygonColorSector: '#ff00ff',
      MapPolygonColorSubsector: '#ffff00',

      MapColorNotFound: '#ffffff',

      // sorting
      AreaSectorsSortOrder: AscDescEnum.Ascending,
      AreaFilesSortByProp: FilesSortPropEnum.FileName,
      CountryProvincesSortOrder: AscDescEnum.Ascending,
      CountryFilesSortByProp: FilesSortPropEnum.FileName,
      MunicipalityContactsSortOrder: AscDescEnum.Ascending,
      MunicipalityFilesSortByProp: FilesSortPropEnum.FileName,
      MunicipalityInfrastructuresSortOrder: AscDescEnum.Ascending,
      MunicipalityMikeScenariosSortOrder: AscDescEnum.Ascending,
      MWQMSiteFilesSortByProp: FilesSortPropEnum.FileName,
      PolSourceSiteFilesSortByProp: FilesSortPropEnum.FileName,
      ProvinceAreasSortOrder: AscDescEnum.Ascending,
      ProvinceFilesSortByProp: FilesSortPropEnum.FileName,
      ProvinceMunicipalitiesSortOrder: AscDescEnum.Ascending,
      RootCountriesSortOrder: AscDescEnum.Ascending,
      RootFilesSortByProp: FilesSortPropEnum.FileName,
      SectorFilesSortByProp: FilesSortPropEnum.FileName,
      SectorSubsectorsSortOrder: AscDescEnum.Ascending,
      SubsectorFilesSortByProp: FilesSortPropEnum.FileName,
      SubsectorMWQMRunsSortOrder: AscDescEnum.Descending,
      SubsectorMWQMSitesSortOrder: AscDescEnum.Ascending,
      SubsectorPolSourceSitesSortOrder: AscDescEnum.Ascending,
    };

  ShowMonitoringStatsChart: boolean = false;
  ShowMonitoringStatsTable: boolean = false;

  // search http loading related
  SearchWorking?: boolean = false;

  // // stat
  // StatRunsForDetail?: number = 30;

  // showing item
  ShowTVItemModelList?: TVItemModel[] = [];

  // showing file item
  ShowTVFileModelList?: TVFileModel[] = [];

  // Analysis
  AnalysisStartRun?: StatMWQMRun = null;
  AnalysisEndRun?: StatMWQMRun = null;
  // AnalysisRuns?: number = 30;
  // AnalysisFullYear?: boolean = true;
  AnalysisShowOnlyUsed?: boolean = false;
  // AnalysisCalculationType?: AnalysisCalculationTypeEnum = AnalysisCalculationTypeEnum.All;
  // AnalysisHighlightSalFromAverage?: number = 8;
  // AnalysisShortRange?: number = 3;
  // AnalysisMidRange?: number = 3;
  // AnalysisDry24h?: number = 4;
  // AnalysisDry48h?: number = 8;
  // AnalysisDry72h?: number = 12;
  // AnalysisDry96h?: number = 16;
  // AnalysisWet24h?: number = 12;
  // AnalysisWet48h?: number = 25;
  // AnalysisWet72h?: number = 37;
  // AnalysisWet96h?: number = 50;
  // AnalysisFCDataVisible?: boolean = true;
  // AnalysisTempDataVisible?: boolean = false;
  // AnalysisSalDataVisible?: boolean = false;
  // AnalysisP90DataVisible?: boolean = false;
  // AnalysisGeoMeanDataVisible?: boolean = false;
  // AnalysisMedianDataVisible?: boolean = false;
  // AnalysisPerOver43DataVisible?: boolean = false;
  // AnalysisPerOver260DataVisible?: boolean = false;

  // visual related
  // TopComponent?: TopComponentEnum = TopComponentEnum.Home; // home | shell
  // ShellSubComponent?: ShellSubComponentEnum = ShellSubComponentEnum.Root; // Root | Country | Province | Area | Sector | Subsector | Municipality
  // RootSubComponent?: RootSubComponentEnum = RootSubComponentEnum.Countries; // Countries | Files | ExportArcGIS
  // CountrySubComponent?: CountrySubComponentEnum = CountrySubComponentEnum.Provinces; // Provinces | Files | OpenDataNational | EmailDistributionList | RainExceedance
  // ProvinceSubComponent?: ProvinceSubComponentEnum = ProvinceSubComponentEnum.Areas; // Areas | Municipalities | Files | SamplingPlan | OpenData | ProvinceTools
  // AreaSubComponent?: AreaSubComponentEnum = AreaSubComponentEnum.Sectors; // Sectors | Files 
  // SectorSubComponent?: SectorSubComponentEnum = SectorSubComponentEnum.Subsectors; // Subsectors | Files
  // SubsectorSubComponent?: SubsectorSubComponentEnum = SubsectorSubComponentEnum.MWQMSites; // MWQMSites | Analysis | MWQMRuns | PollutionSourceSites | Files | SubsectorTools | LogBook
  // MunicipalitySubComponent?: MunicipalitySubComponentEnum = MunicipalitySubComponentEnum.Infrastructures; // Infrastructures | MikeScenarios | Contacts | Files
  // CurrentCountryTVItemID?: number = 0;
  // CurrentProvinceTVItemID?: number = 0;
  // CurrentMunicipalityTVItemID?: number = 0;
  // CurrentAreaTVItemID?: number = 0;
  // CurrentSectorTVItemID?: number = 0;
  // CurrentSubsectorTVItemID?: number = 0;
  BaseApiUrl?: string = '';
  // DetailVisible?: boolean = false;
  // StatCountVisible?: boolean = false;
  // LastUpdateVisible?: boolean = false;
  // InactVisible?: boolean = false;
  // LeftSideNavVisible?: boolean = false;
  // EditVisible?: boolean = false;

  // map
  // MapVisible?: boolean = true;
  EditMapVisible?: boolean = false;
  EditMapChanged?: boolean = false;
  MarkerDragStartPos: google.maps.LatLng = null;
  MarkerDragEndPos: google.maps.LatLng = null;
  MarkerTVItemID: number = 0;
  MarkerMapInfoID: number = 0;
  MarkerLabel: string = '';

  // MapSize?: MapSizeEnum = MapSizeEnum.Size50; // Size30 | Size40 | Size50 | Size60 | Size70

  MapMarkerPathCharacters: string[] = [
    '',
    'm0,0l-5,-10l-11,0l0,-20l32,0l0,20l-11,0l-5,10z',
    'm0,0l-5,-10l-17,0l0,-20l44,0l0,20l-17,0l-5,10z',
    'm0,0l-5,-10l-23,0l0,-20l56,0l0,20l-23,0l-5,10z',
    'm0,0l-5,-10l-29,0l0,-20l68,0l0,20l-29,0l-5,10z',
    'm0,0l-5,-10l-35,0l0,-20l80,0l0,20l-35,0l-5,10z',
  ];

  // MapMarkerColorArea?: string = '#0ffff0';
  // MapMarkerColorClimateSite?: string = '#ff0000';
  // MapMarkerColorCountry?: string = '#00ff00';
  // MapMarkerColorFailed?: string = '#ff0000';
  // MapMarkerColorHydrometricSite?: string = '#ff0000';
  // MapMarkerColorInfrastructure?: string = '#ff0000';
  // MapMarkerColorLessThan10?: string = '#ff0000';
  // MapMarkerColorLiftStation?: string = '#ff0000';
  // MapMarkerColorLineOverflow?: string = '#ff0000';
  // MapMarkerColorMeshNode?: string = '#ff0000';
  // MapMarkerColorMikeBoundaryConditionMesh?: string = '#ff0000';
  // MapMarkerColorMikeBoundaryConditionWebTide?: string = '#ff0000';
  // MapMarkerColorMikeScenario?: string = '#ff0000';
  // MapMarkerColorMikeSource?: string = '#ff0000';
  // MapMarkerColorMikeSourceIncluded?: string = '#ff0000';
  // MapMarkerColorMikeSourceIsRiver?: string = '#ff0000';
  // MapMarkerColorMikeSourceNotIncluded?: string = '#ff0000';
  // MapMarkerColorMunicipality?: string = '#fff000';
  // MapMarkerColorMWQMRun?: string = '#ff0000';
  // MapMarkerColorMWQMSite?: string = '#f0f000';
  // MapMarkerColorNoData?: string = '#ff0000';
  // MapMarkerColorNoDepuration?: string = '#ff0000';
  // MapMarkerColorOtherInfrastructure?: string = '#ff0000';
  // MapMarkerColorOutfall?: string = '#ff0000';
  // MapMarkerColorPassed?: string = '#ff0000';
  // MapMarkerColorPolSourceSite?: string = '#ff0000';
  // MapMarkerColorProvince?: string = '#ff00ff';
  // MapMarkerColorSector?: string = '#ff00ff';
  // MapMarkerColorSeeOtherMunicipality?: string = '#ff0000';
  // MapMarkerColorSubsector?: string = '#0f0ff0';
  // MapMarkerColorTideSite?: string = '#ff0000';
  // MapMarkerColorWasteWaterTreatmentPlant?: string = '#ff0000';
  // MapMarkerColorWebTideNode?: string = '#ff0000';

  // ClassificationColorApproved?: string = '#ff0000';
  // ClassificationColorConditionallyApproved?: string = '#ff0000';
  // ClassificationColorConditionallyRestricted?: string = '#ff0000';
  // ClassificationColorProhibited?: string = '#ff0000';
  // ClassificationColorRestricted?: string = '#ff0000';

  // MapPolylineColorInfrastructureLineOverflowToOutfall?: string = '#00ff00';
  // MapPolylineColorInfrastructureLiftStationToLiftStation?: string = '#ff0000';
  // MapPolylineColorInfrastructureLiftStationToOutfall?: string = '#ff00ff';
  // MapPolylineColorInfrastructureLiftStationToWWTP?: string = '#ffff00';
  // MapPolylineColorInfrastructureWWTPToOutfall?: string = '#00ffff';

  // MapPolygonColorArea?: string = '#ff0000';
  // MapPolygonColorCountry?: string = '#00ff00';
  // MapPolygonColorProvince?: string = '#0000ff';
  // MapPolygonColorSector?: string = '#ff00ff';
  // MapPolygonColorSubsector?: string = '#ffff00';

  // MapColorNotFound?: string = '#ffffff';

  zoom?: number = 12;
  center?: google.maps.LatLngLiteral = { lat: 46.0915449, lng: -64.7242012 };
  options?: google.maps.MapOptions = {
    zoomControl: true,
    scrollwheel: true,
    disableDoubleClickZoom: false,
    mapTypeId: 'satellite', //google.maps.MapTypeId.SATELLITE,
  };
  infoContent?: string = '';

  //HasInternetConnection?: boolean;
  //GoogleMapKey?: string;
  CSSLoaded?: boolean = false;
  IconLoaded?: boolean = false;
  GoogleJSLoaded?: boolean = false;

  // sorting
  // AreaSectorsSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // AreaFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // CountryProvincesSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // CountryFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // MunicipalityContactsSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // MunicipalityFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // MunicipalityInfrastructuresSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // MunicipalityMikeScenariosSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // MWQMSiteFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // PolSourceSiteFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // ProvinceAreasSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // ProvinceFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // ProvinceMunicipalitiesSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // RootCountriesSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // RootFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // SectorFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // SectorSubsectorsSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // SubsectorFilesSortByProp?: FilesSortPropEnum = FilesSortPropEnum.FileName;
  // SubsectorMWQMRunsSortOrder?: AscDescEnum = AscDescEnum.Descending;
  // SubsectorMWQMSitesSortOrder?: AscDescEnum = AscDescEnum.Ascending;
  // SubsectorPolSourceSitesSortOrder?: AscDescEnum = AscDescEnum.Ascending;

  constructor() {
  }
}
