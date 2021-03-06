import { Injectable } from '@angular/core';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { TVItem } from 'src/app/models/generated/db/TVItem.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from '../app/app-loaded.service';
import { JsonDataIsLoadedService } from '../json/json-data-is-loaded.service';

@Injectable({
  providedIn: 'root'
})
export class SubPageService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService, 
    private jsonDataIsLoadedService: JsonDataIsLoadedService) {
  }

  SetSubPage(tvItemModel: TVItemModel) {
    this.appStateService.UserPreference.ShellSubComponent = this.GetSubPage(tvItemModel.TVItem);
  }

  GetSubPage(tvItem: TVItem): ShellSubComponentEnum {
    switch (<TVTypeEnum>tvItem.TVType) {
      case TVTypeEnum.Area:
        {
          this.appStateService.UserPreference.CurrentAreaTVItemID = tvItem.TVItemID;
          if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebArea))
          {
            if (this.appLoadedService.WebArea.TVItemModel.TVItem.TVItemID != tvItem.TVItemID)
            {
              this.appLoadedService.WebArea = <WebArea>{};
            }
          }
          return ShellSubComponentEnum.Area;
        }
      case TVTypeEnum.Country:
        {
          this.appStateService.UserPreference.CurrentCountryTVItemID = tvItem.TVItemID;
          if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebCountry))
          {
            if (this.appLoadedService.WebCountry.TVItemModel.TVItem.TVItemID != tvItem.TVItemID)
            {
              this.appLoadedService.WebCountry = <WebCountry>{};
            }
          }
          return ShellSubComponentEnum.Country;
        }
      case TVTypeEnum.Municipality:
        {
          this.appStateService.UserPreference.CurrentMunicipalityTVItemID = tvItem.TVItemID;
          if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebMunicipality))
          {
            if (this.appLoadedService.WebMunicipality.TVItemModel.TVItem.TVItemID != tvItem.TVItemID)
            {
              this.appLoadedService.WebMunicipality = <WebMunicipality>{};
            }
          }
          return ShellSubComponentEnum.Municipality;
        }
      // case TVTypeEnum.MWQMRun:
      //   {
      //     return ShellSubComponentEnum.MWQMRun;
      //   }
      // case TVTypeEnum.MWQMSite:
      //   {
      //     return ShellSubComponentEnum.MWQMSite;
      //   }
      // case TVTypeEnum.PolSourceSite:
      //   {
      //     return ShellSubComponentEnum.PolSourceSite;
      //   }
      case TVTypeEnum.Province:
        {
          this.appStateService.UserPreference.CurrentProvinceTVItemID = tvItem.TVItemID;
          if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebProvince))
          {
            if (this.appLoadedService.WebProvince.TVItemModel.TVItem.TVItemID != tvItem.TVItemID)
            {
              this.appLoadedService.WebProvince = <WebProvince>{};
            }
          }
          return ShellSubComponentEnum.Province;
        }
      case TVTypeEnum.Root:
        {
          return ShellSubComponentEnum.Root;
        }
      case TVTypeEnum.Sector:
        {
          this.appStateService.UserPreference.CurrentSectorTVItemID = tvItem.TVItemID;
          if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebSector))
          {
            if (this.appLoadedService.WebSector.TVItemModel.TVItem.TVItemID != tvItem.TVItemID)
            {
              this.appLoadedService.WebSector = <WebSector>{};
            }
          }
          return ShellSubComponentEnum.Sector;
        }
      case TVTypeEnum.Subsector:
        {
          this.appStateService.UserPreference.CurrentSubsectorTVItemID = tvItem.TVItemID;
          if (this.jsonDataIsLoadedService.DataIsLoaded(WebTypeEnum.WebSubsector))
          {
            if (this.appLoadedService.WebSubsector.TVItemModel.TVItem.TVItemID != tvItem.TVItemID)
            {
              this.appLoadedService.WebSubsector = <WebSubsector>{};
            }
          }
          return ShellSubComponentEnum.Subsector;
        }
      default:
        {
          return ShellSubComponentEnum.Root;
        }
    }
  }
}
