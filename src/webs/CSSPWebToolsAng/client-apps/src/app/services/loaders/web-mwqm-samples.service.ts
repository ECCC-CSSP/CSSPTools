import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { WebTypeYearEnum } from 'src/app/enums/generated/WebTypeYearEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { MWQMRun } from 'src/app/models/generated/db/MWQMRun.model';
import { MWQMSample } from 'src/app/models/generated/db/MWQMSample.model';
import { MWQMSampleLanguage } from 'src/app/models/generated/db/MWQMSampleLanguage.model';
import { MWQMSite } from 'src/app/models/generated/db/MWQMSite.model';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebMWQMSample } from 'src/app/models/generated/web/WebMWQMSample.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from '../app-language.service';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { SortMWQMRunListService } from '../helpers/sort-mwqm-run-list-desc.service';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';
import { SortMWQMSiteSampleListService } from '../helpers/sort-mwqm-site-sample-list-desc.service';
import { ColorAndLetter } from 'src/app/models/generated/web/ColorAndLetter.model';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';

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
        private sortMWQMRunListService: SortMWQMRunListService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private sortMWQMSiteSampleListService: SortMWQMSiteSampleListService) {
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

    FillStatMWQMSiteList() {
        let StatMWQMSiteList: StatMWQMSite[] = [];
        let MWQMSiteList: MWQMSite[] = this.appLoadedService.AppLoaded$.getValue().MWQMSiteList;
        let countSite: number = this.appLoadedService.AppLoaded$.getValue().MWQMSiteList.length;
        for (let i = 0; i < countSite; i++) {
            let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.AppLoaded$.getValue().WebMWQMSite.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.TVItemID == MWQMSiteList[i].MWQMSiteTVItemID);

            let StatMWQMSiteSampleList: StatMWQMSiteSample[] = this.FillMWQMSiteSampleStat(MWQMSiteModelList[0].TVItemModel);

            StatMWQMSiteList.push(<StatMWQMSite>{ MWQMSite: MWQMSiteList[i], StatMWQMSiteSampleList: StatMWQMSiteSampleList, TVItemModel: MWQMSiteModelList[0].TVItemModel });
        }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ StatMWQMSiteList: StatMWQMSiteList });
    }

    GetMWQMSiteDetail(tvItemModel: TVItemModel): StatMWQMSite {
        let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.AppLoaded$.getValue().StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        return statMWQMSiteList === undefined ? null : statMWQMSiteList[0];
    }

    GetMWQMSiteList(tvItemModel: TVItemModel): StatMWQMSite[] {
        let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.AppLoaded$.getValue().StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        return statMWQMSiteList === undefined ? null : statMWQMSiteList;
    }

    private DoNextWebMWQMSample() {
        this.DoWebMWQMSample(this.TVItemID, this.WebTypeYear, this.DoOther);
    }

    private FillWebMWQMSampleAll(): void {
        let WebMWQMSampleAll: WebMWQMSample;
        let MWQMSampleLanguageList: MWQMSampleLanguage[] = [];
        let MWQMSampleList: MWQMSample[] = [];
        let TVItemParentList: WebBase[] = [];


        MWQMSampleLanguageList = MWQMSampleLanguageList.concat(
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040?.MWQMSampleLanguageList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050?.MWQMSampleLanguageList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050?.MWQMSampleLanguageList);

        MWQMSampleList = MWQMSampleList.concat(
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1990?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2000?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2010?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2020?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2030?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2040?.MWQMSampleList,
            this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050?.MWQMSampleList === undefined
                ? [] : this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample2050?.MWQMSampleList);

        TVItemParentList = TVItemParentList.concat(this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSample1980?.TVItemParentList);

        WebMWQMSampleAll = <WebMWQMSample>{
            MWQMSampleLanguageList: MWQMSampleLanguageList,
            MWQMSampleList: MWQMSampleList,
            TVItemParentList: TVItemParentList
        };

        console.debug(WebMWQMSampleAll);

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMWQMSampleAll: WebMWQMSampleAll });

        this.FillStatMWQMRunList();

        this.FillStatMWQMSiteList();

    }

    private FillStatMWQMRunList() {
        let StatMWQMRunList: StatMWQMRun[] = [];

        let MWQMRunRoutineDescList: MWQMRun[] = this.sortMWQMRunListService.SortMWQMRunListDescByDate(this.appLoadedService.AppLoaded$.getValue().MWQMRunRoutingList);

        let countRun: number = MWQMRunRoutineDescList.length;
        for (let i = 0; i < countRun; i++) {
            let DateText: string = MWQMRunRoutineDescList[i].DateTime_Local.toString();
            let Year: number = parseInt(DateText.substring(0, 4));

            let statMWQMRun: StatMWQMRun = <StatMWQMRun>{
                EndTide: '',
                IsOKRun: true,
                MWQMRunTVItemID: MWQMRunRoutineDescList[i].MWQMRunTVItemID,
                RainDay0: MWQMRunRoutineDescList[i].RainDay0_mm,
                RainDay1: MWQMRunRoutineDescList[i].RainDay1_mm,
                RainDay2: MWQMRunRoutineDescList[i].RainDay2_mm,
                RainDay3: MWQMRunRoutineDescList[i].RainDay3_mm,
                RainDay4: MWQMRunRoutineDescList[i].RainDay4_mm,
                RainDay5: MWQMRunRoutineDescList[i].RainDay5_mm,
                RainDay6: MWQMRunRoutineDescList[i].RainDay6_mm,
                RainDay7: MWQMRunRoutineDescList[i].RainDay7_mm,
                RainDay8: MWQMRunRoutineDescList[i].RainDay8_mm,
                RainDay9: MWQMRunRoutineDescList[i].RainDay9_mm,
                RainDay10: MWQMRunRoutineDescList[i].RainDay10_mm,
                RemoveFromStat: false,
                RunDate: MWQMRunRoutineDescList[i].DateTime_Local,
                RunIndex: i,
                RunYear: Year,
                UseInStat: true,
            };

            StatMWQMRunList.push(statMWQMRun);
        }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ StatMWQMRunList: StatMWQMRunList });
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

    private FillMWQMSiteSampleStat(tvItemModel: TVItemModel): StatMWQMSiteSample[] {
        let SampleTypeText: string = `${SampleTypeEnum.Routine},`;
        let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.AppLoaded$.getValue()?.StatMWQMRunList;

        let StatRuns: number = this.appStateService.AppState$.getValue().StatRunsForDetail;

        if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
            StatRuns = this.appStateService.AppState$.getValue().StatRuns;
        }

        let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSite?.MWQMSiteModelList?.filter(
            c => c.MWQMSite.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

        if (MWQMSiteModelList && MWQMSiteModelList.length > 0) {
            let MWQMSiteSampleSortedList: MWQMSample[] = this.sortMWQMSiteSampleListService.SortMWQMSiteSampleListDescByDate(
                this.appLoadedService.AppLoaded$?.getValue()?.WebMWQMSampleAll?.MWQMSampleList.filter(c => c.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID)
            );

            if (MWQMSiteSampleSortedList && MWQMSiteSampleSortedList.length > 0) {
                let EndYear = parseInt(MWQMSiteSampleSortedList[MWQMSiteSampleSortedList.length - 1].SampleDateTime_Local.toString());
                let StartYear = parseInt(MWQMSiteSampleSortedList[0].SampleDateTime_Local.toString());

                if (MWQMSiteSampleSortedList.length > 0) {
                    let SampleCount: number = 0;
                    let countRun: number = StatMWQMRunList.length;
                    let countSample: number = MWQMSiteSampleSortedList.length;
                    let sUsed: number = 0;
                    for (let r = 0; r < countRun; r++) // at this point all run should be of SampleTypeEnum.Routine
                    {
                        let RunDateText: string = StatMWQMRunList[r].RunDate.toString();
                        let RunYear: number = parseInt(RunDateText.substring(0, 4));
                        let RunMonth: number = parseInt(RunDateText.substring(5, 7));
                        let RunDate: number = parseInt(RunDateText.substring(8, 10));

                        let found: boolean = false;
                        for (let s = sUsed; s < countSample; s++) {
                            let SampleDateText: string = MWQMSiteSampleSortedList[s].SampleDateTime_Local.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));
                            let SampleMonth: number = parseInt(SampleDateText.substring(5, 7));
                            let SampleDate: number = parseInt(SampleDateText.substring(8, 10));
                            let IsRouting: boolean = MWQMSiteSampleSortedList.filter(c => c.SampleTypesText.indexOf(SampleTypeText) > -1) ? true : false;
                            if (RunYear == SampleYear && RunMonth == SampleMonth && RunDate == SampleDate && IsRouting) {
                                SampleCount += 1;
                                StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                    Depth: MWQMSiteSampleSortedList[s].Depth_m,
                                    FC: MWQMSiteSampleSortedList[s].FecCol_MPN_100ml,
                                    IsActive: tvItemModel.TVItem.IsActive,
                                    MWQMRunTVItemID: StatMWQMRunList[r].MWQMRunTVItemID,
                                    MWQMSiteTVItemID: tvItemModel.TVItem.TVItemID,
                                    PH: MWQMSiteSampleSortedList[s].PH,
                                    RunIndex: r,
                                    Sal: MWQMSiteSampleSortedList[s].Salinity_PPT,
                                    SampleDate: MWQMSiteSampleSortedList[s].SampleDateTime_Local,
                                    Temp: MWQMSiteSampleSortedList[s].WaterTemp_C,
                                    UseInStat: StatMWQMRunList[r].UseInStat,
                                    Samples: countSample,
                                });
                                sUsed = s + 1;
                                found = true;
                                break;
                            }
                        }

                        if (!found) {
                            StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                SampleDate: StatMWQMRunList[r].RunDate,
                                RunIndex: r,
                                UseInStat: false,
                            });
                        }
                    }

                    let FCList: number[] = [];
                    let YearList: number[] = [];

                    let countRuns: number = StatMWQMSiteSampleList.length;
                    let LastSampleDate: Date;
                    for (let r = countRuns - 1; r >= 0; r--) {
                        if (tvItemModel.TVItemLanguageList[1].TVText == '0001' && r == 0) {
                            let lsiefj = 34;
                        }
                        if (StatMWQMSiteSampleList[r].FC) {
                            LastSampleDate = StatMWQMSiteSampleList[r].SampleDate;
                            let SampleDateText: string = StatMWQMSiteSampleList[r].SampleDate.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));

                            // for analysis, more condition will be required
                            FCList.push(StatMWQMSiteSampleList[r].FC);
                            YearList.push(SampleYear);
                        }

                        if (FCList.length > StatRuns) {
                            FCList.shift();
                            YearList.shift();
                        }

                        if (FCList.length > 3) {
                            StatMWQMSiteSampleList[r].DataText = FCList.join('|');
                            StatMWQMSiteSampleList[r].LastSampleDate = LastSampleDate;
                            StatMWQMSiteSampleList[r].SampCount = FCList.length;
                            StatMWQMSiteSampleList[r].PercOver43 = this.PercOver43(FCList);
                            StatMWQMSiteSampleList[r].PercOver260 = this.PercOver260(FCList);
                            StatMWQMSiteSampleList[r].MinFC = this.MinFC(FCList);
                            StatMWQMSiteSampleList[r].MaxFC = this.MaxFC(FCList);
                            StatMWQMSiteSampleList[r].Median = this.GetMedian(FCList);
                            StatMWQMSiteSampleList[r].P90 = this.GetP90(FCList);
                            StatMWQMSiteSampleList[r].GeoMean = this.GetGeometricMean(FCList);
                            StatMWQMSiteSampleList[r].ColorAndLetter = this.GetColorAndLetter(
                                StatMWQMSiteSampleList[r].P90,
                                StatMWQMSiteSampleList[r].GeoMean,
                                StatMWQMSiteSampleList[r].Median,
                                StatMWQMSiteSampleList[r].PercOver43,
                                StatMWQMSiteSampleList[r].PercOver260);
                            StatMWQMSiteSampleList[r].StatEndYear = this.MinYear(YearList);
                            StatMWQMSiteSampleList[r].StatStartYear = this.MinYear(YearList);
                            StatMWQMSiteSampleList[r].EndYear = EndYear;
                            StatMWQMSiteSampleList[r].StartYear = StartYear;
                        }
                    }

                    let countStat: number = StatMWQMSiteSampleList.length;
                    for (let i = 0; i < countStat; i++) {
                        StatMWQMSiteSampleList[i].Samples = SampleCount;
                    }
                }
            }

            return StatMWQMSiteSampleList;
        }
    }

    private PercOver43(FCList: number[]): number {
        let dataOver43: number[] = [];
        for (let FC of FCList) {
            if (FC > 43) {
                dataOver43.push(FC);
            }
        }

        return (dataOver43.length / FCList.length) * 100;
    }

    private PercOver260(FCList: number[]): number {
        let dataOver260: number[] = [];
        for (let FC of FCList) {
            if (FC > 260) {
                dataOver260.push(FC);
            }
        }

        return (dataOver260.length / FCList.length) * 100;
    }
    private MinYear(YearList: number[]): number {
        let MinYear: number = 10000;

        for (let Year of YearList) {
            if (MinYear > Year) {
                MinYear = Year;
            }
        }

        return MinYear;
    }
    private MaxYear(YearList: number[]): number {
        let MaxYear: number = 0;

        for (let Year of YearList) {
            if (MaxYear < Year) {
                MaxYear = Year;
            }
        }

        return MaxYear;
    }
    private MaxFC(FCList: number[]): number {
        let MaxFC: number = 0;

        for (let FC of FCList) {
            if (MaxFC < FC) {
                MaxFC = FC;
            }
        }

        return MaxFC;
    }
    private MinFC(FCList: number[]): number {
        let MinFC: number = 10000000;

        for (let FC of FCList) {
            if (MinFC > FC) {
                MinFC = FC;
            }
        }

        return MinFC;
    }
    private GetGeometricMean(FCList: number[]): number {
        let prod: number = 0;

        prod = 1.0;

        for (let FC of FCList) {
            prod *= FC;
        }

        return Math.pow(prod, (1.0 / FCList.length));
    }
    private GetColorAndLetter(P90: number, GeoMean: number, Median: number, PercOver43: number, PercOver260: number): ColorAndLetter {
        let colorAndLetter: ColorAndLetter = <ColorAndLetter>{ color: '', letter: '' };
        if (!Median) {
            return colorAndLetter;
        }
        if ((GeoMean > 88) || (Median > 88) || (P90 > 260) || (PercOver260 > 10)) {
            if ((GeoMean > 181) || (Median > 181) || (P90 > 460) || (PercOver260 > 18)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgbluef', letter: 'F' };
            }
            else if ((GeoMean > 163) || (Median > 163) || (P90 > 420) || (PercOver260 > 17)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgbluee', letter: 'E' };
            }
            else if ((GeoMean > 144) || (Median > 144) || (P90 > 380) || (PercOver260 > 15)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgblued', letter: 'D' };
            }
            else if ((GeoMean > 125) || (Median > 125) || (P90 > 340) || (PercOver260 > 13)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgbluec', letter: 'C' };
            }
            else if ((GeoMean > 107) || (Median > 107) || (P90 > 300) || (PercOver260 > 12)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgblueb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ color: 'bgbluea', letter: 'A' };
            }
        }
        else if ((GeoMean > 14) || (Median > 14) || (P90 > 43) || (PercOver43 > 10)) {
            if ((GeoMean > 76) || (Median > 76) || (P90 > 224) || (PercOver43 > 27)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgredf', letter: 'F' };
            }
            else if ((GeoMean > 63) || (Median > 63) || (P90 > 188) || (PercOver43 > 23)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgrede', letter: 'E' };
            }
            else if ((GeoMean > 51) || (Median > 51) || (P90 > 152) || (PercOver43 > 20)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgredd', letter: 'D' };
            }
            else if ((GeoMean > 39) || (Median > 39) || (P90 > 115) || (PercOver43 > 17)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgredc', letter: 'C' };
            }
            else if ((GeoMean > 26) || (Median > 26) || (P90 > 79) || (PercOver43 > 13)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bgredb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ color: 'bgreda', letter: 'A' };
            }
        }
        else {
            if ((GeoMean > 12) || (Median > 12) || (P90 > 36) || (PercOver43 > 8)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bggreenf', letter: 'F' };
            }
            else if ((GeoMean > 9) || (Median > 9) || (P90 > 29) || (PercOver43 > 7)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bggreene', letter: 'E' };
            }
            else if ((GeoMean > 7) || (Median > 7) || (P90 > 22) || (PercOver43 > 5)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bggreend', letter: 'D' };
            }
            else if ((GeoMean > 5) || (Median > 5) || (P90 > 14) || (PercOver43 > 3)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bggreenc', letter: 'C' };
            }
            else if ((GeoMean > 2) || (Median > 2) || (P90 > 7) || (PercOver43 > 2)) {
                colorAndLetter = <ColorAndLetter>{ color: 'bggreenb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ color: 'bggreena', letter: 'A' };
            }
        }

        return colorAndLetter;
    }
    private GetMedian(FCList: number[]): number {
        let sortedData: number[] = [];

        let countFC: number = FCList.length;
        for (let i = 0; i < countFC; i++) {
            sortedData.push(FCList[i]);
        }

        sortedData.sort((n1, n2) => n1 - n2);
        let size: number = sortedData.length;
        let mid = parseInt((size / 2).toString());
        return (size % 2 != 0) ? sortedData[mid] : (sortedData[mid] + sortedData[mid - 1]) / 2;

    }
    private GetP90(FCList: number[]): number {
        let fcLogList: number[] = [];
        for (let FC of FCList) {
            fcLogList.push(Math.log(FC) / Math.LN10);
        }

        let Average = 0.0;
        let Sum = 0.0;
        for (let d of fcLogList) {
            Sum += d
        }
        Average = Sum / FCList.length;
        let SD: number = this.GetStandardDeviation(fcLogList);
        let P90Log = (SD * 1.28) + Average;
        return Math.pow(10, P90Log);
    }
    private GetStandardDeviation(FCList: number[]): number {
        let avg: number = 0;
        let total: number = 0;
        for (let FC of FCList) {
            total = total + FC;
        }
        avg = total / FCList.length;

        let sum: number = 0;
        for (let FC of FCList) {
            sum += (FC - avg) * (FC - avg);
        }

        return Math.sqrt((sum) / (FCList.length - 1));
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