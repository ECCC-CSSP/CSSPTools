import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class MapMarkersService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService) {
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
          let label: google.maps.MarkerLabel = { color: 'ff0000', fontWeight: 'bold',  text: count.toString() };
          let title = webBase.TVItemModel.TVItemLanguageEN.TVText;
          let info = webBase.TVItemModel.TVItemLanguageEN.TVText;
          let options: google.maps.MarkerOptions = {
            position: position,
            label: label,
            title: title,
            // icon: {
            //   path: google.maps.SymbolPath.CIRCLE,
            //   scale: 3,
            // },
            map: this.appLoadedService.AppLoaded$.getValue().Map,
          };

          markerList.push(new google.maps.Marker(options));
        }
      };
    }

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ GoogleMarkerListMVC: new google.maps.MVCArray<google.maps.Marker>(markerList) });
  }
}
