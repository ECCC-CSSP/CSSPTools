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
      case ClassificationTypeEnum.Approved: return this.appStateService.UserPreference.ClassificationColorApproved;
      case ClassificationTypeEnum.ConditionallyApproved: return this.appStateService.UserPreference.ClassificationColorConditionallyApproved;
      case ClassificationTypeEnum.ConditionallyRestricted: return this.appStateService.UserPreference.ClassificationColorConditionallyRestricted;
      case ClassificationTypeEnum.Prohibited: return this.appStateService.UserPreference.ClassificationColorProhibited;
      case ClassificationTypeEnum.Restricted: return this.appStateService.UserPreference.ClassificationColorRestricted;
    }
  }

  GetMapMarkerColor(TVType: TVTypeEnum): string {

    switch (TVType) {
      case TVTypeEnum.Area: return this.appStateService.UserPreference.MapMarkerColorArea;
      case TVTypeEnum.ClimateSite: return this.appStateService.UserPreference.MapMarkerColorClimateSite;
      case TVTypeEnum.Country: return this.appStateService.UserPreference.MapMarkerColorCountry;
      case TVTypeEnum.Failed: return this.appStateService.UserPreference.MapMarkerColorFailed;
      case TVTypeEnum.HydrometricSite: return this.appStateService.UserPreference.MapMarkerColorHydrometricSite;
      case TVTypeEnum.Infrastructure: return this.appStateService.UserPreference.MapMarkerColorInfrastructure;
      case TVTypeEnum.LessThan10: return this.appStateService.UserPreference.MapMarkerColorLessThan10;
      case TVTypeEnum.LiftStation: return this.appStateService.UserPreference.MapMarkerColorLiftStation;
      case TVTypeEnum.LineOverflow: return this.appStateService.UserPreference.MapMarkerColorLineOverflow;
      case TVTypeEnum.MeshNode: return this.appStateService.UserPreference.MapMarkerColorMeshNode;
      case TVTypeEnum.MikeBoundaryConditionMesh: return this.appStateService.UserPreference.MapMarkerColorMikeBoundaryConditionMesh;
      case TVTypeEnum.MikeBoundaryConditionWebTide: return this.appStateService.UserPreference.MapMarkerColorMikeBoundaryConditionWebTide;
      case TVTypeEnum.MikeScenario: return this.appStateService.UserPreference.MapMarkerColorMikeScenario;
      case TVTypeEnum.MikeSource: return this.appStateService.UserPreference.MapMarkerColorMikeSource;
      case TVTypeEnum.MikeSourceIncluded: return this.appStateService.UserPreference.MapMarkerColorMikeSourceIncluded;
      case TVTypeEnum.MikeSourceIsRiver: return this.appStateService.UserPreference.MapMarkerColorMikeSourceIsRiver;
      case TVTypeEnum.MikeSourceNotIncluded: return this.appStateService.UserPreference.MapMarkerColorMikeSourceNotIncluded;
      case TVTypeEnum.Municipality: return this.appStateService.UserPreference.MapMarkerColorMunicipality;
      case TVTypeEnum.MWQMRun: return this.appStateService.UserPreference.MapMarkerColorMWQMRun;
      case TVTypeEnum.MWQMSite: return this.appStateService.UserPreference.MapMarkerColorMWQMSite;
      case TVTypeEnum.NoData: return this.appStateService.UserPreference.MapMarkerColorNoData;
      case TVTypeEnum.NoDepuration: return this.appStateService.UserPreference.MapMarkerColorNoDepuration;
      case TVTypeEnum.OtherInfrastructure: return this.appStateService.UserPreference.MapMarkerColorOtherInfrastructure;
      case TVTypeEnum.Outfall: return this.appStateService.UserPreference.MapMarkerColorOutfall;
      case TVTypeEnum.Passed: return this.appStateService.UserPreference.MapMarkerColorPassed;
      case TVTypeEnum.PolSourceSite: return this.appStateService.UserPreference.MapMarkerColorPolSourceSite;
      case TVTypeEnum.Province: return this.appStateService.UserPreference.MapMarkerColorProvince;
      case TVTypeEnum.Sector: return this.appStateService.UserPreference.MapMarkerColorSector;
      case TVTypeEnum.SeeOtherMunicipality: return this.appStateService.UserPreference.MapMarkerColorSeeOtherMunicipality;
      case TVTypeEnum.Subsector: return this.appStateService.UserPreference.MapMarkerColorSubsector;
      case TVTypeEnum.TideSite: return this.appStateService.UserPreference.MapMarkerColorTideSite;
      case TVTypeEnum.WasteWaterTreatmentPlant: return this.appStateService.UserPreference.MapMarkerColorWasteWaterTreatmentPlant;
      case TVTypeEnum.WebTideNode: return this.appStateService.UserPreference.MapMarkerColorWebTideNode;
    }
  }

  GetMapPolylineColor(FromTVType: TVTypeEnum, ToTVType: TVTypeEnum): string {

    if (FromTVType == TVTypeEnum.LineOverflow && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.UserPreference.MapPolylineColorInfrastructureLineOverflowToOutfall;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.LiftStation) {
      return this.appStateService.UserPreference.MapPolylineColorInfrastructureLiftStationToLiftStation;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.UserPreference.MapPolylineColorInfrastructureLiftStationToOutfall;
    }
    else if (FromTVType == TVTypeEnum.LiftStation && ToTVType == TVTypeEnum.WasteWaterTreatmentPlant) {
      return this.appStateService.UserPreference.MapPolylineColorInfrastructureLiftStationToWWTP;
    }
    else if (FromTVType == TVTypeEnum.WasteWaterTreatmentPlant && ToTVType == TVTypeEnum.Outfall) {
      return this.appStateService.UserPreference.MapPolylineColorInfrastructureWWTPToOutfall;
    }
    else {
      return this.appStateService.UserPreference.MapColorNotFound;
    }
  }

  GetMapPolygonColor(TVType: TVTypeEnum): string {
    switch (TVType) {
      case TVTypeEnum.Area: return this.appStateService.UserPreference.MapPolygonColorArea;
      case TVTypeEnum.Country: return this.appStateService.UserPreference.MapPolygonColorCountry;
      case TVTypeEnum.Province: return this.appStateService.UserPreference.MapPolygonColorProvince;
      case TVTypeEnum.Sector: return this.appStateService.UserPreference.MapPolygonColorSector;
      case TVTypeEnum.Subsector: return this.appStateService.UserPreference.MapPolygonColorSubsector;
    }
  }
}
