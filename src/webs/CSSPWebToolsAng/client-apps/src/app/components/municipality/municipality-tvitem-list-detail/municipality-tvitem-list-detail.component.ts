import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

import { TVItemModel } from 'src/app/models/generated/models/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { AppStateService } from 'src/app/services/app/app-state.service';

@Component({
  selector: 'app-municipality-tvitem-list-detail',
  templateUrl: './municipality-tvitem-list-detail.component.html',
  styleUrls: ['./municipality-tvitem-list-detail.component.css']
})
export class MunicipalityTVItemListDetailComponent implements OnInit, OnDestroy {
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
