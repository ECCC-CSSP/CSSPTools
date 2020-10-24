import { Injectable } from '@angular/core';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { WebAreaService } from './web-area.service';
import { WebCountryService } from './web-country.service';
import { WebMunicipalityService } from './web-municipalty.service';
import { WebMWQMRunService } from './web-mwqm-runs.service';
import { WebMWQMSiteService } from './web-mwqm-sites.service';
import { WebPolSourceSiteService } from './web-pol-source-sites.service';
import { WebProvinceService } from './web-province.service';
import { WebRootService } from './web-root.service';
import { WebSectorService } from './web-sector.service';
import { WebSubsectorService } from './web-subsector.service';

@Injectable({
    providedIn: 'root'
})
export class ToggleInactiveService {
constructor(private appStateService: AppStateService,
    private appLoadedService: AppLoadedService,
    private getWebRootService: WebRootService,
    private getWebCountryService: WebCountryService,
    private getWebProvinceService: WebProvinceService,
    private getWebAreaService: WebAreaService,
    private getWebSectorService: WebSectorService,
    private getWebSubsectorService: WebSubsectorService,
    private getWebMunicipalityService: WebMunicipalityService,
    private getWebMWQMSiteService: WebMWQMSiteService,
    private getWebMWQMRunService: WebMWQMRunService,
    private getWebPolSourceSiteService: WebPolSourceSiteService,
    ) {

}
    ToggleInactive(appState: AppState): void {
        this.appStateService.UpdateAppState(<AppState>{ InactVisible: !this.appStateService.AppState$.getValue().InactVisible });
        if (appState.ShellSubComponent == ShellSubComponentEnum.Root) {
            this.getWebRootService.UpdateWebRoot(this.appLoadedService.AppLoaded$.getValue().WebRoot);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.Country) {
            this.getWebCountryService.UpdateWebCountry(this.appLoadedService.AppLoaded$.getValue().WebCountry);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.Province) {
            this.getWebProvinceService.UpdateWebProvince(this.appLoadedService.AppLoaded$.getValue().WebProvince);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.Area) {
            this.getWebAreaService.UpdateWebArea(this.appLoadedService.AppLoaded$.getValue().WebArea);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.Sector) {
            this.getWebSectorService.UpdateWebSector(this.appLoadedService.AppLoaded$.getValue().WebSector);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.Subsector) {
            this.getWebSubsectorService.UpdateWebSubsector(this.appLoadedService.AppLoaded$.getValue().WebSubsector);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.Municipality) {
            this.getWebMunicipalityService.UpdateWebMunicipality(this.appLoadedService.AppLoaded$.getValue().WebMunicipality);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.MWQMSite) {
            this.getWebMWQMSiteService.UpdateWebMWQMSite(this.appLoadedService.AppLoaded$.getValue().WebMWQMSite);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.MWQMRun) {
            this.getWebMWQMRunService.UpdateWebMWQMRun(this.appLoadedService.AppLoaded$.getValue().WebMWQMRun);
        }
        else if (appState.ShellSubComponent == ShellSubComponentEnum.PolSourceSite) {
            this.getWebPolSourceSiteService.UpdateWebPolSourceSite(this.appLoadedService.AppLoaded$.getValue().WebPolSourceSite);
        }
        else {
            alert(`ToggleInactive (${ShellSubComponentEnum[appState.ShellSubComponent]}) not implemented. see ToggleInactive in app-loaded.service`);
        }
    }
}