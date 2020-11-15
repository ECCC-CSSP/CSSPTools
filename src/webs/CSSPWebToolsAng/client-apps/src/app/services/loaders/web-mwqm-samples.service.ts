import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebTypeYearEnum } from 'src/app/enums/generated/WebTypeYearEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { MWQMSampleLanguage } from 'src/app/models/generated/db/MWQMSampleLanguage.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebMWQMSample } from 'src/app/models/generated/web/WebMWQMSample.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSampleService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    public GetWebMWQMSample(TVItemID: number, year: WebTypeYearEnum) {
        let languageEnum = GetLanguageEnum();
        switch (year) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample1980: {}, BreadCrumbWebBaseList: [], 
                        Status: 'Loading Web Sample 1980-1990', Working: true });
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample1990: {}, BreadCrumbWebBaseList: [], 
                        Status: 'Loading Web Sample 1990-2000', Working: true });
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2000: {}, BreadCrumbWebBaseList: [],
                        Status: 'Loading Web Sample 2000-2010', Working: true });
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2010: {}, BreadCrumbWebBaseList: [],
                        Status: 'Loading Web Sample 2010-2020', Working: true });
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2020: {}, BreadCrumbWebBaseList: [],
                        Status: 'Loading Web Sample 2020-2030', Working: true });

                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2030: {}, BreadCrumbWebBaseList: [],
                    Status: 'Loading Web Sample 2030-2040', Working: true });
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2040: {}, BreadCrumbWebBaseList: [],
                    Status: 'Loading Web Sample 2040-2050', Working: true });
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2050: {}, BreadCrumbWebBaseList: [],
                    Status: 'Loading Web Sample 2050-2060', Working: true });
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[year]} not implemented yet. See web-mwqm-samples.service.ts -- GetWebMWQMSample function`);
                }
                break;
        }
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSample/${TVItemID}/${year}`;
        return this.httpClient.get<WebMWQMSample>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSample(x, year);
                console.debug(x);
                switch (year) {
                    case WebTypeYearEnum.Year1980:
                        {
                            year = WebTypeYearEnum.Year1990;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year1990:
                        {
                            year = WebTypeYearEnum.Year2000;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year2000:
                        {
                            year = WebTypeYearEnum.Year2010;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year2010:
                        {
                            year = WebTypeYearEnum.Year2020;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year2020:
                        {
                            year = WebTypeYearEnum.Year2030;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year2030:
                        {
                            year = WebTypeYearEnum.Year2040;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year2040:
                        {
                            year = WebTypeYearEnum.Year2050;
                            this.GetNextWebMWQMSamples(TVItemID, year);
                        }
                        break;
                    case WebTypeYearEnum.Year2050:
                        {
                        }
                        break;
                    default:
                        {
                            alert(`${WebTypeYearEnum[year]} not implemented yet. See web-mwqm-samples.service.ts -- GetWebMWQMSample function`);
                        }
                        break;
                }

            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Status: '', Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    FillWebMWQMSampleAll(): void {
        let WebMWQMSampleAll: WebMWQMSample;
        let MWQMSampleLanguageList: MWQMSampleLanguage[] = [];
        let MWQMSampleList: MWQMSample[] = [];
        let TVItemParentList: WebBase[] = [];


        MWQMSampleLanguageList = MWQMSampleLanguageList.concat(
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050.MWQMSampleLanguageList);

        MWQMSampleList = MWQMSampleList.concat(
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050.MWQMSampleList);

        TVItemParentList = TVItemParentList.concat(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980.TVItemParentList);

        WebMWQMSampleAll = <WebMWQMSample>{
            MWQMSampleLanguageList: MWQMSampleLanguageList,
            MWQMSampleList: MWQMSampleList,
            TVItemParentList: TVItemParentList
        };

        console.debug(WebMWQMSampleAll);

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: WebMWQMSampleAll, BreadCrumbWebBaseList: TVItemParentList, Status: '', Working: false });
    }

    private GetNextWebMWQMSamples(TVItemID: number, WebTypeYear: WebTypeYearEnum) {
        this.GetWebMWQMSample(TVItemID, WebTypeYear).subscribe();
    }

    UpdateWebMWQMSampleAll(x: WebMWQMSample) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: x });
    }

    UpdateWebMWQMSample(x: WebMWQMSample, year: WebTypeYearEnum) {
        switch (year) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1980: x, BreadCrumbWebBaseList: x?.TVItemParentList });
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1990: x });
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2000: x });
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2010: x });
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2020: x });
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2030: x });
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2040: x });
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample2050: x });
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[year]} not implemented yet. See web-mwqm-samples.service.ts -- UpdateWebMWQMSample function`);
                }
                break;
        }

        if (this.componentDataLoadedService.DataLoadedSubsector()) {
            this.FillWebMWQMSampleAll(); // does set Working: false
        }

    }
}