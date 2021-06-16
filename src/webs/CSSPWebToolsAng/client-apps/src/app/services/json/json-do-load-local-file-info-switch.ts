import { Injectable } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebRoot } from 'src/app/models/generated/web/WebRoot.model';
import { AppLoadedService } from '../app/app-loaded.service';

@Injectable({
    providedIn: 'root'
})
export class JsonDoLoadLocalFileInfoSwitchService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    DoLoadLocalFileInfoSwitch(WebType: WebTypeEnum) {
        let TVItemIDText = '';

        switch (WebType) {
            case WebTypeEnum.WebArea:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentAreaTVItemID}`;
                }
                break;
            case WebTypeEnum.WebCountry:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentCountryTVItemID}`;
                }
                break;
            case WebTypeEnum.WebMunicipality:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentMunicipalityTVItemID}`;
                }
                break;
            case WebTypeEnum.WebProvince:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentProvinceTVItemID}`;
                }
                break;
            case WebTypeEnum.WebRoot:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentRootTVItemID}`;
                }
                break;
            case WebTypeEnum.WebSector:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSectorTVItemID}`;
                }
                break;
            case WebTypeEnum.WebSubsector:
                {
                    TVItemIDText = `/${this.appStateService.UserPreference.CurrentSubsectorTVItemID}`;
                }
                break;
            default:
                break;
        }

        return TVItemIDText;
    }
    }
