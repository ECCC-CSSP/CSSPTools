import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LoadLocalesMapText } from './map.locales'
import { HttpClient } from '@angular/common/http';
import { MapTextModel } from './map.models';

@Injectable({
  providedIn: 'root'
})
export class MapService {
  mapTextModel$: BehaviorSubject<MapTextModel> = new BehaviorSubject<MapTextModel>(<MapTextModel>{});

  constructor(private httpClient: HttpClient) {
    LoadLocalesMapText(this);
    this.UpdateMapText(<MapTextModel>{ Title: "Something for text" });
  }

  UpdateMapText(mapTextModel: MapTextModel) {
    this.mapTextModel$.next(<MapTextModel>{ ...this.mapTextModel$.getValue(), ...mapTextModel });
  }

}
