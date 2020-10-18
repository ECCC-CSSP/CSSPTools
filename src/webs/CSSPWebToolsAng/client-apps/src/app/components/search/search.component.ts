import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { SearchResult } from '../../models/generated/SearchResult.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppHelperService } from 'src/app/services/app-helper.service';

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

  NavigateTo(sr: SearchResult)
  {
    this.searchResult = sr;
    this.appStateService.UpdateAppState(<AppState>{ SubPage: this.appHelperService.GetSubPage(sr.TVItem), CurrentTVItemID: sr.TVItem.TVItemID });
  }

  ngOnDestroy()
  {
    if (this.sub)
    {
      this.sub.unsubscribe();
    }
  }
}
