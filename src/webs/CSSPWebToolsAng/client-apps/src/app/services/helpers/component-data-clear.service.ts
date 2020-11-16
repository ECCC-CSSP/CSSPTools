import { Injectable } from '@angular/core';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppState } from 'src/app/models/AppState.model';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from '../app-loaded.service';
import { WebCountryService } from '../loaders/web-country.service';
import { WebMunicipalitiesService } from '../loaders/web-municipalities.service';
import { WebProvinceService } from '../loaders/web-province.service';

@Injectable({
  providedIn: 'root'
})
export class ComponentDataClearService {

  constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private webCountryService: WebCountryService,
    private webProvinceService: WebProvinceService,
    private webMunicipalitiesService: WebMunicipalitiesService) {
  }

  DataClearArea(): void {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebArea: {},
      AreaSectorList: [],
      AreaFileListList: [],
      BreadCrumbWebBaseList: [],
    });

    this.appStateService.UpdateAppState(<AppState>{ Working: true });
  }

  DataClearCountry(): void {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebCountry: {},
      CountryProvinceList: [],
      EmailDistributionListContactLanguageList: [],
      EmailDistributionListContactList: [],
      EmailDistributionListLanguageList: [],
      EmailDistributionListList: [],
      BreadCrumbWebBaseList: [],
    });

    this.appStateService.UpdateAppState(<AppState>{ Working: true });
  }

  DataClearProvince(): void {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebProvince: {},
      ProvinceAreaList: [],
      ProvinceFileListList: [],
      ProvinceSamplingPlanList: [],
      BreadCrumbWebBaseList: [],
      WebMunicipalities: {},
    });

    this.appStateService.UpdateAppState(<AppState>{ Working: true });
  }

  DataClearRoot(): void {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebRoot: {},
      RootCountryList: [],
      BreadCrumbWebBaseList: [],
    });

    this.appStateService.UpdateAppState(<AppState>{ Working: true });
  }

  DataClearSector(): void {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebSector: {},
      SectorSubsectorList: [],
      SectorMIKEScenarioList: [],
      BreadCrumbWebBaseList: [],
    });

    this.appStateService.UpdateAppState(<AppState>{ Working: true });
  }

  DataClearSubsector(): void {
    this.appLoadedService.UpdateAppLoaded(<AppLoaded>{
      WebSubsector: {},
      SubsectorMWQMSiteList: [],
      SubsectorMWQMRunList: [],
      SubsectorPolSourceSiteList: [],
      LabSheetModelList: [],
      MWQMAnalysisReportParameterList: [],
      MWQMSubsector: {},
      MWQMSubsectorLanguageList: [],
      UseOfSiteList: [],
      BreadCrumbWebBaseList: [],
      WebMWQMSampleAll: {},
      WebMWQMSample1980: {},
      WebMWQMSample1990: {},
      WebMWQMSample2000: {},
      WebMWQMSample2010: {},
      WebMWQMSample2020: {},
      WebMWQMSample2030: {},
      WebMWQMSample2040: {},
      WebMWQMSample2050: {},
    });

    this.appStateService.UpdateAppState(<AppState>{ Working: true });
  }
}

