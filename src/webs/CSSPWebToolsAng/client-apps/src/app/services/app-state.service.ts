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

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  AppState$: BehaviorSubject<AppState> = new BehaviorSubject<AppState>(<AppState>{});

  constructor() {   
    this.UpdateAppState(<AppState>{
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
      Language: LanguageEnum.en, // en | fr | enAndfr | es
      DetailVisible: false,
      StatCountVisible: false,
      LastUpdateVisible: false,
      EditVisible: false,
      InactVisible: false,
      MenuVisible: false,
      MapVisible: true,
      MapSize: MapSizeEnum.Size50, // Size30 | Size40 | Size50 | Size60 | Size70
  
      MapTitle: "Something for text", 
      zoom: 12,
      center: <google.maps.LatLngLiteral>{ lat: 46.0915449, lng: -64.7242012 },
      options: <google.maps.MapOptions>{
        //zoomControl: true,
        //scrollwheel: true,
        //disableDoubleClickZoom: false,
        mapTypeId: google.maps.MapTypeId.SATELLITE,
        // maxZoom: 15,
        // minZoom: 8,
      },
      // markerList: [],
      // polygonList: [],
      // polylineList: [],
      infoContent: '',

      RootCountriesSortOrder: AscDescEnum.Ascending,
      RootFilesSortOrder: AscDescEnum.Ascending,
      RootFilesSortByProp: FilesSortPropEnum.FileName, 
      CountryProvincesSortOrder: AscDescEnum.Ascending,
      CountryFilesSortOrder: AscDescEnum.Ascending,
      CountryFilesSortByProp: FilesSortPropEnum.FileName, 
      ProvinceAreasSortOrder: AscDescEnum.Ascending,
      ProvinceMunicipalitiesSortOrder: AscDescEnum.Ascending,
      ProvinceFilesSortOrder: AscDescEnum.Ascending,
      ProvinceFilesSortByProp: FilesSortPropEnum.FileName, 
      AreaSectorsSortOrder: AscDescEnum.Ascending,
      AreaFilesSortOrder: AscDescEnum.Ascending,
      AreaFilesSortByProp: FilesSortPropEnum.FileName, 
      SectorSubsectorsSortOrder: AscDescEnum.Ascending,
      SectorMikeScenariosSortOrder: AscDescEnum.Ascending,
      SectorFilesSortOrder: AscDescEnum.Ascending,
      SectorFilesSortByProp: FilesSortPropEnum.FileName, 
      SubsectorMWQMSitesSortOrder: AscDescEnum.Ascending,
      SubsectorMWQMRunsSortOrder: AscDescEnum.Descending,
      SubsectorPolSourceSitesSortOrder: AscDescEnum.Ascending,
      SubsectorFilesSortOrder: AscDescEnum.Ascending,
      SubsectorFilesSortByProp: FilesSortPropEnum.FileName, 
      MunicipalityContactsSortOrder: AscDescEnum.Ascending,
      MunicipalityInfrastructuresSortOrder: AscDescEnum.Ascending,
      MunicipalityFilesSortOrder: AscDescEnum.Ascending,
      MunicipalityFilesSortByProp: FilesSortPropEnum.FileName,
      MunicipalityMIKEScenariosSortOrder: AscDescEnum.Ascending,
      MWQMSiteFilesSortOrder: AscDescEnum.Ascending,
      MWQMSiteFilesSortByProp: FilesSortPropEnum.FileName,
      MWQMRunFilesSortOrder: AscDescEnum.Ascending,
      MWQMRunFilesSortByProp: FilesSortPropEnum.FileName,
      PolSourceSiteFilesSortOrder: AscDescEnum.Ascending,
      PolSourceSiteFilesSortByProp: FilesSortPropEnum.FileName,
  
    });
  }

  UpdateAppState(appState: AppState) {
    this.AppState$.next(<AppState>{ ...this.AppState$.getValue(), ...appState });
  }
  
}
