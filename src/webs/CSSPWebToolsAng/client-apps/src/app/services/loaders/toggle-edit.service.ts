import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Injectable({
    providedIn: 'root'
})
export class ToggleEditService {

    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {
    }

    ToggleEdit(): void {
        this.appStateService.UpdateAppState(<AppState>{ EditVisible: !this.appStateService.AppState$.getValue().EditVisible });
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false });
    }
}