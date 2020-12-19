import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AppLoaded } from 'src/app/models/AppLoaded.model';
import { AppStateService } from 'src/app/services/app-state.service';

@Injectable({
  providedIn: 'root'
})
export class AppLoadedService {
  AppLoaded$: BehaviorSubject<AppLoaded> = new BehaviorSubject<AppLoaded>(<AppLoaded>{});
  //BaseApiUrl = 'https://localhost:4447/api/';
  BaseApiUrl = 'https://localhost:44346/api/';

  constructor(public httpClient: HttpClient,
    public appStateService: AppStateService) {
  }

  UpdateAppLoaded(appLoaded: AppLoaded) {
    this.AppLoaded$.next(<AppLoaded>{ ...this.AppLoaded$.getValue(), ...appLoaded });
  }
}
