import { Injectable } from '@angular/core';
import { SearchModel, SearchTextModel } from './search.models';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { LoadLocalesSearchText } from './search.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { TVItemLanguage } from 'src/app/models/generated/TVItemLanguage.model';
import { catchError, debounceTime, distinctUntilChanged, map, switchMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  //private apiUrl = 'https://jsonplaceholder.typicode.com';
  searchTextModel$: BehaviorSubject<SearchTextModel> = new BehaviorSubject<SearchTextModel>(<SearchTextModel>{});
  searchModel$: BehaviorSubject<SearchModel> = new BehaviorSubject<SearchModel>(<SearchModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSearchText(this);
    this.UpdateSearchText(<SearchTextModel>{ Title: "Something for text" });
  }

  UpdateSearchText(searchTextModel: SearchTextModel) {
    this.searchTextModel$.next(<SearchTextModel>{ ...this.searchTextModel$.getValue(), ...searchTextModel });
  }

  UpdateSearch(searchModel: SearchModel) {
    this.searchModel$.next(<SearchModel>{ ...this.searchModel$.getValue(), ...searchModel });
  }

  GetSearch(term: string) {
    return this.httpClient.get<TVItemLanguage[]>(`/api/search/nb/1`).pipe(
      debounceTime(250),
      distinctUntilChanged(),
      map((x: any) => {
        this.UpdateSearch(<SearchModel>{ TVItemLanguageList: x, Loading: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateSearch(<SearchModel>{ Loading: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

}
