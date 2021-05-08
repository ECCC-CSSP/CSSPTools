import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebPolSourceSites } from 'src/app/models/generated/web/WebPolSourceSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebLabSheetsService } from './web-lab-sheets.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';

@Injectable({
    providedIn: 'root'
})
export class WebPolSourceSitesService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webLabSheetsService: WebLabSheetsService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebPolSourceSites(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebPolSourceSites().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebPolSourceSites()) {
                this.KeepWebPolSourceSites();
            }
            else {
                this.sub = this.GetWebPolSourceSites().subscribe();
            }
        }
    }

    private GetWebPolSourceSites() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebPolSourceSites = <WebPolSourceSites>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebDrogueRuns` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebPolSourceSites - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebPolSourceSites/${this.TVItemID}`;
        return this.httpClient.get<WebPolSourceSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebPolSourceSites(x);
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
        this.webLabSheetsService.DoWebLabSheets(this.TVItemID, this.DoNext);
    }

    private KeepWebPolSourceSites() {
        this.UpdateWebPolSourceSites(this.appLoadedService.WebPolSourceSites);
        console.debug(this.appLoadedService.WebPolSourceSites);
        if (this.DoNext) {
            this.DoWebLabSheets();
        }
    }

    private UpdateWebPolSourceSites(x: WebPolSourceSites) {
        this.appLoadedService.WebPolSourceSites = x;

        this.historyService.AddHistory(this.appLoadedService.WebPolSourceSites?.TVItemModel);

        if (this.componentDataLoadedService.DataLoadedWebPolSourceSites()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}