import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebAllAddressesService } from 'src/app/services/loaders/web-all-addresses.service';

@Injectable({
    providedIn: 'root'
})
export class WebRootService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webAllAddressesService: WebAllAddressesService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebRoot(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebRoot().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.KeepWebRoot();
            }
            else {
                this.sub = this.GetWebRoot().subscribe();
            }
        }
    }

    private GetWebRoot() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebRoot = <WebRoot>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllAddresses` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebRoot - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.LangID]}-CA/Read/WebRoot`;
        return this.httpClient.get<WebRoot>(url).pipe(
            map((x: any) => {
                this.UpdateWebRoot(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllAddresses();
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

    private DoWebAllAddresses() {
        this.webAllAddressesService.DoWebAllAddresses(this.DoNext, this.ForceReload);
    }

    private KeepWebRoot() {
        this.UpdateWebRoot(this.appLoadedService.WebRoot);
        console.debug(this.appLoadedService.WebRoot);
        if (this.DoNext) {
            this.DoWebAllAddresses();
        }
    }

    private UpdateWebRoot(x: WebRoot) {
        this.appLoadedService.WebRoot = x;

        this.historyService.AddHistory(this.appLoadedService.WebRoot?.TVItemModel);

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }

        if (this.appStateService.GoogleJSLoaded) {
            if (this.appStateService.RootSubComponent == RootSubComponentEnum.Countries) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    ...this.appLoadedService.WebRoot.TVItemModelCountryList,
                    ...[this.appLoadedService.WebRoot.TVItemModel]
                ]);
            }

            if (this.appStateService.RootSubComponent == RootSubComponentEnum.Files) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    ...this.appLoadedService.WebRoot.TVItemModelCountryList,
                    ...[this.appLoadedService.WebRoot.TVItemModel]
                ]);
            }

            if (this.appStateService.RootSubComponent == RootSubComponentEnum.ExportArcGIS) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    ...this.appLoadedService.WebRoot.TVItemModelCountryList,
                    ...[this.appLoadedService.WebRoot.TVItemModel]
                ]);
            }
        }
    }
}