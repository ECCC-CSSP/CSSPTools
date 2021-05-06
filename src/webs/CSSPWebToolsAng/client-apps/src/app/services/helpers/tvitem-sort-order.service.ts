import { Injectable } from '@angular/core';
import { AscDescEnum } from 'src/app/enums/generated/AscDescEnum';
import { SortOrderAngularEnum } from 'src/app/enums/generated/SortOrderAngularEnum';
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

  ChangeTVItemSortOrder(sortOrderItem: SortOrderAngularEnum, ascDesc: AscDescEnum) {
    switch (sortOrderItem) {
      case SortOrderAngularEnum.AreaSectors:
        this.appStateService.AreaSectorsSortOrder = ascDesc;
        this.webAreaService.DoWebArea(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.CountryProvinces:
        this.appStateService.CountryProvincesSortOrder = ascDesc;
        this.webCountryService.DoWebCountry(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.MunicipalityMIKEScenarios:
        this.appStateService.MunicipalityMIKEScenariosSortOrder = ascDesc;
        this.webMunicipalityService.DoWebMunicipality(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.ProvinceAreas:
        this.appStateService.ProvinceAreasSortOrder = ascDesc;
        this.webProvinceService.DoWebProvince(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.ProvinceMunicipalities:
        this.appStateService.ProvinceMunicipalitiesSortOrder = ascDesc;
        this.webProvinceService.DoWebProvince(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.RootCountries:
        this.appStateService.RootCountriesSortOrder = ascDesc;
        this.webRootService.DoWebRoot(true);
        break;
      case SortOrderAngularEnum.SectorSubsectors:
        this.appStateService.SectorSubsectorsSortOrder = ascDesc;
        this.webSectorService.DoWebSector(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.SectorMikeScenarios:
        this.appStateService.SectorMikeScenariosSortOrder = ascDesc;
        this.webSubsectorService.DoWebSubsector(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.SubsectorMWQMSites:
        this.appStateService.SubsectorMWQMSitesSortOrder = ascDesc;
        this.webSubsectorService.DoWebSubsector(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.SubsectorMWQMRuns:
        this.appStateService.SubsectorMWQMRunsSortOrder = ascDesc;
        this.webSubsectorService.DoWebSubsector(this.appStateService.CurrentTVItemID, true);
        break;
      case SortOrderAngularEnum.SubsectorPolSourceSites:
        this.appStateService.SubsectorPolSourceSitesSortOrder = ascDesc;
        this.webSubsectorService.DoWebSubsector(this.appStateService.CurrentTVItemID, true);
        break;
      default:
        alert(`${sortOrderItem} not implemented yet. See app-loaded.service.ts -- ChangeTVItemSortOrder function`);
        break;
    }
  }

}