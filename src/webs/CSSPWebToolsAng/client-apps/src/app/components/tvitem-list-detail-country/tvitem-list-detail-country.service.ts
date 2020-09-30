import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVItemListDetailCountryTextModel } from './tvitem-list-detail-country.models';

@Injectable({
  providedIn: 'root'
})
export class TVItemListDetailCountryService {
  TVItemListDetailCountryTextModel$: BehaviorSubject<TVItemListDetailCountryTextModel> = new BehaviorSubject<TVItemListDetailCountryTextModel>(<TVItemListDetailCountryTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateTVItemListDetailCountryText(<TVItemListDetailCountryTextModel>{});
  }

  UpdateTVItemListDetailCountryText(TVItemListDetailCountryTextModel: TVItemListDetailCountryTextModel) {
    this.TVItemListDetailCountryTextModel$.next(<TVItemListDetailCountryTextModel>{ ...this.TVItemListDetailCountryTextModel$.getValue(), ...TVItemListDetailCountryTextModel });
  }

}
