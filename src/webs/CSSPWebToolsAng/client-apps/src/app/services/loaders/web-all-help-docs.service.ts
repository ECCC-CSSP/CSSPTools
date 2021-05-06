import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllHelpDocs } from 'src/app/models/generated/web/WebAllHelpDocs.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllMunicipalitiesService } from 'src/app/services/loaders/web-all-municipalities.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllHelpDocsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllMunicipalitiesServices: WebAllMunicipalitiesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllHelpDocs(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllHelpDocs().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllEmails()) {
                this.KeepWebAllHelpDocs();
            }
            else {
                this.sub = this.GetWebAllHelpDocs().subscribe();
            }
        }
    }

    private GetWebAllHelpDocs() {
        this.appLoadedService.WebAllHelpDocs = <WebAllHelpDocs>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllMunicipalities` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllHelpDocs - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllHelpDocs`;
        return this.httpClient.get<WebAllHelpDocs>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllHelpDocs(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllMunicipalities();
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

    private DoWebAllMunicipalities() {
        this.webAllMunicipalitiesServices.DoWebAllMunicipalities(this.DoNext);
    }

    private KeepWebAllHelpDocs() {
        this.UpdateWebAllHelpDocs(this.appLoadedService.WebAllHelpDocs);
        console.debug(this.appLoadedService.WebAllHelpDocs);
        if (this.DoNext) {
            this.DoWebAllMunicipalities();
        }
    }

    private UpdateWebAllHelpDocs(x: WebAllHelpDocs) {
        this.appLoadedService.WebAllHelpDocs = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllHelpDocs()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}