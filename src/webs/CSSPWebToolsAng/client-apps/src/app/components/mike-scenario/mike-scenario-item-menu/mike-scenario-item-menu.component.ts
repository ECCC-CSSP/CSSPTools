import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mike-scenario-item-menu',
  templateUrl: './mike-scenario-item-menu.component.html',
  styleUrls: ['./mike-scenario-item-menu.component.css']
})
export class MikeScenarioItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService,
    public mapService: MapService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
