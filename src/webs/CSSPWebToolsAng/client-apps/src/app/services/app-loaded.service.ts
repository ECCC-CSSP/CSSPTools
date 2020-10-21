import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { BehaviorSubject, of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { AscDescEnum } from '../enums/generated/AscDescEnum';
import { LanguageEnum } from '../enums/generated/LanguageEnum';
import { ShellSubComponentEnum } from '../enums/generated/ShellSubComponentEnum';
import { TVTypeEnum } from '../enums/generated/TVTypeEnum';
import { AppLoaded } from '../models/AppLoaded.model';
import { AppState } from '../models/AppState.model';
import { Contact } from '../models/generated/Contact.model';
import { Preference } from '../models/generated/Preference.model';
import { SearchResult } from '../models/generated/SearchResult.model';
import { TVFileModel } from '../models/generated/TVFileModel.model';
import { WebArea } from '../models/generated/WebArea.model';
import { WebBase } from '../models/generated/WebBase.model';
import { WebContact } from '../models/generated/WebContact.model';
import { WebCountry } from '../models/generated/WebCountry.model';
import { WebMunicipalities } from '../models/generated/WebMunicipalities.model';
import { WebProvince } from '../models/generated/WebProvince.model';
import { WebRoot } from '../models/generated/WebRoot.model';
import { WebSector } from '../models/generated/WebSector.model';
import { WebSubsector } from '../models/generated/WebSubsector.model';
import { AppHelperService } from './app-helper.service';
import { AppStateService } from './app-state.service';

@Injectable({
  providedIn: 'root'
})
export class AppLoadedService {
  AppLoaded$: BehaviorSubject<AppLoaded> = new BehaviorSubject<AppLoaded>(<AppLoaded>{});
  //BaseApiUrl = 'https://localhost:4447/api/';
  BaseApiUrl = 'https://localhost:44346/api/';

  constructor(private httpClient: HttpClient,
    public appStateService: AppStateService,
    private appHelperService: AppHelperService) {

  }

  UpdateAppLoaded(appLoaded: AppLoaded) {
    this.AppLoaded$.next(<AppLoaded>{ ...this.AppLoaded$.getValue(), ...appLoaded });
  }

  GetLoggedInContact() {
    this.UpdateAppLoaded(<AppLoaded>{ LoggedInContact: {}, Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/LoggedInContact`;
    return this.httpClient.get<Contact>(url).pipe(
      map((x: any) => {
        this.UpdateAppLoaded(<AppLoaded>{ LoggedInContact: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  GetWebContact() {
    this.UpdateAppLoaded(<AppLoaded>{ WebContact: {}, AdminContactList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebContact/0/1`;
    return this.httpClient.get<WebContact>(url).pipe(
      map((x: WebContact) => {
        let adminList: Contact[] = x.ContactList.filter(contact => contact.IsAdmin == true);
        this.UpdateAppLoaded(<AppLoaded>{ WebContact: x, AdminContactList: adminList, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  GetPreference() {
    this.UpdateAppLoaded(<AppLoaded>{ PreferenceList: [], Working: true });
    let url: string = `${this.BaseApiUrl}Preference`;
    return this.httpClient.get<Preference[]>(url).pipe(
      map((x: any) => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  GetWebSubsector(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebSubsector: {}, SubsectorMWQMSiteList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebSubsector/${TVItemID}/1`;
    return this.httpClient.get<WebSubsector>(url).pipe(
      map((x: any) => {
        this.UpdateWebSubsector(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebSubsector(x: WebSubsector) {
    let SubsectorMWQMSiteList: WebBase[] = [];
    let SubsectorMWQMRunList: WebBase[] = [];
    let SubsectorPolSourceSiteList: WebBase[] = [];

    // doing MWQMSiteList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SubsectorMWQMSiteList = x?.TVItemMWQMSiteList.filter((mwqmsite) => { return mwqmsite.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SubsectorMWQMSiteList = x?.TVItemMWQMSiteList;
    }

    // doing MWQMRunList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SubsectorMWQMRunList = x?.TVItemMWQMRunList.filter((mwqmrun) => { return mwqmrun.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SubsectorMWQMRunList = x?.TVItemMWQMRunList;
    }

    // doing PollutionSourceSiteList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SubsectorPolSourceSiteList = x?.TVItemPolSourceSiteList.filter((polsourcesite) => { return polsourcesite.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SubsectorPolSourceSiteList = x?.TVItemPolSourceSiteList;
    }

    this.UpdateAppLoaded(<AppLoaded>{
      WebSubsector: x,
      SubsectorMWQMSiteList: SubsectorMWQMSiteList,
      SubsectorMWQMRunList: SubsectorMWQMRunList,
      SubsectorPolSourceSiteList: SubsectorPolSourceSiteList,
      BreadCrumbWebBaseList: x?.TVItemParentList,
      Working: false
    });
  }

  GetWebSector(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebSector: {}, SectorSubsectorList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebSector/${TVItemID}/1`;
    return this.httpClient.get<WebSector>(url).pipe(
      map((x: any) => {
        this.UpdateWebSector(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebSector(x: WebSector) {
    let SectorSubsectorList: WebBase[] = [];
    let SectorMIKEScenarioList: WebBase[] = [];

    // doing SectorSubsectorList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SectorSubsectorList = x?.TVItemSubsectorList.filter((subsector) => { return subsector.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SectorSubsectorList = x?.TVItemSubsectorList;
    }

    // doing SectorMIKEScenarioList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      SectorMIKEScenarioList = x?.TVItemMikeScenarioList.filter((mikescenario) => { return mikescenario.TVItemModel.TVItem.IsActive == true });
    }
    else {
      SectorMIKEScenarioList = x?.TVItemMikeScenarioList;
    }

    this.UpdateAppLoaded(<AppLoaded>{
      WebSector: x,
      SectorSubsectorList: SectorSubsectorList,
      SectorMIKEScenarioList: SectorMIKEScenarioList,
      BreadCrumbWebBaseList: x?.TVItemParentList,
      Working: false
    });
  }

  GetWebArea(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebArea: {}, AreaSectorList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebArea/${TVItemID}/1`;
    return this.httpClient.get<WebArea>(url).pipe(
      map((x: any) => {
        this.UpdateWebArea(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebArea(x: WebArea) {
    let AreaSectorList: WebBase[] = [];

    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      AreaSectorList = x?.TVItemSectorList.filter((sector) => { return sector.TVItemModel.TVItem.IsActive == true });
    }
    else {
      AreaSectorList = x?.TVItemSectorList;
    }

    this.UpdateAppLoaded(<AppLoaded>{ WebArea: x, AreaSectorList: AreaSectorList, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
  }

  GetWebMunicipalities(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebMunicipalities: {}, ProvinceMunicipalityList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebMunicipalities/${TVItemID}/1`;
    return this.httpClient.get<WebMunicipalities>(url).pipe(
      map((x: any) => {
        this.UpdateWebMunicipalities(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebMunicipalities(x: WebMunicipalities) {
    let ProvinceMunicipalityList: WebBase[] = [];

    // doing ProvinceMunicipalitiesList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      ProvinceMunicipalityList = x?.TVItemMunicipalityList.filter((municipality) => { return municipality.TVItemModel.TVItem.IsActive == true });
    }
    else {
      ProvinceMunicipalityList = x?.TVItemMunicipalityList;
    }

    this.UpdateAppLoaded(<AppLoaded>{
      ProvinceMunicipalityList: ProvinceMunicipalityList,
      Working: false
    });
  }

  GetWebProvince(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebProvince: {}, ProvinceAreaList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebProvince/${TVItemID}/1`;
    return this.httpClient.get<WebProvince>(url).pipe(
      map((x: any) => {
        this.UpdateWebProvince(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebProvince(x: WebProvince) {
    let ProvinceAreaList: WebBase[] = [];
    let ProvinceMunicipalityList: WebBase[] = [];

    // doing ProvinceAreaList
    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      ProvinceAreaList = x?.TVItemAreaList.filter((area) => { return area.TVItemModel.TVItem.IsActive == true });
    }
    else {
      ProvinceAreaList = x?.TVItemAreaList;
    }

    this.UpdateAppLoaded(<AppLoaded>{
      WebProvince: x,
      ProvinceAreaList: ProvinceAreaList,
      BreadCrumbWebBaseList: x?.TVItemParentList,
      Working: false
    });
  }

  GetWebRoot(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebRoot: {}, RootCountryList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebRoot/${TVItemID}/1`;
    return this.httpClient.get<WebRoot>(url).pipe(
      map((x: any) => {
        this.UpdateWebRoot(x);
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebRoot(x: WebRoot) {
    let RootCountryList: WebBase[] = [];

    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      RootCountryList = x?.TVItemCountryList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true });
    }
    else {
      RootCountryList = x?.TVItemCountryList;
    }

    this.UpdateAppLoaded(<AppLoaded>{ WebRoot: x, RootCountryList: RootCountryList, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
  }

  GetWebCountry(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ WebCountry: {}, CountryProvinceList: [], BreadCrumbWebBaseList: [], Working: true });
    let url: string = `${this.BaseApiUrl}en-CA/Read/WebCountry/${TVItemID}/1`;
    return this.httpClient.get<WebCountry>(url).pipe(
      map((x: any) => {
        this.UpdateWebCountry(x);
        console.debug(x);

      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateWebCountry(x: WebCountry) {
    let CountryProvinceList: WebBase[] = [];

    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      CountryProvinceList = x?.TVItemProvinceList.filter((province) => { return province.TVItemModel.TVItem.IsActive == true });
    }
    else {
      CountryProvinceList = x?.TVItemProvinceList;
    }

    this.UpdateAppLoaded(<AppLoaded>{ WebCountry: x, CountryProvinceList: CountryProvinceList, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
  }

  GetSearch(myControl: FormControl) {
    return myControl.valueChanges.pipe(
      startWith(''),
      debounceTime(500),
      distinctUntilChanged(),
      tap(term => {
        this.GetSearchData(term);
      }));
  }

  private GetSearchData(term: string) {
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
    term = ('' + term).trim();
    if (!term) {
      of([]).pipe(
        tap(() => {
          this.UpdateAppLoaded(<AppLoaded>{ SearchResult: [], Working: false });
          console.debug("Clean Search Result");
        })
      ).subscribe();
    }
    else {
      let url: string = `${this.BaseApiUrl}en-CA/search/${term}/1`;
      this.httpClient.get<SearchResult>(url).pipe(
        map((x: any) => {
          this.UpdateAppLoaded(<AppLoaded>{ SearchResult: x, Working: false });
          console.debug(x);
        }),
        catchError(e => of(e).pipe(map(e => {
          this.UpdateAppLoaded(<AppLoaded>{ Working: false, Error: <HttpErrorResponse>e });
          console.debug(e);
        })))
      ).subscribe();
    }
  }

  ToggleInactive(appState: AppState): void {
    this.appStateService.UpdateAppState(<AppState>{ InactVisible: !this.appStateService.AppState$.getValue().InactVisible });
    if (appState.ShellSubComponent == ShellSubComponentEnum.Root) {
      this.UpdateWebRoot(this.AppLoaded$.getValue().WebRoot);
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Country) {
      this.UpdateWebCountry(this.AppLoaded$.getValue().WebCountry);
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Province) {
      this.UpdateWebProvince(this.AppLoaded$.getValue().WebProvince);
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Area) {
      this.UpdateWebArea(this.AppLoaded$.getValue().WebArea);
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Sector) {
      this.UpdateWebSector(this.AppLoaded$.getValue().WebSector);
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Subsector) {
      this.UpdateWebSubsector(this.AppLoaded$.getValue().WebSubsector);
    }
    else {
      alert(`ToggleInactive (${ShellSubComponentEnum[appState.ShellSubComponent]}) not implemented. see ToggleInactive in app-loaded.service`);
    }
  }

  ToggleDetail(): void {
    this.appStateService.UpdateAppState(<AppState>{ DetailVisible: !this.appStateService.AppState$.getValue().DetailVisible });
    this.UpdateAppLoaded(<AppLoaded>{ Working: false });
  }

  ToggleEdit(): void {
    this.appStateService.UpdateAppState(<AppState>{ EditVisible: !this.appStateService.AppState$.getValue().EditVisible });
    this.UpdateAppLoaded(<AppLoaded>{ Working: false });
  }

  SortTVItemList(arr: WebBase[]): WebBase[] {
    if (arr.length == 0) return arr;

    let TVType: TVTypeEnum = this.AppLoaded$.getValue().BreadCrumbWebBaseList[this.AppLoaded$.getValue().BreadCrumbWebBaseList.length - 1].TVItemModel.TVItem.TVType;
    let TVTypeOfList: TVTypeEnum = arr[0].TVItemModel.TVItem.TVType;
    let lang: LanguageEnum = this.appStateService.AppState$.getValue().Language;
    let AscDesc: AscDescEnum = AscDescEnum.Ascending;

    switch (TVType) {
      case TVTypeEnum.Root:
        {
          switch (TVTypeOfList) {
            case TVTypeEnum.Country:
              {
                AscDesc = this.appStateService.AppState$.getValue().RootCountriesSortOrder;
              }
              break;
            default:
              {
                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Root`);
              }
              break;
          }
        }
        break;
      case TVTypeEnum.Country:
        {
          switch (TVTypeOfList) {
            case TVTypeEnum.Province:
              {
                AscDesc = this.appStateService.AppState$.getValue().CountryProvincesSortOrder;
              }
              break;
            default:
              {
                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Country`);
              }
              break;
          }
        }
        break;
      case TVTypeEnum.Province:
        {
          switch (TVTypeOfList) {
            case TVTypeEnum.Area:
              {
                AscDesc = this.appStateService.AppState$.getValue().ProvinceAreasSortOrder;
              }
              break;
            case TVTypeEnum.Municipality:
              {
                AscDesc = this.appStateService.AppState$.getValue().ProvinceMunicipalitiesSortOrder;
              }
              break;
            default:
              {
                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Province`);
              }
              break;
          }
        }
        break;
      case TVTypeEnum.Area:
        {
          switch (TVTypeOfList) {
            case TVTypeEnum.Sector:
              {
                AscDesc = this.appStateService.AppState$.getValue().AreaSectorsSortOrder;
              }
              break;
            default:
              {
                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Area`);
              }
              break;
          }
        }
        break;
      case TVTypeEnum.Sector:
        {
          switch (TVTypeOfList) {
            case TVTypeEnum.Subsector:
              {
                AscDesc = this.appStateService.AppState$.getValue().SectorSubsectorsSortOrder;
              }
              break;
            default:
              {
                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Sector`);
              }
              break;
          }
        }
        break;
      case TVTypeEnum.Subsector:
        {
          switch (TVTypeOfList) {
            case TVTypeEnum.MWQMSite:
              {
                AscDesc = this.appStateService.AppState$.getValue().SubsectorMWQMSitesSortOrder;
              }
              break;
            case TVTypeEnum.MWQMRun:
              {
                AscDesc = this.appStateService.AppState$.getValue().SubsectorMWQMRunsSortOrder;
              }
              break;
            case TVTypeEnum.PolSourceSite:
              {
                AscDesc = this.appStateService.AppState$.getValue().SubsectorPolSourceSitesSortOrder;
              }
              break;
            default:
              {
                alert(`${TVTypeEnum[TVTypeOfList]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function -- case TVTypeEnum.Subsector`);
              }
              break;
          }
        }
        break;
      default:
        {
          alert(`${TVTypeEnum[TVType]} - Not Implemented Yet. See app-loaded.service.ts -- SortTVItemList function`);
        }
        break;
    }

    let webBaseSorted: WebBase[] = [];
    let arr2: TVItemID_TVText_Sort[] = [];
    let sortable: TVItemID_TVText_Sort[] = [];

    for (let i = 0; i < arr.length; i++) {
      sortable.push(<TVItemID_TVText_Sort>{
        TVItemID: arr[i].TVItemModel.TVItem.TVItemID,
        TVText: lang == LanguageEnum.fr ? arr[i].TVItemModel.TVItemLanguageFR.TVText.toLowerCase() : arr[i].TVItemModel.TVItemLanguageEN.TVText.toLowerCase()
      });
    }

    if (AscDesc == AscDescEnum.Ascending) {
      arr2 = sortable.sort(this.predicateAscBy('TVText'));
    }
    else {
      arr2 = sortable.sort(this.predicateDescBy('TVText'));
    }

    for (let i = 0; i < sortable.length; i++) {
      for (let j = 0; j < arr.length; j++) {
        if (arr2[i].TVItemID == arr[j].TVItemModel.TVItem.TVItemID) {
          webBaseSorted.push(arr[j]);
          break;
        }
      }
    }

    return webBaseSorted;
  }

  SortTVFileList(arr: WebBase[], arrFile: TVFileModel[]): TVFileModel[] {
    if (arrFile.length == 0) return arrFile;

    let TVType: TVTypeEnum = this.AppLoaded$.getValue().BreadCrumbWebBaseList[this.AppLoaded$.getValue().BreadCrumbWebBaseList.length - 1].TVItemModel.TVItem.TVType;
    let AscDesc: AscDescEnum = AscDescEnum.Ascending;

    switch (TVType) {
      case TVTypeEnum.Root:
        {
          AscDesc = this.appStateService.AppState$.getValue().RootFilesSortOrder;
        }
        break;
      case TVTypeEnum.Country:
        {
          AscDesc = this.appStateService.AppState$.getValue().CountryFilesSortOrder;
        }
        break;
      case TVTypeEnum.Province:
        {
          AscDesc = this.appStateService.AppState$.getValue().ProvinceFilesSortOrder;
        }
        break;
      case TVTypeEnum.Area:
        {
          AscDesc = this.appStateService.AppState$.getValue().AreaFilesSortOrder;
        }
        break;
      case TVTypeEnum.Sector:
        {
          AscDesc = this.appStateService.AppState$.getValue().SectorFilesSortOrder;
        }
        break;
      case TVTypeEnum.Subsector:
        {
          AscDesc = this.appStateService.AppState$.getValue().SubsectorFilesSortOrder;
        }
        break;
      default:
        {
          alert(`${TVTypeEnum[TVType]} - Not Implemented Yet. See app-loaded.service.ts -- SortFileList function`);
        }
        break;
    }

    let tvFileSorted: TVFileModel[] = [];
    let arrFile2: TVFileID_ServerFileName_Sort[] = [];
    let sortable: TVFileID_ServerFileName_Sort[] = [];

    for (let i = 0; i < arrFile.length; i++) {
      sortable.push(<TVFileID_ServerFileName_Sort>{
        TVFileID: arrFile[i].TVFile.TVFileID,
        ServerFileName: arrFile[i].TVFile.ServerFileName.toLowerCase(),
      });
    }

    if (AscDesc == AscDescEnum.Ascending) {
      arrFile2 = sortable.sort(this.predicateAscBy('ServerFileName'));
    }
    else {
      arrFile2 = sortable.sort(this.predicateDescBy('ServerFileName'));
    }

    for (let i = 0; i < sortable.length; i++) {
      for (let j = 0; j < arrFile.length; j++) {
        if (arrFile2[i].TVFileID == arrFile[j].TVFile.TVFileID) {
          tvFileSorted.push(arrFile[j]);
          break;
        }
      }
    }

    return tvFileSorted;
  }

  predicateAscBy(prop) {
    return function (a, b) {
      if (a[prop] > b[prop]) {
        return 1;
      } else if (a[prop] < b[prop]) {
        return -1;
      }
      return 0;
    }
  }

  predicateDescBy(prop) {
    return function (a, b) {
      if (a[prop] < b[prop]) {
        return 1;
      } else if (a[prop] > b[prop]) {
        return -1;
      }
      return 0;
    }
  }

  ChangeTVItemSortOrder(prop: string, ascDesc: AscDescEnum) {
    switch (prop) {
      case 'AreaSectorsSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ AreaSectorsSortOrder: ascDesc });
        break;
      case 'CountryProvincesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ CountryProvincesSortOrder: ascDesc });
        break;
      case 'ProvinceAreasSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ ProvinceAreasSortOrder: ascDesc });
        break;
      case 'ProvinceMunicipalitiesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ ProvinceMunicipalitiesSortOrder: ascDesc });
        break;
      case 'RootCountriesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ RootCountriesSortOrder: ascDesc });
        break;
      case 'SectorSubsectorsSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SectorSubsectorsSortOrder: ascDesc });
        break;
      case 'SubsectorMWQMSitesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorMWQMSitesSortOrder: ascDesc });
        break;
      case 'SubsectorMWQMRunsSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorMWQMRunsSortOrder: ascDesc });
        break;
      case 'SubsectorPolSourceSitesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorPolSourceSitesSortOrder: ascDesc });
        break;
      default:
        alert(`${prop} not implemented yet. See app-loaded.service.ts -- ChangeTVItemSortOrder function`);
        break;
    }
  }

  ChangeTVFileSortOrder(prop: string, ascDesc: AscDescEnum) {
    switch (prop) {
      case 'AreaFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ AreaFilesSortOrder: ascDesc });
        break;
      case 'CountryFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ CountryFilesSortOrder: ascDesc });
        break;
      case 'ProvinceFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ ProvinceFilesSortOrder: ascDesc });
        break;
      case 'RootFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ RootFilesSortOrder: ascDesc });
        break;
      case 'SectorFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SectorFilesSortOrder: ascDesc });
        break;
      case 'SubsectorFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorFilesSortOrder: ascDesc });
        break;
      default:
        alert(`${prop} not implemented yet. See app-loaded.service.ts -- ChangeTVFileSortOrder function`);
        break;
    }
  }
}

export interface TVItemID_TVText_Sort {
  TVItemID: number;
  TVText: string;
}

export interface TVFileID_ServerFileName_Sort {
  TVFileID: number;
  ServerFileName: string;
}