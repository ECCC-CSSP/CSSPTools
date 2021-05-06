import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllProvinces } from 'src/app/models/generated/web/WebAllProvinces.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllReportTypesService } from 'src/app/services/loaders/web-all-report-types.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllProvincesService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllReportTypesService: WebAllReportTypesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllProvinces(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllProvinces().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllProvinces()) {
                this.KeepWebAllProvinces();
            }
            else {
                this.sub = this.GetWebAllProvinces().subscribe();
            }
        }
    }

    private GetWebAllProvinces() {
        this.appLoadedService.WebAllProvinces = <WebAllProvinces>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllReportTypes` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllProvinces - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllProvinces`;
        return this.httpClient.get<WebAllProvinces>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllProvinces(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllReportTypes();
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

    private DoWebAllReportTypes() {
        this.webAllReportTypesService.DoWebAllReportTypes(this.DoNext);
    }

    private KeepWebAllProvinces() {
        this.UpdateWebAllProvinces(this.appLoadedService.WebAllProvinces);
        console.debug(this.appLoadedService.WebAllProvinces);
        if (this.DoNext) {
            this.DoWebAllReportTypes();
        }
    }

    private UpdateWebAllProvinces(x: WebAllProvinces) {
        this.appLoadedService.WebAllProvinces = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllProvinces()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}