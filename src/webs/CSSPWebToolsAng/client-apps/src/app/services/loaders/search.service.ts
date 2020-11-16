import { _isNumberValue } from '@angular/cdk/coercion';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class SearchService {

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appStateService: AppStateService) {
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
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ SearchResult: [] });
        this.appStateService.UpdateAppState(<AppState>{ SearchWorking: true });
        term = ('' + term).trim();
        if (!term) {
            of([]).pipe(
                tap(() => {
                    this.appStateService.UpdateAppState(<AppState>{ SearchWorking: false });
                    console.debug("Clean Search Result");
                })
            ).subscribe();
        }
        else {           
            this.httpClient.get<SearchResult>(`${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/search/${term}/1`).pipe(
                map((x: any) => {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ SearchResult: x });
                    this.appStateService.UpdateAppState(<AppState>{ SearchWorking: false });
                    console.debug(x);
                }),
                catchError(e => of(e).pipe(map(e => {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ SearchResult: [] });
                    this.appStateService.UpdateAppState(<AppState>{ SearchWorking: false, Error: <HttpErrorResponse>e });
                    console.debug(e);
                })))
            ).subscribe();
        }
    }
}