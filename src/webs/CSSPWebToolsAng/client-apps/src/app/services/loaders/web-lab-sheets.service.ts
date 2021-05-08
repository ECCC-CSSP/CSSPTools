import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebLabSheets } from 'src/app/models/generated/web/WebLabSheets.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebMWQMSamples1980_2020Service } from 'src/app/services/loaders/web-mwqm-samples_1980_2020.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';

@Injectable({
    providedIn: 'root'
})
export class WebLabSheetsService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webMWQMSamples1980_2020Service: WebMWQMSamples1980_2020Service,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebLabSheets(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebLabSheets().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebLabSheets()) {
                this.KeepWebLabSheets();
            }
            else {
                this.sub = this.GetWebLabSheets().subscribe();
            }
        }
    }

    private GetWebLabSheets() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebLabSheets = <WebLabSheets>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMWQMSamples` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebLabSheets - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebLabSheets/${this.TVItemID}`;
        return this.httpClient.get<WebLabSheets>(url).pipe(
            map((x: any) => {
                this.UpdateWebLabSheets(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebMWQMSamples1980_2020();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.Status = ''
                this.appStateService.Working = false
                this.appStateService.Error = <HttpErrorResponse>e;
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMSamples1980_2020() {
        this.webMWQMSamples1980_2020Service.DoWebMWQMSamples1980_2020(this.TVItemID, true);
    }

    private KeepWebLabSheets() {
        this.UpdateWebLabSheets(this.appLoadedService.WebLabSheets);
        console.debug(this.appLoadedService.WebLabSheets);
        if (this.DoNext) {
            this.DoWebMWQMSamples1980_2020();
        }
    }

    private UpdateWebLabSheets(x: WebLabSheets) {
        this.appLoadedService.WebLabSheets = x;

        if (this.componentDataLoadedService.DataLoadedWebLabSheets()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}