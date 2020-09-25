import { Injectable } from '@angular/core';
import { SearchResultModel, SearchTextModel } from './search.models';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { LoadLocalesSearchText } from './search.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { SearchResult } from 'src/app/models/SearchResult.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  searchTextModel$: BehaviorSubject<SearchTextModel> = new BehaviorSubject<SearchTextModel>(<SearchTextModel>{});
  searchResultModel$: BehaviorSubject<SearchResultModel> = new BehaviorSubject<SearchResultModel>(<SearchResultModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSearchText(this);
    this.UpdateSearchText(<SearchTextModel>{ Title: "Something for text" });
  }

  UpdateSearchText(searchTextModel: SearchTextModel) {
    this.searchTextModel$.next(<SearchTextModel>{ ...this.searchTextModel$.getValue(), ...searchTextModel });
  }

  UpdateSearchResult(searchResultModel: SearchResultModel) {
    this.searchResultModel$.next(<SearchResultModel>{ ...this.searchResultModel$.getValue(), ...searchResultModel });
  }

  GetSearch(myControl: FormControl) {
    return myControl.valueChanges.pipe(
      startWith(''),
      debounceTime(500),
      distinctUntilChanged(),
      tap(term => {
        this.GetData(term);
      }));
  }

  private GetData(term: string) {
    this.UpdateSearchResult(<SearchResultModel>{ Working: true });
    term = ('' + term).trim();
    if (!term) {
      of([]).pipe(
        tap(() => {
          this.UpdateSearchResult(<SearchResultModel>{ searchResult: [], Working: false });
          console.debug("Clean Search Result");
        })
      ).subscribe();
    }
    else {
      this.httpClient.get<SearchResult>(`/api/search/${term}/1`).pipe(
        map((x: any) => {
          this.UpdateSearchResult(<SearchResultModel>{ searchResult: x, Working: false });
          console.debug(x);
        }),
        catchError(e => of(e).pipe(map(e => {
          this.UpdateSearchResult(<SearchResultModel>{ Working: false, Error: <HttpErrorResponse>e });
          console.debug(e);
        })))
      ).subscribe();
    }
  }
}
