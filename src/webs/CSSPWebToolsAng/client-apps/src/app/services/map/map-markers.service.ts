import { Injectable } from '@angular/core';
import { GetInfrastructureTypeEnum } from 'src/app/enums/generated/InfrastructureTypeEnum';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { MunicipalitySubComponentEnum } from 'src/app/enums/generated/MunicipalitySubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { PolSourceObservationIssue } from 'src/app/models/generated/db/PolSourceObservationIssue.model';
import { InfrastructureModelPath } from 'src/app/models/generated/web/InfrastructureModelPath.model';
import { MapInfoModel } from 'src/app/models/generated/web/MapInfoModel.model';
import { PolSourceObservationModel } from 'src/app/models/generated/web/PolSourceObservationModel.model';
import { PolSourceSiteModel } from 'src/app/models/generated/web/PolSourceSiteModel.model';
import { StatMWQMSite } from 'src/app/models/generated/web/StatMWQMSite.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { MapHelperService } from 'src/app/services/map/map-helper.service';
import { AppLanguageService } from '../app/app-language.service';

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
    let infrastructureType = GetInfrastructureTypeEnum();

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
          let title = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let info = tvItemModel.TVItemLanguageList[this.appLanguageService.LangID]?.TVText;
          let path: string = this.appStateService.MapMarkerPathCharacters[3]; // 3 characters
          let strokeColor: string = this.mapHelperService.GetMapMarkerColor(mapInfoModel.MapInfo.TVType);
          let fillColor: string = this.mapHelperService.GetMapMarkerColor(mapInfoModel.MapInfo.TVType);

          if (label.text) {
            if (label.text?.length < 6) {
              path = this.appStateService.MapMarkerPathCharacters[label.text?.length];
            }
          }

          if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.MWQMSites
            || this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.Analysis) {
            let statMWQMSiteList: StatMWQMSite[] = this.appLoadedService.StatMWQMSiteList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);

            if (statMWQMSiteList && statMWQMSiteList?.length > 0) {
              strokeColor = statMWQMSiteList[0]?.StatMWQMSiteSampleList[0]?.ColorAndLetter?.hexColor;
              fillColor = statMWQMSiteList[0]?.StatMWQMSiteSampleList[0]?.ColorAndLetter?.hexColor;
              label.text = `${label.text} ${statMWQMSiteList[0]?.StatMWQMSiteSampleList[0]?.ColorAndLetter?.letter}`;

              path = this.appStateService.MapMarkerPathCharacters[label.text?.length];
            }
          }

          if (this.appStateService.UserPreference.SubsectorSubComponent == SubsectorSubComponentEnum.PollutionSourceSites) {
            strokeColor = '#ffffff';
            fillColor = '#ffffff';

            let PolSourceSiteModelList: PolSourceSiteModel[] = this.appLoadedService.WebPolSourceSites.PolSourceSiteModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == tvItemModel.TVItem.TVItemID);

            if (PolSourceSiteModelList && PolSourceSiteModelList?.length > 0) {
              if (PolSourceSiteModelList[0]?.PolSourceObservationModelList != null && PolSourceSiteModelList[0]?.PolSourceObservationModelList.length > 0) {
                let polSourceObservationModel: PolSourceObservationModel = PolSourceSiteModelList[0]?.PolSourceObservationModelList[0];
                if (polSourceObservationModel.PolSourceObservationIssueList != null && polSourceObservationModel.PolSourceObservationIssueList.length > 0) {
                  let PolSourceObservationIssue: PolSourceObservationIssue = polSourceObservationModel.PolSourceObservationIssueList[0];

                  if (PolSourceObservationIssue.ObservationInfo.includes(',91003')) {
                    strokeColor = '#ff0000';
                    fillColor = '#ff0000';
                  }
                  if (PolSourceObservationIssue.ObservationInfo.includes(',91002')) {
                    strokeColor = '#ffcc00';
                    fillColor = '#ffcc00';
                  }
                  if (PolSourceObservationIssue.ObservationInfo.includes(',91001')) {
                    strokeColor = '#00ff00';
                    fillColor = '#00ff00';
                  }
                }
              }

              path = this.appStateService.MapMarkerPathCharacters[label.text?.length];
            }
          }

          if (tvItemModel.TVItem.TVType == TVTypeEnum.Infrastructure) {
            strokeColor = '#ffffff';
            fillColor = '#ffffff';


            switch (mapInfoModel.MapInfo.TVType) {
              case TVTypeEnum.WasteWaterTreatmentPlant:
                {
                  strokeColor = '#ff0000';
                  fillColor = '#ff0000';
                }
                break;
              case TVTypeEnum.LiftStation:
                {
                  strokeColor = '#880000';
                  fillColor = '#880000';
                }
                break;
              case TVTypeEnum.LineOverflow:
                {
                  strokeColor = '#666600';
                  fillColor = '#666600';
                }
                break;
              case TVTypeEnum.Outfall:
                {
                  strokeColor = '#BB6600';
                  fillColor = '#BB6600';
                }
                break;
              default:
                {
                  strokeColor = '#888800';
                  fillColor = '#888800';
                }
                break;
            }

            path = this.appStateService.MapMarkerPathCharacters[label.text?.length];
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
            map: map,
            draggable: this.appStateService.EditMapVisible,
            zIndex: mapInfoModel.MapInfo.TVType == TVTypeEnum.Outfall ? -mapInfoModel.MapInfo.MapInfoID : mapInfoModel.MapInfo.MapInfoID,
          };

          mark = new google.maps.Marker(options);

          if (this.appStateService.EditMapVisible) {
            google.maps.event.addListener(mark, "mousemove", (evt: google.maps.MouseEvent) => {
              if (!this.appStateService.EditMapChanged) {
                (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (evt.latLng.lat().toString().substring(0, 8) +
                  ' ' + evt.latLng.lng().toString().substring(0, 8));
              }
              else {
                (<HTMLInputElement>document.getElementById("CurrentLatLng")).value = (this.appStateService.MarkerDragStartPos.lat().toFixed(6) +
                  ' ' + this.appStateService.MarkerDragStartPos.lng().toFixed(6));
              }
            });

            google.maps.event.addListener(mark, 'dragstart', () => {
              this.appStateService.MarkerTVItemID = mapInfoModel.MapInfo.TVItemID;
              this.appStateService.MarkerMapInfoID = mapInfoModel.MapInfo.MapInfoID;
              this.appStateService.MarkerDragStartPos = this.GetMapInfoCoord(mapInfoModel);
              this.appStateService.EditMapChanged = true;
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

    for (let i = 0, count = markerList.length; i < count; i++) {
      this.appLoadedService.GoogleMarkerListMVC.push(markerList[i]);
    }

    //this.appLoadedService.GoogleMarkerListMVC = new google.maps.MVCArray<google.maps.Marker>(markerList);
  }

  GetMapInfoCoord(mapInfoModel: MapInfoModel): google.maps.LatLng {
    return new google.maps.LatLng(mapInfoModel.MapInfoPointList[0].Lat, mapInfoModel.MapInfoPointList[0].Lng);
  }
}
