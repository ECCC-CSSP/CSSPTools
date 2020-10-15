import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { SearchService } from './search.service';
import { SearchResult } from '../../models/generated/SearchResult.model';
//import { Router } from '@angular/router';
import { AppService } from '../../app.service';
import { AppVar } from 'src/app/app.model';

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

  constructor(public searchService: SearchService, private appService: AppService) {
  }

  ngOnInit() {
    this.sub = this.searchService.GetSearch(this.myControl).subscribe();
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
    this.appService.UpdateAppVar(<AppVar>{ SubPage: this.appService.GetSubPage(sr.TVItem), CurrentTVItemID: sr.TVItem.TVItemID });
  }

  ngOnDestroy()
  {
    if (this.sub)
    {
      this.sub.unsubscribe();
    }
  }
}
