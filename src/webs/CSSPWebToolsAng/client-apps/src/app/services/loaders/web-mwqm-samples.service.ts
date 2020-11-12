import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebTypeYearEnum } from 'src/app/enums/generated/WebTypeYearEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMWQMSample } from 'src/app/models/generated/web/WebMWQMSample.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSampleService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService) {
      }
    
    GetWebMWQMSample(TVItemID: number, year: WebTypeYearEnum) {
        let languageEnum = GetLanguageEnum();
        switch (year) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1980: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1990: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2000: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2010: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2020: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2030: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2040: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2050: {}, BreadCrumbWebBaseList: [], Working: true });
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[year]} not implemented yet. See app-loaded.service.ts -- GetWebSample function`);
                }
                break;
        }
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSample/${TVItemID}/${year}`;
        return this.httpClient.get<WebMWQMSample>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSample(x, year);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebMWQMSample(x: WebMWQMSample, year: WebTypeYearEnum) {
        switch (year) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1980: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1990: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2000: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2010: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2020: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2030: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2040: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2050: x, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[year]} not implemented yet. See app-loaded.service.ts -- GetWebSample function`);
                }
                break;
        }
    }
}