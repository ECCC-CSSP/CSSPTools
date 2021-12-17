import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { DBCommandEnum, GetDBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppLoadedService } from 'src/app/services/app/app-loaded.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';
import { TVItemService } from 'src/app/services/tvitem/tvitem.service';

@Component({
  selector: 'app-tvitem-item',
  templateUrl: './tvitem-item.component.html',
  styleUrls: ['./tvitem-item.component.css']
})
export class TVItemItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() Index: number;

  dbCommandEnum = GetDBCommandEnum();

  constructor(public appStateService: AppStateService,
    public appLoadedService: AppLoadedService,
    public appLanguageService: AppLanguageService,
    public showTVItemService: ShowTVItemService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public tvItemService: TVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
