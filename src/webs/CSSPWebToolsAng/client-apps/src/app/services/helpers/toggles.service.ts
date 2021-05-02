import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
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
        this.appStateService.UpdateAppState(<AppState>{ DetailVisible: !this.appStateService.AppState$.getValue().DetailVisible, Working: false });
    }

    ToggleInactive(appState: AppState): void {
        this.appStateService.UpdateAppState(<AppState>{ InactVisible: !this.appStateService.AppState$.getValue().InactVisible });
        this.ReloadPage(appState);
    }

    ToggleLastUpdate(): void {
        this.appStateService.UpdateAppState(<AppState>{ LastUpdateVisible: !this.appStateService.AppState$.getValue().LastUpdateVisible, Working: false });
    }

    ToggleMap(): void {
        this.appStateService.UpdateAppState(<AppState>{ MapVisible: !this.appStateService.AppState$.getValue().MapVisible });
    }

    ToggleMenu(): void {
        this.appStateService.UpdateAppState(<AppState>{ MenuVisible: !this.appStateService.AppState$.getValue().MenuVisible });
    }

    ToggleStatCount(): void {
        this.appStateService.UpdateAppState(<AppState>{ StatCountVisible: !this.appStateService.AppState$.getValue().StatCountVisible, Working: false });
    }

    ToggleEdit(): void {
        this.appStateService.UpdateAppState(<AppState>{ EditVisible: !this.appStateService.AppState$.getValue().EditVisible, Working: false });
    }

    ToggleEditMap(appState:AppState): void {
        this.appStateService.UpdateAppState(<AppState>{ EditMapVisible: !this.appStateService.AppState$.getValue().EditMapVisible, Working: false });
        this.ReloadPage(appState);
    }

    private ReloadPage(appState: AppState)
    {
        switch (appState.ShellSubComponent) {
            case ShellSubComponentEnum.Area:
                {
                    this.webAreaService.DoWebArea(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Country:
                {
                    this.webCountryService.DoWebCountry(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Municipality:
                {
                    this.webMunicipalityService.DoWebMunicipality(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.MWQMRun:
                {
                    this.webMWQMRunsService.DoWebMWQMRuns(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.MWQMSite:
                {
                    this.webMWQMSitesService.DoWebMWQMSites(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.PolSourceSite:
                {
                    this.webPolSourceSitesService.DoWebPolSourceSites(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Province:
                {
                    this.webProvinceService.DoWebProvince(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Root:
                {
                    this.webRootService.DoWebRoot(true);
                }
                break;
            case ShellSubComponentEnum.Sector:
                {
                    this.webSectorService.DoWebSector(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            case ShellSubComponentEnum.Subsector:
                {
                    this.webSubsectorService.DoWebSubsector(this.appStateService.AppState$.getValue().CurrentTVItemID, true);
                }
                break;
            default:
                {

                }
                break;
        }
    }
}
