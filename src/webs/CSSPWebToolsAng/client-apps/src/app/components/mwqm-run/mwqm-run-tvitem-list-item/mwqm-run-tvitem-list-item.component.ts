import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetLanguageEnum } from 'src/app/enums/generated/LanguageEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';
import { ShowTVItemService } from 'src/app/services/helpers/show-tvitem.service';
import { SubPageService } from 'src/app/services/helpers/sub-page.service';
import { WebMWQMSamples2021_2060Service } from 'src/app/services/loaders/web-mwqm-samples_2021_2060.service';
import { MapService } from 'src/app/services/map/map.service';

@Component({
  selector: 'app-mwqm-run-tvitem-list-item',
  templateUrl: './mwqm-run-tvitem-list-item.component.html',
  styleUrls: ['./mwqm-run-tvitem-list-item.component.css']
})
export class MWQMRunTVItemListItemComponent implements OnInit, OnDestroy {
  @Input() TVItemModelList: TVItemModel[] = [];

  @Input() IsBreadCrumb: boolean = false;

  languageEnum = GetLanguageEnum();
  
  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService,
    public subPageService: SubPageService,
    public mapService: MapService,
    public webMWQMSamples2021_2060Service: WebMWQMSamples2021_2060Service,
    public showTVItemService: ShowTVItemService) {
  }

  ngOnInit() {
  }

  ngOnDestroy()
  {
  }

}
