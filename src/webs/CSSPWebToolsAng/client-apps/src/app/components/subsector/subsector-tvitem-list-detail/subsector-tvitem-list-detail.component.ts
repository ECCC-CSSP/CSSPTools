import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-subsector-tvitem-list-detail',
  templateUrl: './subsector-tvitem-list-detail.component.html',
  styleUrls: ['./subsector-tvitem-list-detail.component.css']
})
export class SubsectorTVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;

  constructor(public appStateService: AppStateService,
    public appLanguageService: AppLanguageService) {
  }

  get tvTypeEnum(): typeof TVTypeEnum {
    return TVTypeEnum;
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }


}
