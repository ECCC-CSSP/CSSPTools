import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebMikeScenarios } from 'src/app/models/generated/web/WebMikeScenarios.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';

@Injectable({
    providedIn: 'root'
})
export class WebMikeScenariosService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private mapService: MapService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMikeScenarios(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebMikeScenarios().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMikeScenarios()) {
                this.KeepWebMikeScenarios();
            }
            else {
                this.sub = this.GetWebMikeScenarios().subscribe();
            }
        }
    }

    private GetWebMikeScenarios() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebMikeScenarios = <WebMikeScenarios>{};

        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMikeScenarios - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebMikeScenarios/${this.TVItemID}`;
        return this.httpClient.get<WebMikeScenarios>(url).pipe(
            map((x: any) => {
                this.UpdateWebMikeScenarios(x);
                console.debug(x);
                if (this.DoNext) {
                    // nothing else to add in the chain
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

    private KeepWebMikeScenarios() {
        this.UpdateWebMikeScenarios(this.appLoadedService.WebMikeScenarios);
        console.debug(this.appLoadedService.WebMikeScenarios);
        if (this.DoNext) {
            // nothing else to add in the chain
        }
    }

    private UpdateWebMikeScenarios(x: WebMikeScenarios) {
        this.appLoadedService.WebMikeScenarios = x
        this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;

        if (this.componentDataLoadedService.DataLoadedWebMikeScenarios()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}