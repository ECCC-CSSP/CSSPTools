import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
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
  private DoOther: boolean;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService) {
  }

  GetWebArea(TVItemID: number, DoOther: boolean) {
    this.DoOther = DoOther;
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebArea: {}, AreaSectorList: [], BreadCrumbWebBaseList: [] });
    this.appStateService.UpdateAppState(<AppState>{
      Status: this.appLanguageService.AppLanguage.LoadingArea[this.appStateService.AppState$?.getValue()?.Language],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebArea/${TVItemID}/1`;
    return this.httpClient.get<WebArea>(url).pipe(
      map((x: any) => {
        this.UpdateWebArea(x);
        console.debug(x);
        if (DoOther) {
          // nothing else to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebArea(x: WebArea) {
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
      BreadCrumbWebBaseList: x?.TVItemParentList,
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