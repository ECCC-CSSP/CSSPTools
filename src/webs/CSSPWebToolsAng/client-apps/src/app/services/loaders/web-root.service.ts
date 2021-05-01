import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebAllAddressesService } from 'src/app/services/loaders/web-all-addresses.service';

@Injectable({
    providedIn: 'root'
})
export class WebRootService {
    private DoOther: boolean;
    private sub: Subscription;
    LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

    constructor(private httpClient: HttpClient,
        private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private appLanguageService: AppLanguageService,
        private sortTVItemListService: SortTVItemListService,
        private structureTVFileListService: StructureTVFileListService,
        private mapService: MapService,
        private webAllAddressesService: WebAllAddressesService,
        private componentDataLoadedService: ComponentDataLoadedService,
        private historyService: HistoryService) {
    }

    DoWebRoot(DoOther: boolean) {
        this.DoOther = DoOther;

        this.sub ? this.sub.unsubscribe() : null;

        if (this.appLoadedService.AppLoaded$.getValue()?.WebRoot) {
            this.KeepWebRoot();
        }
        else {
            this.sub = this.GetWebRoot().subscribe();
        }
    }

    private GetWebRoot() {
        let languageEnum = GetLanguageEnum();
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebRoot: {} });
        this.appStateService.UpdateAppState(<AppState>{
            Status: `${this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebRoot }`,
            Working: true
        });
        let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebRoot`;
        return this.httpClient.get<WebRoot>(url).pipe(
            map((x: any) => {
                this.UpdateWebRoot(x);
                console.debug(x);
                if (this.DoOther) {
                    this.DoWebAllAddresses();
                }
            }),
            catchError(e => of(e).pipe(map(e => {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
                console.debug(e);
            })))
        );
    }

    private DoWebAllAddresses() {
        this.webAllAddressesService.DoWebAllAddresses(this.DoOther);
    }

    private KeepWebRoot() {
        this.UpdateWebRoot(this.appLoadedService.AppLoaded$?.getValue()?.WebRoot);
        console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebRoot);
        if (this.DoOther) {
            this.DoWebAllAddresses();
        }
    }

    private UpdateWebRoot(x: WebRoot) {
        // let RootCountryList: WebBase[] = [];

        // if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
        //     RootCountryList = x?.TVItemCountryList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true });
        // }
        // else {
        //     RootCountryList = x?.TVItemCountryList;
        // }

        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
            WebRoot: x,
            // RootCountryList: this.sortTVItemListService.SortTVItemList(RootCountryList, x?.TVItemParentList),
            // RootFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
            // BreadCrumbRootWebBaseList: x?.TVItemParentList,
            // BreadCrumbWebBaseList: x?.TVItemParentList
        });

        this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebRoot?.TVItemStatMapModel);

        if (this.DoOther) {
            if (this.componentDataLoadedService.DataLoadedWebRoot()) {
                this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
            }
        }
        else {
            this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
        }

        // let webBaseRoot: TVItemStatMapModel[] = <TVItemStatMapModel[]>[
        //     <TVItemStatMapModel>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebRoot..TVItemStatMapModel },
        // ];

        if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
            if (this.appStateService.AppState$.getValue().RootSubComponent == RootSubComponentEnum.Countries) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    ...this.appLoadedService.AppLoaded$.getValue().WebRoot.TVItemStatMapModelCountryList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebRoot.TVItemStatMapModel]
                ]);
            }

            if (this.appStateService.AppState$.getValue().RootSubComponent == RootSubComponentEnum.Files) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    ...this.appLoadedService.AppLoaded$.getValue().WebRoot.TVItemStatMapModelCountryList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebRoot.TVItemStatMapModel]
                ]);
            }

            if (this.appStateService.AppState$.getValue().RootSubComponent == RootSubComponentEnum.ExportArcGIS) {
                this.mapService.ClearMap();
                this.mapService.DrawObjects([
                    ...this.appLoadedService.AppLoaded$.getValue().WebRoot.TVItemStatMapModelCountryList,
                    ...[this.appLoadedService.AppLoaded$.getValue().WebRoot.TVItemStatMapModel]
                ]);
            }
        }
    }
}