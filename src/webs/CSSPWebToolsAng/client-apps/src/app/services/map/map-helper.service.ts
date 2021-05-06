import { Injectable } from '@angular/core';
import { ClassificationTypeEnum } from 'src/app/enums/generated/ClassificationTypeEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
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
    let googleMarkerMVCArray: google.maps.MVCArray<google.maps.Marker> = this.appLoadedService.GoogleMarkerListMVC;
    let length: number = googleMarkerMVCArray.getLength();
    for (let i = 0; i < length; i++) {
      let marker: google.maps.Marker = googleMarkerMVCArray.getAt(i);

      bounds.extend(marker.getPosition());
    }

    let googlePolygonMVCArray: google.maps.MVCArray<google.maps.Polygon> = this.appLoadedService.GooglePolygonListMVC;
    length = googlePolygonMVCArray.getLength();
    for (let i = 0; i < length; i++) {

      googlePolygonMVCArray.getAt(i).getPath().forEach((path) => {
        bounds.extend(path);
      });
    }

    let googlePolylineMVCArray: google.maps.MVCArray<google.maps.Polyline> = this.appLoadedService.GooglePolylineListMVC;
    length = googlePolylineMVCArray.getLength();
    for (let i = 0; i < length; i++) {

      googlePolylineMVCArray.getAt(i).getPath().forEach((path) => {
        bounds.extend(path);
      });
    }

    this.appLoadedService.Map.fitBounds(bounds);
  }

  GetConditionColor(classification: ClassificationTypeEnum): string {

    switch (classification) {
      case ClassificationTypeEnum.Approved: return this.appStateService.ClassificationColorApproved;
      case ClassificationTypeEnum.ConditionallyApproved: return this.appStateService.ClassificationColorConditionallyApproved;
      case ClassificationTypeEnum.ConditionallyRestricted: return this.appStateService.ClassificationColorConditionallyRestricted;
      case ClassificationTypeEnum.Prohibited: return this.appStateService.ClassificationColorProhibited;
      case ClassificationTypeEnum.Restricted: return this.appStateService.ClassificationColorRestricted;
    }
  }

  GetMapMarkerColor(TVType: TVTypeEnum): string {

    switch (TVType) {
      case TVTypeEnum.Area: return this.appStateService.MapMarkerColorArea;
      case TVTypeEnum.ClimateSite: return this.appStateService.MapMarkerColorClimateSite;
      case TVTypeEnum.Country: return this.appStateService.MapMarkerColorCountry;
      case TVTypeEnum.Failed: return this.appStateService.MapMarkerColorFailed;
      case TVTypeEnum.HydrometricSite: return this.appStateService.MapMarkerColorHydrometricSite;
      case TVTypeEnum.Infrastructure: return this.appStateService.MapMarkerColorInfrastructure;
      case TVTypeEnum.LessThan10: return this.appStateService.MapMarkerColorLessThan10;
      case TVTypeEnum.LiftStation: return this.appStateService.MapMarkerColorLiftStation;
      case TVTypeEnum.LineOverflow: return this.appStateService.MapMarkerColorLineOverflow;
      case TVTypeEnum.MeshNode: return this.appStateService.MapMarkerColorMeshNode;
      case TVTypeEnum.MikeBoundaryConditionMesh: return this.appStateService.MapMarkerColorMikeBoundaryConditionMesh;
      case TVTypeEnum.MikeBoundaryConditionWebTide: return this.appStateService.MapMarkerColorMikeBoundaryConditionWebTide;
      case TVTypeEnum.MikeScenario: return this.appStateService.MapMarkerColorMikeScenario;
      case TVTypeEnum.MikeSource: return this.appStateService.MapMarkerColorMikeSource;
      case TVTypeEnum.MikeSourceIncluded: return this.appStateService.MapMarkerColorMikeSourceIncluded;
      case TVTypeEnum.MikeSourceIsRiver: return this.appStateService.MapMarkerColorMikeSourceIsRiver;
      case TVTypeEnum.MikeSourceNotIncluded: return this.appStateService.MapMarkerColorMikeSourceNotIncluded;
      case TVTypeEnum.Municipality: return this.appStateService.MapMarkerColorMunicipality;
      case TVTypeEnum.MWQMRun: return this.appStateService.MapMarkerColorMWQMRun;
      case TVTypeEnum.MWQMSite: return this.appStateService.MapMarkerColorMWQMSite;
      case TVTypeEnum.NoData: return this.appStateService.MapMarkerColorNoData;
      case TVTypeEnum.NoDepuration: return this.appStateService.MapMarkerColorNoDepuration;
      case TVTypeEnum.OtherInfrastructure: return this.appStateService.MapMarkerColorOtherInfrastructure;
      case TVTypeEnum.Outfall: return this.appStateService.MapMarkerColorOutfall;
      case TVTypeEnum.Passed: return this.appStateService.MapMarkerColorPassed;
      case TVTypeEnum.PolSourceSite: return this.appStateService.MapMarkerColorPolSourceSite;
      case TVTypeEnum.Province: return this.appStateService.MapMarkerColorProvince;
      case TVTypeEnum.Sector: return this.appStateService.MapMarkerColorSector;
      case TVTypeEnum.SeeOtherMunicipality: return this.appStateService.MapMarkerColorSeeOtherMunicipality;
      case TVTypeEnum.Subsector: return this.appStateService.MapMarkerColorSubsector;
      case TVTypeEnum.TideSite: return this.appStateService.MapMarkerColorTideSite;
      case TVTypeEnum.WasteWaterTreatmentPlant: return this.appStateService.MapMarkerColorWasteWaterTreatmentPlant;
      case TVTypeEnum.WebTideNode: return this.appStateService.MapMarkerColorWebTideNode;
    }
  }

  GetMapPolylineColor(FromTVType: TVTypeEnum, ToTVType: TVTypeEnum): string {

    if (FromTVType == TVTypeEnum.LineOverflow && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.MapPolylineColorInfrastructureLineOverflowToOutfall;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.LiftStation) {
      return this.appStateService.MapPolylineColorInfrastructureLiftStationToLiftStation;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.MapPolylineColorInfrastructureLiftStationToOutfall;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.WasteWaterTreatmentPlant) {
      return this.appStateService.MapPolylineColorInfrastructureLiftStationToWWTP;
    }
    else if (FromTVType == TVTypeEnum.WasteWaterTreatmentPlant && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.MapPolylineColorInfrastructureWWTPToOutfall;
    }
    else {
      return this.appStateService.MapColorNotFound;
    }
  }

  GetMapPolygonColor(TVType: TVTypeEnum): string {
    switch (TVType) {
      case TVTypeEnum.Area: return this.appStateService.MapPolygonColorArea;
      case TVTypeEnum.Country: return this.appStateService.MapPolygonColorCountry;
      case TVTypeEnum.Province: return this.appStateService.MapPolygonColorProvince;
      case TVTypeEnum.Sector: return this.appStateService.MapPolygonColorSector;
      case TVTypeEnum.Subsector: return this.appStateService.MapPolygonColorSubsector;
    }
  }
}
