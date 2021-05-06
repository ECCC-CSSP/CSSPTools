import { Component, OnInit, OnDestroy, Input } from '@angular/core';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLoadedService } from 'src/app/services/app-loaded.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-tvitem-menu',
  templateUrl: './tvitem-menu.component.html',
  styleUrls: ['./tvitem-menu.component.css']
})
export class TVItemMenuComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;


  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public showTVItemService: ShowTVItemService,
    public mapService: MapService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
