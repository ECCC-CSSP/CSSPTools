import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolygonsService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService) {
  }

  DrawPolygons(webBaseList: WebBase[]) {
    let polygonList: google.maps.Polygon[] = [];

    for (let webBase of webBaseList) {
      for (let mapInfoModel of webBase.TVItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon) {

          let polyPoints = new google.maps.MVCArray<google.maps.LatLng>();
          for (let point of mapInfoModel.MapInfoPointList) {
            polyPoints.push(new google.maps.LatLng(point.Lat, point.Lng));
          }

          let options: google.maps.PolygonOptions = {
            paths: polyPoints,
            strokeColor: "#FF0000",
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: "#FF0000",
            fillOpacity: 0.0,
            map: this.appLoadedService.AppLoaded$.getValue().Map,
          };

          polygonList.push(new google.maps.Polygon(options));
        }
      };
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ GooglePolygonListMVC: new google.maps.MVCArray<google.maps.Polygon>(polygonList) });
  }
}
