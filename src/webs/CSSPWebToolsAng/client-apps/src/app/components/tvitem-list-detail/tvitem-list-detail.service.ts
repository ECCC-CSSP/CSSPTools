import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVItemListDetailTextModel } from './tvitem-list-detail.models';

@Injectable({
  providedIn: 'root'
})
export class TVItemListDetailService {
  TVItemListDetailTextModel$: BehaviorSubject<TVItemListDetailTextModel> = new BehaviorSubject<TVItemListDetailTextModel>(<TVItemListDetailTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateTVItemListDetailText(<TVItemListDetailTextModel>{});
  }

  UpdateTVItemListDetailText(TVItemListDetailTextModel: TVItemListDetailTextModel) {
    this.TVItemListDetailTextModel$.next(<TVItemListDetailTextModel>{ ...this.TVItemListDetailTextModel$.getValue(), ...TVItemListDetailTextModel });
  }

}
