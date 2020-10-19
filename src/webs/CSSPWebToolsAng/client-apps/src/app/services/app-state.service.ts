import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ContentSizeEnum } from '../enums/generated/ContentSizeEnum';
import { CountrySubComponentEnum } from '../enums/generated/CountrySubComponentEnum';
import { LanguageEnum } from '../enums/generated/LanguageEnum';
import { MapSizeEnum } from '../enums/generated/MapSizeEnum';
import { ProvinceSubComponentEnum } from '../enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from '../enums/generated/RootSubComponentEnum';
import { ShellSubComponentEnum } from '../enums/generated/ShellSubComponentEnum';
import { TopComponentEnum } from '../enums/generated/TopComponentEnum';
import { AppState } from '../models/AppState.model';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  AppState$: BehaviorSubject<AppState> = new BehaviorSubject<AppState>(<AppState>{});

  constructor() {   
    this.UpdateAppState(<AppState>{
      TopComponent: TopComponentEnum.Home, // home | shell
      ShellSubComponent: ShellSubComponentEnum.Root, // Root | Country | Province | Area | Sector | Subsector
      RootSubComponent: RootSubComponentEnum.Countries, // Countries | Files | ExportArcGIS
      CountrySubComponent: CountrySubComponentEnum.Provinces, // Provinces | Files | OpenDataNational | EmailDistributionList | RainExceedance
      ProvinceSubComponent: ProvinceSubComponentEnum.Areas, // Areas | Municipalities | Files | SamplingPlan | OpenData | ProvinceTools
      CurrentTVItemID: 0,
      Language: LanguageEnum.en, // en | fr | enAndfr | es
      DetailVisible: false,
      EditVisible: false,
      InactVisible: false,
      MenuVisible: false,
      MapVisible: false,
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
      markerList: [],
      polygonList: [],
      polylineList: [],
      infoContent: ''

    });
  }

  UpdateAppState(appState: AppState) {
    this.AppState$.next(<AppState>{ ...this.AppState$.getValue(), ...appState });
  }
  
}
