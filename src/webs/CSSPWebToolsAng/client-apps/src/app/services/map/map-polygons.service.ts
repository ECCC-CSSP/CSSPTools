import { Injectable } from '@angular/core';
import { count } from 'rxjs/operators';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { MapHelperService } from 'src/app/services/map/map-helper.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolygonsService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private mapHelperService: MapHelperService) {
  }

  DrawPolygons(tvItemModelList: TVItemModel[]) {
    let polygonList: google.maps.Polygon[] = [];

    for (let tvItemModel of tvItemModelList) {
      for (let mapInfoModel of tvItemModel.MapInfoModelList) {
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
            map: this.appLoadedService.Map,
          };

          polygonList.push(new google.maps.Polygon(options));

          google.maps.event.addListener(polygonList[polygonList?.length - 1], "mousemove", (evt: google.maps.MouseEvent) => {
            if (!this.appStateService.EditMapChanged) {
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (evt.latLng.lat().toString().substring(0, 8) +
                ' ' + evt.latLng.lng().toString().substring(0, 8));
            }
            else {
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (this.appStateService.MarkerDragStartPos.lat().toFixed(6) +
                ' ' + this.appStateService.MarkerDragStartPos.lng().toFixed(6));
            }
          });

        }
      };
    }

    for (let i = 0, count = polygonList.length; i < count; i++) {
      this.appLoadedService.GooglePolygonListMVC.push(polygonList[i]);
    }

  }
}
