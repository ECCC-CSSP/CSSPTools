import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolylinesService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService) {
  }

  DrawPolylines(webBaseList: WebBase[]) {
    let polylineList: google.maps.Polyline[] = [];

    for (let webBase of webBaseList) {
      for (let mapInfoModel of webBase.TVItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline) {

          let polyPoints = new google.maps.MVCArray<google.maps.LatLng>();
          for (let point of mapInfoModel.MapInfoPointList) {
            polyPoints.push(new google.maps.LatLng(point.Lat, point.Lng));
          }

          let options: google.maps.PolylineOptions = {
            path: polyPoints,
            strokeColor: "#FF0000",
            strokeOpacity: 0.8,
            strokeWeight: 2,
            map: this.appLoadedService.AppLoaded$.getValue().Map,
          };

          polylineList.push(new google.maps.Polyline(options));
        }
      };
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ GooglePolylineListMVC: new google.maps.MVCArray<google.maps.Polyline>(polylineList) });
  }
}
