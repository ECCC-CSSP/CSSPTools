import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetRootSubComponentEnum, RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RootComponent implements OnInit, OnDestroy {
  subWebRoot: Subscription;
  rootSubComponentEnum = GetRootSubComponentEnum();

  constructor(public appStateService: AppStateService, 
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService) {
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


}
