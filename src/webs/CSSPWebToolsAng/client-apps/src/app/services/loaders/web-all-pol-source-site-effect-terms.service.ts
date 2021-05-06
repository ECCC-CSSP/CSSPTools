import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllPolSourceSiteEffectTerms } from 'src/app/models/generated/web/WebAllPolSourceSiteEffectTerms.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllProvincesService } from 'src/app/services/loaders/web-all-provinces.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllPolSourceSiteEffectTermsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllProvincesService: WebAllProvincesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllPolSourceSiteEffectTerms(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllPolSourceSiteEffectTerms().subscribe();
        }
        else{
            if (this.componentDataLoadedService.DataLoadedWebAllPolSourceSiteEffectTerms()) {
                this.KeepWebAllPolSourceSiteEffectTerms();
            }
            else {
                this.sub = this.GetWebAllPolSourceSiteEffectTerms().subscribe();
            }
            }
    }

    private GetWebAllPolSourceSiteEffectTerms() {
        this.appLoadedService.WebAllPolSourceSiteEffectTerms = <WebAllPolSourceSiteEffectTerms>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllProvinces` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllPolSourceSiteEffectTerms - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllPolSourceSiteEffectTerms`;
        return this.httpClient.get<WebAllPolSourceSiteEffectTerms>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllPolSourceSiteEffectTerms(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllProvinces();
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

    private DoWebAllProvinces() {
        this.webAllProvincesService.DoWebAllProvinces(this.DoNext);
    }

    private KeepWebAllPolSourceSiteEffectTerms() {
        this.UpdateWebAllPolSourceSiteEffectTerms(this.appLoadedService.WebAllPolSourceSiteEffectTerms);
        console.debug(this.appLoadedService.WebAllPolSourceSiteEffectTerms);
        if (this.DoNext) {
            this.DoWebAllProvinces();
        }
    }

    private UpdateWebAllPolSourceSiteEffectTerms(x: WebAllPolSourceSiteEffectTerms) {
        this.appLoadedService.WebAllPolSourceSiteEffectTerms = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllPolSourceSiteEffectTerms()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}