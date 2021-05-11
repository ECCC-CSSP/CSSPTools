import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { SearchService } from 'src/app/services/loaders/search.service';
//import { WebRootService } from 'src/app/services/loaders/web-root.service';
// import { WebCountryService } from 'src/app/services/loaders/web-country.service';
// import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
// import { WebAreaService } from 'src/app/services/loaders/web-area.service';
// import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
// import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
// import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';
// import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';
// import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
// import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit, OnDestroy {
  myControl = new FormControl();
  options = [];
  searchResult: SearchResult;
  formFieldWidthClass: string = '';
  subSearch: Subscription;
  subLoader: Subscription;
  //subWebRoot: Subscription;
  // subWebCountry: Subscription;
  // subWebProvince: Subscription;
  // subWebMunicipalities: Subscription;
  // subWebArea: Subscription;
  // subWebSector: Subscription;
  // subWebSubsector: Subscription;
  // subWebMunicipality: Subscription;
  // subWebMWQMSite: Subscription;
  // subWebMWQMRun: Subscription;
  // subWebPolSourceSite: Subscription;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private searchService: SearchService,
    private loaderService: LoaderService,
    //private webRootService: WebRootService,
    // private webCountryService: WebCountryService,
    // private webProvinceService: WebProvinceService,
    // private webAreaService: WebAreaService,
    // private webSectorService: WebSectorService,
    // private webSubsectorService: WebSubsectorService,
    // private webMunicipalityService: WebMunicipalityService,
    // private webMWQMSitesService: WebMWQMSitesService,
    // private webMWQMRunsService: WebMWQMRunsService,
    // private webPolSourceSitesService: WebPolSourceSitesService
  ) {
  }

  ngOnInit() {
    this.subSearch = this.searchService.GetSearch(this.myControl).subscribe();
  }

  displayFn(searchResult: SearchResult): string {
    return '';
  }

  ToggleSearchWidth() {
    this.formFieldWidthClass == '' ? this.formFieldWidthClass = 'form-field-width' : this.formFieldWidthClass = '';
  }

  NavigateTo(sr: SearchResult) {
    this.searchResult = sr;
    if (sr.TVItem.TVType == TVTypeEnum.Country) {
      this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, null, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Country;
      this.appStateService.CurrentCountryTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Area) {
      this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, null, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Area;
      this.appStateService.CurrentAreaTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Municipality) {
      this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, WebTypeEnum.WebMikeScenarios, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Municipality;
      this.appStateService.CurrentMunicipalityTVItemID = sr.TVItem.TVItemID;
    }
    // else if (sr.TVItem.TVType == TVTypeEnum.MWQMRun) {
    //   this.webMWQMRunsService.DoWebMWQMRuns(sr.TVItem.TVItemID, true);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.MWQMRun;
    //   this.appStateService.CurrentTVItemID = sr.TVItem.TVItemID;
    // }
    // else if (sr.TVItem.TVType == TVTypeEnum.MWQMSite) {
    //   this.webMWQMSitesService.DoWebMWQMSites(sr.TVItem.TVItemID, true);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.MWQMSite;
    //   this.appStateService.CurrentTVItemID = sr.TVItem.TVItemID;
    // }
    // else if (sr.TVItem.TVType == TVTypeEnum.PolSourceSite) {
    //   this.webPolSourceSitesService.DoWebPolSourceSites(sr.TVItem.TVItemID, true);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.PolSourceSite
    //   this.appStateService.CurrentTVItemID = sr.TVItem.TVItemID;
    // }
    else if (sr.TVItem.TVType == TVTypeEnum.Province) {
      this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, WebTypeEnum.WebClimateSites, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Province;
      this.appStateService.CurrentProvinceTVItemID = sr.TVItem.TVItemID;
    }
    // else if (sr.TVItem.TVType == TVTypeEnum.Root) {
    //   this.loaderService.Load<WebRoot>(WebTypeEnum.WebRoot, WebTypeEnum.WebAllAddresses, false);
    //   this.appStateService.ShellSubComponent = ShellSubComponentEnum.Root;
    //   this.appStateService.CurrentTVItemID = sr.TVItem.TVItemID;
    // }
    else if (sr.TVItem.TVType == TVTypeEnum.Sector) {
      this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, null, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Sector;
      this.appStateService.CurrentSectorTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Subsector) {
      this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, WebTypeEnum.WebMWQMSites, false);
      this.appStateService.ShellSubComponent = ShellSubComponentEnum.Subsector;
      this.appStateService.CurrentSubsectorTVItemID = sr.TVItem.TVItemID;
    }
    else {
      alert(`${TVTypeEnum[sr.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }
  }

  ngOnDestroy() {
    this.subSearch ? this.subSearch.unsubscribe() : null;
    this.subLoader ? this.subLoader.unsubscribe() : null;
    //this.subWebRoot ? this.subWebRoot.unsubscribe() : null;
    // this.subWebCountry ? this.subWebCountry.unsubscribe() : null;
    // this.subWebProvince ? this.subWebProvince.unsubscribe() : null;
    // this.subWebMunicipalities ? this.subWebMunicipalities.unsubscribe() : null;
    // this.subWebArea ? this.subWebArea.unsubscribe() : null;
    // this.subWebSector ? this.subWebSector.unsubscribe() : null;
    // this.subWebSubsector ? this.subWebSubsector.unsubscribe() : null;
    // this.subWebMunicipality ? this.subWebMunicipality.unsubscribe() : null;
    // this.subWebMWQMSite ? this.subWebMWQMSite.unsubscribe() : null;
    // this.subWebMWQMRun ? this.subWebMWQMRun.unsubscribe() : null;
    // this.subWebPolSourceSite ? this.subWebPolSourceSite.unsubscribe() : null;
  }
}
