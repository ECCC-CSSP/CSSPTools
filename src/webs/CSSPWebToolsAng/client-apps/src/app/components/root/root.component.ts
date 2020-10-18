import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { LanguageEnum } from '../../enums/generated/LanguageEnum';
import { GetRootSubComponentEnum, RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoaded } from 'src/app/models/AppLoaded.model';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RootComponent implements OnInit, OnDestroy {
  subWebRoot: Subscription;
  rootSubComponentEnum = GetRootSubComponentEnum();

  constructor(public appStateService: AppStateService, public appLoadedService: AppLoadedService) {
  }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebRoot = this.appLoadedService.GetWebRoot(TVItemID).subscribe();
 }

  ngOnDestroy(): void {
    this.subWebRoot ? this.subWebRoot.unsubscribe() : null;
  }

  GetT(language: number): string {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(rootSubComponent: RootSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().RootSubComponent == rootSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(rootSubComponent: RootSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ RootSubComponent: rootSubComponent });
  }

  ToggleInactive(): void {
    this.appStateService.UpdateAppState(<AppState> { InactVisible: !this.appStateService.AppState$.getValue().InactVisible });
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { Working: false });
  }

  ToggleDetail(): void {
    this.appStateService.UpdateAppState(<AppState> { DetailVisible: !this.appStateService.AppState$.getValue().DetailVisible });
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { Working: false });
  }

  ToggleEdit(): void {
    this.appStateService.UpdateAppState(<AppState> { EditVisible: !this.appStateService.AppState$.getValue().EditVisible });
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { Working: false });
  }

}
