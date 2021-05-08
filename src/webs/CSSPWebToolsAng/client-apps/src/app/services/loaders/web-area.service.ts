import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';


@Injectable({
  providedIn: 'root'
})
export class WebAreaService {
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

  DoWebArea(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
    this.TVItemID = TVItemID;
    this.DoNext = DoNext;
    this.ForceReload = ForceReload;
    this.mapService.ClearMap();

    this.sub ? this.sub.unsubscribe() : null;

    if (ForceReload) {
      this.sub = this.GetWebArea().subscribe();
    }
    else {
      if (this.componentDataLoadedService.DataLoadedWebArea()) {
        this.KeepWebArea();
      }
      else {
        this.sub = this.GetWebArea().subscribe();
      }
    }
  }

  private GetWebArea() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.WebArea = <WebArea>{};

    let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
    this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebAllTels - ${ForceReloadText}`;
    this.appStateService.Working = true;

    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebArea/${this.TVItemID}`;
    return this.httpClient.get<WebArea>(url).pipe(
      map((x: any) => {
        this.UpdateWebArea(x);
        console.debug(x);
        if (this.DoNext) {
          // nothing else to add in the chain
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

  private KeepWebArea() {
    this.UpdateWebArea(this.appLoadedService.WebArea);
    console.debug(this.appLoadedService.WebArea);
    if (this.DoNext) {
      // nothing else to add in the chain
    }
  }

  private UpdateWebArea(x: WebArea) {
    this.appLoadedService.WebArea = x;
    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;

    this.historyService.AddHistory(this.appLoadedService.WebArea?.TVItemModel);

    if (this.componentDataLoadedService.DataLoadedWebArea()) {
      this.appStateService.Status = '';
      this.appStateService.Working = false;
    }

    if (this.appStateService.GoogleJSLoaded) {
      if (this.appStateService.AreaSubComponent == AreaSubComponentEnum.Sectors) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebArea.TVItemModelSectorList,
          ...[this.appLoadedService.WebArea.TVItemModel]
        ]);
      }

      if (this.appStateService.AreaSubComponent == AreaSubComponentEnum.Files) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebArea.TVItemModelSectorList,
          ...[this.appLoadedService.WebArea.TVItemModel]
        ]);
      }
    }
  }
}