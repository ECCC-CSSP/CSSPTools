import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, ViewChild, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { GetRootSubComponentEnum, RootSubComponentEnum } from 'src/app/enums/generated/RootSubComponentEnum';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AscDescEnum, GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';
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
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public appHelperService: AppHelperService) {
  }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebRoot = this.appLoadedService.GetWebRoot(TVItemID).subscribe();
    this.appLoadedService.UpdateAppLoaded(<AppLoaded> { RootCountryList: this.appLoadedService.AppLoaded$.getValue().RootCountryList });
  }

  ngOnDestroy(): void {
    this.subWebRoot ? this.subWebRoot.unsubscribe() : null;
  }

  GetT(language: number): string {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(rootSubComponent: RootSubComponentEnum) {
    if (this.appStateService.AppState$.getValue()['RootSubComponent'] == rootSubComponent) {
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
