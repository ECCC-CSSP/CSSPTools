import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class MapMarkersService {

  constructor(private appStateService: AppStateService) {
  }

  FillMapMarkers(webBaseList: WebBase[]) {
    let markers: any[] = [];

    for (let webBase of webBaseList) {
      for (let mapInfoModel of webBase.TVItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Point) {
          let position: google.maps.LatLngLiteral = { lat: mapInfoModel.MapInfoPointList[0].Lat, lng: mapInfoModel.MapInfoPointList[0].Lng };
          let label: google.maps.MarkerLabel = { color: 'red', text: webBase.TVItemModel.TVItemLanguageEN.TVText };
          let title = 'title - ' + webBase.TVItemModel.TVItemLanguageEN.TVText;
          let info = 'info - ' + webBase.TVItemModel.TVItemLanguageEN.TVText;
          let options: google.maps.MarkerOptions = {};

          markers.push({
            position: position,
            label: label,
            title: title,
            info: info,
            options: options,
          });
        }
      };
    }

    this.appStateService.UpdateAppState(<AppState>{ markerList: markers });
  }
}
