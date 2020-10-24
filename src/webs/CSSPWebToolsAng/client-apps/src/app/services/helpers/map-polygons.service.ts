import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolygonsService {

  constructor(private appStateService: AppStateService) {
  }

  FillMapPolygons(webBaseList: WebBase[]) {
    let polygons: any[] = [];

    for (let webBase of webBaseList) {
      for (let mapInfoModel of webBase.TVItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon) {
          // let position: google.maps.LatLngLiteral = { lat: mapInfoModel.MapInfoPointList[0].Lat, lng: mapInfoModel.MapInfoPointList[0].Lng };
          // let label: google.maps.MarkerLabel = { color: 'red', text: webBase.TVItemModel.TVItemLanguageEN.TVText };
          // let title = 'title - ' + webBase.TVItemModel.TVItemLanguageEN.TVText;
          // let info = 'info - ' + webBase.TVItemModel.TVItemLanguageEN.TVText;

          let polyPoints = new google.maps.MVCArray<google.maps.LatLng>();
          for (let point of mapInfoModel.MapInfoPointList) {
            polyPoints.push(new google.maps.LatLng(point.Lat, point.Lng));
          }

          let polygon = new google.maps.Polygon({
            paths: polyPoints,
            strokeColor: "#FF0000",
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: "#FF0000",
            fillOpacity: 0.35,
          });

          polygons.push(polygon);
        }
      };
    }

    this.appStateService.UpdateAppState(<AppState>{ polygonList: polygons });
  }


}
