import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { AppLoadedService } from '../app-loaded.service';
import { LoaderService } from '../loaders/loader.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';

@Injectable({
    providedIn: 'root'
})
export class TogglesService {
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private loaderService: LoaderService
    ) {

    }

    ToggleDetail(): void {
        this.appStateService.UserPreference.DetailVisible = !this.appStateService.UserPreference.DetailVisible;
        this.ReloadPage();
    }

    ToggleInactive(): void {
        this.appStateService.UserPreference.InactVisible = !this.appStateService.UserPreference.InactVisible;
        this.ReloadPage();
    }

    ToggleLastUpdate(): void {
        this.appStateService.UserPreference.LastUpdateVisible = !this.appStateService.UserPreference.LastUpdateVisible;
        this.ReloadPage();
    }

    ToggleMap(): void {
        this.appStateService.UserPreference.MapVisible = !this.appStateService.UserPreference.MapVisible;
    }

    ToggleMenu(): void {
        this.appStateService.UserPreference.LeftSideNavVisible = !this.appStateService.UserPreference.LeftSideNavVisible;
    }

    ToggleStatCount(): void {
        this.appStateService.UserPreference.StatCountVisible = !this.appStateService.UserPreference.StatCountVisible;
        this.ReloadPage();
    }

    ToggleEdit(): void {
        this.appStateService.UserPreference.EditVisible = !this.appStateService.UserPreference.EditVisible;
        this.ReloadPage();
    }

    ToggleEditMap(): void {
        this.appStateService.EditMapVisible = !this.appStateService.EditMapVisible;
        this.ReloadPage();
    }

    private ReloadPage() {
        switch (this.appStateService.UserPreference.ShellSubComponent) {
            case ShellSubComponentEnum.Area:
                {
                    this.loaderService.Load<WebArea>(WebTypeEnum.WebArea, false);
                }
                break;
            case ShellSubComponentEnum.Country:
                {
                    this.loaderService.Load<WebCountry>(WebTypeEnum.WebCountry, false);
                }
                break;
            case ShellSubComponentEnum.Municipality:
                {
                    this.loaderService.Load<WebMunicipality>(WebTypeEnum.WebMunicipality, false);
                }
                break;
            case ShellSubComponentEnum.Province:
                {
                    this.loaderService.Load<WebProvince>(WebTypeEnum.WebProvince, false);
                }
                break;
            case ShellSubComponentEnum.Root:
                {
                    this.loaderService.Load<WebRoot>(WebTypeEnum.WebRoot, false);
                }
                break;
            case ShellSubComponentEnum.Sector:
                {
                    this.loaderService.Load<WebSector>(WebTypeEnum.WebSector, false);
                }
                break;
            case ShellSubComponentEnum.Subsector:
                {
                    this.loaderService.Load<WebSubsector>(WebTypeEnum.WebSubsector, false);
                }
                break;
            default:
                {

                }
                break;
        }
    }
}
