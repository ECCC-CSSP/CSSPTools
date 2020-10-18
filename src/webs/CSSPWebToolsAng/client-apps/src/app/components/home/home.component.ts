import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from '../../enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit, OnDestroy {

  constructor(public appLoadedService: AppLoadedService, 
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) { }

  ngOnInit(): void {
  }

  ngOnDestroy() {
  }

  English() {
    this.appStateService.UpdateAppState(<AppState>{ Language: LanguageEnum.en, TopComponent: TopComponentEnum.Shell });
  }

  French() {
    this.appStateService.UpdateAppState(<AppState>{ Language: LanguageEnum.fr, TopComponent: TopComponentEnum.Shell });
  }
}
