import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { SectorSubComponentEnum } from 'src/app/enums/generated/SectorSubComponentEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';


@Injectable({
  providedIn: 'root'
})
export class WebSectorService {
  private TVItemID: number;
  private DoNext: boolean;
  private ForceReload: boolean;
  private sub: Subscription;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService,
    private historyService: HistoryService) {
  }

  DoWebSector(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
    this.TVItemID = TVItemID;
    this.DoNext = DoNext;
    this.ForceReload = ForceReload;
    this.mapService.ClearMap();

    this.sub ? this.sub.unsubscribe() : null;

    if (ForceReload) {
      this.sub = this.GetWebSector().subscribe();
    }
    else {
      if (this.componentDataLoadedService.DataLoadedWebSector()) {
        this.KeepWebSector();
      }
      else {
        this.sub = this.GetWebSector().subscribe();
      }
    }
  }

  private GetWebSector() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.WebSector = <WebSector>{};

    let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
    this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebSector - ${ForceReloadText}`;
    this.appStateService.Working = true;

    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebSector/${this.TVItemID}`;
    return this.httpClient.get<WebSector>(url).pipe(
      map((x: any) => {
        this.UpdateWebSector(x);
        console.debug(x);
        if (this.DoNext) {
          // nothing more to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.Status = ''
        this.appStateService.Working = false
        this.appStateService.Error = <HttpErrorResponse>e;
        console.debug(e);
      })))
    );
  }

  private KeepWebSector() {
    this.UpdateWebSector(this.appLoadedService.WebSector);
    console.debug(this.appLoadedService.WebSector);
    if (this.DoNext) {
      // nothing more to add in the chain
    }
  }

  private UpdateWebSector(x: WebSector) {
    this.appLoadedService.WebSector = x;
    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;

    this.historyService.AddHistory(this.appLoadedService.WebSector?.TVItemModel);

    if (this.componentDataLoadedService.DataLoadedWebSector()) {
      this.appStateService.Status = '';
      this.appStateService.Working = false;
    }

    if (this.appStateService.GoogleJSLoaded) {
      if (this.appStateService.SectorSubComponent == SectorSubComponentEnum.Subsectors) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebSector.TVItemModelSubsectorList,
          ...[this.appLoadedService.WebSector.TVItemModel]
        ]);
      }

      if (this.appStateService.SectorSubComponent == SectorSubComponentEnum.MIKEScenarios) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebSector.TVItemModelSubsectorList,
          ...[this.appLoadedService.WebSector.TVItemModel]
        ]);
      }
    }
  }
}