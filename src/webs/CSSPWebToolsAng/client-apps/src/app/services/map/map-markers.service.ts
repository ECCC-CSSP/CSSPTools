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
export class MapMarkersService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private mapHelperService: MapHelperService) {
  }

  DrawMarkers(webBaseList: WebBase[]) {
    let map: google.maps.Map = this.appLoadedService.AppLoaded$.getValue().Map;

    let markerList: google.maps.Marker[] = [];

    let count: number = 0;
    for (let webBase of webBaseList) {
      count += 1;
      for (let mapInfoModel of webBase.TVItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Point) {
          let position: google.maps.LatLngLiteral = { lat: mapInfoModel.MapInfoPointList[0].Lat, lng: mapInfoModel.MapInfoPointList[0].Lng };
          let label: google.maps.MarkerLabel = { color: '00ff00', fontWeight: 'bold', text: count.toString() };
          let title = webBase.TVItemModel.TVItemLanguageList[this.appStateService.AppState$.getValue().Language].TVText;
          let info = webBase.TVItemModel.TVItemLanguageList[this.appStateService.AppState$.getValue().Language].TVText;
          let path: string = this.appStateService.AppState$.getValue().MapMarkerPathCharacters[3]; // 3 characters
          let strokeColor: string = this.mapHelperService.GetMapMarkerColor(mapInfoModel.MapInfo.TVType);
          let fillColor: string = this.mapHelperService.GetMapMarkerColor(mapInfoModel.MapInfo.TVType);

          if (label.text) {
            if (label.text.length < 6) {
              path = this.appStateService.AppState$.getValue().MapMarkerPathCharacters[label.text.length];
            }
          }

          let options: google.maps.MarkerOptions = {
            position: position,
            label: label,
            title: title,
            icon: {
              path: path,
              strokeColor: strokeColor,
              strokeOpacity: 1,
              strokeWeight: 1,
              fillColor: fillColor,
              fillOpacity: 0.8,
              rotation: 0,
              scale: 0.8,
              labelOrigin: new google.maps.Point(0, -18),
            },
            map: this.appLoadedService.AppLoaded$.getValue().Map,
          };

          markerList.push(new google.maps.Marker(options));
        }
      };
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ GoogleMarkerListMVC: new google.maps.MVCArray<google.maps.Marker>(markerList) });
  }
}
