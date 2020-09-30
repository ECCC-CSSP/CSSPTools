import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVItemListDetailProvinceTextModel } from './tvitem-list-detail-province.models';

@Injectable({
  providedIn: 'root'
})
export class TVItemListDetailProvinceService {
  TVItemListDetailProvinceTextModel$: BehaviorSubject<TVItemListDetailProvinceTextModel> = new BehaviorSubject<TVItemListDetailProvinceTextModel>(<TVItemListDetailProvinceTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateTVItemListDetailProvinceText(<TVItemListDetailProvinceTextModel>{});
  }

  UpdateTVItemListDetailProvinceText(TVItemListDetailProvinceTextModel: TVItemListDetailProvinceTextModel) {
    this.TVItemListDetailProvinceTextModel$.next(<TVItemListDetailProvinceTextModel>{ ...this.TVItemListDetailProvinceTextModel$.getValue(), ...TVItemListDetailProvinceTextModel });
  }

}
