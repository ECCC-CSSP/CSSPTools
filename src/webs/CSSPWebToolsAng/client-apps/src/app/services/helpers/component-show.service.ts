import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
// import { WebAreaService } from 'src/app/services/loaders/web-area.service';
// import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
// import { WebCountryService } from 'src/app/services/loaders/web-country.service';
// import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
// import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
// import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
//import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
//import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { MWQMRunSubComponentEnum } from 'src/app/enums/generated/MWQMRunSubComponentEnum';
import { MWQMSiteSubComponentEnum } from 'src/app/enums/generated/MWQMSiteSubComponentEnum';
import { PolSourceSiteSubComponentEnum } from 'src/app/enums/generated/PolSourceSiteSubComponentEnum';
// import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';
// import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';
// import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { LoaderService } from '../loaders/loader.service';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';

@Injectable({
  providedIn: 'root'
})
export class ComponentShowService {

  constructor(private appStateService: AppStateService,
    private loaderService: LoaderService,
    //private webRootService: WebRootService,
    // private webCountryService: WebCountryService,
    // private webMunicipalityService: WebMunicipalityService,
    // private webMWQMRunsService: WebMWQMRunsService,
    // private webMWQMSitesService: WebMWQMSitesService,
    // private webPolSourceSitesService: WebPolSourceSitesService,
    // private webProvinceService: WebProvinceService,
    // private webAreaService: WebAreaService,
    // private webSectorService: WebSectorService,
    // private webSubsectorService: WebSubsectorService
    ){
  }

  ShowArea(areaSubComponent: AreaSubComponentEnum) {
    this.appStateService.AreaSubComponent = areaSubComponent;
    this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, null, false);
  }

  ShowCountry(countrySubComponent: CountrySubComponentEnum) {
    this.appStateService.CountrySubComponent = countrySubComponent;
    this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, null, false);
  }

  ShowMunicipality(municipalitySubComponent: MunicipalitySubComponentEnum) {
    this.appStateService.MunicipalitySubComponent = municipalitySubComponent;
    this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, WebTypeEnum.WebMikeScenarios, false);
  }

  // ShowMWQMRun(mwqmRunSubComponent: MWQMRunSubComponentEnum) {
  //   this.appStateService.MWQMRunSubComponent = mwqmRunSubComponent;
  //   this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, WebTypeEnum.WebMikeScenarios, false);
  //   this.webMWQMRunsService.DoWebMWQMRuns(this.appStateService.CurrentTVItemID, true);
  // }

  // ShowMWQMSite(mwqmSiteSubComponent: MWQMSiteSubComponentEnum) {
  //   this.appStateService.MWQMSiteSubComponent = mwqmSiteSubComponent;
  //   this.webMWQMSitesService.DoWebMWQMSites(this.appStateService.CurrentTVItemID, true);
  // }

  // ShowMWQMPolSourceSite(polSourceSiteSubComponent: PolSourceSiteSubComponentEnum) {
  //   this.appStateService.PolSourceSiteSubComponent = polSourceSiteSubComponent;
  //   this.webPolSourceSitesService.DoWebPolSourceSites(this.appStateService.CurrentTVItemID, true);
  // }

  ShowProvince(provinceSubComponent: ProvinceSubComponentEnum) {
    this.appStateService.ProvinceSubComponent = provinceSubComponent;
    this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, WebTypeEnum.WebClimateSites, false);
  }

  ShowRoot(rootSubComponent: RootSubComponentEnum) {
    this.appStateService.RootSubComponent = rootSubComponent;
    this.loaderService.Load<WebRoot>(WebTypeEnum.WebRoot, WebTypeEnum.WebAllAddresses, false);
  }

  ShowSector(sectorSubComponent: SectorSubComponentEnum) {
    this.appStateService.SectorSubComponent = sectorSubComponent;
    this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, null, false);
  }

  ShowSubsector(subsectorSubComponent: SubsectorSubComponentEnum) {
    this.appStateService.SubsectorSubComponent = subsectorSubComponent;
    this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, WebTypeEnum.WebMWQMSites, false);
  }

}
