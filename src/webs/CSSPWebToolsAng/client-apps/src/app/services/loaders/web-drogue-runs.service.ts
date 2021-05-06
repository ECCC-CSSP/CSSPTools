import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebDrogueRuns } from 'src/app/models/generated/web/WebDrogueRuns.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebLabSheetsService } from './web-lab-sheets.service';

@Injectable({
    providedIn: 'root'
})
export class WebDrogueRunsService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webLabSheetsService: WebLabSheetsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebDrogueRuns(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebDrogueRuns().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebDrogueRuns()) {
                this.KeepWebDrogueRuns();
            }
            else {
                this.sub = this.GetWebDrogueRuns().subscribe();
            }
        }
    }

    private GetWebDrogueRuns() {
        this.appLoadedService.WebDrogueRuns = <WebDrogueRuns>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebLabSheets` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebDrogueRuns - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebDrogueRuns/${this.TVItemID}`;
        return this.httpClient.get<WebDrogueRuns>(url).pipe(
            map((x: any) => {
                this.UpdateWebDrogueRuns(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebLabSheets();
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

    private DoWebLabSheets() {
        this.webLabSheetsService.DoWebLabSheets(this.TVItemID, true);
    }

    private KeepWebDrogueRuns() {
        this.UpdateWebDrogueRuns(this.appLoadedService.WebDrogueRuns);
        console.debug(this.appLoadedService.WebDrogueRuns);
        if (this.DoNext) {
            this.DoWebLabSheets();
        }
    }

    private UpdateWebDrogueRuns(x: WebDrogueRuns) {
        this.appLoadedService.WebDrogueRuns = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebDrogueRuns()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}