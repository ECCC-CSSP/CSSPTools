import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebLabSheets } from 'src/app/models/generated/web/WebLabSheets.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebMWQMSamplesService } from 'src/app/services/loaders/web-mwqm-samples.service';

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
        private webMWQMSamplesService: WebMWQMSamplesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebLabSheets(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

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
        this.appLoadedService.WebLabSheets = <WebLabSheets>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMWQMSamples` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebLabSheets - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebLabSheets/${this.TVItemID}`;
        return this.httpClient.get<WebLabSheets>(url).pipe(
            map((x: any) => {
                this.UpdateWebLabSheets(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebMWQMSamples();
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

    private DoWebMWQMSamples() {
        this.webMWQMSamplesService.DoWebMWQMSamples(this.TVItemID, true);
    }

    private KeepWebLabSheets() {
        this.UpdateWebLabSheets(this.appLoadedService.WebLabSheets);
        console.debug(this.appLoadedService.WebLabSheets);
        if (this.DoNext) {
            this.DoWebMWQMSamples();
        }
    }

    private UpdateWebLabSheets(x: WebLabSheets) {
        this.appLoadedService.WebLabSheets = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebLabSheets()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}