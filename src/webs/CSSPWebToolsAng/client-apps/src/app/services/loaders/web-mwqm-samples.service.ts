import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebTypeYearEnum } from 'src/app/enums/generated/WebTypeYearEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { MWQMSampleLanguage } from 'src/app/models/generated/db/MWQMSampleLanguage.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebMWQMSample } from 'src/app/models/generated/web/WebMWQMSample.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSampleService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    public GetWebMWQMSample(TVItemID: number, WebTypeYear: WebTypeYearEnum, DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        switch (WebTypeYear) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample1980: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample1980To1990[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample1990: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample1990To2000[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2000: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2000To2010[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2010: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2010To2020[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2020: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2020To2030[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2030: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2030To2040[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2040: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2040To2050[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2050: {}, BreadCrumbWebBaseList: [] });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2050To2060[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- GetWebMWQMSample function`);
                }
                break;
        }
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSample/${TVItemID}/${WebTypeYear}`;
        return this.httpClient.get<WebMWQMSample>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSample(x, WebTypeYear);
                console.debug(x);
                if (DoOther) {
                    switch (WebTypeYear) {
                        case WebTypeYearEnum.Year1980:
                            {
                                WebTypeYear = WebTypeYearEnum.Year1990;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year1990:
                            {
                                WebTypeYear = WebTypeYearEnum.Year2000;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year2000:
                            {
                                WebTypeYear = WebTypeYearEnum.Year2010;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year2010:
                            {
                                WebTypeYear = WebTypeYearEnum.Year2020;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year2020:
                            {
                                WebTypeYear = WebTypeYearEnum.Year2030;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year2030:
                            {
                                WebTypeYear = WebTypeYearEnum.Year2040;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year2040:
                            {
                                WebTypeYear = WebTypeYearEnum.Year2050;
                                this.GetNextWebMWQMSample(TVItemID, WebTypeYear);
                            }
                            break;
                        case WebTypeYearEnum.Year2050:
                            {
                                // nothing more to add in the chain
                            }
                            break;
                        default:
                            {
                                alert(`${WebTypeYearEnum[WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- GetWebMWQMSample function`);
                            }
                            break;
                    }
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
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

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: WebMWQMSampleAll, BreadCrumbWebBaseList: TVItemParentList });
    }

    private GetNextWebMWQMSample(TVItemID: number, WebTypeYear: WebTypeYearEnum) {
        this.GetWebMWQMSample(TVItemID, WebTypeYear, this.DoOther).subscribe();
    }

    UpdateWebMWQMSampleAll(x: WebMWQMSample) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: x });
    }

    UpdateWebMWQMSample(x: WebMWQMSample, WebTypeYear: WebTypeYearEnum) {
        switch (WebTypeYear) {
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
                    alert(`${WebTypeYearEnum[WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- UpdateWebMWQMSample function`);
                }
                break;
        }

        if (this.componentDataLoadedService.DataLoadedMWQMSample()) {
            this.FillWebMWQMSampleAll();
        }

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            switch (WebTypeYear) {
                case WebTypeYearEnum.Year1980:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample1980To1990()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year1990:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample1990To2000()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year2000:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample2000To2010()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year2010:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample2010To2020()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year2020:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample2020To2030()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year2030:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample2030To2040()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year2040:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample2040To2050()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                case WebTypeYearEnum.Year2050:
                    {
                        if (this.componentDataLoadedService.DataLoadedMWQMSample2050To2060()) {
                            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
                        }
                    }
                    break;
                default:
                    {
                        alert(`${WebTypeYearEnum[WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- UpdateWebMWQMSample function`);
                    }
                    break;
            }
        }
    }
}