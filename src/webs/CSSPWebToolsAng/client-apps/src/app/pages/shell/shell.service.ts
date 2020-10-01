import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { TVTypeEnum, TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';
import { BreadCrumbModel } from 'src/app/models/BreadCrumb.model';
import { TVItem } from 'src/app/models/generated/TVItem.model';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { WebBase } from 'src/app/models/generated/WebBase.model';
import { LanguageEnum } from '../grouping';
import { ShellModel } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  ShellModel$: BehaviorSubject<ShellModel> = new BehaviorSubject<ShellModel>(<ShellModel>{});
  BreadCrumbModel$: BehaviorSubject<BreadCrumbModel> = new BehaviorSubject<BreadCrumbModel>(<BreadCrumbModel>{});

  constructor() {
    //let url = 'https://localhost:4447/api/';
    let url = 'https://localhost:44346/api/';

    this.UpdateShellModel(<ShellModel>{
      Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en,
      BaseApiUrl: url
    });
    this.UpdateBreadCrumbModel(<BreadCrumbModel>{});
    this.SetTVTypeEnum();
  }

  SetTVTypeEnum() {
    this.UpdateShellModel(<ShellModel>{
      TVTypeRoot: TVTypeEnum.Root,
      TVTypeCountry: TVTypeEnum.Country,
      TVTypeProvince: TVTypeEnum.Province,
      TVTypeArea: TVTypeEnum.Area,
      TVTypeSector: TVTypeEnum.Sector,
      TVTypeSubsector: TVTypeEnum.Subsector,
      TVTypeMWQMSite: TVTypeEnum.MWQMSite,
      TVTypeMWQMRun: TVTypeEnum.MWQMRun,
      TVTypePolSourcSite: TVTypeEnum.PolSourceSite,
      TVTypeMikeScenario: TVTypeEnum.MikeScenario,
      TVTypeMunicipality: TVTypeEnum.Municipality,
      TVTypeMWQMSiteSample: TVTypeEnum.MWQMSiteSample,
    });
  }
  SetProperties(properties: string) {
    properties.indexOf("active") > -1 ? this.UpdateShellModel(<ShellModel>{ ActiveVisible: true }) : this.UpdateShellModel(<ShellModel>{ ActiveVisible: false });
    properties.indexOf("detail") > -1 ? this.UpdateShellModel(<ShellModel>{ DetailVisible: true }) : this.UpdateShellModel(<ShellModel>{ DetailVisible: false });
    properties.indexOf("edit") > -1 ? this.UpdateShellModel(<ShellModel>{ EditVisible: true }) : this.UpdateShellModel(<ShellModel>{ EditVisible: false });
    properties.indexOf("file") > -1 ? this.UpdateShellModel(<ShellModel>{ FileVisible: true }) : this.UpdateShellModel(<ShellModel>{ FileVisible: false });
    properties.indexOf("inact") > -1 ? this.UpdateShellModel(<ShellModel>{ InactVisible: true }) : this.UpdateShellModel(<ShellModel>{ InactVisible: false });
    properties.indexOf("map") > -1 ? this.UpdateShellModel(<ShellModel>{ MapVisible: true }) : this.UpdateShellModel(<ShellModel>{ MapVisible: false });
    properties.indexOf("menu") > -1 ? this.UpdateShellModel(<ShellModel>{ MenuVisible: true }) : this.UpdateShellModel(<ShellModel>{ MenuVisible: false });
    properties.indexOf("satellite") > -1 ? this.UpdateShellModel(<ShellModel>{ SatelliteVisible: true }) : this.UpdateShellModel(<ShellModel>{ SatelliteVisible: false });
    properties.indexOf("size30") > -1 ? this.UpdateShellModel(<ShellModel>{ Size30: true, Size40: false, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize30' }) : this.UpdateShellModel(<ShellModel>{ Size30: false });
    properties.indexOf("size40") > -1 ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: true, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize40' }) : this.UpdateShellModel(<ShellModel>{ Size40: false });
    properties.indexOf("size60") > -1 ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: false, Size60: true, Size70: false, MapSizeClass: 'mapSize60' }) : this.UpdateShellModel(<ShellModel>{ Size60: false });
    properties.indexOf("size70") > -1 ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: false, Size60: false, Size70: true, MapSizeClass: 'mapSize70' }) : this.UpdateShellModel(<ShellModel>{ Size70: false });
    properties.indexOf("size50") > -1 ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: true, Size60: false, Size70: false, MapSizeClass: 'mapSize50' }) : this.UpdateShellModel(<ShellModel>{ Size50: false });
    properties.indexOf("satellite") > -1 ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: true, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.SATELLITE }) : this.UpdateShellModel(<ShellModel>{ SatelliteVisible: false });
    properties.indexOf("terrain") > -1 ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: true, mapTypeId: google.maps.MapTypeId.TERRAIN }) : this.UpdateShellModel(<ShellModel>{ TerrainVisible: false });
    properties.indexOf("roadmap") > -1 ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: true, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.ROADMAP }) : this.UpdateShellModel(<ShellModel>{ RoadmapVisible: false });
    properties.indexOf("hybrid") > -1 ? this.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID }) : this.UpdateShellModel(<ShellModel>{ HybridVisible: false });
  }

  ChangeUrl(router: Router, property: string): void {
    let urlNew: string = router.url.replace(',,', ',');
    property == 'active' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ ActiveVisible: false }) : this.UpdateShellModel(<ShellModel>{ ActiveVisible: true })) : null
    property == 'detail' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ DetailVisible: false }) : this.UpdateShellModel(<ShellModel>{ DetailVisible: true })) : null
    property == 'edit' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ EditVisible: false }) : this.UpdateShellModel(<ShellModel>{ EditVisible: true })) : null
    property == 'file' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ FileVisible: false }) : this.UpdateShellModel(<ShellModel>{ FileVisible: true })) : null
    property == 'inact' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ InactVisible: false }) : this.UpdateShellModel(<ShellModel>{ InactVisible: true })) : null
    property == 'map' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ MapVisible: false }) : this.UpdateShellModel(<ShellModel>{ MapVisible: true })) : null
    property == 'menu' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ MenuVisible: false }) : this.UpdateShellModel(<ShellModel>{ MenuVisible: true })) : null
    if (property == 'size30' || property == 'size40' || property == 'size50' || property == 'size60' || property == 'size70') {
      urlNew = urlNew.replace('size30', '').replace('size40', '').replace('size50', '').replace('size60', '').replace('size70', '');
      urlNew = urlNew + (property == 'size30' ? ',size30' : '');
      urlNew = urlNew + (property == 'size40' ? ',size40' : '');
      urlNew = urlNew + (property == 'size50' ? ',size50' : '');
      urlNew = urlNew + (property == 'size60' ? ',size60' : '');
      urlNew = urlNew + (property == 'size70' ? ',size70' : '');

      property == 'size30' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ Size30: false }) : this.UpdateShellModel(<ShellModel>{ Size30: true, Size40: false, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize30' })) : null
      property == 'size40' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ Size40: false }) : this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: true, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize40' })) : null
      property == 'size60' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ Size60: false }) : this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: false, Size60: true, Size70: false, MapSizeClass: 'mapSize60' })) : null
      property == 'size70' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ Size70: false }) : this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: false, Size60: false, Size70: true, MapSizeClass: 'mapSize70' })) : null
      property == 'size50' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ Size50: false }) : this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: true, Size60: false, Size70: false, MapSizeClass: 'mapSize50' })) : null
    }
    else if (property == 'hybrid' || property == 'satellite' || property == 'roadmap' || property == 'terrain') {
      urlNew = urlNew.replace('hybrid', '').replace('satellite', '').replace('roadmap', '').replace('terrain', '');
      urlNew = urlNew + (property == 'hybrid' ? ',hybrid' : '');
      urlNew = urlNew + (property == 'satellite' ? ',satellite' : '');
      urlNew = urlNew + (property == 'roadmap' ? ',roadmap' : '');
      urlNew = urlNew + (property == 'terrain' ? ',terrain' : '');

      property == 'satellite' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ SatelliteVisible: false }) : this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: true, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.SATELLITE })) : null
      property == 'terrain' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ TerrainVisible: false }) : this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: true, mapTypeId: google.maps.MapTypeId.TERRAIN })) : null
      property == 'roadmap' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ RoadMapVisible: false }) : this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: true, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.ROADMAP })) : null
      property == 'hybrid' ? (urlNew.indexOf(property) > -1 ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false }) : this.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID })) : null
      }
    else {
      urlNew = urlNew.indexOf(property) > -1 ? urlNew.replace(property, '') : urlNew + ',' + property;
    }
    router.routeReuseStrategy.shouldReuseRoute = () => false;
    router.navigateByUrl(urlNew);
  }

  UpdateBreadCrumbModel(breadCrumbModel: BreadCrumbModel) {
    this.BreadCrumbModel$.next(<BreadCrumbModel>{ ...this.BreadCrumbModel$.getValue(), ...breadCrumbModel });
  }

  UpdateShellModel(shellModel: ShellModel) {
    this.ShellModel$.next(<ShellModel>{ ...this.ShellModel$.getValue(), ...shellModel });
  }

  GetTVType(tvType: TVTypeEnum) {
    return tvType;
  }

  GetLink(tvItemModel: TVItemModel) {
    return $localize.locale + '/' + this.GetUrl(tvItemModel.TVItem) + '/' + this.GetProperties();
  }

  GetProperties() {
    let properties: string = 'z';
    this.ShellModel$.getValue().ActiveVisible ? properties = properties + ',active' : null;
    this.ShellModel$.getValue().DetailVisible ? properties = properties + ',detail' : null;
    this.ShellModel$.getValue().EditVisible ? properties = properties + ',edit' : null;
    this.ShellModel$.getValue().FileVisible ? properties = properties + ',file' : null;
    this.ShellModel$.getValue().InactVisible ? properties = properties + ',inact' : null;
    this.ShellModel$.getValue().MapVisible ? properties = properties + ',map' : null;
    this.ShellModel$.getValue().MenuVisible ? properties = properties + ',menu' : null;
    this.ShellModel$.getValue().SatelliteVisible ? properties = properties + ',satellite' : null;
    this.ShellModel$.getValue().Size30 ? properties = properties + ',size30' : null;
    this.ShellModel$.getValue().Size40 ? properties = properties + ',size40' : null;
    this.ShellModel$.getValue().Size50 ? properties = properties + ',size50' : null;
    this.ShellModel$.getValue().Size60 ? properties = properties + ',size60' : null;
    this.ShellModel$.getValue().Size70 ? properties = properties + ',size70' : null;

    return properties;
  }

  GetTypeText(tvType: number) {
    return TVTypeEnum_GetIDText(tvType);
  }

  GetUrl(tvItem: TVItem): string {
    switch (<TVTypeEnum>tvItem.TVType) {
      case TVTypeEnum.Address:
        {
          return `address/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Area:
        {
          return `area/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.BoxModel:
        {
          return `boxmodel/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.ClimateSite:
        {
          return `climatesite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Contact:
        {
          return `contact/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Country:
        {
          return `country/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Email:
        {
          return `email/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.File:
        {
          return `file/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.HydrometricSite:
        {
          return `hydrometricsite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Infrastructure:
        {
          return `infrastructure/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.LabSheetInfo:
        {
          return `labsheet/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MWQMRun:
        {
          return `mwqmrun/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MWQMSite:
        {
          return `mwqmsite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MikeScenario:
        {
          return `mikescenario/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.MikeSource:
        {
          return `mikesource/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Municipality:
        {
          return `municipality/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.PolSourceSite:
        {
          return `polsourcesite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Province:
        {
          return `province/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Root:
        {
          return `root/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.SamplingPlan:
        {
          return `samplingplan/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Sector:
        {
          return `sector/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Subsector:
        {
          return `subsector/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.Tel:
        {
          return `tel/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.TideSite:
        {
          return `tidesite/${tvItem.TVItemID}`;
        }
      case TVTypeEnum.VisualPlumesScenario:
        {
          return `visualplumesscenario/${tvItem.TVItemID}`;
        }
      default:
        {
          return ``;
        }
    }
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

}
