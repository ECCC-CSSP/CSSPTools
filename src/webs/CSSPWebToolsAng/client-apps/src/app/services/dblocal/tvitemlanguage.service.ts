import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { TVItemLanguage } from 'src/app/models/generated/db/TVItemLanguage.model';


@Injectable({
    providedIn: 'root'
})
export class TVItemLanguageService {
    private TVText: string;
    private TVItemModel: TVItemModel;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService) {
    }

    Modify(TVText: string, TVItemModel: TVItemModel) {
        this.TVText = TVText;
        this.TVItemModel = TVItemModel;

        this.sub ? this.sub.unsubscribe() : null;

        this.sub = this.DoModify().subscribe();
    }

    private DoModify() {
        let languageEnum = GetLanguageEnum();
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.Saving[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });

        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        
        let tvItemLanguage: TVItemLanguage = JSON.parse(JSON.stringify(this.TVItemModel.TVItemLanguageList[this.appStateService.AppState$?.getValue()?.Language]));

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/TVItem/`;
        return this.httpClient.put<TVItemLanguage>(url, tvItemLanguage, httpOptions).pipe(
            map((x: any) => {
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }
}