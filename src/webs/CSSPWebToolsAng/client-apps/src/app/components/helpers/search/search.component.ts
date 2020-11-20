import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { SearchService } from 'src/app/services/loaders/search.service';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
import { WebMWQMSiteService } from 'src/app/services/loaders/web-mwqm-sites.service';
import { WebMWQMRunService } from 'src/app/services/loaders/web-mwqm-runs.service';
import { WebPolSourceSiteService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { WebMunicipalitiesService } from 'src/app/services/loaders/web-municipalities.service';
import { AppState } from 'src/app/models/AppState.model';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit, OnDestroy {
  myControl = new FormControl();
  options = [];
  searchResult: SearchResult;
  formFieldWidthClass: string = '';
  subSearch: Subscription;
  subWebRoot: Subscription;
  subWebCountry: Subscription;
  subWebProvince: Subscription;
  subWebMunicipalities: Subscription;
  subWebArea: Subscription;
  subWebSector: Subscription;
  subWebSubsector: Subscription;
  subWebMunicipality: Subscription;
  subWebMWQMSite: Subscription;
  subWebMWQMRun: Subscription;
  subWebPolSourceSite: Subscription;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private searchService: SearchService,
    private webRootService: WebRootService,
    private webCountryService: WebCountryService,
    private webProvinceService: WebProvinceService,
    private webMunicipalitiesService: WebMunicipalitiesService,
    private webAreaService: WebAreaService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService,
    private webMunicipalityService: WebMunicipalityService,
    private webMWQMSiteService: WebMWQMSiteService,
    private webMWQMRunService: WebMWQMRunService,
    private webPolSourceSiteService: WebPolSourceSiteService) {
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
      this.webCountryService.DoWebCountry(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Country, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Area) {
      this.webAreaService.DoWebArea(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Area, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Municipality) {
      this.webMunicipalityService.DoWebMunicipality(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Municipality, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.MWQMRun) {
      this.webMWQMRunService.DoWebMWQMRun(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.MWQMRun, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.MWQMSite) {
      this.webMWQMSiteService.DoWebMWQMSite(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.MWQMSite, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.PolSourceSite) {
      this.webPolSourceSiteService.DoWebPolSourceSite(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.PolSourceSite, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Province) {
      this.webProvinceService.DoWebProvince(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Province, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Root) {
      this.webRootService.DoWebRoot(true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Root, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Sector) {
      this.webSectorService.DoWebSector(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Sector, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Subsector) {
      this.webSubsectorService.DoWebSubsector(sr.TVItem.TVItemID, true);
      this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: ShellSubComponentEnum.Subsector, CurrentTVItemID: sr.TVItem.TVItemID });
    }
    else {
      alert(`${TVTypeEnum[sr.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }
  }

  ngOnDestroy() {
    this.subSearch ? this.subSearch.unsubscribe() : null;
    this.subWebRoot ? this.subWebRoot.unsubscribe() : null;
    this.subWebCountry ? this.subWebCountry.unsubscribe() : null;
    this.subWebProvince ? this.subWebProvince.unsubscribe() : null;
    this.subWebMunicipalities ? this.subWebMunicipalities.unsubscribe() : null;
    this.subWebArea ? this.subWebArea.unsubscribe() : null;
    this.subWebSector ? this.subWebSector.unsubscribe() : null;
    this.subWebSubsector ? this.subWebSubsector.unsubscribe() : null;
    this.subWebMunicipality ? this.subWebMunicipality.unsubscribe() : null;
    this.subWebMWQMSite ? this.subWebMWQMSite.unsubscribe() : null;
    this.subWebMWQMRun ? this.subWebMWQMRun.unsubscribe() : null;
    this.subWebPolSourceSite ? this.subWebPolSourceSite.unsubscribe() : null;
  }
}
