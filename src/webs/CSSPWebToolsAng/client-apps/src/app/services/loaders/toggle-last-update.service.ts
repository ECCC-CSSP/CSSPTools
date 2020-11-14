import { Injectable } from '@angular/core';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Injectable({
    providedIn: 'root'
})
export class ToggleLastUpdateService {
    constructor(private appStateService: AppStateService,
        private appLoadedService: AppLoadedService) {

    }
    
    ToggleLastUpdate(): void {
        this.appStateService.UpdateAppState(<AppState>{ LastUpdateVisible: !this.appStateService.AppState$.getValue().LastUpdateVisible });
        this.appLoadedService.UpdateAppLoaded(<AppLoaded>{ Working: false });
    }
}