import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllReportTypes } from 'src/app/models/generated/web/WebAllReportTypes.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllTelsService } from 'src/app/services/loaders/web-all-tels.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllReportTypesService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webAllTelsService: WebAllTelsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllReportTypes(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllReportTypes().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllReportTypes()) {
                this.KeepWebAllReportTypes();
            }
            else {
                this.sub = this.GetWebAllReportTypes().subscribe();
            }
        }
    }

    private GetWebAllReportTypes() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebAllReportTypes = <WebAllReportTypes>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllAllTels` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllReportTypes - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebAllReportTypes`;
        return this.httpClient.get<WebAllReportTypes>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllReportTypes(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllTels();
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

    private DoWebAllTels() {
        this.webAllTelsService.DoWebAllTels(this.DoNext);
    }

    private KeepWebAllReportTypes() {
        this.UpdateWebAllReportTypes(this.appLoadedService.WebAllReportTypes);
        console.debug(this.appLoadedService.WebAllReportTypes);
        if (this.DoNext) {
            this.DoWebAllTels();
        }
    }

    private UpdateWebAllReportTypes(x: WebAllReportTypes) {
        this.appLoadedService.WebAllReportTypes = x;

        if (this.componentDataLoadedService.DataLoadedWebAllReportTypes()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}