import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TVTypeEnum, TVTypeEnum_GetIDText } from 'src/app/enums/generated/TVTypeEnum';
import { BreadCrumbModel } from 'src/app/models/BreadCrumb.model';
import { TVItem } from 'src/app/models/generated/TVItem.model';
import { TVItemModel } from 'src/app/models/generated/TVItemModel.model';
import { LanguageEnum } from '../grouping';
import { ShellModel } from './shell.models';

@Injectable({
  providedIn: 'root'
})
export class ShellService {
  shellModel$: BehaviorSubject<ShellModel> = new BehaviorSubject<ShellModel>(<ShellModel>{});
  BreadCrumbModel$: BehaviorSubject<BreadCrumbModel> = new BehaviorSubject<BreadCrumbModel>(<BreadCrumbModel>{});

  constructor() {
    //let url = 'https://localhost:4447/api/';
    let url = 'https://localhost:44346/api/';

    this.UpdateShellModel(<ShellModel>{
      Language: $localize.locale == "fr-CA" ? LanguageEnum.fr : LanguageEnum.en,
      BaseApiUrl: url,
      MapVisible: false
    });
    this.UpdateBreadCrumbModel(<BreadCrumbModel>{ });
  }

  ToggleMap()
  {
    let Visible: boolean = this.shellModel$.getValue().MapVisible;
    this.UpdateShellModel(<ShellModel>{ MapVisible: !Visible });   
  }

  UpdateBreadCrumbModel(breadCrumbModel: BreadCrumbModel) {
    this.BreadCrumbModel$.next(<BreadCrumbModel>{ ...this.BreadCrumbModel$.getValue(), ...breadCrumbModel });
  }

  UpdateShellModel(shellModel: ShellModel) {
    this.shellModel$.next(<ShellModel>{ ...this.shellModel$.getValue(), ...shellModel });
  }

  GetLink(tvItemModel: TVItemModel)
  {
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
