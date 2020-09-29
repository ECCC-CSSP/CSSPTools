import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TVItemListTextModel } from './tvitem-list.models';

@Injectable({
  providedIn: 'root'
})
export class TVItemListService {
  TVItemListTextModel$: BehaviorSubject<TVItemListTextModel> = new BehaviorSubject<TVItemListTextModel>(<TVItemListTextModel>{});

  constructor(private httpClient: HttpClient) {
    this.UpdateTVItemListText(<TVItemListTextModel>{});
  }

  UpdateTVItemListText(TVItemListTextModel: TVItemListTextModel) {
    this.TVItemListTextModel$.next(<TVItemListTextModel>{ ...this.TVItemListTextModel$.getValue(), ...TVItemListTextModel });
  }
}
