import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';

@Injectable({
    providedIn: 'root'
})
export class WebSubsectorService {
    private TVItemID: number;
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private webMWQMSitesService: WebMWQMSitesService,
        private historyService: HistoryService) {
    }

    DoWebSubsector(TVItemID: number, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebSubsector) {
            this.KeepWebSubsector();
        }
        else {
            this.sub = this.GetWebSubsector().subscribe();
        }
    }

    private GetWebSubsector() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSubsector: {},
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebSubsector }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebSubsector/${this.TVItemID}`;
        return this.httpClient.get<WebSubsector>(url).pipe(
            map((x: any) => {
                this.UpdateWebSubsector(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebMWQMSites();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebMWQMSites() {
        this.webMWQMSitesService.DoWebMWQMSites(this.TVItemID, this.DoOther);
    }

    private KeepWebSubsector() {
        this.UpdateWebSubsector(this.appLoadedService.AppLoaded$?.getValue()?.WebSubsector);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebSubsector);
        if (this.DoOther) {
            this.DoWebMWQMSites();
        }
    }

    private UpdateWebSubsector(x: WebSubsector) {

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSubsector: x,
        });

        this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebSubsector?.TVItemModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }

        if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.MWQMRuns) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebMWQMRuns.MWQMRunModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebPolSourceSites.PolSourceSiteModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.Files) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.SubsectorTools) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }

            if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.LogBook) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.AppLoaded$.getValue().WebMWQMSites.MWQMSiteModelList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebSubsector.TVItemModel],
                ]);
            }
        }
    }
}