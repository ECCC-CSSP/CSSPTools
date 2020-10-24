import { Injectable } from '@angular/core';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { WebAreaService } from './web-area.service';
import { WebCountryService } from './web-country.service';
import { WebProvinceService } from './web-province.service';
import { WebRootService } from './web-root.service';
import { WebSectorService } from './web-sector.service';
import { WebSubsectorService } from './web-subsector.service';

@Injectable({
    providedIn: 'root'
})
export class TVItemSortOrderService {
    constructor(private appLoadedService: AppLoadedService,
      private appStateService: AppStateService,
      private webAreaService: WebAreaService,
      private webCountryService: WebCountryService,
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