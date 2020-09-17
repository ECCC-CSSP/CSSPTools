import { Injectable } from '@angular/core';
import { SearchTextModel } from './search.models';
import { BehaviorSubject } from 'rxjs';
import { LoadLocalesSearchText } from './search.locales';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  searchTextModel$: BehaviorSubject<SearchTextModel> = new BehaviorSubject<SearchTextModel>(<SearchTextModel>{});
  
  constructor() {
    LoadLocalesSearchText(this);
    this.UpdateSearchText(<SearchTextModel>{ Title: "Something for text" });
  }

  UpdateSearchText(searchTextModel: SearchTextModel) {
    this.searchTextModel$.next(<SearchTextModel>{ ...this.searchTextModel$.getValue(), ...searchTextModel });
  }
}
