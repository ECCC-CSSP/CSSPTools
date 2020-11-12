import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMunicipalities } from 'src/app/models/generated/web/WebMunicipalities.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapService } from 'src/app/services/map/map.service';
import { SortTVItemListService } from 'src/app/services/loaders/sort-tvitem-list.service';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';


@Injectable({
  providedIn: 'root'
})
export class WebMunicipalitiesService {

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private sortTVItemListService: SortTVItemListService,
    private mapService: MapService) {
  }

  GetWebMunicipalities(TVItemID: number) {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMunicipalities: {}, Working: true });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebMunicipalities/${TVItemID}/1`;
    return this.httpClient.get<WebMunicipalities>(url).pipe(
      map((x: any) => {
        this.UpdateWebMunicipalities(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebMunicipalities(x: WebMunicipalities) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebMunicipalities: x,
      ProvinceMunicipalityList: this.sortTVItemListService.SortTVItemList(x.TVItemMunicipalityList, x?.TVItemParentList),
      Working: false
    });

    if (this.appStateService.AppState$.getValue().ProvinceSubComponent == ProvinceSubComponentEnum.Municipalities) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().ProvinceMunicipalityList);
    }

  }
}