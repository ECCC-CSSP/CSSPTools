import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppStateService } from 'src/app/services/app-state.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { LoaderService } from 'src/app/services/loaders/loader.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';

@Component({
  selector: 'app-home-test',
  templateUrl: './home-test.component.html',
  styleUrls: ['./home-test.component.css'],
})
export class HomeTestComponent implements OnInit, OnDestroy {
  TVItemModel: TVItemModel;

  constructor(public appLoadedService: AppLoadedService,
    public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    private loaderService: LoaderService,
  ) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  Load() {
    this.appStateService.GoogleJSLoaded = false;
    this.appStateService.UserPreference.CurrentSubsectorTVItemID = 635;
    this.appStateService.UserPreference.ShellSubComponent = ShellSubComponentEnum.Subsector;
    this.appStateService.UserPreference.SubsectorSubComponent = SubsectorSubComponentEnum.MWQMSites;
    this.loaderService.Load<WebMWQMSites>(WebTypeEnum.WebMWQMSites, false);

  }
}
