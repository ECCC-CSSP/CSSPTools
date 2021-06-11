import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { LoggedInContactService } from 'src/app/services/contact/logged-in-contact.service';
import { JsonLoadAllService, JsonLoadListService } from 'src/app/services/json';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { JsonLoadModel } from 'src/app/models/generated/web/JsonLoadModel.model';

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
    private jsonLoadAllService: JsonLoadAllService,
    private loggedInContactService: LoggedInContactService,
    private jsonLoadListService: JsonLoadListService,
  ) { }

  ngOnInit(): void {
    this.loggedInContactService.DoLoggedInContact(false);
    this.jsonLoadListService.JsonToLoadList.push(<JsonLoadModel>{ WebType: WebTypeEnum.WebAllContacts, TVItemID: this.appStateService.UserPreference.CurrentRootTVItemID, ForceReload: false });
    this.jsonLoadAllService.LoadAll();
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
