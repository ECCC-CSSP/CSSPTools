import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllMunicipalities } from 'src/app/models/generated/web/WebAllMunicipalities.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllMWQMLookupMPNsService } from 'src/app/services/loaders/web-all-mwqm-lookup-mpns.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllMunicipalitiesService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllMWQMLookupMPNsService: WebAllMWQMLookupMPNsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllMunicipalities(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllMunicipalities().subscribe();
        }
        else
        {
            if (this.componentDataLoadedService.DataLoadedWebAllMunicipalities()) {
                this.KeepWebAllMunicipalities();
            }
            else {
                this.sub = this.GetWebAllMunicipalities().subscribe();
            }
            }
    }

    private GetWebAllMunicipalities() {
        this.appLoadedService.WebAllMunicipalities = <WebAllMunicipalities>{};
        
        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllMWQMLookupMPNs` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllMunicipalities - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllMunicipalities`;
        return this.httpClient.get<WebAllMunicipalities>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllMunicipalities(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllMWQMLookupMPNs();
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

    private DoWebAllMWQMLookupMPNs() {
        this.webAllMWQMLookupMPNsService.DoWebAllMWQMLookupMPNs(this.DoNext);
    }

    private KeepWebAllMunicipalities() {
        this.UpdateWebAllMunicipalities(this.appLoadedService.WebAllMunicipalities);
        console.debug(this.appLoadedService.WebAllMunicipalities);
        if (this.DoNext) {
            this.DoWebAllMWQMLookupMPNs();
        }
    }

    private UpdateWebAllMunicipalities(x: WebAllMunicipalities) {
        this.appLoadedService.WebAllMunicipalities = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllMunicipalities()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}