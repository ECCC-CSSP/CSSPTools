import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { WebRootService } from 'src/app/services/loaders/web-root.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';

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
    public webRootService: WebRootService,
    public loggedInContactService: LoggedInContactService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    this.webRootService.DoWebRoot(true, false);
  }

  StartWithLanguage(LangID: number) {
    if (LangID == LanguageEnum.fr - 1) {
      this.appLanguageService.SetLanguage(LanguageEnum.fr);
    }
    else {
      this.appLanguageService.SetLanguage(LanguageEnum.en);
    }
    this.appStateService.Working = false;
    this.appStateService.TopComponent = TopComponentEnum.Shell;
  }
}
