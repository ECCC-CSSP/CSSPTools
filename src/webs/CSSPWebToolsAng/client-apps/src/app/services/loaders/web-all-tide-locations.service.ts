import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllTideLocations } from 'src/app/models/generated/web/WebAllTideLocations.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllTideLocationsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllTideLocations(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllTideLocations().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllTideLocations()) {
                this.KeepWebAllTideLocations();
            }
            else {
                this.sub = this.GetWebAllTideLocations().subscribe();
            }
        }
    }

    private GetWebAllTideLocations() {
        this.appLoadedService.WebAllTideLocations = <WebAllTideLocations>{};

        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllTideLocations - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllTideLocations`;
        return this.httpClient.get<WebAllTideLocations>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllTideLocations(x);
                console.debug(x);
                if (this.DoNext) {
                    // nothing more to add in the chain
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

    private KeepWebAllTideLocations() {
        this.UpdateWebAllTideLocations(this.appLoadedService.WebAllTideLocations);
        console.debug(this.appLoadedService.WebAllTideLocations);
        if (this.DoNext) {
            // nothing more to add in the chain
        }
    }

    private UpdateWebAllTideLocations(x: WebAllTideLocations) {
        this.appLoadedService.WebAllTideLocations = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllTideLocations()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}