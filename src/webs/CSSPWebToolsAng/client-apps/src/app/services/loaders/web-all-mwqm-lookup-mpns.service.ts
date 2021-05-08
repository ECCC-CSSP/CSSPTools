import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebAllMWQMLookupMPNs } from 'src/app/models/generated/web/WebAllMWQMLookupMPNs.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { MapService } from '../map/map.service';
import { WebAllPolSourceGroupingsService } from './web-all-pol-source-groupings.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllMWQMLookupMPNsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webAllPolSourceGroupingsService: WebAllPolSourceGroupingsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllMWQMLookupMPNs(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllMWQMLookupMPNs().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllMWQMLookupMPNs()) {
                this.KeepWebAllMWQMLookupMPNs();
            }
            else {
                this.sub = this.GetWebAllMWQMLookupMPNs().subscribe();
            }
        }
    }

    private GetWebAllMWQMLookupMPNs() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebAllMWQMLookupMPNs = <WebAllMWQMLookupMPNs>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllPolSourceGroupings` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllMWQMLookupMPNs - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebAllMWQMLookupMPNs`;
        return this.httpClient.get<WebAllMWQMLookupMPNs>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllMWQMLookupMPNs(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllPolSourceGroupings();
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

    DoWebAllPolSourceGroupings() {
        this.webAllPolSourceGroupingsService.DoWebAllPolSourceGroupings(this.DoNext);
    }

    private KeepWebAllMWQMLookupMPNs() {
        this.UpdateWebAllMWQMLookupMPNs(this.appLoadedService.WebAllMWQMLookupMPNs);
        console.debug(this.appLoadedService.WebAllMWQMLookupMPNs);
        if (this.DoNext) {
            this.DoWebAllPolSourceGroupings();
        }
    }

    private UpdateWebAllMWQMLookupMPNs(x: WebAllMWQMLookupMPNs) {
        this.appLoadedService.WebAllMWQMLookupMPNs = x;

        if (this.componentDataLoadedService.DataLoadedWebAllMWQMLookupMPNs()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}