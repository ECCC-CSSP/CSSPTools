import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllPolSourceGroupings } from 'src/app/models/generated/web/WebAllPolSourceGroupings.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllPolSourceSiteEffectTermsService } from 'src/app/services/loaders/web-all-pol-source-site-effect-terms.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllPolSourceGroupingsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllPolSourceSiteEffectTermsService: WebAllPolSourceSiteEffectTermsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllPolSourceGroupings(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllPolSourceGroupings().subscribe();
        }
        else{
            if (this.componentDataLoadedService.DataLoadedWebAllPolSourceGroupings()) {
                this.KeepWebAllPolSourceGroupings();
            }
            else {
                this.sub = this.GetWebAllPolSourceGroupings().subscribe();
            }
            }
    }

    private GetWebAllPolSourceGroupings() {
        this.appLoadedService.WebAllPolSourceGroupings = <WebAllPolSourceGroupings>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllPolSourceSiteEffectTerms` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllPolSourceGroupings - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllPolSourceGroupings`;
        return this.httpClient.get<WebAllPolSourceGroupings>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllPolSourceGroupings(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllPolSourceSiteEffectTerms();
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

    private DoWebAllPolSourceSiteEffectTerms() {
        this.webAllPolSourceSiteEffectTermsService.DoWebAllPolSourceSiteEffectTerms(this.DoNext);
    }

    private KeepWebAllPolSourceGroupings() {
        this.UpdateWebAllPolSourceGroupings(this.appLoadedService.WebAllPolSourceGroupings);
        console.debug(this.appLoadedService.WebAllPolSourceGroupings);
        if (this.DoNext) {
            this.DoWebAllPolSourceSiteEffectTerms();
        }
    }

    private UpdateWebAllPolSourceGroupings(x: WebAllPolSourceGroupings) {
        this.appLoadedService.WebAllPolSourceGroupings = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllPolSourceGroupings()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}