import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ProvinceSubComponentEnum } from 'src/app/enums/generated/ProvinceSubComponentEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebMunicipalities } from 'src/app/models/generated/WebMunicipalities.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { MapService } from '../map/map.service';
import { SortTVItemListService } from './sort-tvitem-list.service';


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
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebMunicipalities: {}, Working: true });
    let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebMunicipalities/${TVItemID}/1`;
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