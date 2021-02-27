import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { WebAllContactsService } from 'src/app/services/loaders/web-all-contacts.service';
import { PreferenceService } from 'src/app/services/loaders/preferences.service';

@Component({
  selector: 'app-home-item',
  templateUrl: './home-item.component.html',
  styleUrls: ['./home-item.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeItemComponent implements OnInit, OnDestroy {
  languageEnum = GetLanguageEnum();
  
  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public webAllContactsService: WebAllContactsService,
    private preferenceService: PreferenceService) { }

  ngOnInit(): void {
    this.preferenceService.DoPreference();
    this.webAllContactsService.DoWebAllContacts(false);
  }

  ngOnDestroy() {
  }

  English() {
    this.appStateService.UpdateAppState(<AppState>{ Language: LanguageEnum.en, TopComponent: TopComponentEnum.Shell, Working: false });
  }

  French() {
    this.appStateService.UpdateAppState(<AppState>{ Language: LanguageEnum.fr, TopComponent: TopComponentEnum.Shell, Working: false });
  }
}
