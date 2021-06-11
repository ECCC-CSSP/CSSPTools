import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { MapMarkersService } from 'src/app/services/map/map-markers.service';
import { MapPolygonsService } from 'src/app/services/map/map-polygons.service';
import { MapPolylinesService } from 'src/app/services/map/map-polylines.service';
import { MapHelperService } from './map-helper.service';


@Injectable({
  providedIn: 'root'
})
export class MapService {
  map: google.maps.Map;

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private mapMarkersService: MapMarkersService,
    private mapPolygonsService: MapPolygonsService,
    private mapPolylinesService: MapPolylinesService,
    private mapHelperService: MapHelperService) {
  }

  MapMarkerSaveChanges() {
    let coordText: string = (<HTMLInputElement>document.getElementById('ChangedLatLng')).value;
    let lat: number = parseFloat(coordText.substring(0, coordText.indexOf(' ')));
    let lng: number = parseFloat(coordText.substring(coordText.indexOf(' ')));
    alert(`${this.appStateService?.MarkerTVItemID} ||| ${this.appStateService?.MarkerMapInfoID} ||| ${lat} ${lng}`);

    this.appStateService.MarkerLabel = '';
    this.appStateService.EditMapChanged = false;
    this.appStateService.MarkerMapInfoID = 0;
    this.appStateService.MarkerDragStartPos = null;
    this.appStateService.MarkerDragEndPos = null;
  }

  ClearMap() {
    let length: number = this.appLoadedService.GoogleCrossPolylineListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.GoogleCrossPolylineListMVC.getAt(i).setMap(null);
    }

    length = this.appLoadedService.GoogleMarkerListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.GoogleMarkerListMVC.getAt(i).setMap(null);
    }

    length = this.appLoadedService.GooglePolygonListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.GooglePolygonListMVC.getAt(i).setMap(null);
    }

    length = this.appLoadedService.GooglePolylineListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.GooglePolylineListMVC.getAt(i).setMap(null);
    }

    this.appLoadedService.GoogleMarkerListMVC?.clear();
    this.appLoadedService.GooglePolygonListMVC?.clear();
    this.appLoadedService.GooglePolylineListMVC?.clear();

    this.appLoadedService.GoogleMarkerListMVC = new google.maps.MVCArray<google.maps.Marker>([]);
    this.appLoadedService.GooglePolygonListMVC = new google.maps.MVCArray<google.maps.Polygon>([]);
    this.appLoadedService.GooglePolylineListMVC = new google.maps.MVCArray<google.maps.Polyline>([]);
  }

  DrawObjects(tvItemModelList: TVItemModel[]) {
    this.mapMarkersService.DrawMarkers(tvItemModelList);
    this.mapPolygonsService.DrawPolygons(tvItemModelList);
    this.mapPolylinesService.DrawPolylines(tvItemModelList);
    this.mapHelperService.FitBounds();
  }

  SetupMap(mapElement: any) {
    this.appLoadedService.Map = new google.maps.Map(
      mapElement.nativeElement,
      {
        center: new google.maps.LatLng(46.291624, -64.722614),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.HYBRID,
      }
    );
    this.appLoadedService.GoogleCrossPolylineListMVC = new google.maps.MVCArray<google.maps.Polyline>([]);
    this.appLoadedService.GoogleMarkerListMVC = new google.maps.MVCArray<google.maps.Marker>([]);
    this.appLoadedService.GooglePolygonListMVC = new google.maps.MVCArray<google.maps.Polygon>([]);
    this.appLoadedService.GooglePolylineListMVC = new google.maps.MVCArray<google.maps.Polyline>([]);
    this.appLoadedService.MarkerOriginal = null;
    this.appLoadedService.MarkerChanged = null;

    this.appLoadedService.Map.controls[google.maps.ControlPosition.TOP_CENTER].push(document.getElementById("MapTopCenterID"));

    google.maps.event.addListener(this.appLoadedService.Map, "mousemove", (evt: google.maps.MouseEvent) => {
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

  ShowItem(tvItemModel: TVItemModel, event: Event) {
    let length: number = this.appLoadedService.GoogleCrossPolylineListMVC.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.GoogleCrossPolylineListMVC.getAt(i).setMap(null);
    }

    let CurrentPoint: google.maps.LatLng;

    length = tvItemModel.MapInfoModelList?.length;
    for (let i = 0; i < length; i++) {
      if (tvItemModel.MapInfoModelList[i].MapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Point) {
        CurrentPoint = new google.maps.LatLng(tvItemModel.MapInfoModelList[i].MapInfoPointList[0].Lat, tvItemModel.MapInfoModelList[i].MapInfoPointList[0].Lng);
        break;
      }
    }

    let CurrentBound: google.maps.LatLngBounds = this.appLoadedService.Map.getBounds()
    let sw = CurrentBound.getSouthWest();
    let ne = CurrentBound.getNorthEast();

    let CoordList = [];
    CoordList.push(new google.maps.LatLng(sw.lat(), sw.lng()));
    CoordList.push(new google.maps.LatLng(CurrentPoint.lat(), CurrentPoint.lng()));
    CoordList.push(new google.maps.LatLng(sw.lat(), ne.lng()));
    let polyl1: google.maps.Polyline = new google.maps.Polyline({
      path: CoordList,
      strokeColor: '#FCF',
      strokeOpacity: 0.5,
      strokeWeight: 2,
      map: this.appLoadedService.Map,
      zIndex: 200,
    });

    this.appLoadedService.GoogleCrossPolylineListMVC.push(polyl1);
    let CoordList2 = [];
    CoordList2.push(new google.maps.LatLng(ne.lat(), sw.lng()));
    CoordList2.push(new google.maps.LatLng(CurrentPoint.lat(), CurrentPoint.lng()));
    CoordList2.push(new google.maps.LatLng(ne.lat(), ne.lng()));
    let polyl2: google.maps.Polyline = new google.maps.Polyline({
      path: CoordList2,
      strokeColor: '#FCF',
      strokeOpacity: 0.5,
      strokeWeight: 2,
      map: this.appLoadedService.Map,
      zIndex: 200,
    });

    this.appLoadedService.GoogleCrossPolylineListMVC.push(polyl2);
  }

}
