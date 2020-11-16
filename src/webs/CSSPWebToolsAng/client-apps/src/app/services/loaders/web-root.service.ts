import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/loaders/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/loaders/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';

@Injectable({
    providedIn: 'root'
})
export class WebRootService {
    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService,
        private mapService: MapService,
        private componentDataLoadedService: ComponentDataLoadedService) {
    }

    GetWebRoot(TVItemID: number) {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebRoot: {},
            RootCountryList: [],
            RootFileListList: [],
            BreadCrumbWebBaseList: [],
        });
        this.appStateService.UpdateAppState(<AppState>{ Working: true });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebRoot/${TVItemID}/1`;
        return this.httpClient.get<WebRoot>(url).pipe(
            map((x: any) => {
                this.UpdateWebRoot(x);
                console.debug(x);
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
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
            BreadCrumbWebBaseList: x?.TVItemParentList,
        });

        if (this.componentDataLoadedService.DataLoadedRoot()) {
            this.appStateService.UpdateAppState(<AppState>{ Working: false });
        }

        if (this.appStateService.AppState$.getValue().RootSubComponent == RootSubComponentEnum.Countries) {
            this.mapService.ClearMap();
            this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().RootCountryList);
        }
    }
}