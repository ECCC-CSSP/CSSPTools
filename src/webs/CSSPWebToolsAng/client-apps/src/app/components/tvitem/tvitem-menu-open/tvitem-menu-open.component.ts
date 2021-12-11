import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-tvitem-menu-open',
  templateUrl: './tvitem-menu-open.component.html',
  styleUrls: ['./tvitem-menu-open.component.css']
})
export class TVItemMenuOpenComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  ViewVisible: boolean = true;
  ModifyVisible: boolean = false;
  CreateVisible: boolean = false;

  tvTypeEnum = GetTVTypeEnum();

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
