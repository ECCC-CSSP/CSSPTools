import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebDrogueRuns } from 'src/app/models/generated/web/WebDrogueRuns.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { MapService } from '../map/map.service';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';

@Injectable({
  providedIn: 'root'
})
export class WebDrogueRunsService {
  private TVItemID: number;
  private DoNext: boolean;
  private ForceReload: boolean;
  private sub: Subscription;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private mapService: MapService,
    private appLanguageService: AppLanguageService,
    private componentDataLoadedService: ComponentDataLoadedService) {
  }

  DoWebDrogueRuns(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
    this.TVItemID = TVItemID;
    this.DoNext = DoNext;
    this.ForceReload = ForceReload;
    this.mapService.ClearMap();

    this.sub ? this.sub.unsubscribe() : null;

    if (ForceReload) {
      this.sub = this.GetWebDrogueRuns().subscribe();
    }
    else {
      if (this.componentDataLoadedService.DataLoadedWebDrogueRuns()) {
        this.KeepWebDrogueRuns();
      }
      else {
        this.sub = this.GetWebDrogueRuns().subscribe();
      }
    }
  }

  private GetWebDrogueRuns() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.WebDrogueRuns = <WebDrogueRuns>{};

    let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
    this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebDrogueRuns - ${ForceReloadText}`;
    this.appStateService.Working = true;

    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebDrogueRuns/${this.TVItemID}`;
    return this.httpClient.get<WebDrogueRuns>(url).pipe(
      map((x: any) => {
        this.UpdateWebDrogueRuns(x);
        console.debug(x);
        if (this.DoNext) {
          // end of chain
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

  private KeepWebDrogueRuns() {
    this.UpdateWebDrogueRuns(this.appLoadedService.WebDrogueRuns);
    console.debug(this.appLoadedService.WebDrogueRuns);
    if (this.DoNext) {
      // end of chain
    }
  }

  private UpdateWebDrogueRuns(x: WebDrogueRuns) {
    this.appLoadedService.WebDrogueRuns = x;

    if (this.componentDataLoadedService.DataLoadedWebDrogueRuns()) {
      this.appStateService.Status = '';
      this.appStateService.Working = false;
    }

    if (this.appStateService.GoogleJSLoaded) {
      if (this.appStateService.ProvinceSubComponent == ProvinceSubComponentEnum.Areas) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebProvince.TVItemModelAreaList,
          ...[this.appLoadedService.WebProvince.TVItemModel]
        ]);
      }

      if (this.appStateService.ProvinceSubComponent == ProvinceSubComponentEnum.Municipalities) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebProvince.TVItemModelMunicipalityList,
          ...[this.appLoadedService.WebProvince.TVItemModel]
        ]);
      }

      if (this.appStateService.ProvinceSubComponent == ProvinceSubComponentEnum.Files) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebProvince.TVItemModelAreaList,
          ...[this.appLoadedService.WebProvince.TVItemModel]
        ]);
      }

      if (this.appStateService.ProvinceSubComponent == ProvinceSubComponentEnum.OpenData) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebProvince.TVItemModelAreaList,
          ...[this.appLoadedService.WebProvince.TVItemModel]
        ]);
      }

      if (this.appStateService.ProvinceSubComponent == ProvinceSubComponentEnum.SamplingPlan) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebProvince.TVItemModelAreaList,
          ...[this.appLoadedService.WebProvince.TVItemModel]
        ]);
      }

      if (this.appStateService.ProvinceSubComponent == ProvinceSubComponentEnum.ProvinceTools) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebProvince.TVItemModelAreaList,
          ...[this.appLoadedService.WebProvince.TVItemModel]
        ]);
      }
    }
  }
}