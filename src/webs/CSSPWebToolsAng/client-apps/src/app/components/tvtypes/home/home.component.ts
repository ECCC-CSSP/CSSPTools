import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppState } from 'src/app/models/AppState.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { Subscription } from 'rxjs';
import { WebContactService } from 'src/app/services/loaders/web-contact.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit, OnDestroy {
  subWebContact: Subscription;
  languageEnum = GetLanguageEnum();
  
  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public webContactService: WebContactService) { }

  ngOnInit(): void {
    this.subWebContact = this.webContactService.GetWebContact().subscribe();
  }

  ngOnDestroy() {
    this.subWebContact ? this.subWebContact.unsubscribe() : null;
  }

  English() {
    this.appStateService.UpdateAppState(<AppState>{ Language: LanguageEnum.en, TopComponent: TopComponentEnum.Shell });
  }

  French() {
    this.appStateService.UpdateAppState(<AppState>{ Language: LanguageEnum.fr, TopComponent: TopComponentEnum.Shell });
  }
}
