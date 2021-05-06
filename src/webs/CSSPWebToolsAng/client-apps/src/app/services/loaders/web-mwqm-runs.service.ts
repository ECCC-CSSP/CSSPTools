import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { WebMWQMRuns } from 'src/app/models/generated/web/WebMWQMRuns.model';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMRunsService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webPolSourceSitesService: WebPolSourceSitesService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebMWQMRuns(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebMWQMRuns().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMRuns()) {
                this.KeepWebMWQMRuns();
            }
            else {
                this.sub = this.GetWebMWQMRuns().subscribe();
            }
        }
    }

    private GetWebMWQMRuns() {
        this.appLoadedService.WebMWQMRuns = <WebMWQMRuns>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebPolSourceSites` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMWQMRuns - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.LangID}-CA/Read/WebMWQMRuns/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMRuns>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMRuns(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebPolSourceSites();
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

    private DoWebPolSourceSites() {
        this.webPolSourceSitesService.DoWebPolSourceSites(this.TVItemID, this.DoNext);
    }

    private KeepWebMWQMRuns() {
        this.UpdateWebMWQMRuns(this.appLoadedService.WebMWQMRuns);
        console.debug(this.appLoadedService.WebMWQMRuns);
        if (this.DoNext) {
            this.DoWebPolSourceSites();
        }
    }

    private UpdateWebMWQMRuns(x: WebMWQMRuns) {
        this.appLoadedService.WebMWQMRuns = x;

        this.historyService.AddHistory(this.appLoadedService.WebMWQMRuns?.TVItemModel);

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMRuns()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}