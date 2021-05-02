import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Subscription } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from 'src/app/services/helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { HistoryService } from 'src/app/services/helpers/history.service';
import { WebAllTels } from 'src/app/models/generated/web/WebAllTels.model';


@Injectable({
  providedIn: 'root'
})
export class WebAreaService {
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

  DoWebArea(TVItemID: number, DoOther: boolean) {
    this.TVItemID = TVItemID;
    this.DoOther = DoOther;

    this.sub ? this.sub.unsubscribe() : null;

    if (this.appLoadedService.AppLoaded$.getValue()?.WebArea) {
      this.KeepWebArea();
    }
    else {
      this.sub = this.GetWebArea().subscribe();
    }
  }

  private GetWebArea() {
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebArea: {},
    });
    this.appStateService.UpdateAppState(<AppState>{
      Status: `${ this.appLanguageService.AppLanguage.Loading[this.LangID]} - ${ WebAllTels }`,
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebArea/${this.TVItemID}/1`;
    return this.httpClient.get<WebArea>(url).pipe(
      map((x: any) => {
        this.UpdateWebArea(x);
        console.debug(x);
        if (this.DoOther) {
          // nothing else to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  private KeepWebArea() {
    this.UpdateWebArea(this.appLoadedService.AppLoaded$?.getValue()?.WebArea);
    console.debug(this.appLoadedService.AppLoaded$?.getValue()?.WebArea);
    if (this.DoOther) {
      // nothing else to add in the chain
    }
  }

  private UpdateWebArea(x: WebArea) {

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebArea: x,
    });

    this.historyService.AddHistory(this.appLoadedService.AppLoaded$.getValue()?.WebArea?.TVItemModel);

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedWebArea()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
    }

    if (this.appStateService.AppState$.getValue().GoogleJSLoaded) {
      if (this.appStateService.AppState$.getValue().AreaSubComponent == AreaSubComponentEnum.Sectors) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebArea.TVItemModelSectorList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebArea.TVItemModel]
        ]);
      }

      if (this.appStateService.AppState$.getValue().AreaSubComponent == AreaSubComponentEnum.Files) {
        this.mapService.ClearMap();
        this.mapService.DrawObjects([
          ...this.appLoadedService.AppLoaded$.getValue().WebArea.TVItemModelSectorList,
          ...[this.appLoadedService.AppLoaded$.getValue().WebArea.TVItemModel]
        ]);
      }
    }
  }
}