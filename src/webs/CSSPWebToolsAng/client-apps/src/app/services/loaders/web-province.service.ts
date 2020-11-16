import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { SamplingPlan } from 'src/app/models/generated/db/SamplingPlan.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/loaders/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/loaders/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebMunicipalitiesService } from './web-municipalities.service';
import { AppState } from 'src/app/models/AppState.model';

@Injectable({
  providedIn: 'root'
})
export class WebProvinceService {

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    public webMunicipalitiesService: WebMunicipalitiesService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService) {
  }

  GetWebProvince(TVItemID: number) {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebProvince: {},
      ProvinceAreaList: [],
      ProvinceFileListList: [],
      ProvinceSamplingPlanList: [],
      BreadCrumbWebBaseList: [],
    });
    this.appStateService.UpdateAppState(<AppState>{ Working: true });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebProvince/${TVItemID}/1`;
    return this.httpClient.get<WebProvince>(url).pipe(
      map((x: any) => {
        this.UpdateWebProvince(x);
        console.debug(x);
        this.GetWebMunicipalities(TVItemID);      
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  GetWebMunicipalities(TVItemID: number)
  {
    this.webMunicipalitiesService.GetWebMunicipalities(TVItemID).subscribe();
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
    });

    if (this.componentDataLoadedService.DataLoadedProvince()) {
      this.appStateService.UpdateAppState(<AppState>{ Working: false });
    }

    if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.Areas) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList);
    }
  }

}