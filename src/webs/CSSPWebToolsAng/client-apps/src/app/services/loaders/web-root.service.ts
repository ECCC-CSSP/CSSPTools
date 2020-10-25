import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { WebRoot } from 'src/app/models/generated/WebRoot.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { StructureTVFileListService } from './structure-tvfile-list.service';
import { SortTVItemListService } from './sort-tvitem-list.service';

@Injectable({
    providedIn: 'root'
})
export class WebRootService {
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService) {
    }

    GetWebRoot(TVItemID: number) {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebRoot: {}, RootCountryList: [], BreadCrumbWebBaseList: [], Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebRoot/${TVItemID}/1`;
        return this.httpClient.get<WebRoot>(url).pipe(
            map((x: any) => {
                this.UpdateWebRoot(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    UpdateWebRoot(x: WebRoot) {
        let RootCountryList: WebBase[] = [];

        if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
            RootCountryList = x?.TVItemCountryList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true });
        }
        else {
            RootCountryList = x?.TVItemCountryList;
        }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebRoot: x,
            RootCountryList: this.sortTVItemListService.SortTVItemList(RootCountryList, x?.TVItemParentList),
            RootFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
            BreadCrumbWebBaseList: x?.TVItemParentList, Working: false
        });
    }
}