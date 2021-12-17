import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, of, Subscription } from 'rxjs';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from '../app/app-language.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { AppStateService } from '../app/app-state.service';
import { JsonLoadAllService, JsonLoadListService } from '../json';

@Injectable({
    providedIn: 'root'
})
export class CountryService {
    private sub: Subscription;
    private ParentTVItemID: number;
    private TVItemID: number;
    private TVType: TVTypeEnum;
    private TVTextEN: string;
    private TVTextFR: string;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private jsonLoadListService: JsonLoadListService,
        private jsonLoadAllService: JsonLoadAllService) {
    }

    AddCountry(ParentTVItemID: number, TVType: TVTypeEnum) {
        this.ParentTVItemID = ParentTVItemID;
        this.TVType = TVType;

        this.sub ? this.sub.unsubscribe() : null;

        this.sub = this.DoAddCountry().subscribe();
    }

    DeleteCountry(TVItemID: number, TVType: TVTypeEnum) {
        this.TVItemID = TVItemID;
        this.TVType = TVType;

        this.sub ? this.sub.unsubscribe() : null;

        this.sub = this.DoDeleteCountry().subscribe();
    }

    ModifyTVTextCountry(TVItemID: number, TVType: TVTypeEnum, TVTextEN: string, TVTextFR: string) {
        this.TVItemID = TVItemID;
        this.TVType = TVType;
        this.TVTextEN = TVTextEN;
        this.TVTextFR = TVTextFR;

        this.sub ? this.sub.unsubscribe() : null;

        this.sub = this.DoModifyTVTextCountry().subscribe();
    }

    private DoAddCountry() {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/CountryLocal/${this.ParentTVItemID}`;

        return this.httpClient.post(url, '').pipe(map((x: TVItemModel) => { this.DoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoDeleteCountry() {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/CountryLocal/${this.TVItemID}`;

        return this.httpClient.delete(url).pipe(map((x: TVItemModel) => { this.DoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }

    private DoModifyTVTextCountry() {
        let languageEnum = GetLanguageEnum();

        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/CountryLocal`;

        return this.httpClient.put(url, { TVItemID: this.TVItemID, TVTextEN: this.TVTextEN, TVTextFR: this.TVTextFR })
        .pipe(map((x: TVItemModel) => { this.DoUpdate(x); }), catchError(e => of(e).pipe(map(e => { this.DoError(e); }))));
    }


    private DoUpdate(x: TVItemModel) {

        this.appStateService.Status = '';
        this.appStateService.Working = false;
        this.jsonLoadListService.SetToLoadList(TVTypeEnum.Root, this.appStateService.UserPreference.CurrentRootTVItemID, true);
        this.jsonLoadAllService.LoadAll();
    
        console.debug(x);
    }

    private DoError(e: any) {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        console.debug(e);
    }
}
