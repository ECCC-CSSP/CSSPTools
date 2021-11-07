import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { MapHelperService } from 'src/app/services/map/map-helper.service';
import { AppLanguageService } from '../app/app-language.service';

@Injectable({
  providedIn: 'root'
})
export class MapPolylinesService {

  constructor(private appStateService: AppStateService,
    private appLanguageService: AppLanguageService,
    private appLoadedService: AppLoadedService,
    private mapHelperService: MapHelperService) {
  }

  DrawPolylines(tvItemMapList: TVItemModel[]) {
    let polylineList: google.maps.Polyline[] = [];
    let polygonList: google.maps.Polygon[] = [];

    for (let tvItemModel of tvItemMapList) {
      for (let mapInfoModel of tvItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline) {

          if (tvItemModel.TVItem.TVType != TVTypeEnum.Classification) {

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

            google.maps.event.addListener(polylineList[polylineList?.length - 1], "mousemove", (evt: google.maps.MapMouseEvent) => {
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

          if (tvItemModel.TVItem.TVType == TVTypeEnum.Classification) {

            let polyPoints = new google.maps.MVCArray<google.maps.LatLng>();
            for (let point of mapInfoModel.MapInfoPointList) {
              polyPoints.push(new google.maps.LatLng(point.Lat, point.Lng));
            }

            let strokeColor: string = "#000000";

            switch (tvItemModel.TVItemLanguageList[0 /* english */]?.TVText.substring(0, 1).toUpperCase()) {
              case ('A'):
                {
                  strokeColor = "#00FF00";
                }
                break;
              case ('R'):
                {
                  strokeColor = "#FF0000";
                }
                break;
              case ('P'):
                {
                  strokeColor = "#cccccc";
                }
                break;
              case ('CA'):
                {
                  strokeColor = "#e1bd00";
                }
                break;
              case ('CR'):
                {
                  strokeColor = "#9932cc";
                }
                break;
              default:
            }

            for (let i = 0, count = polyPoints.getLength() - 1; i < count; i++) {
              let spherical = google.maps.geometry.spherical;
              let F = polyPoints.getAt(i); // new google.maps.LatLng(polyPoints[i].lat(), polyPoints[i].lng());
              let T = polyPoints.getAt(i + 1); //new google.maps.LatLng(polyPoints[i + 1].lat(), polyPoints[i + 1].lng());
              // M is the middle of [FT]
              let latM = (polyPoints.getAt(i).lat() + polyPoints.getAt(i + 1).lat()) / 2;
              let longM = (polyPoints.getAt(i).lng() + polyPoints.getAt(i + 1).lng()) / 2;
              let M = new google.maps.LatLng(latM, longM);
              // Get direction of the segment
              let heading = spherical.computeHeading(F, T);
              let dist = 50; // distance in meters
              let length = spherical.computeDistanceBetween(F, T);
              if (length < 50) {
                dist = 10;
              }
              else if (length < 200) {
                dist = 20;
              }
              // Place point A that is oriented at 90° in a distance of dist from M
              let A = spherical.computeOffset(M, dist, heading + 90);
              let perpendicularCoordinates = [F, T, A, F];

              let polyg: google.maps.Polygon = new google.maps.Polygon({
                paths: perpendicularCoordinates,
                strokeColor: strokeColor,
                strokeOpacity: 1.0,
                strokeWeight: 2,
                fillColor: strokeColor,
                fillOpacity: 1.0,
                map: this.appLoadedService.Map,
                //zIndex: zIndex,
              });

              polyg.setMap(this.appLoadedService.Map);

              polygonList.push(polyg);

            }
          }


        }
      };
    }

    for (let i = 0, count = polylineList.length; i < count; i++) {
      this.appLoadedService.GooglePolylineListMVC.push(polylineList[i]);
    }

    for (let i = 0, count = polygonList.length; i < count; i++) {
      this.appLoadedService.GooglePolygonListMVC.push(polygonList[i]);
    }
  }
}
