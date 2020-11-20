import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
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
    private TVItemID: number;
    private DoOther: boolean;
    private WebTypeYear: WebTypeYearEnum;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    DoWebMWQMSample(TVItemID: number, WebTypeYear: WebTypeYearEnum, DoOther: boolean) {
        this.TVItemID = TVItemID;
        this.DoOther = DoOther;
        this.WebTypeYear = WebTypeYear;

        this.sub ? this.sub.unsubscribe() : null;

        switch (this.WebTypeYear) {
            case WebTypeYearEnum.Year1980:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample1980?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample1990?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample2000?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample2010?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample2020?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample2030?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample2040?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    if (this.appLoadedService.AppLoaded$.getValue()?.WebMWQMSample2050?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
                        this.KeepWebMWQMSample();
                    }
                    else {
                        this.sub = this.GetWebMWQMSample().subscribe();
                    }
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[this.WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- DoWebMWQMSample function`);
                }
                break;

        }
    }

    private DoNextWebMWQMSample() {
        this.DoWebMWQMSample(this.TVItemID, this.WebTypeYear, this.DoOther);
    }

    private GetWebMWQMSample() {
        let languageEnum = GetLanguageEnum();
        switch (this.WebTypeYear) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample1980: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample1980To1990[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample1990: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample1990To2000[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2000: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2000To2010[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2010: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2010To2020[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2020: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2020To2030[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2030: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2030To2040[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2040: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2040To2050[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: {}, WebMWQMSample2050: {} });
                    this.appStateService.UpdateAppState(<AppState>{
                        Status: this.appLanguageService.AppLanguage.LoadingMWQMSample2050To2060[this.appStateService.AppState$?.getValue()?.Language],
                        Working: true
                    });
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[this.WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- GetWebMWQMSample function`);
                }
                break;
        }
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMWQMSample/${this.TVItemID}/${this.WebTypeYear}`;
        return this.httpClient.get<WebMWQMSample>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSample(x);
                console.debug(x);
                if (this.DoOther) {
                    switch (this.WebTypeYear) {
                        case WebTypeYearEnum.Year1980:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year1990;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year1990:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year2000;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year2000:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year2010;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year2010:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year2020;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year2020:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year2030;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year2030:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year2040;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year2040:
                            {
                                this.WebTypeYear = WebTypeYearEnum.Year2050;
                                this.DoNextWebMWQMSample();
                            }
                            break;
                        case WebTypeYearEnum.Year2050:
                            {
                                // nothing more to add in the chain
                            }
                            break;
                        default:
                            {
                                alert(`${WebTypeYearEnum[this.WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- GetWebMWQMSample function`);
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

    private FillWebMWQMSampleAll(): void {
        let WebMWQMSampleAll: WebMWQMSample;
        let MWQMSampleLanguageList: MWQMSampleLanguage[] = [];
        let MWQMSampleList: MWQMSample[] = [];
        let TVItemParentList: WebBase[] = [];


        MWQMSampleLanguageList = MWQMSampleLanguageList.concat(
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050?.MWQMSampleLanguageList);

        MWQMSampleList = MWQMSampleList.concat(
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050?.MWQMSampleList);

        TVItemParentList = TVItemParentList.concat(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.TVItemParentList);

        WebMWQMSampleAll = <WebMWQMSample>{
            MWQMSampleLanguageList: MWQMSampleLanguageList,
            MWQMSampleList: MWQMSampleList,
            TVItemParentList: TVItemParentList
        };

        console.debug(WebMWQMSampleAll);

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: WebMWQMSampleAll });
    }

    private KeepWebMWQMSample() {
        switch (this.WebTypeYear) {
            case WebTypeYearEnum.Year1980:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year1990:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year2000:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year2010:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year2020:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year2030:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year2040:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            case WebTypeYearEnum.Year2050:
                {
                    this.UpdateWebMWQMSample(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050);
                    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050);
                    if (this.DoOther) {
                        // nothing else to add in the chain
                    }
                }
                break;
            default:
                {
                    alert(`${WebTypeYearEnum[this.WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- KeepWebMWQMSample function`);
                }
                break;
        }
    }

    private UpdateWebMWQMSample(x: WebMWQMSample) {
        switch (this.WebTypeYear) {
            case WebTypeYearEnum.Year1980:
                {
                    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSample1980: x });
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
                    alert(`${WebTypeYearEnum[this.WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- UpdateWebMWQMSample function`);
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
            switch (this.WebTypeYear) {
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
                        alert(`${WebTypeYearEnum[this.WebTypeYear]} not implemented yet. See web-mwqm-samples.service.ts -- UpdateWebMWQMSample function`);
                    }
                    break;
            }
        }
    }
}