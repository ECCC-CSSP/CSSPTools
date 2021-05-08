import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

@Injectable({
  providedIn: 'root'
})
export class WebCountryService {
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

  DoWebCountry(TVItemID: number, DoNext: boolean = true, ForceReload: boolean = true) {
    this.TVItemID = TVItemID;
    this.DoNext = DoNext;
    this.ForceReload = ForceReload;
    this.mapService.ClearMap();

    this.sub ? this.sub.unsubscribe() : null;

    if (ForceReload) {
      this.sub = this.GetWebCountry().subscribe();
    }
    else {
      if (this.componentDataLoadedService.DataLoadedWebCountry()) {
        this.KeepWebCountry();
      }
      else {
        this.sub = this.GetWebCountry().subscribe();
      }
    }
  }

  private GetWebCountry() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.WebCountry = <WebCountry>{};

    let ForceReloadText = this.ForceReload ? `${this.appLanguageService.ForceReload[this.appLanguageService.LangID]}` : '';
    this.appStateService.Status = `${this.appLanguageService.Loading[this.appLanguageService.LangID]} - WebCountry - ${ForceReloadText}`;
    this.appStateService.Working = true;

    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appLanguageService.Language]}-CA/Read/WebCountry/${this.TVItemID}`;
    return this.httpClient.get<WebCountry>(url).pipe(
      map((x: any) => {
        this.UpdateWebCountry(x);
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

  private KeepWebCountry() {
    this.UpdateWebCountry(this.appLoadedService.WebCountry);
    console.debug(this.appLoadedService.WebCountry);
    if (this.DoNext) {
      // nothing more to add in the chain
    }
  }

  private UpdateWebCountry(x: WebCountry) {
    this.appLoadedService.WebCountry = x;
    this.appLoadedService.BreadCrumbTVItemModelList = x.TVItemModelParentList;

    this.historyService.AddHistory(this.appLoadedService.WebCountry?.TVItemModel);

    if (this.componentDataLoadedService.DataLoadedWebCountry()) {
      this.appStateService.Status = '';
      this.appStateService.Working = false;
    }

    if (this.appStateService.GoogleJSLoaded) {
      if (this.appStateService.CountrySubComponent == CountrySubComponentEnum.Provinces) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.CountrySubComponent == CountrySubComponentEnum.Files) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.CountrySubComponent == CountrySubComponentEnum.OpenDataNational) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.CountrySubComponent == CountrySubComponentEnum.EmailDistributionList) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.CountrySubComponent == CountrySubComponentEnum.RainExceedance) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.WebCountry.TVItemModel]
        ]);
      }
    }
  }
}