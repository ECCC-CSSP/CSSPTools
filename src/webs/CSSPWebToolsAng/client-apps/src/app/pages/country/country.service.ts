import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { LoadLocalesCountryText } from './country.locales';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

import { WebCountry } from '../../models/generated/WebCountry.model';
import { CountryTextModel, WebCountryModel } from './country.models';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  CountryTextModel$: BehaviorSubject<CountryTextModel> = new BehaviorSubject<CountryTextModel>(<CountryTextModel>{});
  WebCountryModel$: BehaviorSubject<WebCountryModel> = new BehaviorSubject<WebCountryModel>(<WebCountryModel>{});
  
  constructor(private httpClient: HttpClient) {
    LoadLocalesCountryText(this);
    this.UpdateCountryText(<CountryTextModel>{ Title: "Something for text" });
  }

  GetWebCountry() {
    this.UpdateWebCountry(<WebCountryModel>{ Working: true });
    return this.httpClient.get<WebCountry>('/api/Read/WebCountry/5/1').pipe(
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
  }
}
