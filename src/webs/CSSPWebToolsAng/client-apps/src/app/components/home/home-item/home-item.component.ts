import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { WebAllAddresses } from 'src/app/models/generated/web/WebAllAddresses.model';

@Component({
  selector: 'app-home-item',
  templateUrl: './home-item.component.html',
  styleUrls: ['./home-item.component.css'],
})
export class HomeItemComponent implements OnInit, OnDestroy {
  lang = GetLanguageEnum();

  LangIDList: number[] = [LanguageEnum.en - 1, LanguageEnum.fr - 1];

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
    this.loggedInContactService.DoLoggedInContact(false);
    this.loaderService.Load<WebAllAddresses>(WebTypeEnum.WebAllAddresses, WebTypeEnum.WebAllContacts, false);
  }

  ngOnDestroy(): void {
  }

  StartWithLanguage(LangID: number) {
    if (LangID == LanguageEnum.fr - 1) {
      this.appLanguageService.SetLanguage(LanguageEnum.fr);
    }
    else {
      this.appLanguageService.SetLanguage(LanguageEnum.en);
    }
    this.appStateService.Working = false;
    this.appStateService.UserPreference.TopComponent = TopComponentEnum.Shell;
  }
}
