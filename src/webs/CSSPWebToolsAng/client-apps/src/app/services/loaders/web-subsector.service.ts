import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebTypeYearEnum } from 'src/app/enums/generated/WebTypeYearEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';
import { WebMWQMSiteService } from './web-mwqm-sites.service';

@Injectable({
    providedIn: 'root'
})
export class WebSubsectorService {
    private DoOther: boolean;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private webMWQMSiteService: WebMWQMSiteService) {
    }

    GetWebSubsector(TVItemID: number, DoOther: boolean) {
        this.DoOther = DoOther;
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSubsector: {},
            SubsectorMWQMSiteList: [],
            SubsectorMWQMRunList: [],
            SubsectorPolSourceSiteList: [],
            LabSheetModelList: [],
            MWQMAnalysisReportParameterList: [],
            MWQMSubsector: {},
            MWQMSubsectorLanguageList: [],
            UseOfSiteList: [],
            BreadCrumbWebBaseList: [],
        });
        this.appStateService.UpdateAppState(<AppState>{
            Status: this.appLanguageService.AppLanguage.LoadingSubsector[this.appStateService.AppState$?.getValue()?.Language],
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebSubsector/${TVItemID}/1`;
        return this.httpClient.get<WebSubsector>(url).pipe(
            map((x: any) => {
                this.UpdateWebSubsector(x);
                console.debug(x);
                if (DoOther) {
                    this.GetWebMWQMSite(TVItemID);
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    GetWebMWQMSite(TVItemID: number) {
        this.webMWQMSiteService.GetWebMWQMSite(TVItemID, this.DoOther).subscribe();
    }

    UpdateWebSubsector(x: WebSubsector) {
        let SubsectorMWQMSiteList: WebBase[] = [];
        let SubsectorMWQMRunList: WebBase[] = [];
        let SubsectorPolSourceSiteList: WebBase[] = [];

        // doing MWQMSiteList
        if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
            SubsectorMWQMSiteList = x?.TVItemMWQMSiteList.filter((mwqmsite) => { return mwqmsite.TVItemModel.TVItem.IsActive == true });
        }
        else {
            SubsectorMWQMSiteList = x?.TVItemMWQMSiteList;
        }

        // doing MWQMRunList
        if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
            SubsectorMWQMRunList = x?.TVItemMWQMRunList.filter((mwqmrun) => { return mwqmrun.TVItemModel.TVItem.IsActive == true });
        }
        else {
            SubsectorMWQMRunList = x?.TVItemMWQMRunList;
        }

        // doing PollutionSourceSiteList
        if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
            SubsectorPolSourceSiteList = x?.TVItemPolSourceSiteList.filter((polsourcesite) => { return polsourcesite.TVItemModel.TVItem.IsActive == true });
        }
        else {
            SubsectorPolSourceSiteList = x?.TVItemPolSourceSiteList;
        }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebSubsector: x,
            SubsectorMWQMSiteList: this.sortTVItemListService.SortTVItemList(SubsectorMWQMSiteList, x?.TVItemParentList),
            SubsectorMWQMRunList: this.sortTVItemListService.SortTVItemList(SubsectorMWQMRunList, x?.TVItemParentList),
            SubsectorPolSourceSiteList: this.sortTVItemListService.SortTVItemList(SubsectorPolSourceSiteList, x?.TVItemParentList),
            SubsectorFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
            LabSheetModelList: x?.LabSheetModelList,
            MWQMAnalysisReportParameterList: x?.MWQMAnalysisReportParameterList,
            MWQMSubsector: x?.MWQMSubsector,
            MWQMSubsectorLanguageList: x?.MWQMSubsectorLanguageList,
            UseOfSiteList: x?.UseOfSiteList,
            BreadCrumbWebBaseList: x?.TVItemParentList,
        });

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedSubsector()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }

        if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().SubsectorMWQMSiteList);
        }

        if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.MWQMRuns) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().SubsectorMWQMRunList);
        }

        if (this.appStateService.AppState$.getValue().SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().SubsectorPolSourceSiteList);
        }
    }
}