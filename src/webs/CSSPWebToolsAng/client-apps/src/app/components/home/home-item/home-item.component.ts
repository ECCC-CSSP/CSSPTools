import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { WebContactService } from 'src/app/services/loaders/web-contact.service';
import { PreferenceService } from 'src/app/services/loaders/preferences.service';
import { WebSubsectorService } from 'src/app/services/loaders/web-subsector.service';

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
    public webContactService: WebContactService,
    // delete line below after testing
    public webSubsectorService: WebSubsectorService,
    private preferenceService: PreferenceService) { }

  ngOnInit(): void {
    this.preferenceService.DoPreference();
    this.webContactService.DoWebContact(false);
    // delete line below after testing
    this.webSubsectorService.DoWebSubsector(635, true);
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
