import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';

@Injectable({
    providedIn: 'root'
})
export class WebSubsectorService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private webMWQMSitesService: WebMWQMSitesService,
        private historyService: HistoryService) {
    }

    DoWebSubsector(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebSubsector().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.KeepWebSubsector();
            }
            else {
                this.sub = this.GetWebSubsector().subscribe();
            }
        }
    }

    private GetWebSubsector() {
        this.appLoadedService.WebSubsector = <WebSubsector>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMWQMSites` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebSubsector - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebSubsector/${this.TVItemID}`;
        return this.httpClient.get<WebSubsector>(url).pipe(
            map((x: any) => {
                this.UpdateWebSubsector(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebMWQMSites();
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

    private DoWebMWQMSites() {
        this.webMWQMSitesService.DoWebMWQMSites(this.TVItemID, this.DoNext);
    }

    private KeepWebSubsector() {
        this.UpdateWebSubsector(this.appLoadedService.WebSubsector);
        console.debug(this.appLoadedService.WebSubsector);
        if (this.DoNext) {
            this.DoWebMWQMSites();
        }
    }

    private UpdateWebSubsector(x: WebSubsector) {

        this.appLoadedService.WebSubsector = x;

        this.historyService.AddHistory(this.appLoadedService.WebSubsector?.TVItemModel);

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }

        if (this.appStateService.GoogleJSLoaded) {
            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMRuns) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMRuns.MWQMRunModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.Files) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.SubsectorTools) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.LogBook) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.WebSubsector.TVItemModel],
                ]);
            }
        }
    }
}