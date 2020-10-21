import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { GetAreaSubComponentEnum, AreaSubComponentEnum } from 'src/app/enums/generated/AreaSubComponentEnum';
import { AppState } from 'src/app/models/AppState.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppHelperService } from 'src/app/services/app-helper.service';
import { GetAscDescEnum } from 'src/app/enums/generated/AscDescEnum';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AreaComponent implements OnInit, OnDestroy {
  subWebArea: Subscription;
  areaSubComponentEnum = GetAreaSubComponentEnum();
  tvTypeEnum = GetTVTypeEnum();
  ascDescEnum = GetAscDescEnum();

  constructor(public appStateService: AppStateService, 
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public appHelperService: AppHelperService) { }

  ngOnInit(): void {
    let TVItemID: number = this.appStateService.AppState$.getValue().CurrentTVItemID;
    this.subWebArea = this.appLoadedService.GetWebArea(TVItemID).subscribe();
  }

  ngOnDestroy(): void {
    this.subWebArea ? this.subWebArea.unsubscribe() : null;
  }

  GetT(language: number): string
  {
    let a: LanguageEnum = language;
    return LanguageEnum[language];
  }

  ColorSelection(areaSubComponent: AreaSubComponentEnum) {
    if (this.appStateService.AppState$.getValue().AreaSubComponent == areaSubComponent) {
      return 'selected';
    }
    else {
      return '';
    }
  }

  Show(areaSubComponent: AreaSubComponentEnum) {
    this.appStateService.UpdateAppState(<AppState>{ AreaSubComponent: areaSubComponent });
  }

}
