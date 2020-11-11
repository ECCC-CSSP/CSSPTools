import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { SamplingPlan } from 'src/app/models/generated/SamplingPlan.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { WebProvince } from 'src/app/models/generated/WebProvince.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { StructureTVFileListService } from './structure-tvfile-list.service';
import { SortTVItemListService } from './sort-tvitem-list.service';
import { MapService } from '../map/map.service';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';

@Injectable({
  providedIn: 'root'
})
export class WebProvinceService {

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService) {
  }

  GetWebProvince(TVItemID: number) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebProvince: {},
      ProvinceAreaList: [],
      BreadCrumbWebBaseList: [],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${this.appStateService.AppState$.getValue().Language}-CA/Read/WebProvince/${TVItemID}/1`;
    return this.httpClient.get<WebProvince>(url).pipe(
      map((x: any) => {
        this.UpdateWebProvince(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebProvince(x: WebProvince) {
    let ProvinceAreaList: WebBase[] = [];
    let ProvinceSamplingPlanList: SamplingPlan[] = [];

    // doing ProvinceAreaList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      ProvinceAreaList = x?.TVItemAreaList.filter((province) => { return province.TVItemModel?.TVItem.IsActive == true });
    }
    else {
      ProvinceAreaList = x?.TVItemAreaList;
    }

    // doing ProvinceSamplingPlanList
    // might need filtering in the future
    ProvinceSamplingPlanList = x?.SamplingPlanList;

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebProvince: x,
      ProvinceAreaList: this.sortTVItemListService.SortTVItemList(ProvinceAreaList, x?.TVItemParentList),
      ProvinceFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
      ProvinceSamplingPlanList: ProvinceSamplingPlanList,
      BreadCrumbWebBaseList: x?.TVItemParentList,
      Working: false
    });

    if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.Areas) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList);
    }
  }
}