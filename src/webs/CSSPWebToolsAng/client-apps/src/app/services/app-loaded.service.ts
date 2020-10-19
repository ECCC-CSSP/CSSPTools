import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { BehaviorSubject, of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, map, startWith, tap } from 'rxjs/operators';
import { ShellSubComponentEnum } from '../enums/generated/ShellSubComponentEnum';
import { AppLoaded } from '../models/AppLoaded.model';
import { AppState } from '../models/AppState.model';
import { Contact } from '../models/generated/Contact.model';
import { Preference } from '../models/generated/Preference.model';
import { SearchResult } from '../models/generated/SearchResult.model';
import { WebBase } from '../models/generated/WebBase.model';
import { WebContact } from '../models/generated/WebContact.model';
import { WebCountry } from '../models/generated/WebCountry.model';
import { WebProvince } from '../models/generated/WebProvince.model';
import { WebRoot } from '../models/generated/WebRoot.model';
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
    private appStateService: AppStateService,
    private appHelperService: AppHelperService) {

  }

  UpdateAppLoaded(appLoaded: AppLoaded) {
    this.AppLoaded$.next(<AppLoaded>{ ...this.AppLoaded$.getValue(), ...appLoaded });
  }

  GetLoggedInContact() {
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
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
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
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
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
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

  GetWebProvince(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
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

    if (!this.appStateService.AppState$?.getValue()?.InactVisible) {
      ProvinceAreaList = x?.TVItemAreaList.filter((area) => { return area.TVItemModel.TVItem.IsActive == true });
    }
    else {
      ProvinceAreaList = x?.TVItemAreaList;
    }

    this.UpdateAppLoaded(<AppLoaded>{ WebProvince: x, ProvinceAreaList: ProvinceAreaList, BreadCrumbWebBaseList: x?.TVItemParentList, Working: false });
  }

  GetWebRoot(TVItemID: number) {
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
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
    this.UpdateAppLoaded(<AppLoaded>{ Working: true });
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
        this.GetData(term);
      }));
  }

  private GetData(term: string) {
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
      //this.UpdateWebArea(this.AppLoaded$.getValue().WebArea);
      alert('ToggleInactive (Area) not implemented. see ToggleInactive in app-loaded.service');
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Sector) {
      //this.UpdateWebSector(this.AppLoaded$.getValue().WebSector);
      alert('ToggleInactive (Sector) not implemented. see ToggleInactive in app-loaded.service');
    }
    else if (appState.ShellSubComponent == ShellSubComponentEnum.Subsector) {
      //this.UpdateWebSubsector(this.AppLoaded$.getValue().WebSubsector);
      alert('ToggleInactive (Subsector) not implemented. see ToggleInactive in app-loaded.service');
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


}
