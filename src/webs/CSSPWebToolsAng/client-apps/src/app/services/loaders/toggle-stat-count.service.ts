import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from '../app-loaded.service';
import { AppStateService } from '../app-state.service';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Injectable({
    providedIn: 'root'
})
export class ToggleStatCountService {
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {

    }
    
    ToggleStatCount(): void {
        this.appStateService.UpdateAppState(<AppState>{ StatCountVisible: !this.appStateService.AppState$.getValue().StatCountVisible });
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false });
    }
}