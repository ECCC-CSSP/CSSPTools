import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapHelperService } from 'src/app/services/map/map-helper.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolylinesService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private mapHelperService: MapHelperService) {
  }

  DrawPolylines(tvItemStatMapList: TVItemModel[]) {
    let polylineList: google.maps.Polyline[] = [];

    for (let tvItemModel of tvItemStatMapList) {
      for (let mapInfoModel of tvItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline) {

          let polyPoints = new google.maps.MVCArray<google.maps.LatLng>();
          for (let point of mapInfoModel.MapInfoPointList) {
            polyPoints.push(new google.maps.LatLng(point.Lat, point.Lng));
          }

          let strokeColor: string = this.mapHelperService.GetMapPolylineColor(mapInfoModel.MapInfo.TVType, mapInfoModel.MapInfo.TVType);

          let options: google.maps.PolylineOptions = {
            path: polyPoints,
            strokeColor: strokeColor,
            strokeOpacity: 0.8,
            strokeWeight: 2,
            map: this.appLoadedService.Map,
          };

          polylineList.push(new google.maps.Polyline(options));

          google.maps.event.addListener(polylineList[polylineList.length - 1], "mousemove", (evt: google.maps.MouseEvent) => {
            if (!this.appStateService.EditMapChanged) {
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (evt.latLng.lat().toString().substring(0, 8) +
                ' ' + evt.latLng.lng().toString().substring(0, 8));
            }
            else{
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (this.appStateService.MarkerDragStartPos.lat().toFixed(6) +
              ' ' + this.appStateService.MarkerDragStartPos.lng().toFixed(6));
            }
          });

        }
      };
    }

    this.appLoadedService.GooglePolylineListMVC = new google.maps.MVCArray<google.maps.Polyline>(polylineList);
  }
}
