import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { StructureTVFileListService } from 'src/app/services/helpers/structure-tvfile-list.service';
import { SortTVItemListService } from 'src/app/services/helpers/sort-tvitem-list.service';
import { MapService } from 'src/app/services/map/map.service';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { ComponentDataLoadedService } from '../helpers/component-data-loaded.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from '../app-language.service';

@Injectable({
  providedIn: 'root'
})
export class WebCountryService {
  private DoOther: boolean;

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService,
    private componentDataLoadedService: ComponentDataLoadedService) {
  }

  GetWebCountry(TVItemID: number, DoOther: boolean) {
    this.DoOther = DoOther; PageTransitionEvent
    let languageEnum = GetLanguageEnum();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ WebCountry: {}, CountryProvinceList: [], BreadCrumbWebBaseList: [] });
    this.appStateService.UpdateAppState(<AppState>{
      Status: this.appLanguageService.AppLanguage.LoadingCountry[this.appStateService.AppState$?.getValue()?.Language],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}${languageEnum[this.appStateService.AppState$.getValue().Language]}-CA/Read/WebCountry/${TVItemID}/1`;
    return this.httpClient.get<WebCountry>(url).pipe(
      map((x: any) => {
        this.UpdateWebCountry(x);
        console.debug(x);
        if (DoOther) {
          // nothing more to add in the chain
        }
      }),
      catchError(e => of(e).pipe(map(e => {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebCountry(x: WebCountry) {
    let CountryProvinceList: WebBase[] = [];

    // doing CountryProvinceList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      CountryProvinceList = x?.TVItemProvinceList.filter((province) => { return province.TVItemModel.TVItem.IsActive == true });
    }
    else {
      CountryProvinceList = x?.TVItemProvinceList;
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebCountry: x,
      CountryProvinceList: this.sortTVItemListService.SortTVItemList(CountryProvinceList, x?.TVItemParentList),
      CountryFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
      EmailDistributionListContactLanguageList: x?.EmailDistributionListContactLanguageList,
      EmailDistributionListContactList: x?.EmailDistributionListContactList,
      EmailDistributionListLanguageList: x?.EmailDistributionListLanguageList,
      EmailDistributionListList: x?.EmailDistributionListList,
      BreadCrumbWebBaseList: x?.TVItemParentList,
    });

    if (this.DoOther) {
      if (this.componentDataLoadedService.DataLoadedCountry()) {
        this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
      }
    }
    else {
      this.appStateService.UpdateAppState(<AppState>{ Status: '', Working: false });
    }

    if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.Provinces) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().CountryProvinceList);
    }
  }
}