import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { SamplingPlan } from 'src/app/models/generated/db/SamplingPlan.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { WebMunicipalitiesService } from './web-municipalities.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';
import { HistoryService } from '../helpers/history.service';

@Injectable({
  providedIn: 'root'
})
export class WebProvinceService {
  private TVItemID: number;
  private DoOther: boolean;
  private sub: Subscription;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    public webMunicipalitiesService: WebMunicipalitiesService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService,
    private historyService: HistoryService) {
  }

  DoWebProvince(TVItemID: number, DoOther: boolean) {
    this.TVItemID = TVItemID;
    this.DoOther = DoOther;

    this.sub ? this.sub.unsubscribe() : null;

    if (this.appLoadedService.AppLoaded$.getValue()?.WebProvince?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
      this.KeepWebProvince();
    }
    else {
      this.sub = this.GetWebProvince().subscribe();
    }
  }

  private GetWebProvince() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebProvince: {},
      ProvinceAreaList: [],
      ProvinceFileListList: [],
      ProvinceSamplingPlanList: [],
      BreadCrumbProvinceWebBaseList: [],
      BreadCrumbWebBaseList: [],
      WebMunicipalities: {},
      WebClimateSite: {},
      WebHydrometricSite: {},
    });
    this.appStateService.UpdateAppState(<AppState>{
      Status: this.appLanguageService.AppLanguage.LoadingProvince[this.appStateService.AppState$?.getValue()?.Language],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebProvince/${this.TVItemID}/1`;
    return this.httpClient.get<WebProvince>(url).pipe(
      map((x: any) => {
        this.UpdateWebProvince(x);
        console.debug(x);
        if (this.DoOther) {
          this.DoWebMunicipalities();
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  private DoWebMunicipalities() {
    this.webMunicipalitiesService.DoWebMunicipalities(this.TVItemID, this.DoOther);
  }

  private KeepWebProvince() {
    this.UpdateWebProvince(this.appLoadedService.AppLoaded$?.getValue()?.WebProvince);
    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebProvince);
    if (this.DoOther) {
      this.DoWebMunicipalities();
    }
  }

  private UpdateWebProvince(x: WebProvince) {
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
      BreadCrumbProvinceWebBaseList: x?.TVItemParentList,
      BreadCrumbWebBaseList: x?.TVItemParentList
    });

    this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebProvince?.TVItemModel);

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedProvince()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
    }

    let webBaseProvince: WebBase[] = <WebBase[]>[
      <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebProvince.TVItemModel },
    ];

    if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
      if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.Areas) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList,
          ...webBaseProvince
        ]);
      }

      if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.Files) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList,
          ...webBaseProvince
        ]);
      }

      if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.OpenData) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList,
          ...webBaseProvince
        ]);
      }

      if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.SamplingPlan) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList,
          ...webBaseProvince
        ]);
      }

      if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.ProvinceTools) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().ProvinceAreaList,
          ...webBaseProvince
        ]);
      }
    }
  }
}