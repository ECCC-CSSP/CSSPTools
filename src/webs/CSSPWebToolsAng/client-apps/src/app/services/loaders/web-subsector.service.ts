import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { WebSubsector } from 'src/app/models/generated/WebSubsector.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { SortTVFileListService } from './sort-tvfile-list.service';
import { SortTVItemListService } from './sort-tvitem-list.service';


@Injectable({
    providedIn: 'root'
})
export class WebSubsectorService {

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService, 
        private appLoadedService: AppLoadedService,
        private sortTVItemListService: SortTVItemListService,
        private sortTVFileListService: SortTVFileListService) {
      }
    
    GetWebSubsector(TVItemID: number) {
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
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebSubsector/${TVItemID}/1`;
        return this.httpClient.get<WebSubsector>(url).pipe(
            map((x: any) => {
                this.UpdateWebSubsector(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
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
            SubsectorFileList: this.sortTVFileListService.SortTVFileList(SubsectorMWQMSiteList, x.TVItemModel.TVFileModelList, x?.TVItemParentList), 
            LabSheetModelList: x?.LabSheetModelList,
            MWQMAnalysisReportParameterList: x?.MWQMAnalysisReportParameterList,
            MWQMSubsector: x?.MWQMSubsector,
            MWQMSubsectorLanguageList: x?.MWQMSubsectorLanguageList,
            UseOfSiteList: x?.UseOfSiteList,
            BreadCrumbWebBaseList: x?.TVItemParentList,
            Working: false
        });
    }
}