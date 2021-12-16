import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AnalysisCalculationTypeEnum } from '../../enums/generated/AnalysisCalculationTypeEnum';
import { StatMWQMRun } from '../../models/generated/models/StatMWQMRun.model';
import { TVFileModel } from '../../models/generated/models/TVFileModel.model';
import { TVItemModel } from '../../models/generated/models/TVItemModel.model';
import { UserPreferenceModel } from '../../models/generated/models/UserPreferenceModel.model';

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
      MapWidthText: '50%',
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
      InfrastructureFilesSortByProp: FilesSortPropEnum.FileName,
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

  ShowMonitoringStats?: boolean = false;

  // search http loading related
  SearchWorking?: boolean = false;

  // showing item
  ShowTVItemModelList?: TVItemModel[] = [];

  // showing file item
  ShowTVFileModelList?: TVFileModel[] = [];

  // Analysis
  AnalysisStartRun?: StatMWQMRun = null;
  AnalysisEndRun?: StatMWQMRun = null;
  AnalysisShowOnlyUsed?: boolean = false;

  BaseApiUrl?: string = '';

  // map
  EditMapVisible?: boolean = false;
  EditMapChanged?: boolean = false;
  MarkerDragStartPos: google.maps.LatLng = null;
  MarkerDragEndPos: google.maps.LatLng = null;
  MarkerTVItemID: number = 0;
  MarkerMapInfoID: number = 0;
  MarkerLabel: string = '';

  MapMarkerPathCharacters: string[] = [
    '',
    'm0,0l-5,-10l-11,0l0,-20l32,0l0,20l-11,0l-5,10z',
    'm0,0l-5,-10l-17,0l0,-20l44,0l0,20l-17,0l-5,10z',
    'm0,0l-5,-10l-23,0l0,-20l56,0l0,20l-23,0l-5,10z',
    'm0,0l-5,-10l-29,0l0,-20l68,0l0,20l-29,0l-5,10z',
    'm0,0l-5,-10l-35,0l0,-20l80,0l0,20l-35,0l-5,10z',
    'm0,0l-5,-10l-41,0l0,-20l92,0l0,20l-41,0l-5,10z',
    'm0,0l-5,-10l-47,0l0,-20l104,0l0,20l-47,0l-5,10z',
    'm0,0l-5,-10l-53,0l0,-20l116,0l0,20l-53,0l-5,10z',
    'm0,0l-5,-10l-59,0l0,-20l128,0l0,20l-59,0l-5,10z',
    'm0,0l-5,-10l-65,0l0,-20l140,0l0,20l-65,0l-5,10z',
  ];

  zoom?: number = 12;
  center?: google.maps.LatLngLiteral = { lat: 46.0915449, lng: -64.7242012 };
  options?: google.maps.MapOptions = {
    zoomControl: true,
    scrollwheel: true,
    disableDoubleClickZoom: false,
    mapTypeId: 'satellite', //google.maps.MapTypeId.SATELLITE,
  };
  infoContent?: string = '';

  CSSLoaded?: boolean = false;
  IconLoaded?: boolean = false;
  GoogleJSLoaded?: boolean = false;


  constructor() {
  }
}
