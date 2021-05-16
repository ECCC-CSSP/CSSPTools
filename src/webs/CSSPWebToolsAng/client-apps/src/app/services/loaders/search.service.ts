import { _isNumberValue } from '@angular/cdk/coercion';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class SearchService {

    constructor(private appLoadedService: AppLoadedService,
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
            let TermList: string[] = term.split(' ');

            if (TermList.length == 0) {
                return [];
            }
            if (TermList.length == 1) {
                let TVItemModelTempList: TVItemModel[] = this.appLoadedService.WebAllSearch.TVItemModelList.filter(c => c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[0]));
                if (TVItemModelTempList.length > 10) {
                    return TVItemModelTempList.slice(0, 10);
                }
            }
            if (TermList.length == 2) {
                let TVItemModelTempList: TVItemModel[] = this.appLoadedService.WebAllSearch.TVItemModelList.filter(c =>
                    c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[0])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[1]));
                if (TVItemModelTempList.length > 10) {
                    return TVItemModelTempList.slice(0, 10);
                }
            }
            if (TermList.length == 3) {
                let TVItemModelTempList: TVItemModel[] = this.appLoadedService.WebAllSearch.TVItemModelList.filter(c =>
                    c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[0])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[1])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[2]));
                if (TVItemModelTempList.length > 10) {
                    return TVItemModelTempList.slice(0, 10);
                }
            }
            if (TermList.length == 4) {
                let TVItemModelTempList: TVItemModel[] = this.appLoadedService.WebAllSearch.TVItemModelList.filter(c =>
                    c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[0])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[1])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[2])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[3]));
                if (TVItemModelTempList.length > 10) {
                    return TVItemModelTempList.slice(0, 10);
                }
            }
            if (TermList.length >= 5) {
                let TVItemModelTempList: TVItemModel[] = this.appLoadedService.WebAllSearch.TVItemModelList.filter(c =>
                    c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[0])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[1])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[2])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[3])
                    && c.TVItemLanguageList[this.appLanguageService.LangID].TVText.includes(TermList[4]));
                if (TVItemModelTempList.length > 10) {
                    return TVItemModelTempList.slice(0, 10);
                }
            }
        }
    }
}