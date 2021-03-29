import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
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
import { AppState } from 'src/app/models/AppState.model';
import { AnalysisCalculationTypeEnum } from '../enums/generated/AnalysisCalculationTypeEnum';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  AppState$: BehaviorSubject<AppState> = new BehaviorSubject<AppState>(<AppState>{});

  constructor() {
    this.UpdateAppState(<AppState>{
      // http loading related
      Working: null,
      Error: null,
      Status: null,

      // http history related
      History: [],

      // search http loading related
      SearchWorking: null,

      // stat
      StatRunsForDetail: 30,

      // showing item
      ShowTVItemModelList: [],

      // showing file item
      ShowTVFileModelList: [],

      // Analysis
      AnalysisStartRun: null,
      AnalysisEndRun: null,
      AnalysisRuns: 20,
      AnalysisFullYear: true,
      AnalysisShowOnlyUsed: false,
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
      SectorSubComponent: SectorSubComponentEnum.Subsectors, // Subsectors | Files | MIKEScenarios
      SubsectorSubComponent: SubsectorSubComponentEnum.MWQMSites, // MWQMSites | Analysis | MWQMRuns | PollutionSourceSites | Files | SubsectorTools | LogBook
      MunicipalitySubComponent: MunicipalitySubComponentEnum.Infrastructures, // Infrastructures | MIKEScenarios | Contacts | Files
      MWQMSiteSubComponent: MWQMSiteSubComponentEnum.Information, // Information | Files
      MWQMRunSubComponent: MWQMRunSubComponentEnum.Information, // Information | Files
      PolSourceSiteSubComponent: PolSourceSiteSubComponentEnum.Information, // Information | Files
      CurrentTVItemID: 1,
      SamplingPlanID: 0,
      Language: LanguageEnum.en, // en | fr | enAndfr | es
      BaseApiUrl: '',
      DetailVisible: false,
      StatCountVisible: false,
      LastUpdateVisible: false,
      InactVisible: false,
      MenuVisible: false,
      EditVisible: false,

      // map 
      MapVisible: true,
      EditMapVisible: false,
      EditMapChanged: false,
      MarkerDragStartPos: null,
      MarkerDragEndPos: null,
      MarkerTVItemID: 0,
      MarkerMapInfoID: 0,
      MarkerLabel: '',
      
      MapSize: MapSizeEnum.Size50, // Size30 | Size40 | Size50 | Size60 | Size70

      MapMarkerPathCharacters: [
        '',
        'm0,0l-5,-10l-11,0l0,-20l32,0l0,20l-11,0l-5,10z',
        'm0,0l-5,-10l-17,0l0,-20l44,0l0,20l-17,0l-5,10z',
        'm0,0l-5,-10l-23,0l0,-20l56,0l0,20l-23,0l-5,10z',
        'm0,0l-5,-10l-29,0l0,-20l68,0l0,20l-29,0l-5,10z',
        'm0,0l-5,-10l-35,0l0,-20l80,0l0,20l-35,0l-5,10z',
      ],

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

      zoom: 12,
      center: /*<google.maps.LatLngLiteral> */{ lat: 46.0915449, lng: -64.7242012 },
      options: /* <google.maps.MapOptions> */{
        zoomControl: true,
        scrollwheel: true,
        disableDoubleClickZoom: false,
        mapTypeId: 'satellite', //google.maps.MapTypeId.SATELLITE,
      },
      infoContent: '',

      //HasInternetConnection: false,
      //GoogleMapKey: '',
      CSSLoaded: false,
      IconLoaded: false,
      GoogleJSLoaded: false,

      // sorting
      AreaSectorsSortOrder: AscDescEnum.Ascending,
      AreaFilesSortByProp: FilesSortPropEnum.FileName,
      AreaFilesSortOrder: AscDescEnum.Ascending,
      CountryProvincesSortOrder: AscDescEnum.Ascending,
      CountryFilesSortByProp: FilesSortPropEnum.FileName,
      CountryFilesSortOrder: AscDescEnum.Ascending,
      MunicipalityContactsSortOrder: AscDescEnum.Ascending,
      MunicipalityFilesSortByProp: FilesSortPropEnum.FileName,
      MunicipalityFilesSortOrder: AscDescEnum.Ascending,
      MunicipalityInfrastructuresSortOrder: AscDescEnum.Ascending,
      MunicipalityMIKEScenariosSortOrder: AscDescEnum.Ascending,
      MWQMRunFilesSortByProp: FilesSortPropEnum.FileName,
      MWQMRunFilesSortOrder: AscDescEnum.Ascending,
      MWQMSiteFilesSortByProp: FilesSortPropEnum.FileName,
      MWQMSiteFilesSortOrder: AscDescEnum.Ascending,
      PolSourceSiteFilesSortByProp: FilesSortPropEnum.FileName,
      PolSourceSiteFilesSortOrder: AscDescEnum.Ascending,
      ProvinceAreasSortOrder: AscDescEnum.Ascending,
      ProvinceFilesSortByProp: FilesSortPropEnum.FileName,
      ProvinceFilesSortOrder: AscDescEnum.Ascending,
      ProvinceMunicipalitiesSortOrder: AscDescEnum.Ascending,
      RootCountriesSortOrder: AscDescEnum.Ascending,
      RootFilesSortByProp: FilesSortPropEnum.FileName,
      RootFilesSortOrder: AscDescEnum.Ascending,
      SectorFilesSortByProp: FilesSortPropEnum.FileName,
      SectorFilesSortOrder: AscDescEnum.Ascending,
      SectorMikeScenariosSortOrder: AscDescEnum.Ascending,
      SectorSubsectorsSortOrder: AscDescEnum.Ascending,
      SubsectorFilesSortByProp: FilesSortPropEnum.FileName,
      SubsectorFilesSortOrder: AscDescEnum.Ascending,
      SubsectorMWQMRunsSortOrder: AscDescEnum.Descending,
      SubsectorMWQMSitesSortOrder: AscDescEnum.Ascending,
      SubsectorPolSourceSitesSortOrder: AscDescEnum.Ascending,

    });
  }

  UpdateAppState(appState: AppState) {
    this.AppState$.next(<AppState>{ ...this.AppState$.getValue(), ...appState });
  }

}
