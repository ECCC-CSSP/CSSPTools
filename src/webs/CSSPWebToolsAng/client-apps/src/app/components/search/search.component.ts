import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { SearchResult } from '../../models/generated/SearchResult.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { HttpErrorResponse } from '@angular/common/http';
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
  sub: Subscription;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appHelperService: AppHelperService) {
  }

  ngOnInit() {
    this.sub = this.appLoadedService.GetSearch(this.myControl).subscribe();
  }

  displayFn(searchResult: SearchResult): string {
    return searchResult ? searchResult.TVItemLanguage.TVText : "";
  }

  ToggleSearchWidth() {
    this.formFieldWidthClass == '' ? this.formFieldWidthClass = 'form-field-width' : this.formFieldWidthClass = '';
  }

  NavigateTo(sr: SearchResult) {
    this.searchResult = sr;
    this.appHelperService.SearchNavigateTo(sr);
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
