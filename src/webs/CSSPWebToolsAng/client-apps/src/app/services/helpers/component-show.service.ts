import { Injectable } from '@angular/core';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { LoaderService } from '../loaders/loader.service';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
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
    ){
  }

  ShowArea(areaSubComponent: AreaSubComponentEnum) {
    this.appStateService.UserPreference.AreaSubComponent = areaSubComponent;
    this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, null, false);
  }

  ShowCountry(countrySubComponent: CountrySubComponentEnum) {
    this.appStateService.UserPreference.CountrySubComponent = countrySubComponent;
    this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, null, false);
  }

  ShowMunicipality(municipalitySubComponent: MunicipalitySubComponentEnum) {
    this.appStateService.UserPreference.MunicipalitySubComponent = municipalitySubComponent;
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
    this.appStateService.UserPreference.ProvinceSubComponent = provinceSubComponent;
    this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, WebTypeEnum.WebClimateSites, false);
  }

  ShowRoot(rootSubComponent: RootSubComponentEnum) {
    this.appStateService.UserPreference.RootSubComponent = rootSubComponent;
    this.loaderService.Load<WebRoot>(WebTypeEnum.WebRoot, WebTypeEnum.WebAllAddresses, false);
  }

  ShowSector(sectorSubComponent: SectorSubComponentEnum) {
    this.appStateService.UserPreference.SectorSubComponent = sectorSubComponent;
    this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, null, false);
  }

  ShowSubsector(subsectorSubComponent: SubsectorSubComponentEnum) {
    this.appStateService.UserPreference.SubsectorSubComponent = subsectorSubComponent;
    this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, WebTypeEnum.WebMWQMSites, false);
  }

}
