import { Component, OnInit, ChangeDetectionStrategy, Injectable } from '@angular/core';
import { Observable, of, Subject, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged, map, startWith, switchMap, tap } from 'rxjs/operators';
import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';
import { SearchService } from './search.service';
import { SearchResult } from 'src/app/models/searchresult';
import { Router, NavigationExtras } from '@angular/router';
import { AppService } from 'src/app/services';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit {
  myControl = new FormControl();
  options = [];
  filteredOptions: Observable<SearchService>;
  searchResult: SearchResult;
  formFieldWidthClass: string = '';

  constructor(private searchService: SearchService, private router: Router, private appService: AppService) {
  }

  ngOnInit() {
    this.filteredOptions = this.searchService.GetSearch(this.myControl);
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
    this.router.navigateByUrl($localize.locale + '/' + this.searchService.GetUrl(sr));
  }
}
