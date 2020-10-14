import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesSearchVar } from './search.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { SearchResult } from '../../models/generated/SearchResult.model';
import { SearchVar } from '.';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  SearchVar$: BehaviorSubject<SearchVar> = new BehaviorSubject<SearchVar>(<SearchVar>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesSearchVar(this);
    this.UpdateSearchVar(<SearchVar>{ SearchTitle: "Something for text" });
  }

  UpdateSearchVar(searchVar: SearchVar) {
    this.SearchVar$.next(<SearchVar>{ ...this.SearchVar$.getValue(), ...searchVar });
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
    this.UpdateSearchVar(<SearchVar>{ Working: true });
    term = ('' + term).trim();
    if (!term) {
      of([]).pipe(
        tap(() => {
          this.UpdateSearchVar(<SearchVar>{ searchResult: [], Working: false });
          console.debug("Clean Search Result");
        })
      ).subscribe();
    }
    else {
      this.httpClient.get<SearchResult>(`/api/search/${term}/1`).pipe(
        map((x: any) => {
          this.UpdateSearchVar(<SearchVar>{ searchResult: x, Working: false });
          console.debug(x);
        }),
        catchError(e => of(e).pipe(map(e => {
          this.UpdateSearchVar(<SearchVar>{ Working: false, Error: <HttpErrorResponse>e });
          console.debug(e);
        })))
      ).subscribe();
    }
  }
}
