import { _isNumberValue } from '@angular/cdk/coercion';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { SearchResult } from 'src/app/models/generated/helper/SearchResult.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class SearchService {

    constructor(private httpClient: HttpClient,
        private appLoadedService: AppLoadedService,
        private appStateService: AppStateService,
        private appLanguageService: AppLanguageService) {
    }

    GetSearch(myControl: FormControl) {
        return myControl.valueChanges.pipe(
            startWith(''),
            debounceTime(500),
            distinctUntilChanged(),
            tap((term: string) => {
                this.GetSearchData(term);
            }));
    }

    private GetSearchData(term: string) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.SearchResult = [];
        this.appStateService.SearchWorking = true;
        term = ('' + term).trim();
        if (!term) {
            of([]).pipe(
                tap(() => {
                    this.appStateService.SearchWorking = false;
                    console.debug("Clean Search Result");
                })
            ).subscribe();
        }
        else {           
            this.httpClient.get<SearchResult>(`${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/search/${term}/0`).pipe(
                map((x: any) => {
                    this.appLoadedService.SearchResult = x;
                    this.appStateService.SearchWorking = false;
                    console.debug(x);
                }),
                catchError(e => of(e).pipe(map(e => {
                    this.appLoadedService.SearchResult = [];
                    this.appStateService.SearchWorking = false;
                    this.appStateService.Error = <HttpErrorResponse>e;
                    console.debug(e);
                })))
            ).subscribe();
        }
    }
}