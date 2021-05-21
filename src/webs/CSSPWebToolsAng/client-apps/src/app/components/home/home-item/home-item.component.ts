import { Component, OnInit, OnDestroy } from '@angular/core';
import { GetLanguageEnum, LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TopComponentEnum } from 'src/app/enums/generated/TopComponentEnum';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoggedInContactService } from 'src/app/services/loaders/logged-in-contact.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { LoadListService } from 'src/app/services/helpers/loading-list.service';
import { LoadModel } from 'src/app/models/generated/web/LoadModel.model';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';

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
    private loggedInContactService: LoggedInContactService,
    private loadListService: LoadListService,
  ) { }

  ngOnInit(): void {
    this.loggedInContactService.DoLoggedInContact(false);
    this.loadListService.ToLoadList.push(<LoadModel>{ WebType: WebTypeEnum.WebAllContacts, TVItemID: this.appStateService.UserPreference.CurrentRootTVItemID, ForceReload: false });
    this.loaderService.LoadAll();
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
