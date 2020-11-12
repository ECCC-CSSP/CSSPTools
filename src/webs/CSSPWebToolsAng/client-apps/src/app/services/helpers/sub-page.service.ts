import { Injectable } from '@angular/core';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItem } from 'src/app/models/generated/db/TVItem.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class SubPageService {

  constructor(private appStateService: AppStateService) {
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
}
