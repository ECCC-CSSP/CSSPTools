import { Injectable } from '@angular/core';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
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
export class TVFileSortOrderService {
  constructor(private appLoadedService: AppLoadedService,
    private appStateService: AppStateService,
    private webAreaService: WebAreaService,
    private webCountryService: WebCountryService,
    private webProvinceService: WebProvinceService,
    private webRootService: WebRootService,
    private webSectorService: WebSectorService,
    private webSubsectorService: WebSubsectorService,) {
  }

  ChangeTVFileSortOrder(prop: string, ascDesc: AscDescEnum) {
    switch (prop) {
      case 'AreaFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ AreaFilesSortOrder: ascDesc });
        this.webAreaService.UpdateWebArea(this.appLoadedService.AppLoaded$.getValue().WebArea);
        break;
      case 'CountryFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ CountryFilesSortOrder: ascDesc });
        this.webCountryService.UpdateWebCountry(this.appLoadedService.AppLoaded$.getValue().WebCountry);
        break;
      case 'ProvinceFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ ProvinceFilesSortOrder: ascDesc });
        this.webProvinceService.UpdateWebProvince(this.appLoadedService.AppLoaded$.getValue().WebProvince);
        break;
      case 'RootFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ RootFilesSortOrder: ascDesc });
        this.webRootService.UpdateWebRoot(this.appLoadedService.AppLoaded$.getValue().WebRoot);
        break;
      case 'SectorFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SectorFilesSortOrder: ascDesc });
        this.webSectorService.UpdateWebSector(this.appLoadedService.AppLoaded$.getValue().WebSector);
        break;
      case 'SubsectorFilesSortOrder':
        this.appStateService.UpdateAppState(<AppState>{ SubsectorFilesSortOrder: ascDesc });
        this.webSubsectorService.UpdateWebSubsector(this.appLoadedService.AppLoaded$.getValue().WebSubsector);
        break;
      default:
        alert(`${prop} not implemented yet. See app-loaded.service.ts -- ChangeTVFileSortOrder function`);
        break;
    }
  }
}