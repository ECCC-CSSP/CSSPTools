import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { WebTypeEnum } from 'src/app/enums/generated/WebTypeEnum';
import { ShellSubComponentEnum } from 'src/app/enums/generated/ShellSubComponentEnum';
import { SubsectorSubComponentEnum } from 'src/app/enums/generated/SubsectorSubComponentEnum';
import { WebMWQMSites } from 'src/app/models/generated/web/WebMWQMSites.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { JsonLoadAllService, JsonLoadListService } from 'src/app/services/json';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

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
    private jsonLoadAllService: JsonLoadAllService,
    private jsonLoadListService: JsonLoadListService
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
    this.jsonLoadListService.SetToLoadList(TVTypeEnum.Subsector, 635, false);
    this.jsonLoadAllService.LoadAll();
  }
}
