import { Injectable } from '@angular/core';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { WebAreaService } from 'src/app/services/loaders/web-area.service';
import { WebCountryService } from 'src/app/services/loaders/web-country.service';
import { WebMunicipalityService } from 'src/app/services/loaders/web-municipalty.service';
import { WebMWQMRunService } from 'src/app/services/loaders/web-mwqm-runs.service';
import { WebMWQMSiteService } from 'src/app/services/loaders/web-mwqm-sites.service';
import { WebPolSourceSiteService } from 'src/app/services/loaders/web-pol-source-sites.service';
import { WebProvinceService } from 'src/app/services/loaders/web-province.service';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { WebSectorService } from 'src/app/services/loaders/web-sector.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';

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