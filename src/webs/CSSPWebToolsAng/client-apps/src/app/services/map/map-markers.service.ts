import { Injectable } from '@angular/core';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { MapInfoModel } from 'src/app/models/generated/web/MapInfoModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { MapHelperService } from 'src/app/services/map/map-helper.service';
import { AppLanguageService } from '../app-language.service';

@Injectable({
  providedIn: 'root'
})
export class MapMarkersService {

  tvItemModelList: TVItemModel[];

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private appLanguageService: AppLanguageService,
    private mapHelperService: MapHelperService) {
  }

  DrawMarkers(tvItemModelList: TVItemModel[]) {
    this.tvItemModelList = tvItemModelList;

    let map: google.maps.Map = this.appLoadedService.Map;

    let markerList: google.maps.Marker[] = [];

    let count: number = 0;
    for (let tvItemModel of tvItemModelList) {
      for (let mapInfoModel of tvItemModel.MapInfoModelList) {
        if (mapInfoModel.MapInfo?.MapInfoDrawType == MapInfoDrawTypeEnum.Point) {
          let mark: google.maps.Marker = new google.maps.Marker();

          count += 1;

          let position: google.maps.LatLngLiteral = { lat: mapInfoModel.MapInfoPointList[0].Lat, lng: mapInfoModel.MapInfoPointList[0].Lng };
          let label: google.maps.MarkerLabel = { color: '00ff00', fontWeight: 'bold', text: count.toString() };
          let title = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
          let info = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID].TVText;
          let path: string = this.appStateService.MapMarkerPathCharacters[3]; // 3 characters
          let strokeColor: string = this.mapHelperService.GetMapMarkerColor(mapInfoModel.MapInfo.TVType);
          let fillColor: string = this.mapHelperService.GetMapMarkerColor(mapInfoModel.MapInfo.TVType);

          if (label.text) {
            if (label.text.length < 6) {
              path = this.appStateService.MapMarkerPathCharacters[label.text.length];
            }
          }

          // if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites) {
          //   let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);

          //   if (statMWQMSiteList && statMWQMSiteList.length > 0) {
          //     strokeColor = statMWQMSiteList[0]?.StatMWQMSiteSampleList[0]?.ColorAndLetter?.hexColor;
          //     fillColor = statMWQMSiteList[0]?.StatMWQMSiteSampleList[0]?.ColorAndLetter?.hexColor;
          //     label.text = `${label.text} ${statMWQMSiteList[0]?.StatMWQMSiteSampleList[0]?.ColorAndLetter?.letter}`;
          //   }
          // }

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
            map: map,
            draggable: this.appStateService.EditMapVisible,
            zIndex: mapInfoModel.MapInfo.MapInfoID,
          };

          mark = new google.maps.Marker(options);

          if (this.appStateService.EditMapVisible) {
            google.maps.event.addListener(mark, "mousemove", (evt: google.maps.MouseEvent) => {
              if (!this.appStateService.EditMapChanged) {
                (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (evt.latLng.lat().toString().substring(0, 8) +
                  ' ' + evt.latLng.lng().toString().substring(0, 8));
              }
              else{
                (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (this.appStateService.MarkerDragStartPos.lat().toFixed(6) +
                ' ' + this.appStateService.MarkerDragStartPos.lng().toFixed(6));
              }
            });

            google.maps.event.addListener(mark, 'dragstart', () => {
              this.appStateService.MarkerTVItemID = mapInfoModel.MapInfo.TVItemID;
              this.appStateService.MarkerMapInfoID = mapInfoModel.MapInfo.MapInfoID;
              this.appStateService.MarkerDragStartPos = this.GetMapInfoCoord(mapInfoModel);
              this.appStateService.EditMapChanged =  true;
              this.appStateService.MarkerLabel = mark.getLabel().text;
             
              (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (this.appStateService.MarkerDragStartPos.lat().toFixed(6) +
                ' ' + this.appStateService.MarkerDragStartPos.lng().toFixed(6));
            });
            google.maps.event.addListener(mark, 'drag', () => {
              (<HTMLInputElement>document.getElementById("ChangedLatLng")).value = (mark.getPosition().lat().toFixed(6) +
                ' ' + mark.getPosition().lng().toFixed(6));
            });
            google.maps.event.addListener(mark, 'dragend', () => {
              this.appStateService.MarkerDragEndPos = mark.getPosition();
              (<HTMLInputElement>document.getElementById("ChangedLatLng")).value = (mark.getPosition().lat().toFixed(6) +
                ' ' + mark.getPosition().lng().toFixed(6));
            });
          }
          markerList.push(mark);

        }
      };
    }

    this.appLoadedService.GoogleMarkerListMVC = new google.maps.MVCArray<google.maps.Marker>(markerList);
  }

  GetMapInfoCoord(mapInfoModel: MapInfoModel): google.maps.LatLng {
    return new google.maps.LatLng(mapInfoModel.MapInfoPointList[0].Lat, mapInfoModel.MapInfoPointList[0].Lng);
  }
}
