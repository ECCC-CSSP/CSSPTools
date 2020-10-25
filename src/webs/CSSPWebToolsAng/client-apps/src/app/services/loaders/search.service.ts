import { _isNumberValue } from '@angular/cdk/coercion';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { SearchResult } from 'src/app/models/generated/SearchResult.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
    providedIn: 'root'
})
export class SearchService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    GetSearch(myControl: FormControl) {
        return myControl.valueChanges.pipe(
            startWith(''),
            debounceTime(500),
            distinctUntilChanged(),
            tap(term => {
                this.GetSearchData(term);
            }));
    }

    private GetSearchData(term: string) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: true });
        term = ('' + term).trim();
        if (!term) {
            of([]).pipe(
                tap(() => {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ SearchResult: [], Working: false });
                    console.debug("Clean Search Result");
                })
            ).subscribe();
        }
        else {           
            this.httpClient.get<SearchResult>(`${this.appLoadedService.BaseApiUrl}en-CA/search/${term}/1`).pipe(
                map((x: any) => {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ SearchResult: x, Working: false });
                    console.debug(x);
                }),
                catchError(e => of(e).pipe(map(e => {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                    console.debug(e);
                })))
            ).subscribe();
        }
    }
}