import { Injectable } from '@angular/core';
import { CountrySubComponentEnum } from '../enums/generated/CountrySubComponentEnum';
import { MapInfoDrawTypeEnum } from '../enums/generated/MapInfoDrawTypeEnum';
import { ProvinceSubComponentEnum } from '../enums/generated/ProvinceSubComponentEnum';
import { RootSubComponentEnum } from '../enums/generated/RootSubComponentEnum';
import { ShellSubComponentEnum } from '../enums/generated/ShellSubComponentEnum';
import { TVTypeEnum, TVTypeEnum_GetIDText } from '../enums/generated/TVTypeEnum';
import { AppState } from '../models/AppState.model';
import { SearchResult } from '../models/generated/SearchResult.model';
import { TVItem } from '../models/generated/TVItem.model';
import { TVItemModel } from '../models/generated/TVItemModel.model';
import { WebBase } from '../models/generated/WebBase.model';
import { AppStateService } from './app-state.service';

@Injectable({
  providedIn: 'root'
})
export class AppHelperService {

  constructor(private appStateService: AppStateService) {   
  }

  GetTVType(tvType: TVTypeEnum) {
    return tvType;
  }

  SetSubPage(tvItemModel: TVItemModel) {
    this.appStateService.UpdateAppState(<AppState>{ ShellSubComponent: this.GetSubPage(tvItemModel.TVItem), CurrentTVItemID: tvItemModel.TVItem.TVItemID });
  }

  GetSubPage(tvItem: TVItem): ShellSubComponentEnum {
    switch (<TVTypeEnum>tvItem.TVType) {
      // case TVTypeEnum.Address:
      //   {
      //     return `address`;
      //   }
      case TVTypeEnum.Area:
        {
          return ShellSubComponentEnum.Area;
        }
      // case TVTypeEnum.BoxModel:
      //   {
      //     return `boxmodel`;
      //   }
      // case TVTypeEnum.ClimateSite:
      //   {
      //     return `climatesite`;
      //   }
      // case TVTypeEnum.Contact:
      //   {
      //     return `contact`;
      //   }
      case TVTypeEnum.Country:
        {
          return ShellSubComponentEnum.Country;
        }
      // case TVTypeEnum.Email:
      //   {
      //     return `email`;
      //   }
      // case TVTypeEnum.File:
      //   {
      //     return `file`;
      //   }
      // case TVTypeEnum.HydrometricSite:
      //   {
      //     return `hydrometricsite`;
      //   }
      // case TVTypeEnum.Infrastructure:
      //   {
      //     return `infrastructure`;
      //   }
      // case TVTypeEnum.LabSheetInfo:
      //   {
      //     return `labsheet`;
      //   }
      // case TVTypeEnum.MWQMRun:
      //   {
      //     return `mwqmrun`;
      //   }
      // case TVTypeEnum.MWQMSite:
      //   {
      //     return `mwqmsite`;
      //   }
      // case TVTypeEnum.MikeScenario:
      //   {
      //     return `mikescenario`;
      //   }
      // case TVTypeEnum.MikeSource:
      //   {
      //     return `mikesource`;
      //   }
      // case TVTypeEnum.Municipality:
      //   {
      //     return `municipality`;
      //   }
      // case TVTypeEnum.PolSourceSite:
      //   {
      //     return `polsourcesite`;
      //   }
      case TVTypeEnum.Province:
        {
          return ShellSubComponentEnum.Province;
        }
      case TVTypeEnum.Root:
        {
          return ShellSubComponentEnum.Root;
        }
      // case TVTypeEnum.SamplingPlan:
      //   {
      //     return `samplingplan`;
      //   }
      case TVTypeEnum.Sector:
        {
          return ShellSubComponentEnum.Sector;
        }
      case TVTypeEnum.Subsector:
        {
          return ShellSubComponentEnum.Subsector;
        }
      // case TVTypeEnum.Tel:
      //   {
      //     return `tel`;
      //   }
      // case TVTypeEnum.TideSite:
      //   {
      //     return `tidesite`;
      //   }
      // case TVTypeEnum.VisualPlumesScenario:
      //   {
      //     return `visualplumesscenario`;
      //   }
      default:
        {
          return ShellSubComponentEnum.Root;
        }
    }
  }

  GetTypeText(tvType: number) {
    return TVTypeEnum_GetIDText(tvType, this.appStateService);
  }

  GetTypeIcon(tvType: number) {
    switch (<TVTypeEnum>tvType) {
      case TVTypeEnum.Address:
        {
          return 'add_alert';
        }
      case TVTypeEnum.Area:
        {
          return 'all_out';
        }
      case TVTypeEnum.BoxModel:
        {
          return 'inbox';
        }
      case TVTypeEnum.ClimateSite:
        {
          return 'book';
        }
      case TVTypeEnum.Contact:
        {
          return 'article';
        }
      case TVTypeEnum.Country:
        {
          return 'build';
        }
      case TVTypeEnum.Email:
        {
          return 'email';
        }
      case TVTypeEnum.File:
        {
          return 'attach_file';
        }
      case TVTypeEnum.HydrometricSite:
        {
          return 'soap';
        }
      case TVTypeEnum.Infrastructure:
        {
          return 'opacity';
        }
      case TVTypeEnum.LabSheetInfo:
        {
          return 'label';
        }
      case TVTypeEnum.MWQMRun:
        {
          return 'directions_run';
        }
      case TVTypeEnum.MWQMSite:
        {
          return 'attach_money';
        }
      case TVTypeEnum.MikeScenario:
        {
          return 'agriculture';
        }
      case TVTypeEnum.MikeSource:
        {
          return 'source';
        }
      case TVTypeEnum.Municipality:
        {
          return 'location_city';
        }
      case TVTypeEnum.PolSourceSite:
        {
          return 'poll';
        }
      case TVTypeEnum.Province:
        {
          return 'public';
        }
      case TVTypeEnum.Root:
        {
          return 'room';
        }
      case TVTypeEnum.SamplingPlan:
        {
          return 'update';
        }
      case TVTypeEnum.Sector:
        {
          return 'security';
        }
      case TVTypeEnum.Subsector:
        {
          return 'directions_subway';
        }
      case TVTypeEnum.Tel:
        {
          return 'settings_cell';
        }
      case TVTypeEnum.TideSite:
        {
          return 'tour';
        }
      case TVTypeEnum.VisualPlumesScenario:
        {
          return 'vpn_key';
        }
      default:
        {
          return 'home';
        }
    }
  }

  GetCount(tvItemModel: TVItemModel, tvType?: TVTypeEnum): number {
    let count = 0;
    if (tvType == null) {
      tvItemModel.TVItemStatList.filter((c) => { count += c.ChildCount });
    }
    else {
      var tvItemStat = tvItemModel.TVItemStatList.filter((c) => { return c.TVType == tvType });
      if (tvItemStat.length > 0) {
        count = tvItemStat[0].ChildCount;
      }
    }

    return count;
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

    this.appStateService.UpdateAppState(<AppState>{ markerList: markers });
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

    this.appStateService.UpdateAppState(<AppState>{ polygonList: polygons });
  }


}
