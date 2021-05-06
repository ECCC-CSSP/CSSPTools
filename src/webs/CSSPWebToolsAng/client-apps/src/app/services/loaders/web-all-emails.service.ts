import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllHelpDocsService } from 'src/app/services/loaders/web-all-help-docs.service';
import { WebAllEmails } from 'src/app/models/generated/web/WebAllEmails.model';

@Injectable({
    providedIn: 'root'
})
export class WebAllEmailsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllHelpDocsServices: WebAllHelpDocsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllEmails(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllEmails().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllEmails()) {
                this.KeepWebAllEmails();
            }
            else {
                this.sub = this.GetWebAllEmails().subscribe();
            }
        }
    }

    private GetWebAllEmails() {
        this.appLoadedService.WebAllEmails = <WebAllEmails>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllHelpDocs` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllEmails - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllEmails`;
        return this.httpClient.get<WebAllEmails>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllEmails(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllHelpDocs();
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

    private DoWebAllHelpDocs() {
        this.webAllHelpDocsServices.DoWebAllHelpDocs(this.DoNext);
    }

    private KeepWebAllEmails() {
        this.UpdateWebAllEmails(this.appLoadedService.WebAllEmails);
        console.debug(this.appLoadedService.WebAllHelpDocs);
        if (this.DoNext) {
            this.DoWebAllHelpDocs();
        }
    }

    private UpdateWebAllEmails(x: WebAllEmails) {
        this.appLoadedService.WebAllEmails = x;

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllEmails()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
    }
}