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
    this.UpdateShellModel(<ShellModel> { ActiveVisible: true, MapVisible: true, HybridVisible: true, MapSizeClass: "mapSize50", Size50: true });
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

  SetProperties(property: string) {
    property == 'active' ? this.UpdateShellModel(<ShellModel>{ ActiveVisible: !this.ShellModel$.getValue().ActiveVisible }) : null;
    property == 'detail' ? this.UpdateShellModel(<ShellModel>{ DetailVisible: !this.ShellModel$.getValue().DetailVisible }) : null;
    property == 'edit' ? this.UpdateShellModel(<ShellModel>{ EditVisible: !this.ShellModel$.getValue().EditVisible }) : null;
    property == 'file' ? this.UpdateShellModel(<ShellModel>{ FileVisible: !this.ShellModel$.getValue().FileVisible }) : null;
    property == 'inact' ? this.UpdateShellModel(<ShellModel>{ InactVisible: !this.ShellModel$.getValue().InactVisible }) : null;
    property == 'map' ? this.UpdateShellModel(<ShellModel>{ MapVisible: !this.ShellModel$.getValue().MapVisible }) : null;
    property == 'menu' ? this.UpdateShellModel(<ShellModel>{ MenuVisible: !this.ShellModel$.getValue().MenuVisible }) : null;
    property == 'size30' ? this.UpdateShellModel(<ShellModel>{ Size30: true, Size40: false, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize30' }) : null;
    property == 'size40' ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: true, Size50: false, Size60: false, Size70: false, MapSizeClass: 'mapSize40' }) : null;
    property == 'size60' ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: false, Size60: true, Size70: false, MapSizeClass: 'mapSize60' }) : null;
    property == 'size70' ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: false, Size60: false, Size70: true, MapSizeClass: 'mapSize70' }) : null;
    property == 'size50' ? this.UpdateShellModel(<ShellModel>{ Size30: false, Size40: false, Size50: true, Size60: false, Size70: false, MapSizeClass: 'mapSize50' }) : null;
    property == 'satellite' ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: true, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.SATELLITE }) : null;
    property == 'terrain' ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: true, mapTypeId: google.maps.MapTypeId.TERRAIN }) : null;
    property == 'roadmap' ? this.UpdateShellModel(<ShellModel>{ HybridVisible: false, SatelliteVisible: false, RoadmapVisible: true, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.ROADMAP }) : null;
    property == 'hybrid' ? this.UpdateShellModel(<ShellModel>{ HybridVisible: true, SatelliteVisible: false, RoadmapVisible: false, TerrainVisible: false, mapTypeId: google.maps.MapTypeId.HYBRID }) : null;
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
    return $localize.locale + '/' + this.GetUrl(tvItemModel.TVItem);
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
