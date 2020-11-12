import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Injectable({
    providedIn: 'root'
})
export class ToggleDetailService {
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {

    }
    
    ToggleDetail(): void {
        this.appStateService.UpdateAppState(<AppState>{ DetailVisible: !this.appStateService.AppState$.getValue().DetailVisible });
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false });
    }
}