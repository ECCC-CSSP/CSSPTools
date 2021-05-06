import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { StatMWQMRun } from 'src/app/models/generated/web/StatMWQMRun.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { StatMWQMSiteSample } from 'src/app/models/generated/web/StatMWQMSiteSample.model';
import { MWQMSiteModel } from 'src/app/models/generated/web/MWQMSiteModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebMWQMSamples } from 'src/app/models/generated/web/WebMWQMSamples.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { SortMWQMRunListService } from 'src/app/services/helpers/sort-mwqm-run-list-desc.service';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';
import { SortMWQMSiteSampleModelListService } from 'src/app/services/helpers/sort-mwqm-site-sample-list.service';
import { ColorAndLetter } from 'src/app/models/generated/web/ColorAndLetter.model';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { MapService } from 'src/app/services/map/map.service';
import { SortMWQMSiteModelListService } from 'src/app/services/helpers/sort-mwqm-site-model-list.service';
import { AnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { MWQMRunModel } from 'src/app/models/generated/web/MWQMRunModel.model';
import { MWQMRunModelSiteAndSampleModel, MWQMSiteModelAndSampleModel } from 'src/app/models/MWQMRunModelSiteAndSample.model';
import { MWQMSampleModel } from 'src/app/models/generated/web/MWQMSampleModel.model';

@Injectable({
    providedIn: 'root'
})
export class WebMWQMSamplesService {
    private TVItemID: number;
    private DoNext: boolean;
    private ForceReload: boolean;
    private sub: Subscription;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortMWQMRunListService: SortMWQMRunListService,
        private sortMWQMSiteModelService: SortMWQMSiteModelListService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private sortMWQMSiteSampleModelListService: SortMWQMSiteSampleModelListService) {
    }

    DoWebMWQMSamples(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
        this.TVItemID = TVItemID;
        this.DoNext = DoNext;
        this.ForceReload = ForceReload;

        this.sub ? this.sub.unsubscribe() : null;

        if (ForceReload) {
            this.sub = this.GetWebMWQMSamples1980_2020().subscribe();
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSamples()) {
                this.KeepWebMWQMSamples();
            }
            else {
                this.sub = this.GetWebMWQMSamples1980_2020().subscribe();
            }
        }
    }

    FillStatMWQMSiteList() {
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.StatMWQMRunList;

        if (StatMWQMRunList == undefined || StatMWQMRunList.length == 0) {
            return;
        }

        let countR: number = StatMWQMRunList.length;
        for (let r = 0; r < countR; r++) {
            StatMWQMRunList[r].UseInStat = false;
        }

        let StatMWQMSiteList: StatMWQMSite[] = [];
        let MWQMSiteModelActiveList: MWQMSiteModel[] = this.sortMWQMSiteModelService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == true));
        let MWQMSiteModelInactiveList: MWQMSiteModel[] = this.sortMWQMSiteModelService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == false));
        let countSite: number = MWQMSiteModelActiveList.length;
        for (let i = 0; i < countSite; i++) {
            let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.MWQMSite.MWQMSiteTVItemID == MWQMSiteModelActiveList[i].TVItemModel.TVItem.TVItemID);

            let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForMWQMSites(MWQMSiteModelActiveList[i].TVItemModel);
            }

            if (this.appStateService.TopComponent == TopComponentEnum.Home || this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
                StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForAnalysis(MWQMSiteModelActiveList[i].TVItemModel);
            }

            StatMWQMSiteList.push(<StatMWQMSite>{ SalinityAverage: this.GetSalinityAverage(StatMWQMSiteSampleList), MWQMSiteModel: MWQMSiteModelList[0], StatMWQMSiteSampleList: StatMWQMSiteSampleList, TVItemModel: MWQMSiteModelActiveList[i].TVItemModel });
        }

        if (this.appStateService.InactVisible) {
            countSite = MWQMSiteModelInactiveList.length;
            for (let i = 0; i < countSite; i++) {
                let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.MWQMSite.MWQMSiteTVItemID == MWQMSiteModelInactiveList[i].TVItemModel.TVItem.TVItemID);

                let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
                if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                    StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForMWQMSites(MWQMSiteModelActiveList[i].TVItemModel);
                }

                if (this.appStateService.TopComponent == TopComponentEnum.Home || this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
                    StatMWQMSiteSampleList = this.FillMWQMSiteSampleStatForAnalysis(MWQMSiteModelActiveList[i].TVItemModel);
                }

                StatMWQMSiteList.push(<StatMWQMSite>{ SalinityAverage: this.GetSalinityAverage(StatMWQMSiteSampleList), MWQMSiteModel: MWQMSiteModelList[0], StatMWQMSiteSampleList: StatMWQMSiteSampleList, TVItemModel: MWQMSiteModelInactiveList[i].TVItemModel });
            }
        }

        this.appLoadedService.StatMWQMSiteList = StatMWQMSiteList;

        if (this.appLoadedService.StatMWQMRunList?.length > 0) {
            if (this.appStateService.AnalysisStartRun == null) {
                this.appStateService.AnalysisStartRun = this.appLoadedService.StatMWQMRunList[0];
                this.appStateService.AnalysisEndRun = this.appLoadedService.StatMWQMRunList[this.appLoadedService.StatMWQMRunList.length - 1];
            }
        }

    }

    private GetSalinityAverage(statMWQMSiteSampleList: StatMWQMSiteSample[]): number {
        let SalinityAverage: number = null;
        if (statMWQMSiteSampleList != undefined && statMWQMSiteSampleList.length > 0) {
            let count: number = statMWQMSiteSampleList.length;
            let total: number = 0;
            let valCount: number = 0
            for (let i = 0; i < count; i++) {
                if (statMWQMSiteSampleList[i].Sal != null) {
                    valCount += 1;
                    total += statMWQMSiteSampleList[i].Sal;
                }
            }

            if (valCount > 0) {
                SalinityAverage = total / valCount;
            }
        }

        return SalinityAverage;
    }

    GetMWQMRunModelSiteAndSampleDetail(tvItemModel: TVItemModel): MWQMRunModelSiteAndSampleModel {
        let mwqmRunModelSiteAndSampleModel: MWQMRunModelSiteAndSampleModel = new MWQMRunModelSiteAndSampleModel();
        let mwqmSiteModelAndSampleModelList: MWQMSiteModelAndSampleModel[] = [];

        let mwqmRunModelList: MWQMRunModel[] = this.appLoadedService.WebMWQMRuns.MWQMRunModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);

        if (mwqmRunModelList !== undefined && mwqmRunModelList.length > 0) {
            mwqmRunModelSiteAndSampleModel.MWQMRunModel = mwqmRunModelList[0];

            let mwqmSampleModelList: MWQMSampleModel[] = this.appLoadedService.WebMWQMSamples.MWQMSampleModelList?.filter(c => c.MWQMSample.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

            let MWQMSiteModelActiveList: MWQMSiteModel[] = this.sortMWQMSiteModelService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == true));

            let count: number = MWQMSiteModelActiveList.length;
            for (let i = 0; i < count; i++) {
                let mwqmSampleModelTempList: MWQMSampleModel[] = mwqmSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == MWQMSiteModelActiveList[i].TVItemModel.TVItem.TVItemID);
                if (mwqmSampleModelTempList !== undefined && mwqmSampleModelTempList.length > 0) {
                    mwqmSiteModelAndSampleModelList.push(<MWQMSiteModelAndSampleModel>{ MWQMSiteModel: MWQMSiteModelActiveList[i], MWQMSample: mwqmSampleModelTempList[0] });
                }
            }

            let MWQMSiteModelInactiveList: MWQMSiteModel[] = this.sortMWQMSiteModelService.SortMWQMSiteModelListByTVTextAsc(this.appLoadedService.WebMWQMSites.MWQMSiteModelList.filter(c => c.TVItemModel.TVItem.IsActive == false));

            count = MWQMSiteModelInactiveList.length;
            for (let i = 0; i < count; i++) {
                let mwqmSampleModelTempList: MWQMSampleModel[] = mwqmSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == MWQMSiteModelInactiveList[i].TVItemModel.TVItem.TVItemID);
                if (mwqmSampleModelTempList !== undefined && mwqmSampleModelTempList.length > 0) {
                    mwqmSiteModelAndSampleModelList.push(<MWQMSiteModelAndSampleModel>{ MWQMSiteModel: MWQMSiteModelInactiveList[i], MWQMSample: mwqmSampleModelTempList[0] });
                }
            }

            mwqmRunModelSiteAndSampleModel.MWQMSiteModelAndSampleModelList = mwqmSiteModelAndSampleModelList;
        }

        return mwqmRunModelSiteAndSampleModel;
    }

    GetMWQMSiteDetail(tvItemModel: TVItemModel): StatMWQMSite {
        let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        return statMWQMSiteList === undefined ? null : statMWQMSiteList[0];
    }

    GetMWQMSiteList(tvItemModel: TVItemModel): StatMWQMSite[] {
        let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);
        return statMWQMSiteList === undefined ? null : statMWQMSiteList;
    }

    private FillStatMWQMRunList() {
        let StatMWQMRunList: StatMWQMRun[] = [];

        let MWQMRunRoutineDescList: MWQMRunModel[] = this.sortMWQMRunListService.SortMWQMRunListDescByDate(this.appLoadedService.WebMWQMRuns.MWQMRunModelList);

        let countRun: number = MWQMRunRoutineDescList.length;
        for (let i = 0; i < countRun; i++) {
            let DateText: string = MWQMRunRoutineDescList[i].MWQMRun.DateTime_Local.toString();
            let Year: number = parseInt(DateText.substring(0, 4));
            let Month: number = parseInt(DateText.substring(5, 7));
            let Day: number = parseInt(DateText.substring(8, 10));

            let statMWQMRun: StatMWQMRun = <StatMWQMRun>{
                IsOKRun: true,
                MWQMRunTVItemID: MWQMRunRoutineDescList[i].MWQMRun.MWQMRunTVItemID,
                RainDay0: MWQMRunRoutineDescList[i].MWQMRun.RainDay0_mm,
                RainDay1: MWQMRunRoutineDescList[i].MWQMRun.RainDay1_mm,
                RainDay2: MWQMRunRoutineDescList[i].MWQMRun.RainDay2_mm,
                RainDay3: MWQMRunRoutineDescList[i].MWQMRun.RainDay3_mm,
                RainDay4: MWQMRunRoutineDescList[i].MWQMRun.RainDay4_mm,
                RainDay5: MWQMRunRoutineDescList[i].MWQMRun.RainDay5_mm,
                RainDay6: MWQMRunRoutineDescList[i].MWQMRun.RainDay6_mm,
                RainDay7: MWQMRunRoutineDescList[i].MWQMRun.RainDay7_mm,
                RainDay8: MWQMRunRoutineDescList[i].MWQMRun.RainDay8_mm,
                RainDay9: MWQMRunRoutineDescList[i].MWQMRun.RainDay9_mm,
                RainDay10: MWQMRunRoutineDescList[i].MWQMRun.RainDay10_mm,
                RemoveFromStat: false,
                RunDate: MWQMRunRoutineDescList[i].MWQMRun.DateTime_Local,
                RunIndex: i,
                RunYear: Year,
                RunMonth: Month,
                RunDay: Day,
                StartTide: MWQMRunRoutineDescList[i].MWQMRun.Tide_Start,
                EndTide: MWQMRunRoutineDescList[i].MWQMRun.Tide_End,
                UseInStat: true,
            };

            StatMWQMRunList.push(statMWQMRun);
        }

        this.appLoadedService.StatMWQMRunList = StatMWQMRunList;

        if (StatMWQMRunList.length > 0) {
            this.appStateService.AnalysisStartRun = StatMWQMRunList[0];
            this.appStateService.AnalysisEndRun = StatMWQMRunList[StatMWQMRunList.length - 1];
        }
    }

    private GetWebMWQMSamples1980_2020() {
        this.appLoadedService.WebMWQMSamples = <WebMWQMSamples>{};

        let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebMWQMSamples2021_2060` : '';
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMWQMSamples1980_2020 - ${NextText} - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebMWQMSamples1980_2020/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSamples>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSamples1980_2020(x);
                console.debug(x);
                if (this.DoNext) {
                    this.GetWebMWQMSamples2021_2060();
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

    private GetWebMWQMSamples2021_2060() {
        let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
        this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebMWQMSamples2021_2060 - ${ForceReloadText}`;
        this.appStateService.Working = true;

        let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebMWQMSamples2021_2060/${this.TVItemID}`;
        return this.httpClient.get<WebMWQMSamples>(url).pipe(
            map((x: any) => {
                this.UpdateWebMWQMSamples2021_2060(x);
                console.debug(x);
                if (this.DoNext) {
                    // nothing for now
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

    private FillMWQMSiteSampleStatForAnalysis(tvItemModel: TVItemModel): StatMWQMSiteSample[] {
        let SampleTypeText: string = `${SampleTypeEnum.Routine},`;
        let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.StatMWQMRunList;

        let StatRuns = this.appStateService.AnalysisRuns;

        let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites?.MWQMSiteModelList?.filter(
            c => c.MWQMSite.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

        if (MWQMSiteModelList && MWQMSiteModelList.length > 0) {
            let MWQMSiteSampleModelSortedList: MWQMSampleModel[] = this.sortMWQMSiteSampleModelListService.SortMWQMSiteSampleModelListDescByDate(
                this.appLoadedService.WebMWQMSamples?.MWQMSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID)
            );

            if (MWQMSiteSampleModelSortedList && MWQMSiteSampleModelSortedList.length > 0) {
                let EndYear = parseInt(MWQMSiteSampleModelSortedList[MWQMSiteSampleModelSortedList.length - 1].MWQMSample.SampleDateTime_Local.toString());
                let StartYear = parseInt(MWQMSiteSampleModelSortedList[0].MWQMSample.SampleDateTime_Local.toString());

                if (MWQMSiteSampleModelSortedList.length > 0) {

                    let SampleCount: number = 0;
                    let countRun: number = StatMWQMRunList.length;
                    let countSample: number = MWQMSiteSampleModelSortedList.length;
                    let sUsed: number = 0;
                    let useCount: number = 0;

                    for (let r = 0; r < countRun; r++) // at this point all run should be of SampleTypeEnum.Routine
                    {
                        let RunDateText: string = StatMWQMRunList[r].RunDate.toString();
                        let RunYear: number = parseInt(RunDateText.substring(0, 4));
                        let RunMonth: number = parseInt(RunDateText.substring(5, 7));
                        let RunDate: number = parseInt(RunDateText.substring(8, 10));

                        let found: boolean = false;
                        for (let s = sUsed; s < countSample; s++) {
                            let SampleDateText: string = MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));
                            let SampleMonth: number = parseInt(SampleDateText.substring(5, 7));
                            let SampleDay: number = parseInt(SampleDateText.substring(8, 10));
                            let IsRouting: boolean = MWQMSiteSampleModelSortedList.filter(c => c.MWQMSample.SampleTypesText.indexOf(SampleTypeText) > -1) ? true : false;
                            if (RunYear == SampleYear && RunMonth == SampleMonth && RunDate == SampleDay && IsRouting) {
                                SampleCount += 1;
                                StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                    Depth: MWQMSiteSampleModelSortedList[s].MWQMSample.Depth_m,
                                    FC: MWQMSiteSampleModelSortedList[s].MWQMSample.FecCol_MPN_100ml,
                                    IsActive: tvItemModel.TVItem.IsActive,
                                    MWQMRunTVItemID: StatMWQMRunList[r].MWQMRunTVItemID,
                                    MWQMSiteTVItemID: tvItemModel.TVItem.TVItemID,
                                    PH: MWQMSiteSampleModelSortedList[s].MWQMSample.PH,
                                    RunIndex: r,
                                    Sal: MWQMSiteSampleModelSortedList[s].MWQMSample.Salinity_PPT,
                                    SampleDate: MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local,
                                    Temp: MWQMSiteSampleModelSortedList[s].MWQMSample.WaterTemp_C,
                                    UseInStat: StatMWQMRunList[r].UseInStat,
                                    Samples: countSample,
                                    SampleYear: SampleYear,
                                    SampleMonth: SampleMonth,
                                    SampleDay: SampleDay,
                                });
                                //StatMWQMRunList[r].UseInStat = true;
                                sUsed = s + 1;
                                found = true;

                                StatMWQMSiteSampleList[StatMWQMSiteSampleList.length - 1].UseInStat = false;

                                let skipVal: boolean = false;

                                // let SampleDate: Date = new Date(SampleYear, SampleMonth, SampleDay);
                                // let AnalysisStartDate: Date = this.appStateService.AnalysisStartRun.RunDate;

                                // Check Start Run Date
                                if (MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString().substring(0, 10) > this.appStateService.AnalysisStartRun.RunDate.toString().substring(0, 10)) {
                                    skipVal = true;
                                }

                                // Check End Run Date
                                if (MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString().substring(0, 10) < this.appStateService.AnalysisEndRun.RunDate.toString().substring(0, 10)) {
                                    skipVal = true;
                                }

                                // Check Runs
                                if (useCount >= this.appStateService.AnalysisRuns) {
                                    skipVal = true;
                                }

                                if (this.appStateService.AnalysisCalculationType == AnalysisCalculationTypeEnum.All) {
                                    // everything is ok, nothing to do
                                }

                                if (this.appStateService.AnalysisCalculationType == AnalysisCalculationTypeEnum.Dry) {
                                    if (StatMWQMRunList[r].RainDay1 >= this.appStateService.AnalysisDry24h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2) >= this.appStateService.AnalysisDry48h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3) >= this.appStateService.AnalysisDry72h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3 + StatMWQMRunList[r].RainDay4) >= this.appStateService.AnalysisDry96h) {
                                        skipVal = true;
                                    }
                                }

                                if (this.appStateService.AnalysisCalculationType == AnalysisCalculationTypeEnum.Wet) {
                                    if (StatMWQMRunList[r].RainDay1 <= this.appStateService.AnalysisWet24h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2) <= this.appStateService.AnalysisWet48h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3) <= this.appStateService.AnalysisWet72h
                                        && (StatMWQMRunList[r].RainDay1 + StatMWQMRunList[r].RainDay2 + StatMWQMRunList[r].RainDay3 + StatMWQMRunList[r].RainDay4) <= this.appStateService.AnalysisWet96h) {
                                        skipVal = true;
                                    }
                                }

                                if (StatMWQMRunList[r].RemoveFromStat) {
                                    skipVal = true;
                                }

                                if (!skipVal) {
                                    useCount += 1;
                                    StatMWQMRunList[r].UseInStat = true;
                                    StatMWQMSiteSampleList[StatMWQMSiteSampleList.length - 1].UseInStat = true;
                                }

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
                        if (StatMWQMSiteSampleList[r].FC && StatMWQMSiteSampleList[r].UseInStat) {
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
                            StatMWQMSiteSampleList[r].StatStartYear = this.MaxYear(YearList);
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

    private FillMWQMSiteSampleStatForMWQMSites(tvItemModel: TVItemModel): StatMWQMSiteSample[] {
        let SampleTypeText: string = `${SampleTypeEnum.Routine},`;
        let StatMWQMSiteSampleList: StatMWQMSiteSample[] = [];
        let StatMWQMRunList: StatMWQMRun[] = this.appLoadedService.StatMWQMRunList;

        let StatRuns: number = this.appStateService.StatRunsForDetail;

        let MWQMSiteModelList: MWQMSiteModel[] = this.appLoadedService.WebMWQMSites?.MWQMSiteModelList?.filter(
            c => c.MWQMSite.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID);

        if (MWQMSiteModelList && MWQMSiteModelList.length > 0) {
            let MWQMSiteSampleModelSortedList: MWQMSampleModel[] = this.sortMWQMSiteSampleModelListService.SortMWQMSiteSampleModelListDescByDate(
                this.appLoadedService.WebMWQMSamples?.MWQMSampleModelList.filter(c => c.MWQMSample.MWQMSiteTVItemID == tvItemModel.TVItem.TVItemID)
            );

            if (MWQMSiteSampleModelSortedList && MWQMSiteSampleModelSortedList.length > 0) {
                let EndYear = parseInt(MWQMSiteSampleModelSortedList[MWQMSiteSampleModelSortedList.length - 1].MWQMSample.SampleDateTime_Local.toString());
                let StartYear = parseInt(MWQMSiteSampleModelSortedList[0].MWQMSample.SampleDateTime_Local.toString());

                if (MWQMSiteSampleModelSortedList.length > 0) {

                    let SampleCount: number = 0;
                    let countRun: number = StatMWQMRunList.length;
                    let countSample: number = MWQMSiteSampleModelSortedList.length;
                    let sUsed: number = 0;

                    for (let r = 0; r < countRun; r++) // at this point all run should be of SampleTypeEnum.Routine
                    {
                        let RunDateText: string = StatMWQMRunList[r].RunDate.toString();
                        let RunYear: number = parseInt(RunDateText.substring(0, 4));
                        let RunMonth: number = parseInt(RunDateText.substring(5, 7));
                        let RunDate: number = parseInt(RunDateText.substring(8, 10));

                        let found: boolean = false;
                        for (let s = sUsed; s < countSample; s++) {
                            let SampleDateText: string = MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local.toString();
                            let SampleYear: number = parseInt(SampleDateText.substring(0, 4));
                            let SampleMonth: number = parseInt(SampleDateText.substring(5, 7));
                            let SampleDate: number = parseInt(SampleDateText.substring(8, 10));
                            let IsRouting: boolean = MWQMSiteSampleModelSortedList.filter(c => c.MWQMSample.SampleTypesText.indexOf(SampleTypeText) > -1) ? true : false;
                            if (RunYear == SampleYear && RunMonth == SampleMonth && RunDate == SampleDate && IsRouting) {
                                SampleCount += 1;
                                StatMWQMSiteSampleList.push(<StatMWQMSiteSample>{
                                    Depth: MWQMSiteSampleModelSortedList[s].MWQMSample.Depth_m,
                                    FC: MWQMSiteSampleModelSortedList[s].MWQMSample.FecCol_MPN_100ml,
                                    IsActive: tvItemModel.TVItem.IsActive,
                                    MWQMRunTVItemID: StatMWQMRunList[r].MWQMRunTVItemID,
                                    MWQMSiteTVItemID: tvItemModel.TVItem.TVItemID,
                                    PH: MWQMSiteSampleModelSortedList[s].MWQMSample.PH,
                                    RunIndex: r,
                                    Sal: MWQMSiteSampleModelSortedList[s].MWQMSample.Salinity_PPT,
                                    SampleDate: MWQMSiteSampleModelSortedList[s].MWQMSample.SampleDateTime_Local,
                                    Temp: MWQMSiteSampleModelSortedList[s].MWQMSample.WaterTemp_C,
                                    UseInStat: StatMWQMRunList[r].UseInStat,
                                    Samples: countSample,
                                    SampleYear: SampleYear,
                                    SampleMonth: SampleMonth,
                                    SampleDay: SampleDate,
                                });
                                //StatMWQMRunList[r].UseInStat = true;
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
                            StatMWQMSiteSampleList[r].StatStartYear = this.MaxYear(YearList);
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
                colorAndLetter = <ColorAndLetter>{ hexColor: '#8888ff', color: 'bgbluef', letter: 'F' };
            }
            else if ((GeoMean > 163) || (Median > 163) || (P90 > 420) || (PercOver260 > 17)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#9999ff', color: 'bgbluee', letter: 'E' };
            }
            else if ((GeoMean > 144) || (Median > 144) || (P90 > 380) || (PercOver260 > 15)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#aaaaff', color: 'bgblued', letter: 'D' };
            }
            else if ((GeoMean > 125) || (Median > 125) || (P90 > 340) || (PercOver260 > 13)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#bbbbff', color: 'bgbluec', letter: 'C' };
            }
            else if ((GeoMean > 107) || (Median > 107) || (P90 > 300) || (PercOver260 > 12)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ccccff', color: 'bgblueb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ddddff', color: 'bgbluea', letter: 'A' };
            }
        }
        else if ((GeoMean > 14) || (Median > 14) || (P90 > 43) || (PercOver43 > 10)) {
            if ((GeoMean > 76) || (Median > 76) || (P90 > 224) || (PercOver43 > 27)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#aa0000', color: 'bgredf', letter: 'F' };
            }
            else if ((GeoMean > 63) || (Median > 63) || (P90 > 188) || (PercOver43 > 23)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#cc0000', color: 'bgrede', letter: 'E' };
            }
            else if ((GeoMean > 51) || (Median > 51) || (P90 > 152) || (PercOver43 > 20)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ff1111', color: 'bgredd', letter: 'D' };
            }
            else if ((GeoMean > 39) || (Median > 39) || (P90 > 115) || (PercOver43 > 17)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ff4444', color: 'bgredc', letter: 'C' };
            }
            else if ((GeoMean > 26) || (Median > 26) || (P90 > 79) || (PercOver43 > 13)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ff9999', color: 'bgredb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ffcccc', color: 'bgreda', letter: 'A' };
            }
        }
        else {
            if ((GeoMean > 12) || (Median > 12) || (P90 > 36) || (PercOver43 > 8)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#ccffcc', color: 'bggreenf', letter: 'F' };
            }
            else if ((GeoMean > 9) || (Median > 9) || (P90 > 29) || (PercOver43 > 7)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#99ff99', color: 'bggreene', letter: 'E' };
            }
            else if ((GeoMean > 7) || (Median > 7) || (P90 > 22) || (PercOver43 > 5)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#44ff44', color: 'bggreend', letter: 'D' };
            }
            else if ((GeoMean > 5) || (Median > 5) || (P90 > 14) || (PercOver43 > 3)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#11ff11', color: 'bggreenc', letter: 'C' };
            }
            else if ((GeoMean > 2) || (Median > 2) || (P90 > 7) || (PercOver43 > 2)) {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#00bb00', color: 'bggreenb', letter: 'B' };
            }
            else {
                colorAndLetter = <ColorAndLetter>{ hexColor: '#009900', color: 'bggreena', letter: 'A' };
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

    private KeepWebMWQMSamples() {
        this.UpdateWebMWQMSamples1980_2020(this.appLoadedService.WebMWQMSamples);
        console.debug(this.appLoadedService.WebMWQMSamples);
        if (this.DoNext) {
            // nothing else to add in the chain
        }
    }

    private UpdateWebMWQMSamples1980_2020(x: WebMWQMSamples) {
        this.appLoadedService.WebMWQMSamples = x;
    }
    private UpdateWebMWQMSamples2021_2060(x: WebMWQMSamples) {
        this.appLoadedService.WebMWQMSamples.MWQMSampleModelList.concat(x.MWQMSampleModelList);
        this.appLoadedService.WebMWQMSamples = this.appLoadedService.WebMWQMSamples;

        this.FillStatMWQMRunList();

        this.FillStatMWQMSiteList();

        if (this.DoNext) {
            if (this.componentDataLoadedService.DataLoadedWebSubsector()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }
        else {
            if (this.componentDataLoadedService.DataLoadedWebMWQMSamples()) {
                this.appStateService.Status = '';
                this.appStateService.Working = false;
            }
        }

        if (this.appStateService.GoogleJSLoaded) {
            if (this.appStateService.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    //...this.appLoadedService.WebMWQMSites.MWQMSiteModelList.,
                    //...[this.appLoadedService.WebMWQMSites.TVItemModel],
                ]);
            }
        }
    }
}