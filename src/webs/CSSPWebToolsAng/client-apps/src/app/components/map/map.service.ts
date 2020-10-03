import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { LatLng } from 'src/app/models/generated/LatLng.model';
import { PolyPoint } from 'src/app/models/generated/PolyPoint.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { ShellModel, ShellService } from 'src/app/pages/shell';
import { LoadLocalesMapText } from './map.locales'
import { MapModel, MapTextModel } from './map.models';

@Injectable({
  providedIn: 'root'
})
export class MapService {
  MapTextModel$: BehaviorSubject<MapTextModel> = new BehaviorSubject<MapTextModel>(<MapTextModel>{});
  MapModel$: BehaviorSubject<MapModel> = new BehaviorSubject<MapModel>(<MapModel>{});

  constructor(private shellService: ShellService) {
    LoadLocalesMapText(this);
    this.UpdateMapTextModel(<MapTextModel>{ Title: "Something for text" });
    this.shellService.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID });
    this.UpdateMapModel(<MapModel>{
      zoom: 12,
      center: <google.maps.LatLngLiteral>{ lat: 46.0915449, lng: -64.7242012 },
      options: <google.maps.MapOptions>{
        //zoomControl: true,
        //scrollwheel: true,
        //disableDoubleClickZoom: false,
        mapTypeId: this.shellService.ShellModel$?.getValue()?.mapTypeId,
        // maxZoom: 15,
        // minZoom: 8,
      },
      markerList: [],
      polygonList: [],
      polylineList: [],
      infoContent: ''
    });
  }

  ToggleMapType(router: Router, property: string) {
    property == "hybrid" ? this.shellService.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID }) : null;
    property == "satellite" ? this.shellService.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: true, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.SATELLITE }) : null;
    property == "roadmap" ? this.shellService.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: true, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.ROADMAP }) : null;
    property == "terrain" ? this.shellService.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: true, mapTypeId: google.maps.MapTypeId.TERRAIN }) : null;
    //this.shellService.ChangeUrl(router, property);
  }

  UpdateMapTextModel(mapTextModel: MapTextModel) {
    this.MapTextModel$.next(<MapTextModel>{ ...this.MapTextModel$.getValue(), ...mapTextModel });
  }

  UpdateMapModel(mapModel: MapModel) {
    this.MapModel$.next(<MapModel>{ ...this.MapModel$.getValue(), ...mapModel });
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

    this.UpdateMapModel(<MapModel>{ markerList: markers });
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

    this.UpdateMapModel(<MapModel>{ polygonList: polygons });
  }

}
