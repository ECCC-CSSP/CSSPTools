import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { LoadModel } from 'src/app/models/generated/web/LoadModel.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppStateService } from '../app-state.service';

@Injectable({
  providedIn: 'root'
})
export class LoadListService {

  ToLoadList: LoadModel[] = [];

  constructor(private appStateService: AppStateService) {
  }

  SetToLoadList(TVType: TVTypeEnum, TVItemID: number, ForceReload: boolean) {
    switch (TVType) {
      case TVTypeEnum.Root: this.FillRoot(TVItemID, ForceReload); break;
      case TVTypeEnum.Country: this.FillCountry(TVItemID, ForceReload); break;
      case TVTypeEnum.Province: this.FillProvince(TVItemID, ForceReload); break;
      case TVTypeEnum.Municipality: this.FillMunicipality(TVItemID, ForceReload); break;
      case TVTypeEnum.Area: this.FillArea(TVItemID, ForceReload); break;
      case TVTypeEnum.Sector: this.FillSector(TVItemID, ForceReload); break;
      case TVTypeEnum.Subsector: this.FillSubsector(TVItemID, ForceReload); break;
      default: break;
    }
  }

  NavigateTo(tvItemModel: TVItemModel) {
    let ParentTVItemIDList: number[] = [];
    let strArr: string[] = tvItemModel.TVItem.TVPath.split('p');
    for (let i = 0, count = strArr?.length; i < count; i++) {
      if (strArr[i] != '') {
        ParentTVItemIDList.push(parseInt(strArr[i]));
      }
    }
    if (this.IsTVItemModelParentsOK(tvItemModel, ParentTVItemIDList)) {
      if (tvItemModel.TVItem.TVType == TVTypeEnum.Country) {
        this.FillRoot(ParentTVItemIDList[0], false);
        this.FillCountry(ParentTVItemIDList[1], false);
        this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Country;
        this.appStateService.UserPreference.CurrentRootTVItemID = ParentTVItemIDList[0];
        this.appStateService.UserPreference.CurrentCountryTVItemID = ParentTVItemIDList[1];
      }
      else if (tvItemModel.TVItem.TVType == TVTypeEnum.Province) {
        this.FillRoot(ParentTVItemIDList[0], false);
        this.FillCountry(ParentTVItemIDList[1], false);
        this.FillProvince(ParentTVItemIDList[2], false);
        this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Province;
        this.appStateService.UserPreference.CurrentRootTVItemID = ParentTVItemIDList[0];
        this.appStateService.UserPreference.CurrentCountryTVItemID = ParentTVItemIDList[1];
        this.appStateService.UserPreference.CurrentProvinceTVItemID = ParentTVItemIDList[2];
      }
      else if (tvItemModel.TVItem.TVType == TVTypeEnum.Area) {
        this.FillRoot(ParentTVItemIDList[0], false);
        this.FillCountry(ParentTVItemIDList[1], false);
        this.FillProvince(ParentTVItemIDList[2], false);
        this.FillArea(ParentTVItemIDList[3], false);
        this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Area;
        this.appStateService.UserPreference.CurrentRootTVItemID = ParentTVItemIDList[0];
        this.appStateService.UserPreference.CurrentCountryTVItemID = ParentTVItemIDList[1];
        this.appStateService.UserPreference.CurrentProvinceTVItemID = ParentTVItemIDList[2];
        this.appStateService.UserPreference.CurrentAreaTVItemID = ParentTVItemIDList[3];
      }
      else if (tvItemModel.TVItem.TVType == TVTypeEnum.Municipality) {
        this.FillRoot(ParentTVItemIDList[0], false);
        this.FillCountry(ParentTVItemIDList[1], false);
        this.FillProvince(ParentTVItemIDList[2], false);
        this.FillMunicipality(ParentTVItemIDList[3], false);
        this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Municipality;
        this.appStateService.UserPreference.CurrentRootTVItemID = ParentTVItemIDList[0];
        this.appStateService.UserPreference.CurrentCountryTVItemID = ParentTVItemIDList[1];
        this.appStateService.UserPreference.CurrentProvinceTVItemID = ParentTVItemIDList[2];
        this.appStateService.UserPreference.CurrentMunicipalityTVItemID = ParentTVItemIDList[3];
      }
      else if (tvItemModel.TVItem.TVType == TVTypeEnum.Sector) {
        this.FillRoot(ParentTVItemIDList[0], false);
        this.FillCountry(ParentTVItemIDList[1], false);
        this.FillProvince(ParentTVItemIDList[2], false);
        this.FillArea(ParentTVItemIDList[3], false);
        this.FillSector(ParentTVItemIDList[4], false);
        this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Sector;
        this.appStateService.UserPreference.CurrentRootTVItemID = ParentTVItemIDList[0];
        this.appStateService.UserPreference.CurrentCountryTVItemID = ParentTVItemIDList[1];
        this.appStateService.UserPreference.CurrentProvinceTVItemID = ParentTVItemIDList[2];
        this.appStateService.UserPreference.CurrentAreaTVItemID = ParentTVItemIDList[3];
        this.appStateService.UserPreference.CurrentSectorTVItemID = ParentTVItemIDList[4];
      }
      else if (tvItemModel.TVItem.TVType == TVTypeEnum.Subsector) {
        this.FillRoot(ParentTVItemIDList[0], false);
        this.FillCountry(ParentTVItemIDList[1], false);
        this.FillProvince(ParentTVItemIDList[2], false);
        this.FillArea(ParentTVItemIDList[3], false);
        this.FillSector(ParentTVItemIDList[4], false);
        this.FillSubsector(ParentTVItemIDList[5], false);
        this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Subsector;
        this.appStateService.UserPreference.CurrentRootTVItemID = ParentTVItemIDList[0];
        this.appStateService.UserPreference.CurrentCountryTVItemID = ParentTVItemIDList[1];
        this.appStateService.UserPreference.CurrentProvinceTVItemID = ParentTVItemIDList[2];
        this.appStateService.UserPreference.CurrentAreaTVItemID = ParentTVItemIDList[3];
        this.appStateService.UserPreference.CurrentSectorTVItemID = ParentTVItemIDList[4];
        this.appStateService.UserPreference.CurrentSubsectorTVItemID = ParentTVItemIDList[5];
      }
      else {
        alert(`${TVTypeEnum[tvItemModel.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
      }
    }
  }

  private FillRoot(TVItemID: number, ForceReload: boolean) {
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllAddresses, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllContacts, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllCountries, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllEmails, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllHelpDocs, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllMunicipalities, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllMWQMLookupMPNs, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllPolSourceGroupings, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllPolSourceSiteEffectTerms, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllProvinces, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllReportTypes, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllSearch, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllTels, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllTideLocations, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebRoot, TVItemID: TVItemID, ForceReload: ForceReload });

  }

  private FillCountry(TVItemID: number, ForceReload: boolean) {
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMonitoringRoutineStatsByYearForCountry, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMonitoringOtherStatsByYearForCountry, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebCountry, TVItemID: TVItemID, ForceReload: ForceReload });
  }

  private FillProvince(TVItemID: number, ForceReload: boolean) {
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebClimateSites, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebHydrometricSites, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebTideSites, TVItemID: TVItemID, ForceReload: ForceReload });
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebDrogueRuns, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMonitoringRoutineStatsByYearForProvince, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMonitoringOtherStatsByYearForProvince, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebProvince, TVItemID: TVItemID, ForceReload: ForceReload });
  }

  private FillMunicipality(TVItemID: number, ForceReload: boolean) {
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMikeScenarios, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMunicipality, TVItemID: TVItemID, ForceReload: ForceReload });
  }

  private FillArea(TVItemID: number, ForceReload: boolean) {
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebArea, TVItemID: TVItemID, ForceReload: ForceReload });
  }

  private FillSector(TVItemID: number, ForceReload: boolean) {
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebSector, TVItemID: TVItemID, ForceReload: ForceReload });
  }

  private FillSubsector(TVItemID: number, ForceReload: boolean) {
    // this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebLabSheets, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMWQMRuns, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMWQMSites, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebPolSourceSites, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMWQMSamples1980_2020, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebMWQMSamples2021_2060, TVItemID: TVItemID, ForceReload: ForceReload });
    this.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebSubsector, TVItemID: TVItemID, ForceReload: ForceReload });
  }

  private IsTVItemModelParentsOK(tvItemModel: TVItemModel, ParentTVItemIDList: number[]): boolean {
    if (tvItemModel.TVItem.TVType == TVTypeEnum.Country) {
      if (ParentTVItemIDList?.length != 2) {
        this.appStateService.Error = new HttpErrorResponse({ error: 'ParentTVItemIDList != 2', status: 403 });
        return false;
      }
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Province) {
      if (ParentTVItemIDList?.length != 3) {
        this.appStateService.Error = new HttpErrorResponse({ error: 'ParentTVItemIDList != 3', status: 403 });
        return false;
      }
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Area) {
      if (ParentTVItemIDList?.length != 4) {
        this.appStateService.Error = new HttpErrorResponse({ error: 'ParentTVItemIDList != 4', status: 403 });
        return false;
      }
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Municipality) {
      if (ParentTVItemIDList?.length != 4) {
        this.appStateService.Error = new HttpErrorResponse({ error: 'ParentTVItemIDList != 4', status: 403 });
        return false;
      }
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Sector) {
      if (ParentTVItemIDList?.length != 5) {
        this.appStateService.Error = new HttpErrorResponse({ error: 'ParentTVItemIDList != 5', status: 403 });
        return false;
      }
    }
    else if (tvItemModel.TVItem.TVType == TVTypeEnum.Subsector) {
      if (ParentTVItemIDList?.length != 6) {
        this.appStateService.Error = new HttpErrorResponse({ error: 'ParentTVItemIDList != 6', status: 403 });
        return false;
      }
    }
    else {
      alert(`${TVTypeEnum[tvItemModel.TVItem.TVType]} - Not Implemented Yet. See search.component.ts -- NavigateTo Function`);
    }

    return true;
  }

}


