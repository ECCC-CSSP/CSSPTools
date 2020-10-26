import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebArea } from 'src/app/models/generated/WebArea.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { StructureTVFileListService } from './structure-tvfile-list.service';
import { SortTVItemListService } from './sort-tvitem-list.service';
import { MapService } from '../map/map.service';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';


@Injectable({
  providedIn: 'root'
})
export class WebAreaService {
  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService) {
  }

  GetWebArea(TVItemID: number) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebArea: {}, AreaSectorList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebArea/${TVItemID}/1`;
    return this.httpClient.get<WebArea>(url).pipe(
      map((x: any) => {
        this.UpdateWebArea(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
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
      Working: false
    });

    if (this.appStateService.AppState$.getValue().AreaSubComponent == AreaSubComponentEnum.Sectors) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().AreaSectorList);    
      }
  }
}