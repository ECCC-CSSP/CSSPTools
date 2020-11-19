import { Injectable } from '@angular/core';
import { ClassificationTypeEnum } from 'src/app/enums/generated/ClassificationTypeEnum';
import { MapInfoDrawTypeEnum } from 'src/app/enums/generated/MapInfoDrawTypeEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/web/WebBase.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class MapHelperService {
  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService) {
  }

  FitBounds() {
    let bounds = new google.maps.LatLngBounds();
    let googleMarkerMVCArray: google.maps.MVCArray<google.maps.Marker> = this.appLoadedService.AppLoaded$.getValue().GoogleMarkerListMVC;
    let length: number = googleMarkerMVCArray.getLength();
    for (let i = 0; i < length; i++) {
      let marker: google.maps.Marker = googleMarkerMVCArray.getAt(i);

      bounds.extend(marker.getPosition());
    }

    let googlePolygonMVCArray: google.maps.MVCArray<google.maps.Polygon> = this.appLoadedService.AppLoaded$.getValue().GooglePolygonListMVC;
    length = googlePolygonMVCArray.getLength();
    for (let i = 0; i < length; i++) {

      googlePolygonMVCArray.getAt(i).getPath().forEach((path) => {
        bounds.extend(path);
      });
    }

    let googlePolylineMVCArray: google.maps.MVCArray<google.maps.Polyline> = this.appLoadedService.AppLoaded$.getValue().GooglePolylineListMVC;
    length = googlePolylineMVCArray.getLength();
    for (let i = 0; i < length; i++) {

      googlePolylineMVCArray.getAt(i).getPath().forEach((path) => {
        bounds.extend(path);
      });
    }

    this.appLoadedService.AppLoaded$.getValue().Map.fitBounds(bounds);
  }

  GetConditionColor(classification: ClassificationTypeEnum): string {

    switch (classification) {
      case ClassificationTypeEnum.Approved: return this.appStateService.AppState$.getValue().ClassificationColorApproved;
      case ClassificationTypeEnum.ConditionallyApproved: return this.appStateService.AppState$.getValue().ClassificationColorConditionallyApproved;
      case ClassificationTypeEnum.ConditionallyRestricted: return this.appStateService.AppState$.getValue().ClassificationColorConditionallyRestricted;
      case ClassificationTypeEnum.Prohibited: return this.appStateService.AppState$.getValue().ClassificationColorProhibited;
      case ClassificationTypeEnum.Restricted: return this.appStateService.AppState$.getValue().ClassificationColorRestricted;
    }
  }

  GetMapMarkerColor(TVType: TVTypeEnum): string {

    switch (TVType) {
      case TVTypeEnum.Area: return this.appStateService.AppState$.getValue().MapMarkerColorArea;
      case TVTypeEnum.ClimateSite: return this.appStateService.AppState$.getValue().MapMarkerColorClimateSite;
      case TVTypeEnum.Country: return this.appStateService.AppState$.getValue().MapMarkerColorCountry;
      case TVTypeEnum.Failed: return this.appStateService.AppState$.getValue().MapMarkerColorFailed;
      case TVTypeEnum.HydrometricSite: return this.appStateService.AppState$.getValue().MapMarkerColorHydrometricSite;
      case TVTypeEnum.Infrastructure: return this.appStateService.AppState$.getValue().MapMarkerColorInfrastructure;
      case TVTypeEnum.LessThan10: return this.appStateService.AppState$.getValue().MapMarkerColorLessThan10;
      case TVTypeEnum.LiftStation: return this.appStateService.AppState$.getValue().MapMarkerColorLiftStation;
      case TVTypeEnum.LineOverflow: return this.appStateService.AppState$.getValue().MapMarkerColorLineOverflow;
      case TVTypeEnum.MeshNode: return this.appStateService.AppState$.getValue().MapMarkerColorMeshNode;
      case TVTypeEnum.MikeBoundaryConditionMesh: return this.appStateService.AppState$.getValue().MapMarkerColorMikeBoundaryConditionMesh;
      case TVTypeEnum.MikeBoundaryConditionWebTide: return this.appStateService.AppState$.getValue().MapMarkerColorMikeBoundaryConditionWebTide;
      case TVTypeEnum.MikeScenario: return this.appStateService.AppState$.getValue().MapMarkerColorMikeScenario;
      case TVTypeEnum.MikeSource: return this.appStateService.AppState$.getValue().MapMarkerColorMikeSource;
      case TVTypeEnum.MikeSourceIncluded: return this.appStateService.AppState$.getValue().MapMarkerColorMikeSourceIncluded;
      case TVTypeEnum.MikeSourceIsRiver: return this.appStateService.AppState$.getValue().MapMarkerColorMikeSourceIsRiver;
      case TVTypeEnum.MikeSourceNotIncluded: return this.appStateService.AppState$.getValue().MapMarkerColorMikeSourceNotIncluded;
      case TVTypeEnum.Municipality: return this.appStateService.AppState$.getValue().MapMarkerColorMunicipality;
      case TVTypeEnum.MWQMRun: return this.appStateService.AppState$.getValue().MapMarkerColorMWQMRun;
      case TVTypeEnum.MWQMSite: return this.appStateService.AppState$.getValue().MapMarkerColorMWQMSite;
      case TVTypeEnum.NoData: return this.appStateService.AppState$.getValue().MapMarkerColorNoData;
      case TVTypeEnum.NoDepuration: return this.appStateService.AppState$.getValue().MapMarkerColorNoDepuration;
      case TVTypeEnum.OtherInfrastructure: return this.appStateService.AppState$.getValue().MapMarkerColorOtherInfrastructure;
      case TVTypeEnum.Outfall: return this.appStateService.AppState$.getValue().MapMarkerColorOutfall;
      case TVTypeEnum.Passed: return this.appStateService.AppState$.getValue().MapMarkerColorPassed;
      case TVTypeEnum.PolSourceSite: return this.appStateService.AppState$.getValue().MapMarkerColorPolSourceSite;
      case TVTypeEnum.Province: return this.appStateService.AppState$.getValue().MapMarkerColorProvince;
      case TVTypeEnum.Sector: return this.appStateService.AppState$.getValue().MapMarkerColorSector;
      case TVTypeEnum.SeeOtherMunicipality: return this.appStateService.AppState$.getValue().MapMarkerColorSeeOtherMunicipality;
      case TVTypeEnum.Subsector: return this.appStateService.AppState$.getValue().MapMarkerColorSubsector;
      case TVTypeEnum.TideSite: return this.appStateService.AppState$.getValue().MapMarkerColorTideSite;
      case TVTypeEnum.WasteWaterTreatmentPlant: return this.appStateService.AppState$.getValue().MapMarkerColorWasteWaterTreatmentPlant;
      case TVTypeEnum.WebTideNode: return this.appStateService.AppState$.getValue().MapMarkerColorWebTideNode;
    }
  }

  GetMapPolylineColor(FromTVType: TVTypeEnum, ToTVType: TVTypeEnum): string {

    if (FromTVType == TVTypeEnum.LineOverflow && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.AppState$.getValue().MapPolylineColorInfrastructureLineOverflowToOutfall;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.LiftStation) {
      return this.appStateService.AppState$.getValue().MapPolylineColorInfrastructureLiftStationToLiftStation;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.AppState$.getValue().MapPolylineColorInfrastructureLiftStationToOutfall;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.WasteWaterTreatmentPlant) {
      return this.appStateService.AppState$.getValue().MapPolylineColorInfrastructureLiftStationToWWTP;
    }
    else if (FromTVType == TVTypeEnum.WasteWaterTreatmentPlant && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.AppState$.getValue().MapPolylineColorInfrastructureWWTPToOutfall;
    }
    else {
      return this.appStateService.AppState$.getValue().MapColorNotFound;
    }
  }

  GetMapPolygonColor(TVType: TVTypeEnum): string {
    switch (TVType) {
      case TVTypeEnum.Area: return this.appStateService.AppState$.getValue().MapPolygonColorArea;
      case TVTypeEnum.Country: return this.appStateService.AppState$.getValue().MapPolygonColorCountry;
      case TVTypeEnum.Province: return this.appStateService.AppState$.getValue().MapPolygonColorProvince;
      case TVTypeEnum.Sector: return this.appStateService.AppState$.getValue().MapPolygonColorSector;
      case TVTypeEnum.Subsector: return this.appStateService.AppState$.getValue().MapPolygonColorSubsector;
    }
  }
}
