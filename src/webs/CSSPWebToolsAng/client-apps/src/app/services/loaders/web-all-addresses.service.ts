import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { WebAllContactsService } from 'src/app/services/loaders/web-all-contacts.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';


@Injectable({
    providedIn: 'root'
})
export class WebAllAddressesService {
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private mapService: MapService,
        private webAllContactsService: WebAllContactsService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebAllAddresses(DoNext: boolean = true, ForceReload: boolean = true) {
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;
        this.mapService.ClearMap();

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebAllAddresses().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebAllAddresses()) {
                this.KeepWebAllAddresses();
            }
            else {
                this.sub = this.GetWebAllAddresses().subscribe();
            }
        }
    }

    private GetWebAllAddresses() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.WebAllAddresses = <WebAllAddresses>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebAllContacts` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllAddresses - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebAllAddresses`;
        return this.httpClient.get<WebAllAddresses>(url).pipe(
            map((x: WebAllAddresses) => {
                this.UpdateWebAllAddresses(x);
                console.debug(x);
                if (this.DoNext) {
                    this.DoWebAllContacts();
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

    private DoWebAllContacts() {
        this.webAllContactsService.DoWebAllContacts(this.DoNext);
    }

    private KeepWebAllAddresses() {
        this.UpdateWebAllAddresses(this.appLoadedService.WebAllAddresses);
        console.debug(this.appLoadedService.WebAllAddresses);
        if (this.DoNext) {
            this.DoWebAllContacts();
        }
    }

    private UpdateWebAllAddresses(x: WebAllAddresses) {
        this.appLoadedService.WebAllAddresses = x;

        if (this.componentDataLoadedService.DataLoadedWebAllAddresses()) {
            this.appStateService.Status = '';
            this.appStateService.Working = false;
        }
    }
}