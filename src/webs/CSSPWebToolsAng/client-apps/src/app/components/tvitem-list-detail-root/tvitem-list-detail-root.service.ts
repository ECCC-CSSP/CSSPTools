import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, of } from 'rxjs';
import { TVItemListDetailRootTextModel } from './tvitem-list-detail-root.models';

@Injectable({
  providedIn: 'root'
})
export class TVItemListDetailRootService {
  TVItemListDetailRootTextModel$: BehaviorSubject<TVItemListDetailRootTextModel> = new BehaviorSubject<TVItemListDetailRootTextModel>(<TVItemListDetailRootTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateTVItemListDetailRootText(<TVItemListDetailRootTextModel>{});
  }

  UpdateTVItemListDetailRootText(TVItemListDetailRootTextModel: TVItemListDetailRootTextModel) {
    this.TVItemListDetailRootTextModel$.next(<TVItemListDetailRootTextModel>{ ...this.TVItemListDetailRootTextModel$.getValue(), ...TVItemListDetailRootTextModel });
  }

}
