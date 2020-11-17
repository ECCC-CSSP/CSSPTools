import { Injectable } from '@angular/core';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
import { WebMunicipalityService } from '../loaders/web-municipalty.service';

@Injectable({
  providedIn: 'root'
})
export class TVItemSortOrderService {
  constructor(private appLoadedService: AppLoadedService,
    private appStateService: AppStateService,
    private webAreaService: WebAreaService,
    private webCountryService: WebCountryService,
    private webMunicipalityService: WebMunicipalityService,
    private webProvinceService: WebProvinceService,
    private webRootService: WebRootService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService,
  ) {
  }

  ChangeTVItemSortOrder(prop: string, ascDesc: AscDescEnum) {
    switch (prop) {
      case 'AreaSectorsSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ AreaSectorsSortOrder: ascDesc });
        this.webAreaService.UpdateWebArea(this.appLoadedService.AppLoaded$.getValue().WebArea);
        break;
      case 'CountryProvincesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ CountryProvincesSortOrder: ascDesc });
        this.webCountryService.UpdateWebCountry(this.appLoadedService.AppLoaded$.getValue().WebCountry);
        break;
      case 'MunicipalityMIKEScenariosSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ MunicipalityMIKEScenariosSortOrder: ascDesc });
        this.webMunicipalityService.UpdateWebMunicipality(this.appLoadedService.AppLoaded$.getValue().WebMunicipality);
        break;
      case 'ProvinceAreasSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ ProvinceAreasSortOrder: ascDesc });
        this.webProvinceService.UpdateWebProvince(this.appLoadedService.AppLoaded$.getValue().WebProvince);
        break;
      case 'ProvinceMunicipalitiesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ ProvinceMunicipalitiesSortOrder: ascDesc });
        this.webProvinceService.UpdateWebProvince(this.appLoadedService.AppLoaded$.getValue().WebProvince);
        break;
      case 'RootCountriesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ RootCountriesSortOrder: ascDesc });
        this.webRootService.UpdateWebRoot(this.appLoadedService.AppLoaded$.getValue().WebRoot);
        break;
      case 'SectorSubsectorsSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SectorSubsectorsSortOrder: ascDesc });
        this.webSectorService.UpdateWebSector(this.appLoadedService.AppLoaded$.getValue().WebSector);
        break;
      case 'SectorMikeScenariosSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SectorMikeScenariosSortOrder: ascDesc });
        this.webSectorService.UpdateWebSector(this.appLoadedService.AppLoaded$.getValue().WebSector);
        break;
      case 'SubsectorMWQMSitesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorMWQMSitesSortOrder: ascDesc });
        this.webSubsectorService.UpdateWebSubsector(this.appLoadedService.AppLoaded$.getValue().WebSubsector);
        break;
      case 'SubsectorMWQMRunsSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorMWQMRunsSortOrder: ascDesc });
        this.webSubsectorService.UpdateWebSubsector(this.appLoadedService.AppLoaded$.getValue().WebSubsector);
        break;
      case 'SubsectorPolSourceSitesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorPolSourceSitesSortOrder: ascDesc });
        this.webSubsectorService.UpdateWebSubsector(this.appLoadedService.AppLoaded$.getValue().WebSubsector);
        break;
      default:
        alert(`${prop} not implemented yet. See app-loaded.service.ts -- ChangeTVItemSortOrder function`);
        break;
    }
  }

}