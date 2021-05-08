import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { MapService } from 'src/app/services/map/map.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { WebMikeScenariosService } from './web-mike-scenarios.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

@Injectable({
    providedIn: 'root'
})
export class WebMunicipalityService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webMikeScenariosService: WebMikeScenariosService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMunicipality(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebMunicipality().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMunicipality()) {
                this.KeepWebMunicipality();
            }
            else {
                this.sub = this.GetWebMunicipality().subscribe();
            }
        }
    }

    private GetWebMunicipality() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebMunicipality = <WebMunicipality>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMikeScenarios` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMunicipality - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebMunicipality/${this.TVItemID}`;
        return this.httpClient.get<WebMunicipality>(url).pipe(
            map((x: any) => {
                this.UpdateWebMunicipality(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebMikeScenarios();
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

    private DoWebMikeScenarios() {
        this.webMikeScenariosService.DoWebMikeScenarios(this.TVItemID, true);
    }

    private KeepWebMunicipality() {
        this.UpdateWebMunicipality(this.appLoadedService.WebMunicipality);
        console.debug(this.appLoadedService.WebMunicipality);
        if (this.DoNext) {
            this.DoWebMikeScenarios();
        }
    }

    private UpdateWebMunicipality(x: WebMunicipality) {
        this.appLoadedService.WebMunicipality = x;
        this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;

        if (this.componentDataLoadedService.DataLoadedWebMunicipality()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }

        if (this.appStateService.GoogleJSLoaded) {
            if (this.appStateService.MunicipalitySubComponent == MunicipalitySubComponentEnum.Infrastructures) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.WebMunicipality.TVItemModel]
                ]);
            }

            if (this.appStateService.MunicipalitySubComponent == MunicipalitySubComponentEnum.Contacts) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.WebMunicipality.TVItemModel]
                ]);
            }

            if (this.appStateService.MunicipalitySubComponent == MunicipalitySubComponentEnum.MIKEScenarios) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.WebMunicipality.TVItemModel]
                ]);
            }

            if (this.appStateService.MunicipalitySubComponent == MunicipalitySubComponentEnum.Files) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    // ...this.appLoadedService.WebMunicipality.InfrastructureModelList,
                    // ...[this.appLoadedService.WebMunicipality.TVItemModel]
                ]);
            }
        }
    }
}