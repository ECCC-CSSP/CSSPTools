import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';


@Injectable({
  providedIn: 'root'
})
export class WebAreaService {
  private TVItemID: number;
  private DoOther: boolean;
  private sub: Subscription;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService) {
  }

  DoWebArea(TVItemID: number, DoOther: boolean) {
    this.TVItemID = TVItemID;
    this.DoOther = DoOther;

    this.sub ? this.sub.unsubscribe() : null;

    if (this.appLoadedService.AppLoaded$.getValue()?.WebArea?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
      this.KeepWebArea();
    }
    else {
      this.sub = this.GetWebArea().subscribe();
    }
  }

  private GetWebArea() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebArea: {},
      AreaSectorList: [],
      BreadCrumbAreaWebBaseList: [],
      BreadCrumbWebBaseList: []
    });
    this.appStateService.UpdateAppState(<AppState>{
      Status: this.appLanguageService.AppLanguage.LoadingArea[this.appStateService.AppState$?.getValue()?.Language],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebArea/${this.TVItemID}/1`;
    return this.httpClient.get<WebArea>(url).pipe(
      map((x: any) => {
        this.UpdateWebArea(x);
        console.debug(x);
        if (this.DoOther) {
          // nothing else to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  private KeepWebArea() {
    this.UpdateWebArea(this.appLoadedService.AppLoaded$?.getValue()?.WebArea);
    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebArea);
    if (this.DoOther) {
      // nothing else to add in the chain
    }
  }

  private UpdateWebArea(x: WebArea) {
    let AreaSectorList: WebBase[] = [];

    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      AreaSectorList = x?.TVItemSectorList.filter((sector) => { return sector.TVItemModel.TVItem.IsActive == true });
    }
    else {
      AreaSectorList = x?.TVItemSectorList;
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebArea: x,
      AreaSectorList: this.sortTVItemListService.SortTVItemList(AreaSectorList, x?.TVItemParentList),
      AreaFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
      BreadCrumbAreaWebBaseList: x?.TVItemParentList,
      BreadCrumbWebBaseList: x?.TVItemParentList
    });

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedArea()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
    }

    let webBaseArea: WebBase[] = <WebBase[]>[
      <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebArea.TVItemModel },
    ];

    if (this.appStateService.AppState$.getValue().AreaSubComponent == AreaSubComponentEnum.Sectors) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects([
        ...this.appLoadedService.AppLoaded$.getValue().AreaSectorList,
        ...webBaseArea
      ]);
    }

    if (this.appStateService.AppState$.getValue().AreaSubComponent == AreaSubComponentEnum.Files) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects([
        ...this.appLoadedService.AppLoaded$.getValue().AreaSectorList,
        ...webBaseArea
      ]);
    }
  }
}