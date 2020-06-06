/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularComponentsGenerated\bin\Debug\netcoreapp3.1\AngularComponentsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { Injectable } from '@angular/core';
import { SearchTextModel, SearchModel } from './search.models';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSearchText } from './search.locales';
import { Router } from '@angular/router';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Search } from 'src/app/models/generated/Search.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  searchTextModel$: BehaviorSubject<SearchTextModel> = new BehaviorSubject<SearchTextModel>(<SearchTextModel>{});
  searchModel$: BehaviorSubject<SearchModel> = new BehaviorSubject<SearchModel>(<SearchModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSearchText(this);
    this.UpdateSearchText(<SearchTextModel>{ Title: "Something2 for text" });
  }

  UpdateSearchText(searchTextModel: SearchTextModel) {
    this.searchTextModel$.next(<SearchTextModel>{ ...this.searchTextModel$.getValue(), ...searchTextModel });
  }

  UpdateSearchModel(searchModel: SearchModel) {
    this.searchModel$.next(<SearchModel>{ ...this.searchModel$.getValue(), ...searchModel });
  }

  GetSearch(router: Router) {
    let oldURL = router.url;
    this.UpdateSearchModel(<SearchModel>{ Working: true, Error: null });

    return this.httpClient.get<Search[]>('/api/Search').pipe(
      map((x: any) => {
        console.debug(`Search OK. Return: ${x}`);
        this.searchModel$.getValue().SearchList = <Search[]>x;
        this.UpdateSearchModel(this.searchModel$.getValue());
        this.UpdateSearchModel(<SearchModel>{ Working: false, Error: null });
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateSearchModel(<SearchModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(`Search ERROR. Return: ${<HttpErrorResponse>e}`);
        router.navigateByUrl('', { skipLocationChange: true }).then(() => {
          router.navigate([`/${oldURL}`]);
        });
      })))
    );
  }
}
