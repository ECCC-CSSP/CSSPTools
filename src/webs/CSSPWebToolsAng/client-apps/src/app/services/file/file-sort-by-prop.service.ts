import { Injectable } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppStateService } from '../app/app-state.service';
import { FilesSortPropEnum } from 'src/app/enums/generated/FilesSortPropEnum';

@Injectable({
  providedIn: 'root'
})
export class FileSortByPropService {
  constructor(private appStateService: AppStateService) {
  }

  SetFileSortByProp(TVType: TVTypeEnum, filesSortPropEnum: FilesSortPropEnum): void {
    switch (TVType) {
      case TVTypeEnum.Area:
        {
          this.appStateService.UserPreference.AreaFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.Country:
        {
          this.appStateService.UserPreference.CountryFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.Infrastructure:
        {
          this.appStateService.UserPreference.InfrastructureFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.Municipality:
        {
          this.appStateService.UserPreference.MunicipalityFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.MWQMSite:
        {
          this.appStateService.UserPreference.MWQMSiteFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.PolSourceSite:
        {
          this.appStateService.UserPreference.PolSourceSiteFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.Province:
        {
          this.appStateService.UserPreference.ProvinceFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.Root:
        {
          this.appStateService.UserPreference.RootFilesSortByProp = filesSortPropEnum;
        }
        break;
      case TVTypeEnum.Sector:
        {
          this.appStateService.UserPreference.SectorFilesSortByProp = filesSortPropEnum;
        }
      case TVTypeEnum.Subsector:
        {
          this.appStateService.UserPreference.SubsectorFilesSortByProp = filesSortPropEnum;
        }
      default:
        break;
    }
  }

  GetFileSortByProp(TVType: TVTypeEnum): FilesSortPropEnum {
    switch (TVType) {
      case TVTypeEnum.Area:
        {
          return this.appStateService.UserPreference.AreaFilesSortByProp;
        }
      case TVTypeEnum.Country:
        {
          return this.appStateService.UserPreference.CountryFilesSortByProp;
        }
      case TVTypeEnum.Infrastructure:
        {
          return this.appStateService.UserPreference.InfrastructureFilesSortByProp;
        }
      case TVTypeEnum.Municipality:
        {
          return this.appStateService.UserPreference.MunicipalityFilesSortByProp;
        }
      case TVTypeEnum.MWQMSite:
        {
          return this.appStateService.UserPreference.MWQMSiteFilesSortByProp;
        }
      case TVTypeEnum.PolSourceSite:
        {
          return this.appStateService.UserPreference.PolSourceSiteFilesSortByProp;
        }
      case TVTypeEnum.Province:
        {
          return this.appStateService.UserPreference.ProvinceFilesSortByProp;
        }
      case TVTypeEnum.Root:
        {
          return this.appStateService.UserPreference.RootFilesSortByProp;
        }
      case TVTypeEnum.Sector:
        {
          return this.appStateService.UserPreference.SectorFilesSortByProp;
        }
      case TVTypeEnum.Subsector:
        {
          return this.appStateService.UserPreference.SubsectorFilesSortByProp;
        }
      default:
        {
          return null;
        }
    }

  }

}