import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from '../app-loaded.service';
import { WebAreaService } from '../loaders/web-area.service';
import { WebSectorService } from '../loaders/web-sector.service';
import { WebCountryService } from '../loaders/web-country.service';
import { WebMunicipalitiesService } from '../loaders/web-municipalities.service';
import { WebProvinceService } from '../loaders/web-province.service';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { WebSubsectorService } from '../loaders/web-subsector.service';
import { WebMWQMSampleService } from '../loaders/web-mwqm-samples.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentShowService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private webCountryService: WebCountryService,
    private webProvinceService: WebProvinceService,
    private webMunicipalitiesService: WebMunicipalitiesService,
    private webAreaService: WebAreaService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService,
    private webMWQMSampleService: WebMWQMSampleService) {
  }

  ShowArea(areaSubComponent: AreaSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ AreaSubComponent: areaSubComponent });
    this.webAreaService.UpdateWebArea(this.appLoadedService.AppLoaded$.getValue().WebArea);
  }

  ShowCountry(countrySubComponent: CountrySubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ CountrySubComponent: countrySubComponent });
    this.webCountryService.UpdateWebCountry(this.appLoadedService.AppLoaded$.getValue().WebCountry);
  }

  ShowProvince(provinceSubComponent: ProvinceSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ ProvinceSubComponent: provinceSubComponent });
    this.webProvinceService.UpdateWebProvince(this.appLoadedService.AppLoaded$.getValue().WebProvince);
    this.webMunicipalitiesService.UpdateWebMunicipalities(this.appLoadedService.AppLoaded$.getValue().WebMunicipalities);
  }

  ShowRoot(rootSubComponent: RootSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ RootSubComponent: rootSubComponent });
  }

  ShowSector(sectorSubComponent: SectorSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ SectorSubComponent: sectorSubComponent });
    this.webSectorService.UpdateWebSector(this.appLoadedService.AppLoaded$.getValue().WebSector);
  }

  ShowSubsector(subsectorSubComponent: SubsectorSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ SubsectorSubComponent: subsectorSubComponent });
    this.webSubsectorService.UpdateWebSubsector(this.appLoadedService.AppLoaded$.getValue().WebSubsector);
    this.webMWQMSampleService.UpdateWebMWQMSampleAll(this.appLoadedService.AppLoaded$.getValue().WebMWQMSampleAll);
  }

}
