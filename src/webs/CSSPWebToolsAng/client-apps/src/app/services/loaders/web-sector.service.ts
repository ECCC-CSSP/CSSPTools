import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';


@Injectable({
  providedIn: 'root'
})
export class WebSectorService {
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

  GetWebSector(TVItemID: number, DoOther: boolean) {
    this.DoOther = DoOther;
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebSector: {},
      SectorSubsectorList: [],
      SectorMIKEScenarioList: [],
      BreadCrumbWebBaseList: [],
    });
    this.appStateService.UpdateAppState(<AppState>{
      Status: this.appLanguageService.AppLanguage.LoadingSector[this.appStateService.AppState$?.getValue()?.Language],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebSector/${TVItemID}/1`;
    return this.httpClient.get<WebSector>(url).pipe(
      map((x: any) => {
        this.UpdateWebSector(x);
        console.debug(x);
        if (DoOther) {
          // nothing more to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebSector(x: WebSector) {
    let SectorSubsectorList: WebBase[] = [];
    let SectorMIKEScenarioList: WebBase[] = [];

    // doing SectorSubsectorList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SectorSubsectorList = x?.TVItemSubsectorList.filter((subsector) => { return subsector.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SectorSubsectorList = x?.TVItemSubsectorList;
    }

    // doing SectorMIKEScenarioList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SectorMIKEScenarioList = x?.TVItemMikeScenarioList.filter((mikescenario) => { return mikescenario.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SectorMIKEScenarioList = x?.TVItemMikeScenarioList;
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebSector: x,
      SectorSubsectorList: this.sortTVItemListService.SortTVItemList(SectorSubsectorList, x?.TVItemParentList),
      SectorMIKEScenarioList: this.sortTVItemListService.SortTVItemList(SectorMIKEScenarioList, x?.TVItemParentList),
      SectorFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
      BreadCrumbWebBaseList: x?.TVItemParentList,
    });

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedSector()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
    }

    let webBaseSector: WebBase[] = <WebBase[]>[
      <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebSector.TVItemModel },
    ];

    if (this.appStateService.AppState$.getValue().SectorSubComponent == SectorSubComponentEnum.Subsectors) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects([
        ...this.appLoadedService.AppLoaded$.getValue().SectorSubsectorList,
        ...webBaseSector
      ]);
    }

    if (this.appStateService.AppState$.getValue().SectorSubComponent == SectorSubComponentEnum.MIKEScenarios) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects([
        ...this.appLoadedService.AppLoaded$.getValue().SectorSubsectorList,
        ...webBaseSector,
        ...this.appLoadedService.AppLoaded$.getValue().SectorMIKEScenarioList
      ]);
    }
  }
}