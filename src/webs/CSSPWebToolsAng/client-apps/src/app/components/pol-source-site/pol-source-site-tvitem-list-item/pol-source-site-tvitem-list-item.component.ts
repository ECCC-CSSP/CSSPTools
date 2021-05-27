import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { PolSourceSiteService } from 'src/app/services/helpers/pol-source-site.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-pol-source-site-tvitem-list-item',
  templateUrl: './pol-source-site-tvitem-list-item.component.html',
  styleUrls: ['./pol-source-site-tvitem-list-item.component.css']
})
export class PolSourceSiteTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public showTVItemService: ShowTVItemService,
    public polSourceSiteService: PolSourceSiteService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
