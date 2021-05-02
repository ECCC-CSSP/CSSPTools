import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';

@Injectable({
  providedIn: 'root'
})
export class WebCountryService {
  private TVItemID: number;
  private DoOther: boolean;
  private sub: Subscription;
  LangID: number = this.appStateService.AppState$?.getValue()?.Language == LanguageEnum.fr ? 1 : 0;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService,
    private historyService: HistoryService) {
  }

  DoWebCountry(TVItemID: number, DoOther: boolean) {
    this.TVItemID = TVItemID;
    this.DoOther = DoOther;

    this.sub ? this.sub.unsubscribe() : null;

    if (this.appLoadedService.AppLoaded$.getValue()?.WebCountry) {
      this.KeepWebCountry();
    }
    else {
      this.sub = this.GetWebCountry().subscribe();
    }
  }

  private GetWebCountry() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebCountry: {},
    });
    this.appStateService.UpdateAppState(<AppState>{
      Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebCountry }`,
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebCountry/${this.TVItemID}`;
    return this.httpClient.get<WebCountry>(url).pipe(
      map((x: any) => {
        this.UpdateWebCountry(x);
        console.debug(x);
        if (this.DoOther) {
          // nothing more to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  private KeepWebCountry() {
    this.UpdateWebCountry(this.appLoadedService.AppLoaded$?.getValue()?.WebCountry);
    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebCountry);
    if (this.DoOther) {
      // nothing more to add in the chain
    }
  }

  private UpdateWebCountry(x: WebCountry) {

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebCountry: x,
    });

    this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebCountry?.TVItemModel);

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedWebCountry()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
    }

    if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
      if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.Provinces) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.Files) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.OpenDataNational) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.EmailDistributionList) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModel]
        ]);
      }

      if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.RainExceedance) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModelProvinceList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebCountry.TVItemModel]
        ]);
      }
    }
  }
}