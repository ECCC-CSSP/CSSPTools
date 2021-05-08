import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebMWQMSamples2021_2060Service } from './web-mwqm-samples_2021_2060.service';
import { MapService } from '../map/map.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSamples1980_2020Service {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webMWQMSamples2021_2060Service: WebMWQMSamples2021_2060Service,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMWQMSamples1980_2020(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebMWQMSamples1980_2020().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSamples1980_2020()) {
                this.KeepWebMWQMSamples1980_2020();
            }
            else {
                this.sub = this.GetWebMWQMSamples1980_2020().subscribe();
            }
        }
    }

    private GetWebMWQMSamples1980_2020() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebMWQMSamples1980_2020 = <WebMWQMSamples>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMWQMSamples2021_2060` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMWQMSamples1980_2020 - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebMWQMSamples1980_2020/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSamples>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSamples1980_2020(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebMWQMSamples2021_2060();
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

    private DoWebMWQMSamples2021_2060() {
        this.webMWQMSamples2021_2060Service.DoWebMWQMSamples2021_2060(this.TVItemID, true);
    }

    private KeepWebMWQMSamples1980_2020() {
        this.UpdateWebMWQMSamples1980_2020(this.appLoadedService.WebMWQMSamples1980_2020);
        console.debug(this.appLoadedService.WebMWQMSamples1980_2020);
        if (this.DoNext) {
            this.DoWebMWQMSamples2021_2060();
        }
    }

    private UpdateWebMWQMSamples1980_2020(x: WebMWQMSamples) {
        this.appLoadedService.WebMWQMSamples1980_2020 = x;
        this.appLoadedService.WebMWQMSamples = x;
 
        if (this.componentDataLoadedService.DataLoadedWebMWQMSamples1980_2020()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}