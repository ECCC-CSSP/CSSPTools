import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetTVTypeEnum, TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-pol-source-site-tvitem-list-detail',
  templateUrl: './pol-source-site-tvitem-list-detail.component.html',
  styleUrls: ['./pol-source-site-tvitem-list-detail.component.css']
})
export class PolSourceSiteTVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  tvTypeEnum = GetTVTypeEnum();

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
