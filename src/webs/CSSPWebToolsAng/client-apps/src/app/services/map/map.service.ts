import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapMarkersService } from 'src/app/services/map/map-markers.service';
import { MapPolygonsService } from 'src/app/services/map/map-polygons.service';
import { MapPolylinesService } from 'src/app/services/map/map-polylines.service';
import { PreferenceService } from '../loaders/preferences.service';
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
    private mapHelperService: MapHelperService,
    private preferenceService: PreferenceService) {
  }

  ClearMap() {
    let length: number = this.appLoadedService.AppLoaded$.getValue()?.GoogleCrossPolylineListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.AppLoaded$.getValue().GoogleCrossPolylineListMVC.getAt(i).setMap(null);
    }

    length = this.appLoadedService.AppLoaded$.getValue()?.GoogleMarkerListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.AppLoaded$.getValue().GoogleMarkerListMVC.getAt(i).setMap(null);
    }

    length = this.appLoadedService.AppLoaded$.getValue()?.GooglePolygonListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.AppLoaded$.getValue().GooglePolygonListMVC.getAt(i).setMap(null);
    }

    length = this.appLoadedService.AppLoaded$.getValue()?.GooglePolylineListMVC?.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.AppLoaded$.getValue().GooglePolylineListMVC.getAt(i).setMap(null);
    }

    this.appLoadedService.AppLoaded$.getValue()?.GoogleMarkerListMVC?.clear();
    this.appLoadedService.AppLoaded$.getValue()?.GooglePolygonListMVC?.clear();
    this.appLoadedService.AppLoaded$.getValue()?.GooglePolylineListMVC?.clear();

    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      GoogleMarkerListMVC: new google.maps.MVCArray<google.maps.Marker>([]),
      GooglePolygonListMVC: new google.maps.MVCArray<google.maps.Polygon>([]),
      GooglePolylineListMVC: new google.maps.MVCArray<google.maps.Polyline>([]),
    });
  }

  DrawObjects(webBaseList: WebBase[]) {
    this.mapMarkersService.DrawMarkers(webBaseList);
    this.mapPolygonsService.DrawPolygons(webBaseList);
    this.mapPolylinesService.DrawPolylines(webBaseList);
    this.mapHelperService.FitBounds();
  }

  SetupMap(mapElement: any) {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      Map: new google.maps.Map(
        mapElement.nativeElement,
        {
          center: new google.maps.LatLng(46.291624, -64.722614),
          zoom: 10,
          mapTypeId: google.maps.MapTypeId.HYBRID,
        }
      ),
      GoogleCrossPolylineListMVC: new google.maps.MVCArray<google.maps.Polyline>([]),
      GoogleMarkerListMVC: new google.maps.MVCArray<google.maps.Marker>([]),
      GooglePolygonListMVC: new google.maps.MVCArray<google.maps.Polygon>([]),
      GooglePolylineListMVC: new google.maps.MVCArray<google.maps.Polyline>([]),
    });
  }

  ShowItem(tvItemModel: TVItemModel, event: Event) {
    let length: number = this.appLoadedService.AppLoaded$.getValue().GoogleCrossPolylineListMVC.getLength();
    for (let i = 0; i < length; i++) {
      this.appLoadedService.AppLoaded$.getValue().GoogleCrossPolylineListMVC.getAt(i).setMap(null);
    }

    let CurrentPoint: google.maps.LatLng;

    length = tvItemModel.MapInfoModelList.length;
    for (let i = 0; i < length; i++) {
      if (tvItemModel.MapInfoModelList[i].MapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Point) {
        CurrentPoint = new google.maps.LatLng(tvItemModel.MapInfoModelList[i].MapInfoPointList[0].Lat, tvItemModel.MapInfoModelList[i].MapInfoPointList[0].Lng);
        break;
      }
    }

    let CurrentBound: google.maps.LatLngBounds = this.appLoadedService.AppLoaded$.getValue().Map.getBounds()
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
      map: this.appLoadedService.AppLoaded$.getValue().Map,
      zIndex: 200,
    });

    this.appLoadedService.AppLoaded$.getValue().GoogleCrossPolylineListMVC.push(polyl1);
    let CoordList2 = [];
    CoordList2.push(new google.maps.LatLng(ne.lat(), sw.lng()));
    CoordList2.push(new google.maps.LatLng(CurrentPoint.lat(), CurrentPoint.lng()));
    CoordList2.push(new google.maps.LatLng(ne.lat(), ne.lng()));
    let polyl2: google.maps.Polyline = new google.maps.Polyline({
      path: CoordList2,
      strokeColor: '#FCF',
      strokeOpacity: 0.5,
      strokeWeight: 2,
      map: this.appLoadedService.AppLoaded$.getValue().Map,
      zIndex: 200,
    });

    this.appLoadedService.AppLoaded$.getValue().GoogleCrossPolylineListMVC.push(polyl2);

    //event.stopPropagation();
  }

}
