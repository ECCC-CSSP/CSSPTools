import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { TVItemStatMapModel } from 'src/app/models/generated/web/TVItemStatMapModel.model';
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

  DrawPolylines(tvItemStatMapList: TVItemStatMapModel[]) {
    let polylineList: google.maps.Polyline[] = [];

    for (let tvItemStatMapModel of tvItemStatMapList) {
      for (let mapInfoModel of tvItemStatMapModel.MapInfoModelList) {
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
            map: this.appLoadedService.AppLoaded$.getValue().Map,
          };

          polylineList.push(new google.maps.Polyline(options));

          google.maps.event.addListener(polylineList[polylineList.length - 1], "mousemove", (evt: google.maps.MouseEvent) => {
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

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ GooglePolylineListMVC: new google.maps.MVCArray<google.maps.Polyline>(polylineList) });
  }
}
