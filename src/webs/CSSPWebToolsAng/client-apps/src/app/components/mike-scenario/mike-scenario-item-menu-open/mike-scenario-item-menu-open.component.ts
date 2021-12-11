import { Input } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MikeScenarioModel } from 'src/app/models/generated/models/MikeScenarioModel.model';

import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';

@Component({
  selector: 'app-mike-scenario-item-menu-open',
  templateUrl: './mike-scenario-item-menu-open.component.html',
  styleUrls: ['./mike-scenario-item-menu-open.component.css']
})
export class MikeScenarioItemMenuOpenComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  ViewVisible: boolean = true;
  ModifyVisible: boolean = false;
  CreateVisible: boolean = false;

  mikeScenarioModel: MikeScenarioModel;

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService) { }

  ngOnInit(): void {
    let MikeScenarioModelList: MikeScenarioModel[] = this.appLoadedService.WebMikeScenarios?.MikeScenarioModelList?.filter(c => c.TVItemModel.TVItem.TVItemID == this.TVItemModel.TVItem.TVItemID);
    if (MikeScenarioModelList != undefined && MikeScenarioModelList.length > 0) {
      this.mikeScenarioModel = MikeScenarioModelList[0];
    }
  }

  ngOnDestroy(): void {
  }

}
