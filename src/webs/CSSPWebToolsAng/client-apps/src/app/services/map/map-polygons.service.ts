import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapHelperService } from './map-helper.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolygonsService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private mapHelperService: MapHelperService) {
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

          let strokeColor: string = this.mapHelperService.GetMapPolygonColor(mapInfoModel.MapInfo.TVType);
          let fillColor: string = this.mapHelperService.GetMapPolygonColor(mapInfoModel.MapInfo.TVType);

          let options: google.maps.PolygonOptions = {
            paths: polyPoints,
            strokeColor: strokeColor,
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: fillColor,
            fillOpacity: 0.0,
            map: this.appLoadedService.AppLoaded$.getValue().Map,
          };

          polygonList.push(new google.maps.Polygon(options));

          google.maps.event.addListener(polygonList[polygonList.length - 1], "mousemove", (evt: google.maps.MouseEvent) => {
            if (!this.appStateService.AppState$.getValue().EditMapChanged) {
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (evt.latLng.lat().toString().substring(0, 8) +
                ' ' + evt.latLng.lng().toString().substring(0, 8));
            }
            else{
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (this.appStateService.AppState$.getValue().MarkerDragStartPos.lat().toFixed(6) +
              ' ' + this.appStateService.AppState$.getValue().MarkerDragStartPos.lng().toFixed(6));
            }
          });

        }
      };
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ GooglePolygonListMVC: new google.maps.MVCArray<google.maps.Polygon>(polygonList) });
  }
}
