import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { WebMWQMRunsService } from 'src/app/services/loaders/web-mwqm-runs.service';
import { WebMWQMSitesService } from 'src/app/services/loaders/web-mwqm-sites.service';
import { WebPolSourceSitesService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';
import { AppLoadedService } from '../app-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class TogglesService {
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private webAreaService: WebAreaService,
        private webCountryService: WebCountryService,
        private webMunicipalityService: WebMunicipalityService,
        private webMWQMSitesService: WebMWQMSitesService,
        private webMWQMRunsService: WebMWQMRunsService,
        private webPolSourceSitesService: WebPolSourceSitesService,
        private webProvinceService: WebProvinceService,
        private webRootService: WebRootService,
        private webSectorService: WebSectorService,
        private webSubsectorService: WebSubsectorService,
    ) {

    }

    ToggleDetail(): void {
        this.appStateService.DetailVisible = !this.appStateService.DetailVisible; 
        this.appStateService.Working = false;
    }

    ToggleInactive(): void {
        this.appStateService.InactVisible = !this.appStateService.InactVisible;
        this.ReloadPage();
    }

    ToggleLastUpdate(): void {
        this.appStateService.LastUpdateVisible = !this.appStateService.LastUpdateVisible; 
        this.appStateService.Working = false;
    }

    ToggleMap(): void {
        this.appStateService.MapVisible = !this.appStateService.MapVisible;
    }

    ToggleMenu(): void {
        this.appStateService.MenuVisible = !this.appStateService.MenuVisible;
    }

    ToggleStatCount(): void {
        this.appStateService.StatCountVisible = !this.appStateService.StatCountVisible; 
        this.appStateService.Working = false;
    }

    ToggleEdit(): void {
        this.appStateService.EditVisible = !this.appStateService.EditVisible; 
        this.appStateService.Working = false;
    }

    ToggleEditMap(): void {
        this.appStateService.EditMapVisible = !this.appStateService.EditMapVisible; 
        this.appStateService.Working = false;
        this.ReloadPage();
    }

    private ReloadPage()
    {
        switch (this.appStateService.ShellSubComponent) {
            case ShellSubComponentEnum.Area:
                {
                    this.webAreaService.DoWebArea(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Country:
                {
                    this.webCountryService.DoWebCountry(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Municipality:
                {
                    this.webMunicipalityService.DoWebMunicipality(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.MWQMRun:
                {
                    this.webMWQMRunsService.DoWebMWQMRuns(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.MWQMSite:
                {
                    this.webMWQMSitesService.DoWebMWQMSites(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.PolSourceSite:
                {
                    this.webPolSourceSitesService.DoWebPolSourceSites(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Province:
                {
                    this.webProvinceService.DoWebProvince(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Root:
                {
                    this.webRootService.DoWebRoot(true);
                }
                break;
            case ShellSubComponentEnum.Sector:
                {
                    this.webSectorService.DoWebSector(this.appStateService.CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Subsector:
                {
                    this.webSubsectorService.DoWebSubsector(this.appStateService.CurrentTVItemID, true);
                }
                break;
            default:
                {

                }
                break;
        }
    }
}
