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
import { WebRootService } from '../loaders/web-root.service';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { WebMunicipalityService } from '../loaders/web-municipalty.service';
import { MWQMRunSubComponentEnum } from 'src/app/enums/generated/MWQMRunSubComponentEnum';
import { WebMWQMRunService } from '../loaders/web-mwqm-runs.service';
import { WebMWQMSiteService } from '../loaders/web-mwqm-sites.service';
import { WebPolSourceSiteService } from '../loaders/web-pol-source-sites.service';
import { MWQMSiteSubComponentEnum } from 'src/app/enums/generated/MWQMSiteSubComponentEnum';
import { PolSourceSiteSubComponentEnum } from 'src/app/enums/generated/PolSourceSiteSubComponentEnum';

@Injectable({
  providedIn: 'root'
})
export class ComponentShowService {

  constructor(private appStateService: AppStateService,
    private webRootService: WebRootService,
    private webCountryService: WebCountryService,
    private webMunicipalityService: WebMunicipalityService,
    private webMWQMRunService: WebMWQMRunService,
    private webMWQMSiteService: WebMWQMSiteService,
    private webPolSourceSiteService: WebPolSourceSiteService,
    private webProvinceService: WebProvinceService,
    private webAreaService: WebAreaService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService) {
  }

  ShowArea(areaSubComponent: AreaSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ AreaSubComponent: areaSubComponent });
    this.webAreaService.DoWebArea(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowCountry(countrySubComponent: CountrySubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ CountrySubComponent: countrySubComponent });
    this.webCountryService.DoWebCountry(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowMunicipality(municipalitySubComponent: MunicipalitySubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ MunicipalitySubComponent: municipalitySubComponent });
    this.webMunicipalityService.DoWebMunicipality(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowMWQMRun(mwqmRunSubComponent: MWQMRunSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ MWQMRunSubComponent: mwqmRunSubComponent });
    this.webMWQMRunService.DoWebMWQMRun(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowMWQMSite(mwqmSiteSubComponent: MWQMSiteSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ MWQMSiteSubComponent: mwqmSiteSubComponent });
    this.webMWQMSiteService.DoWebMWQMSite(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowMWQMPolSourceSite(polSourceSiteSubComponent: PolSourceSiteSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ PolSourceSiteSubComponent: polSourceSiteSubComponent });
    this.webPolSourceSiteService.DoWebPolSourceSite(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowProvince(provinceSubComponent: ProvinceSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ ProvinceSubComponent: provinceSubComponent });
    this.webProvinceService.DoWebProvince(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowRoot(rootSubComponent: RootSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ RootSubComponent: rootSubComponent });
    this.webRootService.DoWebRoot(true);
  }

  ShowSector(sectorSubComponent: SectorSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ SectorSubComponent: sectorSubComponent });
    this.webSectorService.DoWebSector(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

  ShowSubsector(subsectorSubComponent: SubsectorSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ SubsectorSubComponent: subsectorSubComponent });
    this.webSubsectorService.DoWebSubsector(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
  }

}
