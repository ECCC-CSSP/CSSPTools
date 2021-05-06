import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebClimateSites } from 'src/app/models/generated/web/WebClimateSites.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebHydrometricSitesService } from 'src/app/services/loaders/web-hydrometric-sites.service';


@Injectable({
    providedIn: 'root'
})
export class WebClimateSitesService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webHydrometricSitesService: WebHydrometricSitesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebClimateSites(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebClimateSites().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebClimateSites()) {
                this.KeepWebClimateSites();
            }
            else {
                this.sub = this.GetWebClimateSites().subscribe();
            }
        }
    }

    private GetWebClimateSites() {
        this.appLoadedService.WebClimateSites = <WebClimateSites>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebHydrometricSites` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebClimateSites - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebClimateSites/${this.TVItemID}`;
        return this.httpClient.get<WebClimateSites>(url).pipe(
            map((x: any) => {
                this.UpdateWebClimateSites(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebHydrometricSites();
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

    private DoWebHydrometricSites() {
        this.webHydrometricSitesService.DoWebHydrometricSites(this.TVItemID, this.DoNext);
    }

    private KeepWebClimateSites() {
        this.UpdateWebClimateSites(this.appLoadedService.WebClimateSites);
        console.debug(this.appLoadedService.WebClimateSites);
        if (this.DoNext) {
            this.DoWebHydrometricSites();
        }
    }

    private UpdateWebClimateSites(x: WebClimateSites) {
        this.appLoadedService.WebClimateSites = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebProvince()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebClimateSites()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}