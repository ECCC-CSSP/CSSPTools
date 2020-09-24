import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVItemListItemTextModel } from './tvitem-list-item.models';

@Injectable({
  providedIn: 'root'
})
export class TVItemListItemService {
  TVItemListItemTextModel$: BehaviorSubject<TVItemListItemTextModel> = new BehaviorSubject<TVItemListItemTextModel>(<TVItemListItemTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateTVItemListItemText(<TVItemListItemTextModel>{});
  }

  UpdateTVItemListItemText(TVItemListItemTextModel: TVItemListItemTextModel) {
    this.TVItemListItemTextModel$.next(<TVItemListItemTextModel>{ ...this.TVItemListItemTextModel$.getValue(), ...TVItemListItemTextModel });
  }

}
