import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { WebSector } from 'src/app/models/generated/WebSector.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { StructureTVFileListService } from './structure-tvfile-list.service';
import { SortTVItemListService } from './sort-tvitem-list.service';
import { MapService } from '../map/map.service';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';


@Injectable({
  providedIn: 'root'
})
export class WebSectorService {

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService) {
  }

  GetWebSector(TVItemID: number) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebSector: {},
      SectorSubsectorList: [],
      SectorMIKEScenarioList: [],
      BreadCrumbWebBaseList: [],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebSector/${TVItemID}/1`;
    return this.httpClient.get<WebSector>(url).pipe(
      map((x: any) => {
        this.UpdateWebSector(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
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
      Working: false
    });

    if (this.appStateService.AppState$.getValue().SectorSubComponent == SectorSubComponentEnum.Subsectors) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().SectorSubsectorList);
    }

    if (this.appStateService.AppState$.getValue().SectorSubComponent == SectorSubComponentEnum.MIKEScenarios) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().SectorMIKEScenarioList);
    }
  }
}