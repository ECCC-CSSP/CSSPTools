import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { EmailDistributionList } from 'src/app/models/generated/EmailDistributionList.model';
import { EmailDistributionListContact } from 'src/app/models/generated/EmailDistributionListContact.model';
import { EmailDistributionListContactLanguage } from 'src/app/models/generated/EmailDistributionListContactLanguage.model';
import { EmailDistributionListLanguage } from 'src/app/models/generated/EmailDistributionListLanguage.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { WebCountry } from 'src/app/models/generated/WebCountry.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { StructureTVFileListService } from './structure-tvfile-list.service';
import { SortTVItemListService } from './sort-tvitem-list.service';
import { MapService } from '../map/map.service';
import { CountrySubComponentEnum } from 'src/app/enums/generated/CountrySubComponentEnum';

@Injectable({
  providedIn: 'root'
})
export class WebCountryService {

  constructor(private httpClient: HttpClient,
    private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private sortTVItemListService: SortTVItemListService,
    private structureTVFileListService: StructureTVFileListService,
    private mapService: MapService) {
  }

  GetWebCountry(TVItemID: number) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebCountry: {},
      CountryProvinceList: [],
      EmailDistributionListContactLanguageList: [],
      EmailDistributionListContactList: [],
      EmailDistributionListLanguageList: [],
      EmailDistributionListList: [],
      BreadCrumbWebBaseList: [],
      Working: true
    });
    let url: string = `${this.appLoadedService.BaseApiUrl}en-CA/Read/WebCountry/${TVItemID}/1`;
    return this.httpClient.get<WebCountry>(url).pipe(
      map((x: any) => {
        this.UpdateWebCountry(x);
        console.debug(x);

      }),
      catchError(e => of(e).pipe(map(e => {
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebCountry(x: WebCountry) {
    let CountryProvinceList: WebBase[] = [];
    let EmailDistributionListContactLanguageList: EmailDistributionListContactLanguage[] = [];
    let EmailDistributionListContactList: EmailDistributionListContact[] = [];
    let EmailDistributionListLanguageList: EmailDistributionListLanguage[] = [];
    let EmailDistributionListList: EmailDistributionList[] = [];

    // doing CountryProvinceList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      CountryProvinceList = x?.TVItemProvinceList.filter((province) => { return province.TVItemModel.TVItem.IsActive == true });
    }
    else {
      CountryProvinceList = x?.TVItemProvinceList;
    }

    EmailDistributionListContactLanguageList = x?.EmailDistributionListContactLanguageList;
    EmailDistributionListContactList = x?.EmailDistributionListContactList;
    EmailDistributionListLanguageList = x?.EmailDistributionListLanguageList;
    EmailDistributionListList = x?.EmailDistributionListList;

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebCountry: x,
      CountryProvinceList: this.sortTVItemListService.SortTVItemList(CountryProvinceList, x?.TVItemParentList),
      CountryFileListList: this.structureTVFileListService.StructureTVFileList(x.TVItemModel),
      EmailDistributionListContactLanguageList: EmailDistributionListContactLanguageList,
      EmailDistributionListContactList: EmailDistributionListContactList,
      EmailDistributionListLanguageList: EmailDistributionListLanguageList,
      EmailDistributionListList: EmailDistributionListList,
      BreadCrumbWebBaseList: x?.TVItemParentList,
      Working: false
    });

    if (this.appStateService.AppState$.getValue().CountrySubComponent == CountrySubComponentEnum.Provinces) {
      this.mapService.ClearMap();
      this.mapService.DrawObjects(this.appLoadedService.AppLoaded$.getValue().CountryProvinceList);
    }
  }
}