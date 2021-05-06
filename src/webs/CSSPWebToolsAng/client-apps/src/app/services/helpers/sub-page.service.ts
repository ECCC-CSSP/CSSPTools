import { Injectable } from '@angular/core';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
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
    this.appStateService.ShellSubComponent = this.GetSubPage(tvItemModel.TVItem);
    this.appStateService.CurrentTVItemID = tvItemModel.TVItem.TVItemID;
  }

  GetSubPage(tvItem: TVItem): ShellSubComponentEnum {
    switch (<TVTypeEnum>tvItem.TVType) {
      case TVTypeEnum.Area:
        {
          return ShellSubComponentEnum.Area;
        }
      case TVTypeEnum.Country:
        {
          return ShellSubComponentEnum.Country;
        }
      case TVTypeEnum.Municipality:
        {
          return ShellSubComponentEnum.Municipality;
        }
      case TVTypeEnum.MWQMRun:
        {
          return ShellSubComponentEnum.MWQMRun;
        }
      case TVTypeEnum.MWQMSite:
        {
          return ShellSubComponentEnum.MWQMSite;
        }
      case TVTypeEnum.PolSourceSite:
        {
          return ShellSubComponentEnum.PolSourceSite;
        }
      case TVTypeEnum.Province:
        {
          return ShellSubComponentEnum.Province;
        }
      case TVTypeEnum.Root:
        {
          return ShellSubComponentEnum.Root;
        }
      case TVTypeEnum.Sector:
        {
          return ShellSubComponentEnum.Sector;
        }
      case TVTypeEnum.Subsector:
        {
          return ShellSubComponentEnum.Subsector;
        }
      default:
        {
          return ShellSubComponentEnum.Root;
        }
    }
  }
}
