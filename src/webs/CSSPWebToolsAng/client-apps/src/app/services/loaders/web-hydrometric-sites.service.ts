import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebHydrometricSites } from 'src/app/models/generated/web/WebHydrometricSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebDrogueRunsService } from './web-drogue-runs.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';


@Injectable({
    providedIn: 'root'
})
export class WebHydrometricSitesService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webDrogueRunsService: WebDrogueRunsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebHydrometricSites(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebHydrometricSites().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebHydrometricSites()) {
                this.KeepWebHydrometricSites();
            }
            else {
                this.sub = this.GetWebHydrometricSites().subscribe();
            }
        }
    }

    private GetWebHydrometricSites() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebHydrometricSites = <WebHydrometricSites>{};

        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebHydrometricSites - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebHydrometricSites/${this.TVItemID}`;
        return this.httpClient.get<WebHydrometricSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebHydrometricSites(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebDrogueRuns();
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

    private DoWebDrogueRuns() {
        this.webDrogueRunsService.DoWebDrogueRuns(this.TVItemID, this.DoNext);
    }

    private KeepWebHydrometricSites() {
        this.UpdateWebHydrometricSites(this.appLoadedService.WebHydrometricSites);
        console.debug(this.appLoadedService.WebHydrometricSites);
        if (this.DoNext) {
            this.DoWebDrogueRuns();
        }
    }

    private UpdateWebHydrometricSites(x: WebHydrometricSites) {
        this.appLoadedService.WebHydrometricSites = x;

        if (this.componentDataLoadedService.DataLoadedWebHydrometricSites()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}