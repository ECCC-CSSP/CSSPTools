import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { AppLoadedService } from '../app/app-loaded.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebArea } from 'src/app/models/generated/web/WebArea.model';
import { WebCountry } from 'src/app/models/generated/web/WebCountry.model';
import { WebMunicipality } from 'src/app/models/generated/web/WebMunicipality.model';
import { WebProvince } from 'src/app/models/generated/web/WebProvince.model';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { WebSector } from 'src/app/models/generated/web/WebSector.model';
import { WebSubsector } from 'src/app/models/generated/web/WebSubsector.model';
import { JsonLoadAllService, JsonLoadListService } from 'src/app/services/json';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

@Injectable({
    providedIn: 'root'
})
export class TogglesService {
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService,
        private jsonLoadAllService: JsonLoadAllService,
        private jsonLoadListService: JsonLoadListService) {

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

    ReloadPage() {
        switch (this.appStateService.UserPreference.ShellSubComponent) {
            case ShellSubComponentEnum.Area:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Area, this.appStateService.UserPreference.CurrentAreaTVItemID, false);
                }
                break;
            case ShellSubComponentEnum.Country:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Country, this.appStateService.UserPreference.CurrentCountryTVItemID, false);
                }
                break;
            case ShellSubComponentEnum.Municipality:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Municipality, this.appStateService.UserPreference.CurrentMunicipalityTVItemID, false);
                }
                break;
            case ShellSubComponentEnum.Province:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Province, this.appStateService.UserPreference.CurrentProvinceTVItemID, false);
                }
                break;
            case ShellSubComponentEnum.Root:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Root, this.appStateService.UserPreference.CurrentRootTVItemID, false);
                }
                break;
            case ShellSubComponentEnum.Sector:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Sector, this.appStateService.UserPreference.CurrentSectorTVItemID, false);
                }
                break;
            case ShellSubComponentEnum.Subsector:
                {
                    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Subsector, this.appStateService.UserPreference.CurrentSubsectorTVItemID, false);
                }
                break;
            default:
                {

                }
                break;
        }

        this.jsonLoadAllService.LoadAll();
    }
}
