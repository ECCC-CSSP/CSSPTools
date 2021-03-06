import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-subsector-tvitem-list-item',
  templateUrl: './subsector-tvitem-list-item.component.html',
  styleUrls: ['./subsector-tvitem-list-item.component.css']
})
export class SubsectorTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
