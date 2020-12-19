import { Component, OnInit, ChangeDetectionStrategy, OnDestroy, Input } from '@angular/core';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';
import { AppState } from 'src/app/models/AppState.model';
import { TVItemModel } from 'src/app/models/generated/web/TVItemModel.model';
import { AppLanguageService } from 'src/app/services/app-language.service';
import { AppStateService } from 'src/app/services/app-state.service';

@Component({
  selector: 'app-municipality-tvitem-list-detail',
  templateUrl: './municipality-tvitem-list-detail.component.html',
  styleUrls: ['./municipality-tvitem-list-detail.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MunicipalityTVItemListDetailComponent implements OnInit, OnDestroy {
  @Input() TVItemModel: TVItemModel;
  @Input() AppState: AppState;

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
