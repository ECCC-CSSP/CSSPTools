import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllCountries } from 'src/app/models/generated/web/WebAllCountries.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllEmailsService } from 'src/app/services/loaders/web-all-emails.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';

@Injectable({
    providedIn: 'root'
})
export class WebAllCountriesService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webAllEmailsService: WebAllEmailsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllCountries(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllCountries().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllCountries()) {
                this.KeepWebAllCountries();
            }
            else {
                this.sub = this.GetWebAllCountries().subscribe();
            }
        }
    }

    private GetWebAllCountries() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebAllCountries = <WebAllCountries>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllEmails` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllCountries - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebAllCountries`;
        return this.httpClient.get<WebAllCountries>(url).pipe(
            map((x: any) => {
                this.UpdateWebAllCountries(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllEmails();
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

    private DoWebAllEmails() {
        this.webAllEmailsService.DoWebAllEmails(this.DoNext);
    }

    private KeepWebAllCountries() {
        this.UpdateWebAllCountries(this.appLoadedService.WebAllCountries);
        console.debug(this.appLoadedService.WebAllCountries);
        if (this.DoNext) {
            this.DoWebAllEmails();
        }
    }

    private UpdateWebAllCountries(x: WebAllCountries) {
        this.appLoadedService.WebAllCountries = x;

        if (this.componentDataLoadedService.DataLoadedWebAllCountries()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}