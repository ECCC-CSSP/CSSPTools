import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesCountryText } from './country.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebCountry } from '../../models/generated/WebCountry.model';
import { CountryTextModel, WebBaseProvinceModel, WebCountryModel } from './country.models';
import { BreadCrumbModel } from '../../models/BreadCrumb.model';
import { ShellService } from '../shell';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  CountryTextModel$: BehaviorSubject<CountryTextModel> = new BehaviorSubject<CountryTextModel>(<CountryTextModel>{});
  WebCountryModel$: BehaviorSubject<WebCountryModel> = new BehaviorSubject<WebCountryModel>(<WebCountryModel>{});
  WebProvinceModel$: BehaviorSubject<WebBaseProvinceModel> = new BehaviorSubject<WebBaseProvinceModel>(<WebBaseProvinceModel>{});

  constructor(public shellService: ShellService, private httpClient: HttpClient) {
    LoadLocalesCountryText(this);
    this.UpdateCountryText(<CountryTextModel>{ Title: "Something for text" });
  }

  GetWebCountry(TVItemID: number) {
    this.UpdateWebCountry(<WebCountryModel>{ Working: true });
    return this.httpClient.get<WebCountry>(`/api/Read/WebCountry/${ TVItemID }/1`).pipe(
      map((x: any) => {
        this.UpdateWebCountry(<WebCountryModel>{ WebCountry: x, Working: false });
        console.debug(x);
      }),
      catchError(e => of(e).pipe(map(e => {
        this.UpdateWebCountry(<WebCountryModel>{ Working: false, Error: <HttpErrorResponse>e });
        console.debug(e);
      })))
    );
  }

  UpdateCountryText(countryTextModel: CountryTextModel) {
    this.CountryTextModel$.next(<CountryTextModel>{ ...this.CountryTextModel$.getValue(), ...countryTextModel });
  }

  UpdateWebCountry(webCountryModel: WebCountryModel) {
    this.WebCountryModel$.next(<WebCountryModel>{ ...this.WebCountryModel$.getValue(), ...webCountryModel });
    this.shellService.UpdateBreadCrumbModel(<BreadCrumbModel>{ WebBaseList: this.WebCountryModel$.getValue()?.WebCountry?.TVItemParentList });

    let webBaseProvinceModel: WebBaseProvinceModel = <WebBaseProvinceModel>{ WebBaseProvinceList: [] };

    if (this.shellService.ShellModel$?.getValue()?.ActiveVisible && this.shellService.ShellModel$?.getValue()?.InactVisible) {
      webBaseProvinceModel = <WebBaseProvinceModel>{ WebBaseProvinceList: this.WebCountryModel$?.getValue()?.WebCountry?.TVItemProvinceList };
    }
    else if (this.shellService.ShellModel$?.getValue()?.ActiveVisible) {
      webBaseProvinceModel = <WebBaseProvinceModel>{ WebBaseProvinceList: this.WebCountryModel$?.getValue()?.WebCountry?.TVItemProvinceList.filter((country) => { return country.TVItemModel.TVItem.IsActive == true }) };
    }
    else if (this.shellService.ShellModel$?.getValue()?.InactVisible) {
      webBaseProvinceModel = <WebBaseProvinceModel>{ WebBaseProvinceList: this.WebCountryModel$?.getValue()?.WebCountry?.TVItemProvinceList.filter((country) => { return country.TVItemModel.TVItem.IsActive == false }) };
    }

    this.UpdateWebProvinceModel(webBaseProvinceModel);
  }

  UpdateWebProvinceModel(webBaseProvinceModel: WebBaseProvinceModel) {
    this.WebProvinceModel$.next(<WebBaseProvinceModel>{ ...this.WebProvinceModel$.getValue(), ...webBaseProvinceModel });
  }
}
