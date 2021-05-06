import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllTels } from 'src/app/models/generated/web/WebAllTels.model';
import { WebAllTideLocationsService } from 'src/app/services/loaders/web-all-tide-locations.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllTelsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllTideLocationsServices: WebAllTideLocationsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllTels(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

            if (ForceReload) {
            this.sub = this.GetWebAllTels().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllTels()) {
                this.KeepWebAllTels();
            }
            else {
                this.sub = this.GetWebAllTels().subscribe();
            }
        }
    }

    private GetWebAllTels() {
        this.appLoadedService.WebAllTels = <WebAllTels>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllAllTideLocations` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllTels - ${NextText} - ${ForceReloadText}`
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllTels`;
        return this.httpClient.get<WebAllTels>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllTels(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllTideLocations();
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

    private DoWebAllTideLocations() {
        this.webAllTideLocationsServices.DoWebAllTideLocations(this.DoNext);
    }

    private KeepWebAllTels() {
        this.UpdateWebAllTels(this.appLoadedService.WebAllTels);
        console.debug(this.appLoadedService.WebAllHelpDocs);
        if (this.DoNext) {
            this.DoWebAllTideLocations();
        }
    }

    private UpdateWebAllTels(x: WebAllTels) {
        this.appLoadedService.WebAllTels = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllTels()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}