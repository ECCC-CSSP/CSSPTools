import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { FormControl } from '@angular/forms';
import { SearchService } from './search.service';
import { SearchResult } from 'src/app/models/searchresult';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchComponent implements OnInit, OnDestroy {
  myControl = new FormControl();
  options = [];
  //filteredOptions: Observable<SearchService>;
  searchResult: SearchResult;
  formFieldWidthClass: string = '';
  sub: Subscription;

  constructor(public searchService: SearchService, private router: Router) {
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
    this.router.navigateByUrl($localize.locale + '/' + this.searchService.GetUrl(sr));
  }

  ngOnDestroy()
  {
    if (this.sub)
    {
      this.sub.unsubscribe();
    }
  }
}
