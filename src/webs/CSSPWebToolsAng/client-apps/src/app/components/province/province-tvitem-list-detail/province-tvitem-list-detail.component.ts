import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { GetTVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-province-tvitem-list-detail',
  templateUrl: './province-tvitem-list-detail.component.html',
  styleUrls: ['./province-tvitem-list-detail.component.css']
})
export class ProvinceTVItemListDetailComponent implements OnInit, OnDestroy {
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
