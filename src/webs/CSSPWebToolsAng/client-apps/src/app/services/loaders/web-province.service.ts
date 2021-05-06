import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebClimateSitesService } from './web-climate-sites.service';

@Injectable({
  providedIn: 'root'
})
export class WebProvinceService {
  private TVItemID: number;
  private DoNext: boolean;
  private ForceReload: boolean;
  private sub: Subscription;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private mapService: MapService,
    private webClimateSitesService: WebClimateSitesService,
    private componentDataLoadedService: ComponentDataLoadedService,
    private historyService: HistoryService) {
  }

  DoWebProvince(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
    this.TVItemID = TVItemID;
    this.DoNext = DoNext;
    this.ForceReload = ForceReload;

    this.sub ? this.sub.unsubscribe() : null;

    if (ForceReload) {
      this.sub = this.GetWebProvince().subscribe();
    }
    else {
      if (this.componentDataLoadedService.DataLoadedWebProvince()) {
        this.KeepWebProvince();
      }
      else {
        this.sub = this.GetWebProvince().subscribe();
      }
    }
  }

  private GetWebProvince() {
    this.appLoadedService.WebProvince = <WebProvince>{};

    let NextText = this.DoNext ? `${this.appLanguageService.Next[this.appLanguageService.LangID]} - WebClimateSites` : '';
    let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
    this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebProvince - ${NextText} - ${ForceReloadText}`;
    this.appStateService.Working = true;

    let url: string = `${this.appLoadedService.BaseApiUrl}${this.appLanguageService.Language}-CA/Read/WebProvince/${this.TVItemID}`;
    return this.httpClient.get<WebProvince>(url).pipe(
      map((x: any) => {
        this.UpdateWebProvince(x);
        console.debug(x);
        if (this.DoNext) {
          this.DoWebClimateSites();
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

  private DoWebClimateSites() {
    this.webClimateSitesService.DoWebClimateSites(this.TVItemID, this.DoNext);
}

  private KeepWebProvince() {
    this.UpdateWebProvince(this.appLoadedService.WebProvince);
    console.debug(this.appLoadedService.WebProvince);
    if (this.DoNext) {
      this.DoWebClimateSites();
    }
  }

  private UpdateWebProvince(x: WebProvince) {
    this.appLoadedService.WebProvince = x;

    this.historyService.AddHistory(this.appLoadedService.WebProvince?.TVItemModel);

    if (this.DoNext) {
      if (this.componentDataLoadedService.DataLoadedWebProvince()) {
        this.appStateService.Status = '';
        this.appStateService.Working = false;
      }
    }
    else {
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