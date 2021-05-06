import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSitesService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webMWQMRunsService: WebMWQMRunsService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebMWQMSites(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebMWQMSites().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSites()) {
                this.KeepWebMWQMSites();
            }
            else {
                this.sub = this.GetWebMWQMSites().subscribe();
            }
        }
    }

    private GetWebMWQMSites() {
        this.appLoadedService.WebMWQMSites = <WebMWQMSites>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMWQMRuns` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMWQMSites - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebMWQMSites/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSites(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebMWQMRuns();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.Status = '';
                this.appStateService.Working = true;
                this.appStateService.Error = <HttpErrorResponse>e;
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMRuns() {
        this.webMWQMRunsService.DoWebMWQMRuns(this.TVItemID, this.DoNext);
    }

    private KeepWebMWQMSites() {
        this.UpdateWebMWQMSites(this.appLoadedService.WebMWQMSites);
        console.debug(this.appLoadedService.WebMWQMSites);
        if (this.DoNext) {
            this.DoWebMWQMRuns();
        }
    }

    private UpdateWebMWQMSites(x: WebMWQMSites) {
        this.appLoadedService.WebMWQMSites = x;

        this.historyService.AddHistory(this.appLoadedService.WebMWQMSites?.TVItemModel);

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSites()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}