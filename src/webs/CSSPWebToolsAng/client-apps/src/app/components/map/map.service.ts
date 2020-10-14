import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AppService } from '../../app.service';
import { AppVar } from '../../app.model';
import { MapInfoDrawTypeEnum } from '../../enums/generated/MapInfoDrawTypeEnum';
import { WebBase } from '../../models/generated/WebBase.model';
import { LoadLocalesMapText } from './map.locales'
import { MapVar } from './map.models';

@Injectable({
  providedIn: 'root'
})
export class MapService {
  MapVar$: BehaviorSubject<MapVar> = new BehaviorSubject<MapVar>(<MapVar>{});

  constructor(private appService: AppService) {
    LoadLocalesMapText(this);
    this.UpdateMapVar(<MapVar>{ 
      MapTitle: "Something for text", 
      zoom: 12,
      center: <google.maps.LatLngLiteral>{ lat: 46.0915449, lng: -64.7242012 },
      options: <google.maps.MapOptions>{
        //zoomControl: true,
        //scrollwheel: true,
        //disableDoubleClickZoom: false,
        mapTypeId: this.appService.AppVar$?.getValue()?.mapTypeId,
        // maxZoom: 15,
        // minZoom: 8,
      },
      markerList: [],
      polygonList: [],
      polylineList: [],
      infoContent: ''
    });
    this.appService.UpdateAppVar(<AppVar>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID });
  }

  ToggleMapType(router: Router, property: string) {
    property == "hybrid" ? this.appService.UpdateAppVar(<AppVar>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID }) : null;
    property == "satellite" ? this.appService.UpdateAppVar(<AppVar>{ HybridVisible: true, SatelliteVisible: true, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.SATELLITE }) : null;
    property == "roadmap" ? this.appService.UpdateAppVar(<AppVar>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: true, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.ROADMAP }) : null;
    property == "terrain" ? this.appService.UpdateAppVar(<AppVar>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: true, mapTypeId: google.maps.MapTypeId.TERRAIN }) : null;
    //this.shellService.ChangeUrl(router, property);
  }

  UpdateMapVar(mapVar: MapVar) {
    this.MapVar$.next(<MapVar>{ ...this.MapVar$.getValue(), ...mapVar });
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

    this.UpdateMapVar(<MapVar>{ markerList: markers });
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

    this.UpdateMapVar(<MapVar>{ polygonList: polygons });
  }

}
