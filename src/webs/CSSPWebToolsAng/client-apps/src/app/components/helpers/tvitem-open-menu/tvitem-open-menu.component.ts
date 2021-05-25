import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-tvitem-open-menu',
  templateUrl: './tvitem-open-menu.component.html',
  styleUrls: ['./tvitem-open-menu.component.css']
})
export class TVItemOpenMenuComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  ShowView: boolean = true;
  ShowModify: boolean = false;
  ShowCreate: boolean = false;

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
