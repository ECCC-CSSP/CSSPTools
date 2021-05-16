import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { SearchService } from 'src/app/services/loaders/search.service';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit, OnDestroy {
  myControl = new FormControl();
  options = [];
  searchResult: TVItemModel;
  formFieldWidthClass: string = '';
  subSearch: Subscription;
  subLoader: Subscription;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private searchService: SearchService,
    private loaderService: LoaderService,
  ) {
  }

  ngOnInit() {
    this.subSearch = this.searchService.GetSearch(this.myControl).subscribe();
  }

  displayFn(searchResult: TVItemModel): string {
    return '';
  }

  ToggleSearchWidth() {
    this.formFieldWidthClass == '' ? this.formFieldWidthClass = 'form-field-width' : this.formFieldWidthClass = '';
  }

  NavigateTo(sr: TVItemModel) {
    this.searchResult = sr;
    if (sr.TVItem.TVType == TVTypeEnum.Country) {
      this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, null, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Country;
      this.appStateService.UserPreference.CurrentCountryTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Area) {
      this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, null, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Area;
      this.appStateService.UserPreference.CurrentAreaTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Municipality) {
      this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, WebTypeEnum.WebMikeScenarios, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Municipality;
      this.appStateService.UserPreference.CurrentMunicipalityTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Province) {
      this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, WebTypeEnum.WebClimateSites, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Province;
      this.appStateService.UserPreference.CurrentProvinceTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Sector) {
      this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, null, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Sector;
      this.appStateService.UserPreference.CurrentSectorTVItemID = sr.TVItem.TVItemID;
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Subsector) {
      this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, WebTypeEnum.WebMWQMSites, false);
      this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Subsector;
      this.appStateService.UserPreference.CurrentSubsectorTVItemID = sr.TVItem.TVItemID;
    }
    else {
      alert(`${TVTypeEnum[sr.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }
  }

  ngOnDestroy() {
    this.subSearch ? this.subSearch.unsubscribe() : null;
    this.subLoader ? this.subLoader.unsubscribe() : null;
  }
}
