import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllContacts } from 'src/app/models/generated/web/WebAllContacts.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllCountriesService } from 'src/app/services/loaders/web-all-countries.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllContactsService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private webAllCountriesService: WebAllCountriesService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllContacts(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllContacts().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllContacts()) {
                this.KeepWebAllContacts();
            }
            else {
                this.sub = this.GetWebAllContacts().subscribe();
            }
        }
    }

    private GetWebAllContacts() {
        this.appLoadedService.WebAllContacts = <WebAllContacts>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllCountries` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllContacts - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebAllContacts`;
        return this.httpClient.get<WebAllContacts>(url).pipe(
            map((x: WebAllContacts) => {
                this.UpdateWebAllContacts(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllCountries();
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

    private DoWebAllCountries() {
        this.webAllCountriesService.DoWebAllCountries(this.DoNext);
    }

    private KeepWebAllContacts() {
        this.UpdateWebAllContacts(this.appLoadedService.WebAllContacts);
        console.debug(this.appLoadedService.WebAllContacts);
        console.debug(this.appLoadedService.AdminContactModel);
        if (this.DoNext) {
            this.DoWebAllCountries();
        }
    }

    private UpdateWebAllContacts(x: WebAllContacts) {
        this.appLoadedService.WebAllContacts = x;

        this.appLoadedService.AdminContactModel = this.appLoadedService.WebAllContacts.ContactModelList.filter((c) => c.Contact != null && c.Contact.IsAdmin == true);

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllContacts()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }

        }
    }
}