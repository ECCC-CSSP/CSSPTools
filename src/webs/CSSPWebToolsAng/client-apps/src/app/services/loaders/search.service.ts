import { _isNumberValue } from '@angular/cdk/coercion';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { of } from 'rxjs';
import { debounceTime, distinctUntilChanged, startWith, tap } from 'rxjs/operators';
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
            let TVItemModelList: TVItemModel[] = [];

            if (TermList.length == 0) {
                return [];
            }


            if (TermList.length == 1) {
                if (_isNumberValue(TermList)) {
                    let TermNumber: number = parseInt(TermList[0]);
                    for (let i = 0, count = this.appLoadedService.WebAllSearch.TVItemModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItem.TVItemID == TermNumber) {
                            TVItemModelList.push(this.appLoadedService.WebAllSearch.TVItemModelList[i]);
                            break;
                        }
                    }
                }
                else {
                    let TermListLower0 = TermList[0].toLowerCase();
                    for (let i = 0, count = this.appLoadedService.WebAllSearch.TVItemModelList.length; i < count; i++) {
                        if (this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower0)) {
                            TVItemModelList.push(this.appLoadedService.WebAllSearch.TVItemModelList[i]);
                            if (TVItemModelList.length > 10) {
                                break;
                            }
                        }
                    }
                }
                this.appLoadedService.SearchResult = TVItemModelList.reverse();

                this.appStateService.SearchWorking = false;
                console.debug(this.appLoadedService.SearchResult);
            }
            if (TermList.length == 2) {
                let TermListLower0 = TermList[0].toLowerCase();
                let TermListLower1 = TermList[1].toLowerCase();
                for (let i = 0, count = this.appLoadedService.WebAllSearch.TVItemModelList.length; i < count; i++) {
                    if (this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower0)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower1)) {
                        TVItemModelList.push(this.appLoadedService.WebAllSearch.TVItemModelList[i]);
                        if (TVItemModelList.length > 10) {
                            break;
                        }
                    }
                }
                this.appLoadedService.SearchResult = TVItemModelList.reverse();

                this.appStateService.SearchWorking = false;
                console.debug(this.appLoadedService.SearchResult);
            }
            if (TermList.length == 3) {
                let TermListLower0 = TermList[0].toLowerCase();
                let TermListLower1 = TermList[1].toLowerCase();
                let TermListLower2 = TermList[2].toLowerCase();
                for (let i = 0, count = this.appLoadedService.WebAllSearch.TVItemModelList.length; i < count; i++) {
                    if (this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower0)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower1)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower2)) {
                        TVItemModelList.push(this.appLoadedService.WebAllSearch.TVItemModelList[i]);
                        if (TVItemModelList.length > 10) {
                            break;
                        }
                    }
                }
                this.appLoadedService.SearchResult = TVItemModelList.reverse();

                this.appStateService.SearchWorking = false;
                console.debug(this.appLoadedService.SearchResult);
            }
            if (TermList.length == 4) {
                let TermListLower0 = TermList[0].toLowerCase();
                let TermListLower1 = TermList[1].toLowerCase();
                let TermListLower2 = TermList[2].toLowerCase();
                let TermListLower3 = TermList[3].toLowerCase();
                for (let i = 0, count = this.appLoadedService.WebAllSearch.TVItemModelList.length; i < count; i++) {
                    if (this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower0)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower1)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower2)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower3)) {
                        TVItemModelList.push(this.appLoadedService.WebAllSearch.TVItemModelList[i]);
                        if (TVItemModelList.length > 10) {
                            break;
                        }
                    }
                }
                this.appLoadedService.SearchResult = TVItemModelList.reverse();

                this.appStateService.SearchWorking = false;
                console.debug(this.appLoadedService.SearchResult);
            }
            if (TermList.length >= 5) {
                let TermListLower0 = TermList[0].toLowerCase();
                let TermListLower1 = TermList[1].toLowerCase();
                let TermListLower2 = TermList[2].toLowerCase();
                let TermListLower3 = TermList[3].toLowerCase();
                let TermListLower4 = TermList[4].toLowerCase();
                for (let i = 0, count = this.appLoadedService.WebAllSearch.TVItemModelList.length; i < count; i++) {
                    if (this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower0)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower1)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower2)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower3)
                        && this.appLoadedService.WebAllSearch.TVItemModelList[i].TVItemLanguageList[this.appLanguageService.LangID].TVText.toLowerCase().includes(TermListLower4)) {
                        TVItemModelList.push(this.appLoadedService.WebAllSearch.TVItemModelList[i]);
                        if (TVItemModelList.length > 10) {
                            break;
                        }
                    }
                }
                this.appLoadedService.SearchResult = TVItemModelList.reverse();

                this.appStateService.SearchWorking = false;
                console.debug(this.appLoadedService.SearchResult);
            }
        }
    }
}