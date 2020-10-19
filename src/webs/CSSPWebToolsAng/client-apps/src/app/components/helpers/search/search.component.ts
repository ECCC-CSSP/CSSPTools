import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { SearchResult } from 'src/app/models/generated/SearchResult.model';
import { AppLanguageService } from 'src/app/services/app-language.service';

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

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appHelperService: AppHelperService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
    this.subSearch = this.appLoadedService.GetSearch(this.myControl).subscribe();
  }

  displayFn(searchResult: SearchResult): string {
    return searchResult ? searchResult.TVItemLanguage.TVText : "";
  }

  ToggleSearchWidth() {
    this.formFieldWidthClass == '' ? this.formFieldWidthClass = 'form-field-width' : this.formFieldWidthClass = '';
  }

  NavigateTo(sr: SearchResult) {
    this.searchResult = sr;
    if (sr.TVItem.TVType == TVTypeEnum.Root) {
      this.subWebRoot = this.appLoadedService.GetWebRoot(sr.TVItem.TVItemID).subscribe();
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Country) {
      this.subWebCountry = this.appLoadedService.GetWebCountry(sr.TVItem.TVItemID).subscribe();
    }
    else if (sr.TVItem.TVType == TVTypeEnum.Province) {
      this.subWebProvince = this.appLoadedService.GetWebProvince(sr.TVItem.TVItemID).subscribe();
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
  }
}
