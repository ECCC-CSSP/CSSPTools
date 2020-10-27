import { Injectable } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class TypeIconService {

  constructor(private appStateService: AppStateService) {
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
