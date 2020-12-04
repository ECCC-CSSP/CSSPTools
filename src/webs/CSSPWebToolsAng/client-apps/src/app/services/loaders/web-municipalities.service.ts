import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMunicipalities } from 'src/app/models/generated/web/WebMunicipalities.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';
import { WebClimateSiteService } from './web-climate-site.service';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';


@Injectable({
  providedIn: 'root'
})
export class WebMunicipalitiesService {
  private TVItemID: number;
  private DoOther: boolean;
  private sub: Subscription;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private sortTVItemListService: SortTVItemListService,
    private mapService: MapService,
    private webClimateSiteService: WebClimateSiteService,
    private componentDataLoadedService: ComponentDataLoadedService) {
  }

  DoWebMunicipalities(TVItemID: number, DoOther: boolean) {
    this.TVItemID = TVItemID;
    this.DoOther = DoOther;

    this.sub ? this.sub.unsubscribe() : null;

    if (this.appLoadedService.AppLoaded$.getValue()?.WebMunicipalities?.TVItemModel?.TVItem?.TVItemID == TVItemID) {
      this.KeepWebMunicipalities();
    }
    else {
      this.sub = this.GetWebMunicipalities().subscribe();
    }
  }

  private GetWebMunicipalities() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMunicipalities: {} });
    this.appStateService.UpdateAppState(<AppState>{
      Status: this.appLanguageService.AppLanguage.LoadingProvinceMunicipalities[this.appStateService.AppState$?.getValue()?.Language],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMunicipalities/${this.TVItemID}/1`;
    return this.httpClient.get<WebMunicipalities>(url).pipe(
      map((x: any) => {
        this.UpdateWebMunicipalities(x);
        console.debug(x);
        if (this.DoOther) {
          this.DoWebClimateSite();
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  private DoWebClimateSite() {
    this.webClimateSiteService.DoWebClimateSite(this.TVItemID, this.DoOther);
  }

  private KeepWebMunicipalities() {
    this.UpdateWebMunicipalities(this.appLoadedService.AppLoaded$?.getValue()?.WebMunicipalities);
    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebMunicipalities);
    if (this.DoOther) {
      this.DoWebClimateSite();
    }
  }

  private UpdateWebMunicipalities(x: WebMunicipalities) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebMunicipalities: x,
      ProvinceMunicipalityList: this.sortTVItemListService.SortTVItemList(x.TVItemMunicipalityList, x?.TVItemParentList),
    });

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedProvince()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      if (this.componentDataLoadedService.DataLoadedMunicipalities()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }

    let webBaseProvince: WebBase[] = <WebBase[]>[
      <WebBase>{ TVItemModel: this.appLoadedService.AppLoaded$.getValue().WebProvince.TVItemModel },
    ];

    if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
      if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.Municipalities) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().ProvinceMunicipalityList,
          ...webBaseProvince
        ]);
      }
    }
  }
}